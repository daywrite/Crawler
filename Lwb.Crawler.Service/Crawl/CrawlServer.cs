using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;
using DotNet.Utilities;
namespace Lwb.Crawler.Service.Crawl
{
    public class CrawlServer
    {
        public static string Root { get; set; }//根目录
        public static string CaseRoot { get; set; }//专案目录


        public static OpenPlot openPlot = new OpenPlot();

        public static bool InitServer(string root)
        {
            Root = root;

            CaseRoot = Root + "\\Cases";
            DirFileHelper.CreateDirectory(CaseRoot);

            return false;
        }
        internal static List<CrawlTask> GetCrawlTasks()
        {
            List<CrawlTask> sList = new List<CrawlTask>();


            CrawlTask crawlTask = openPlot.GetCrawlTask();
            if (crawlTask != null)
            {
                sList.Add(crawlTask);
            }
            
            return sList;
        }
    }
}
