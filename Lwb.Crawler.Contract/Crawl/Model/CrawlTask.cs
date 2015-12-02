using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Crawl.Model
{
    [DataContract]
    public class CrawlTask
    {
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
