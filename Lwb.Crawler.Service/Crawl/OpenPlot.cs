using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Service.Crawl
{
    public class OpenPlot
    {
        public PlotWaterLine Line = new PlotWaterLine();//专案生产线
        internal CrawlTask GetCrawlTask()
        {
            CrawlTask crawlTask=Line.GetCrawlTask();

            return crawlTask;
        }
    }
}
