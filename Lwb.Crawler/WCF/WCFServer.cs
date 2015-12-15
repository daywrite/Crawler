using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Contract.Model;
//using Lwb.Crawler.Crawl.Model;

namespace Lwb.Crawler
{
    public class WCFServer
    {
        /// <summary>
        /// WCF远程接口交互
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pType"></param>
        /// <param name="pAuthority"></param>
        /// <returns></returns>
        private static LwbResult LwbProcess(object pData, int pType, string pAuthority)
        {
            using (ChannelFactory<ICrawler> channelFactory = new ChannelFactory<ICrawler>("crawlerservice"))
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
            LwbResult sLwbResult = LwbProcess(pInput获取生产线任务列表, (int)CrawlCmd.获取生产线任务列表, null);

            return sLwbResult;
        }

        /// <summary>
        /// 爬虫获取到html发送回服务中心
        /// </summary>
        /// <param name="pCrawlResult"></param>
        public static void SendingCrawlResult(CrawlResult pCrawlResult)
        {
            LwbProcess(pCrawlResult, (int)CrawlCmd.发送爬行任务, null);
        }                   
    }  
}
