using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;
using Dapper;
using Lwb.Crawler.Contract.Model;
namespace Lwb.Crawler.Service.Db
{
    public class CrawlDbAdapter
    {
        public List<CrawlTaskDetail> Read(int count)
        {
            List<CTask> ret = new List<CTask>();

            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = string.Format("select top {0} Id,CTaskId,Url from CTask where IsDeleted=0 order by CreatedTime desc",count);
                sqlConnection.Open();
                ret = sqlConnection.Query<CTask>(sql, null).ToList();
                sqlConnection.Close();
            }

            List<CrawlTaskDetail> sList = new List<CrawlTaskDetail>();
            ret.ForEach(t => sList.Add(ReadInner(t)));

            return sList;
        }

        public CrawlTaskDetail ReadInner(CTask cTask)
        {
            CrawlTaskDetail crawlTaskDetail = new CrawlTaskDetail();
            crawlTaskDetail.ID = cTask.Id;
            crawlTaskDetail.BaseUrl = cTask.Url;
            crawlTaskDetail.Qurey = null;
            
            return crawlTaskDetail;
        }
    }
}
