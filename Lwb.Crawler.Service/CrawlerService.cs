using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract;
using Lwb.Crawler.Contract.Model;

using Dapper;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Service.Crawl;
namespace Lwb.Crawler.Service
{
    public class CrawlerService : ICrawler
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public List<CTask> Query(Input input)
        {

            List<CTask> ret = new List<CTask>();

            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = "select Id,CTaskId,Url from CTask";
                sqlConnection.Open();
                ret = sqlConnection.Query<CTask>(sql, null).ToList();
                sqlConnection.Close();
            }

            return ret;

        }
        public List<CrawlTask> QueryCrawlTask(Input input)
        {
            if (input.Type == 3)
            {
                return CrawlServer.GetCrawlTasks();
            }

            return null;
        }
    }
}
