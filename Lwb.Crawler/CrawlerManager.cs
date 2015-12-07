using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet4.Utilities;
using Lwb.Crawler;
using Lwb.Crawler.Contract.Crawl.Model;
namespace Lwb.Crawler
{
    public class CrawlerManager
    {
        private static HttpHelper httpHelper;
        private static HttpItem item;
        private static HttpResult result;
        static CrawlerManager()
        {
            httpHelper = new HttpHelper();
            item = new HttpItem();
        }

        public static void Adapter()
        {
            HainaResultInfo<List<CrawlTask>> sTaskList = WCFServer.HanaiProcess();
            if (sTaskList != null && sTaskList.Content.Count != 0)
            {
                foreach (var index in sTaskList.Content)
                {
                    ExecuteTask(index);
                }
                //Console.WriteLine(sTaskList.Content.Count);
            }
            else
            {
                Console.WriteLine("还没有任务哦");
            }
        }

        public static void ExecuteTask(object obj)
        {
            CrawlTask sCrawlTask = (CrawlTask)obj;

            foreach (var index in sCrawlTask.List)
            {
                item.URL = index.Url;
                item.Method = "get";

                result = httpHelper.GetHtml(item);

                Console.WriteLine(result.Html);
            }

            //WCFServer.SendCrawlResult(1);
        }
    }
}
