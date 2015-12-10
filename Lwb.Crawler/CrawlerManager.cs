using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNet4.Utilities;
using Haina.Base;
using Lwb.Crawler;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Contract.Model;
namespace Lwb.Crawler
{
    public class CrawlerManager
    {
        private static object mLocker = new object();

        private static HttpHelper httpHelper;
        private static HttpItem item;
        private static HttpResult result;

        private static Dictionary<string, HostStatus> mHostDic = new Dictionary<string, HostStatus>();    //主机累积错误
        private static Dictionary<Int128, CrawlTask> mTaskPool = new Dictionary<Int128, CrawlTask>();     //当前爬虫在线任务

        private static DateTime mLastAddTaskDt { get; set; }
        private static bool mCanAttemper { get; set; }//爬虫是否能调度
        public static int MaxThreads { get; set; }//爬虫能接受的最大任务数量
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
            if (mCanAttemper)
            {
                try
                {
                    mCanAttemper = false;
                    int sMax;
                    lock (mLocker)
                    {
                        sMax = (MaxThreads - mTaskPool.Count) > 5 ? 5 : (MaxThreads - mTaskPool.Count);
                    }
                    if (sMax > 0)
                    {
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
                        LwbResult sLwbResult = WCFServer.GetCrawlTask(new Input获取生产线任务列表 { RuningTaskHost = sList, TaskMax = sMax });

                        List<CrawlTask> sCrawlTaskList = sLwbResult.Data as List<CrawlTask>;
                        if (sCrawlTaskList == null)
                            return new LwbResult(LwbResultType.Error, "爬虫抓取返回数据格式错误");

                        if (sCrawlTaskList.Count != 0)
                        {
                            sCrawlTaskList.ForEach(t =>
                            {
                                lock (mLocker)
                                {
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
                        }

                        return new LwbResult(LwbResultType.Success, "爬虫正在干活中，很开心");
                    }
                    else
                    {
                        return new LwbResult(LwbResultType.Success, "爬虫已经正在干将近" + MaxThreads + "个任务，让他歇会吧");
                    }
                }
                catch (Exception ee)
                {
                    return new LwbResult(LwbResultType.Error, "爬虫在干活过程中生病了"+ee.Message);
                }
                finally
                {
                    mCanAttemper = true;
                }
            }
            else
            {
                return new LwbResult(LwbResultType.Success, "爬虫正在干活中，请勿累死爬虫");
            }
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void ExeTask(object obj)
        {
            CrawlTask sCrawlTask = obj as CrawlTask;
            CrawlResult sCrawlResult = new CrawlResult();
            sCrawlTask.List.ForEach(t => {
                item.URL = t.Url;
                item.Method = "get";

                result = httpHelper.GetHtml(item);

                sCrawlResult.PlotKey = sCrawlTask.PlotKey;
                sCrawlResult.LineID = sCrawlTask.LineID;
                sCrawlResult.List.Add(new CrawlResultDetail { ID = t.ID, Content = result.Html });
            });
            WCFServer.SendingCrawlResult(sCrawlResult);
        }       
    }
}
