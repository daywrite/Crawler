using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNet4.Utilities;
using Haina;
using Haina.Base;
using Lwb.Crawler;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Contract.Model;
namespace Lwb.Crawler
{
    /// <summary>
    /// 爬虫管理类
    /// </summary>
    public class CrawlerManager
    {
        /// <summary>
        /// 多线程锁
        /// </summary>
        private static object mLocker = new object();

        //跟爬虫爬取网页html代码有关
        private static HttpHelper httpHelper;
        private static HttpItem item;
        private static HttpResult result;

        //主机累积错误
        private static Dictionary<string, HostStatus> mHostDic = new Dictionary<string, HostStatus>();
        //当前爬虫在线任务
        private static Dictionary<Int128, CrawlTask> mTaskPool = new Dictionary<Int128, CrawlTask>();

        private static DateTime mLastAddTaskDt { get; set; }
        //爬虫是否能调度
        private static bool mCanAttemper { get; set; }
        //爬虫能接受的最大任务数量
        public static int MaxThreads { get; set; }

        #region 辅助字段
        //最小延时
        public static int DelayMin { get; set; }
        //最大延时                       
        public static int DelayMax { get; set; }
        #endregion
        static CrawlerManager()
        {
            httpHelper = new HttpHelper();
            item = new HttpItem();

            mCanAttemper = true;
            MaxThreads = 30;
        }

        /// <summary>
        /// 爬虫去干活去喽
        /// </summary>
        /// <returns></returns>
        public static LwbResult DbAdapter()
        {
            if (!mCanAttemper)
                return new LwbResult(LwbResultType.Success, "爬虫正在获取任务中，请勿累死爬虫");

            try
            {
                //锁定爬虫，让其暂时不接受任务
                mCanAttemper = false;
                int sMax;
                lock (mLocker)
                {
                    sMax = (MaxThreads - mTaskPool.Count) > 5 ? 5 : (MaxThreads - mTaskPool.Count);
                }
                //爬虫已经在干任务达到30个
                if (sMax == 0)
                    return new LwbResult(LwbResultType.Success, "爬虫已经正在干将近" + MaxThreads + "个任务，让他歇会吧");

                List<string> sList = new List<string>();
                lock (mLocker)
                {
                    foreach (KeyValuePair<string, HostStatus> sKp in mHostDic)
                    {
                        if (sKp.Value.Busy)
                        {
                            sList.Add(sKp.Key);
                        }
                    }
                }
                //去远程服务器取任务
                LwbResult sLwbResult = WCFServer.GetCrawlTask(new Input获取生产线任务列表 { RuningTaskHost = sList, TaskMax = sMax });
                //先看看结果
                if (sLwbResult.ResultType != LwbResultType.Success)
                    return sLwbResult;
                //转换结果
                List<CrawlTask> sCrawlTaskList = sLwbResult.Data as List<CrawlTask>;
                if (sCrawlTaskList == null)
                    return new LwbResult(LwbResultType.Error, "爬虫抓取返回数据格式错误");
                if (sCrawlTaskList.Count == 0)
                    return new LwbResult(LwbResultType.Success, "爬虫获取到的任务数量为0");

                sCrawlTaskList.ForEach(t =>
                {
                    lock (mLocker)
                    {
                        //任务包缓冲池
                        mTaskPool[t.ID] = t;

                        HostStatus sHostStatus;
                        if (mHostDic.TryGetValue(t.Host, out sHostStatus) == false)
                        {
                            sHostStatus = new HostStatus(t.Host);
                            mHostDic[t.Host] = sHostStatus;
                        }
                        sHostStatus.TaskCount++;
                    }
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ExeTask), t);
                });
                mLastAddTaskDt = DateTime.Now;

                return new LwbResult(LwbResultType.Success, "爬虫获取任务完毕，很开心");
            }
            catch (Exception ee)
            {
                return new LwbResult(LwbResultType.Error, "爬虫在获取任务中生病了" + ee.Message);
            }
            finally
            {
                mCanAttemper = true;
            }
        }

        /// <summary>
        /// 线程池抓取任务
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void ExeTask(object obj)
        {
            CrawlTask sCrawlTask = obj as CrawlTask;

            CrawlResult sCrawlResult = new CrawlResult(sCrawlTask.ID, sCrawlTask.PlotKey, sCrawlTask.LineID);

            sCrawlTask.List.ForEach(t =>
            {
                try
                {
                    item.URL = t.Url;
                    item.Method = "get";

                    result = httpHelper.GetHtml(item);


                    sCrawlResult.List.Add(new CrawlResultDetail
                    {
                        Result = true,
                        ID = t.ID,
                        Ext = "html",
                        Content = result.Html,
                        Info = null
                    });

                    if (DelayMin >= DelayMax)
                    {
                        DelayMax = DelayMin + 5000;
                    }
                    Thread.Sleep(new Random().Next(DelayMin, DelayMax));
                }
                catch (Exception ee)
                {
                    sCrawlResult.List.Add(new CrawlResultDetail
                    {
                        Result = false,
                        ID = t.ID,
                        Ext = "Error",
                        Content = null,
                        Info = ee.Message
                    });
                }
            });

            lock (mLocker)
            {
                mTaskPool.Remove(sCrawlTask.ID);
                //界面设计
            }

            //发送任务回数据中心
            WCFServer.SendingCrawlResult(sCrawlResult);
        }
    }
}
