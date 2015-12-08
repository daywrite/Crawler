using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Concurrent;

using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Service.Db;
using Haina.Crawl.OpenCase.Meta;
using Haina.Base;
using Lwb.Crawler.Contract.Model;

namespace Lwb.Crawler.Service.Crawl
{
    [Serializable]
    public class PlotWaterLine
    {
        private object mLocker = new object();
        private bool mExit;
        public string Host { get; set; }//主机名域名缓存的文件名
        public int PRI = 1;                                     //调度优先级  
        public string BaseURL;							        //请求基本的URL
        public string Method = "GET";					        //请求的发送方,Get，Post，File
        public string Accept;
        public string Referer;							        //引用页面值
        public string Chaset = "GB2312"; 					    //请求结果的解码方式
        public ParameterCollection Paras;			            //请求参数集合
        public MetaFeild PageFeild;                             //页数字段提取，如果该参数存在，启动时，首次执行需要在服务器执行，获取页码参数，进而生成任务
        public List<DrillRegularRule> DrillRegularRules = new List<DrillRegularRule>();  //正则表达式提取集合
        public int TaskBagSize = 20;//任务包的大小
        public int TaskBagPer = 100;//每次读取任务的个数
        public int DelayMin = 1000;                             //最小延时     
        public int DelayMax = 6000;                             //最大延时  
        public int ErrorReTry;						            //错误重试次数，如果重试次数超过规定次数，自动跳过之用
        public string UserAgent = "Mozilla/4.0 (compatible; MSIE 9.0; Windows NT 6;.NET CLR 2.0)";
        #region 运行时属性
        private volatile int mState;                              //状态0-停止，1-执行中
        private DateTime mLastProduceDt = DateTime.MinValue;      //最后开始时间
        private DateTime mLastRetrieveDt = DateTime.Now;          //上次回收任务时间
        //private CrawlTaskDbAdapter mCrawlTaskDbAdapter;           //待采任务
        private Dictionary<Int128, CrawlTask> mRunningTaskDic = new Dictionary<Int128, CrawlTask>();  // 已经分发尚未收到结果正在执行的任务
        private Dictionary<Int128, CrawlTaskDetail> mRunningTaskDetailDic = new Dictionary<Int128, CrawlTaskDetail>();  // 已经分发尚未收到结果正在执行的详细任务


        private Dictionary<string, List<CrawlTaskDetail>> mErrTaskPool = new Dictionary<string, List<CrawlTaskDetail>>();  // 出错的采集任务
        private Dictionary<string, int> mErrInfoPool = new Dictionary<string, int>();

        private Queue<CrawlTaskDetail> mTaskDetailWaitHandOutQueue = new Queue<CrawlTaskDetail>();             //待分发任务队列
        private volatile List<CrawlTaskDetail> mLocalTaskWaitDrillList = new List<CrawlTaskDetail>();          //使用本地缓存提取的任务集合
        //private volatile List<CrawlOriData> mCrawlDataWaitDrillList = new List<CrawlOriData>();                //待提取的原始数据
        //private volatile List<DrillCRecord> mRecordWaitSubmitList = new List<DrillCRecord>();                  //待提交的提取结果

        internal volatile int mRecievedTotal;                  //累计接收到的处理结果
        internal volatile int mLocalTaskWaitDrillCount;        //使用本地缓存待处理的任务数
        internal volatile int mCrawlDataWaitDrillCount;        //抓取待处理的任务数
        internal volatile int mRecordWaitSubmitCount;          //提取到数据等待存储到中心服务器的数据
        internal volatile int mErrCount;                       //出错信息数
        #endregion
        private CrawlDbAdapter crawlDbAdapter = new CrawlDbAdapter();
        private string mOriDataCacheDbName;
        /// <summary>
        /// 生产线的名称
        /// </summary>
        public string DbName
        {
            get
            {
                if (mOriDataCacheDbName == null)
                {
                    mOriDataCacheDbName = Plot.Name + "_" + Name;
                }
                return mOriDataCacheDbName;
            }
            set
            {
                mOriDataCacheDbName = null;
            }
        }
        public int ID { get; set; }
        public string Name { get; set; }                                //流水线名称
        public bool IsFileLine { get; set; }                             //文件流水线
        public bool AutoStart;						            //自动调度
        public DateTime CanStartDate = DateTime.Now;            //可以开始调度的时刻
        public int RunSpan = 120;                               //循环周期
        #region 获取监视信息
       
