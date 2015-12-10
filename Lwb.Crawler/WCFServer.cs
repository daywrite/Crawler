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
        public static void SendCrawlResult(CrawlResult pCrawlResult)
        {
            try
            {
                using (ChannelFactory<ICrawler> channelFactory = new ChannelFactory<ICrawler>("crawlerservice"))
                {
                    ICrawler proxy = channelFactory.CreateChannel();
                    using (proxy as IDisposable)
                    {
                        proxy.ReceiveCrawlResult(pCrawlResult);
                    }
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("SendCrawResult" + ee.Message);
            }
        }


        public static HainaResultInfo<List<CrawlTask>> HanaiProcess()
        {
            try
            {
                using (ChannelFactory<ICrawler> channelFactory = new ChannelFactory<ICrawler>("crawlerservice"))
                {
                    ICrawler proxy = channelFactory.CreateChannel();
                    using (proxy as IDisposable)
                    {
                        List<CrawlTask> cTaskList = proxy.QueryCrawlTask(new Input { Type = 3 });
                        return new HainaResultInfo<List<CrawlTask>> { Content = cTaskList };
                    }
                }
            }
            catch (Exception E)
            {
                return null;
            }
        }        
    }

    public class HainaResultInfo<TEntity>
    {
        public TEntity Content { get; set; }
    }
}
