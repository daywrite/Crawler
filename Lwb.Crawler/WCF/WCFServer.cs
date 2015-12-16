using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Contract.Model;
using Lwb.Crawler.Service;
//using Lwb.Crawler.Crawl.Model;

namespace Lwb.Crawler
{
    public class WCFServer
    {
        //远程数据中心列表
        private static List<string> mAuthorityList = new List<string>();
        private static int mPos;
        /// <summary>
        /// WCF远程接口交互
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pType"></param>
        /// <param name="pAuthority"></param>
        /// <returns></returns>
        private static LwbResult LwbProcess(object pData, int pType, string pAuthority)
        {
            using (ChannelFactory<ICrawler> channelFactory = new ChannelFactory<ICrawler>(
                   new WSHttpBinding(SecurityMode.None),
                   new EndpointAddress(pAuthority + "/crawlerservice")))
            {
                ICrawler proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    return proxy.LwbEach(new LwbInput { Type = pType, Data = pData });
                }

            }
        }

        /// <summary>
        /// 获取一个不同域名的的生产线任务
        /// </summary>
        /// <param name="pInput获取生产线任务列表"></param>
        /// <returns></returns>
        internal static LwbResult GetCrawlTask(Input获取生产线任务列表 pInput获取生产线任务列表)
        {
            if (mAuthorityList == null || mAuthorityList.Count == 0)
            {
                mAuthorityList.Add("http://127.0.0.1:8080");
            }

            if (mAuthorityList.Count > 0)
            {
                mPos++;
                if (mPos >= mAuthorityList.Count)
                    mPos = 0;
                string sAuthority = mAuthorityList[mPos];
                LwbResult sLwbResult = LwbProcess(pInput获取生产线任务列表, (int)CrawlCmd.获取生产线任务列表, sAuthority);

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
                    t.Authority = sAuthority;
                });

                return sLwbResult;
            }
            else
            {
                return new LwbResult(LwbResultType.Error, "未找到远程数据中心服务器");
            }
        }

        /// <summary>
        /// 爬虫获取到html发送回服务中心
        /// </summary>
        /// <param name="pCrawlResult"></param>
        public static void SendingCrawlResult(CrawlResult pCrawlResult, string pAuthority)
        {
            LwbProcess(pCrawlResult, (int)CrawlCmd.发送爬行任务, pAuthority);
        }
    }
}
