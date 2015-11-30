using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract;
using Lwb.Crawler.Contract.Model;

using Dapper;
namespace Lwb.Crawler.Service
{
    public class CrawlerService : ICrawler
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public List<CTask> Query()
        {
            List<CTask> result = new List<CTask>();
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = "select Id,CTaskId,Url from CTask";
                sqlConnection.Open();
                result = sqlConnection.Query<CTask>(sql, null).ToList();
                sqlConnection.Close();
            }

            return result;
        }
    }
}
