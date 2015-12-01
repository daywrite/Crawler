using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Service.Crawl
{
    public class CrawlServer
    {
        public static OpenPlot openPlot = new OpenPlot();
        internal static List<CrawlTask> GetCrawlTasks()
        {
            List<CrawlTask> sList = new List<CrawlTask>();


            CrawlTask crawlTask = openPlot.GetCrawlTask();
            sList.Add(crawlTask);

            return sList;
        }
    }
}
