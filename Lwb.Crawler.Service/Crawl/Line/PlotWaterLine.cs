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
using System.Xml.Serialization;
using System.Threading;
using Lwb.Crawler.Contract.Crawl;

namespace Lwb.Crawler.Service.Crawl
{
    [Serializable]
    public class PlotWaterLine
    {
        private object mLocker = new object();
        private bool mExit;
        [XmlIgnore]
        public OpenPlot Plot;
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
        public string CleanRule;                                //清洗规则，清洗Html代码的规则，用不着了，因为不解析Html结构了，以后留做他用
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
        private volatile List<CrawlOriData> mCrawlDataWaitDrillList = new List<CrawlOriData>();                //待提取的原始数据
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
                    mOriDataCacheDbName = "123" + "_" + Name;
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

        #endregion
        private ConcurrentQueue<CrawlTaskDetail> taskDetailWaitHandOutQueue = new ConcurrentQueue<CrawlTaskDetail>();//待分发的任务队列

        /// <summary>
        /// 生产线调度
        /// </summary>
        internal void Attemper(DateTime pDt)
        {
            lock (mLocker)
            {
                #region 中间结果调度处理
                if (mCrawlDataWaitDrillList.Count > 0)      //待提取处理的信息
                {
                    //List<CrawlOriData> sCrawlDataList = mCrawlDataWaitDrillList;         //替换接水盆
                    //mCrawlDataWaitDrillList = new List<CrawlOriData>();
                    ThreadPool.QueueUserWorkItem(new WaitCallback(DrillCrawlData), mCrawlDataWaitDrillList);
                }
                #endregion
            }
        }

        private void DrillCrawlData(object obj)
        {
            List<CrawlOriData> sDrillCrawlData = obj as List<CrawlOriData>;
            if (sDrillCrawlData != null)
                sDrillCrawlData.ForEach(t => DrillProcess(t));
        }
        private void DrillProcess(CrawlOriData pCrawlOriData)
        {
            List<DrillResult> sResultList = null;

            sResultList = DrillRegularResult(pCrawlOriData);
        }