        public OpenPlot Plot { get; set; }
        
        #endregion
        private ConcurrentQueue<CrawlTaskDetail> taskDetailWaitHandOutQueue = new ConcurrentQueue<CrawlTaskDetail>();//待分发的任务队列
        internal CrawlTask GetCrawlTask()
        {
            List<CrawlTaskDetail> taskDetailList = new List<CrawlTaskDetail>();

            if (taskDetailWaitHandOutQueue.Count < TaskBagSize)
            {
                List<CrawlTaskDetail> tmpTaskDetail = crawlDbAdapter.Read(TaskBagSize * TaskBagPer);
                tmpTaskDetail.ForEach(t => taskDetailWaitHandOutQueue.Enqueue(t));

                CrawlTaskDetail crawlTaskDetail;
                while (taskDetailWaitHandOutQueue.Count > 0 && taskDetailList.Count < TaskBagSize)
                {
                    taskDetailWaitHandOutQueue.TryDequeue(out crawlTaskDetail);
                    taskDetailList.Add(crawlTaskDetail);
                }
                if (taskDetailList.Count > 0)
                {
                    CrawlTask crawlTask = CreateCrawlTask(taskDetailList);

                    return crawlTask;
                }
            }

            return null;
        }
        public void InitWaterLine()
        {

        }
        public string Url
        {
            get
            {
                if (Paras != null && Paras.Count > 0)
                {
                    return BaseURL + "?" + Paras.ToQuery(); ;
                }
                return BaseURL;
            }
            set
            {
                Paras = new ParameterCollection();
                Uri sUri = new Uri(value);
                BaseURL = "http://" + sUri.Authority + sUri.AbsolutePath;
                string[] mTmpStrs = sUri.Query.Trim('?').Split('&');
                if (mTmpStrs.Length > 0)
                {
                    for (int i = 0; i < mTmpStrs.Length; i++)
                    {
                        if (mTmpStrs[i].Trim().Length > 0)
                        {
                            Paras.Add(new Parameter(mTmpStrs[i]));
                        }
                    }
                }
                Host = sUri.Authority.ToLower();
            }
        }
        public int State
        {
            get
            {
                return mState;
            }
        }
        /// <summary>
        /// 生产线的监视信息
        /// </summary>
        public PlotLineState LineState
        {
            get
            {
                lock (mLocker)
                {
                    PlotLineState sPlotLineState = new PlotLineState();
                    sPlotLineState.State = mState;
                    sPlotLineState.WaitTaskCount = mTaskDetailWaitHandOutQueue.Count;
                    sPlotLineState.OnlineTaskCount = mRunningTaskDetailDic.Count;

                    sPlotLineState.ErrCount = mErrCount;
                    sPlotLineState.LocalWaitCount = mLocalTaskWaitDrillCount;
                    sPlotLineState.WaitDrillCount = mCrawlDataWaitDrillCount;
                    sPlotLineState.LastProduceDt = mLastProduceDt;
                    sPlotLineState.DrillWaitSaveCount = mRecordWaitSubmitCount;
                    sPlotLineState.TotalRecieved = mRecievedTotal;
                    return sPlotLineState;
                }
            }
        }
        /// <summary>
        /// 获取生产线名称
        /// </summary>
        /// <returns></returns>
        public int Group
        {
            get
            {
                if (IsFileLine)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        #region 生产线启动-停止
        public void Start()
        {
            mExit = false;
            mState = (int)WaterLineState.Start;
        }
        #endregion
        private CrawlTask CreateCrawlTask(List<CrawlTaskDetail> pTaskDetailList)
        {
            if (mState == (int)WaterLineState.Stop)
            {
                return null;
            }

            CrawlTask sCrawlTask = new CrawlTask();
            sCrawlTask.List = pTaskDetailList;
            return sCrawlTask;
        }
    }
}
