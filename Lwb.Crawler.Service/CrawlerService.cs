using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using Lwb.Crawler.Contract;
using Lwb.Crawler.Contract.Model;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Service
{
    /// <summary>
    /// Wcf服务器数据交互接口
    /// </summary>
    public class CrawlerService : ICrawler
    {        
        public List<CrawlTask> QueryCrawlTask(Input input)
        {
            if (input.Type == 3)
            {
                return CrawlServer.GetCrawlTasks(null, 1, 1);
            }

            return null;
        }

        public void ReceiveCrawlResult(CrawlResult pCrawlResult)
        {
            CrawlServer.ReceiveCrawlResult(pCrawlResult);
        }

        
    }
}