        private List<DrillResult> DrillRegularResult(CrawlOriData pCrawlOriData)
        {
            StringBuilder sHtmlSb = new StringBuilder(pCrawlOriData.Data.ToString());
            //执行清洗操作
            if (CleanRule != null && CleanRule.Length > 0)
            {
                string[] sCleanRules = CleanRule.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                if (sCleanRules.Length > 0)
                {
                    for (int i = 0; i < sCleanRules.Length; i++)
                    {
                        string[] sCleanRule = sCleanRules[i].Split('|');
                        if (sCleanRule.Length == 1)
                        {
                            sHtmlSb.Replace(sCleanRule[0], "");
                        }
                        else if (sCleanRule.Length == 2)
                        {
                            sHtmlSb.Replace(sCleanRule[0], sCleanRule[1]);
                        }
                    }
                }
            }

            List<DrillResult> Records = new List<DrillResult>();
            //对当前html进行一个规则实例化-富血模型类
            RegScriptTransactor sRegScriptTransactor = new RegScriptTransactor(sHtmlSb.ToString());
            //（多个）记录区-规则提取
            DrillRegularRules.ForEach(t =>
            {
                if (sRegScriptTransactor.CanExe(t))
                {
                    if (t.DrillType == 0)
                    {
                        string sName = t.FeatureType == 0 ? LineFeatureType.链接.ToString() : LineFeatureType.图片.ToString();
                        DrillResult sDrillResult = new DrillResult();
                        string[] sRdData = sRegScriptTransactor.GetUrls(t, pCrawlOriData.Url);
                        //是否能找到记录区
                        if (sRdData != null && sRdData.Length > 0)
                        {
                            RegularMetaFeild sFeild = null;
                            if (t.Feilds != null && t.Feilds.Count >= 5) { sFeild = t.Feilds[1]; }
                            //生成结果集                            
                            for (int j = 0; j < sRdData.Length; j++)
                            {
                                sDrillResult.Records.Add(new DrillCRecord(Plot.Name, sName, sRdData[j]));
                            }
                        }
                        Records.Add(sDrillResult);
                    }
                    else
                    {
                        //高级自定义提取
                        //规则结果对象
                        DrillResult sDrillResult = new DrillResult();
                        //获取记录区片段
                        string[] sRegionHtmls = sRegScriptTransactor.GetRecordHtmls(t);
                        if (sRegionHtmls != null)
                        {
                            for (int j = 0; j < sRegionHtmls.Length; j++)
                            {
                                RegScriptTransactor sRegionTransactor = new RegScriptTransactor(sRegionHtmls[j]);
                                DrillCRecord sDrillCRecord = new DrillCRecord();
                                //sDrillCRecord.DbModelID = sDrillRule.MetaModalID;
                                SRecord sCRecord = new SRecord();
                                sDrillCRecord.Record = sCRecord;
                                //sCRecord.DbID = sDrillRule.DbID;
                                //sCRecord.Meta = new string[sDrillRule.Feilds.Count];
                                for (int k = 0; k < t.Feilds.Count; k++)
                                {
                                    RegularMetaFeild sRegularMetaFeild = t.Feilds[k];
                                    if (sRegularMetaFeild.Name == "来源链接")
                                    {
                                        sCRecord.Url = pCrawlOriData.Url;
                                    }
                                    else if (sRegularMetaFeild.Rule != null)
                                    {
                                        string sValue = sRegionTransactor.Exe(sRegularMetaFeild.Rule);
                                        sCRecord.Url = sValue;
                                        if (sRegularMetaFeild.BindType > 0 && sValue != null && sValue.Trim().Length > 0)
                                        {
                                            string[] sUrls = sValue.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                            if (sUrls != null && sUrls.Length > 0)
                                            {
                                                Dictionary<string, string> sUrlDic = new Dictionary<string, string>();
                                                for (int ii = 0; ii < sUrls.Length; ii++)
                                                {
                                                    string sUrl = sUrls[ii].Trim();
                                                    if (sUrlDic.ContainsKey(sUrl.ToLower()) == false)
                                                    {
                                                        sUrlDic[sUrl.ToLower()] = sUrl;
                                                        string[] sUrlSpans = sUrl.Split('\t');
                                                        if (sUrlSpans.Length > 1 && (sUrlSpans[1].StartsWith("http://") || sUrlSpans[1].StartsWith("https://")))
                                                        {
                                                            //sDrillCRecord.AddDownload(sUrlSpans[1], pData.Url, sRegularMetaFeild.BindType);
                                                        }
                                                        else if (sUrlSpans[0].StartsWith("http://") || sUrlSpans[0].StartsWith("https://"))
                                                        {
                                                            //sDrillCRecord.AddDownload(sUrlSpans[0], pData.Url, sRegularMetaFeild.BindType);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                sDrillResult.Records.Add(sDrillCRecord);
                            }
                        }
                        Records.Add(sDrillResult);
                    };
                }
            });
            return Records;
        }
        /// <summary>
        /// 获取一个任务包
        /// </summary>
        /// <returns></returns>
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
                    //创建一个任务包
                    CrawlTask crawlTask = CreateCrawlTask(taskDetailList);
                    lock (mLocker)
                    {
                        mRunningTaskDic[crawlTask.ID] = crawlTask;
                        for (int i = 0; i < taskDetailList.Count; i++)
                        {
                            mRunningTaskDetailDic[taskDetailList[i].Key] = taskDetailList[i];
                        }
                    }
                    return crawlTask;
                }
            }

            return null;
        }

        /// <summary>
        /// 将任务实体类列表封装成一个任务包
        /// </summary>
        /// <param name="pTaskDetailList"></param>
        /// <returns></returns>
        private CrawlTask CreateCrawlTask(List<CrawlTaskDetail> pTaskDetailList)
        {
            if (mState == (int)WaterLineState.Stop)
            {
                return null;
            }
            //实例化任务包
            CrawlTask sCrawlTask = new CrawlTask();

            sCrawlTask.Host = Host;//任务包的主页地址
            sCrawlTask.PlotKey = Plot.Key;//专案的Key作为任务包的PlotKey
            sCrawlTask.LineID = ID;

            sCrawlTask.List = pTaskDetailList;
            return sCrawlTask;
        }

        internal void RecieveCrawlResult(CrawlResult pResult)
        {
            CrawlTask sCrawlTask;
            lock (mLocker)
            {
                if (mRunningTaskDic.TryGetValue(pResult.TaskID, out sCrawlTask) == false || sCrawlTask.List.Count != pResult.List.Count)  //未注册的任务
                {
                    return;
                }
                else
                {
                    //该任务算是完成了
                    mRunningTaskDic.Remove(pResult.TaskID);
                    for (int i = 0; i < sCrawlTask.List.Count; i++)
                    {
                        mRunningTaskDetailDic.Remove(sCrawlTask.List[i].Key);
                    }
                }
            }
            //最后时间
            mLastProduceDt = DateTime.Now;
            //将任务和结果合并成一个对象
            List<CrawlOriData> sCrawlOriDataList = new List<CrawlOriData>();
            for (int i = 0; i < sCrawlTask.List.Count; i++)
            {
                CrawlResultDetail sCrawlResultDetail = pResult.List[i];
                CrawlTaskDetail sCrawlTaskDetail = sCrawlTask.List[i];

                CrawlOriData sCrawlOriData = new CrawlOriData(sCrawlTaskDetail, sCrawlResultDetail, (byte)("utf-8".Equals(Chaset, StringComparison.OrdinalIgnoreCase) ? 0 : 1));

                //存储原始数据
                crawlDbAdapter.InsertCrawlResult(pResult.List);
                //
                sCrawlOriDataList.Add(sCrawlOriData);

            }
            //更新数据库标示，已经完成任务
            AddCrawlDatasWaitDrill(sCrawlOriDataList);

        }
        internal void AddCrawlDatasWaitDrill(List<CrawlOriData> pDatList)
        {
            if (pDatList.Count > 0)
            {
                lock (mLocker)
                {
                    mCrawlDataWaitDrillList.AddRange(pDatList);
                }
            }
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

        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            mExit = false;
            mState = (int)WaterLineState.Start;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Stop()
        {
            mState = 0;
        }

        #endregion

    }
}
