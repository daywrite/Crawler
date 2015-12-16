using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using Lwb.Crawler.Contract.Model;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Service.Db
{
    /// <summary>
    /// 抓取数据库操作类
    /// </summary>
    public class CrawlDbAdapter
    {
        /// <summary>
        /// 获取数据库CTask任务
        /// </summary>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public List<CrawlTaskDetail> Read(int count)
        {
            //数据库表实体类列表
            List<CTask> ret = new List<CTask>();

            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = string.Format("select top {0} Id,Url from CTask where IsDeleted=0 order by CreatedTime desc", count);
                sqlConnection.Open();
                ret = sqlConnection.Query<CTask>(sql, null).ToList();
                sqlConnection.Close();
            }

            //任务类实体列表
            List<CrawlTaskDetail> sList = new List<CrawlTaskDetail>();
            ret.ForEach(t => sList.Add(ReadInner(t)));

            return sList;
        }

        /// <summary>
        /// 将数据库实体类列表转化成人物类实体列表
        /// </summary>
        /// <param name="cTask"></param>
        /// <returns></returns>
        public CrawlTaskDetail ReadInner(CTask cTask)
        {
            CrawlTaskDetail crawlTaskDetail = new CrawlTaskDetail();
            crawlTaskDetail.ID = cTask.Id;
            crawlTaskDetail.Url = cTask.Url;

            return crawlTaskDetail;
        }

        /// <summary>
        /// 批量将返回的任务插入到数据库
        /// </summary>
        /// <param name="pCrawlResultDetailList"></param>
        public void InsertCrawlResult(List<CrawlResultDetail> pCrawlResultDetailList)
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = string.Format("Insert into CTaskResult values(@url,@rcontent,@isdeleted,@createdtime)");
                sqlConnection.Open();
                pCrawlResultDetailList.ForEach(t => sqlConnection.Execute(sql,
                    new
                    {
                        url = "",
                        rcontent = t.Content,
                        isdeleted = false,
                        createdtime = DateTime.Now
                    })
                        );

                sqlConnection.Close();
            }
        }
        /// <summary>
        /// 单条插入数据库
        /// </summary>
        /// <param name="pCrawlResultDetailList"></param>
        public void InsertCrawlResult(CrawlResultDetail pCrawlResultDetail)
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = string.Format("Insert into CTaskResult values(@url,@rcontent,@isdeleted,@createdtime)");
                sqlConnection.Open();
                sqlConnection.Execute(sql,
                    new
                    {
                        url = "",
                        rcontent = pCrawlResultDetail.Content,
                        isdeleted = false,
                        createdtime = DateTime.Now
                    });

                sqlConnection.Close();
            }
        }
        /// <summary>
        /// 任务完成后更新标志数据库
        /// </summary>
        /// <param name="id"></param>
        public void UpdateCTask(int id)
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                string sql = string.Format("Update CTask set IsDeleted=1 where Id={0}", id);
                sqlConnection.Open();
                sqlConnection.Execute(sql);
                sqlConnection.Close();
            }
        }
    }
}
