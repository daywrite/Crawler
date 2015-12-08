using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Haina.Base;

namespace Lwb.Crawler.Contract.Crawl.Model
{
    [DataContract]
    public class CrawlTask
    {
        public CrawlTask()
        {
            ID = new Int128(Guid.NewGuid().ToByteArray());
            CreateDt = DateTime.Now;
            WorkTimeSpan = 60;
        }
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public Int128 ID { get; set; }       //任务标识
        [DataMember]
        public Int128 PlotKey { get; set; }                  //专案标识
        [DataMember]
        public int LineID { get; set; }                         //生产线标识
        [DataMember]
        public DateTime CreateDt { get; set; }   //任务分发时刻
        [DataMember]
        public int WorkTimeSpan { get; set; }            //任务有效期
        [DataMember]
        public List<CrawlTaskDetail> List = new List<CrawlTaskDetail>();     //任务列表
    }

    [DataContract]
    public class CrawlTaskDetail
    {
        [DataMember]
        public int ID { get; set; }                 //任务标识  
        [DataMember]
        public string Url { get; set; }         //请求url
    }
}
