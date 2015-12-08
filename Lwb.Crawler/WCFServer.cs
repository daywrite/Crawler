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
            catch (Exception E)
            {

            }
        }
    }

    public class HainaResultInfo<TEntity>
    {
        public TEntity Content { get; set; }
    }
}
