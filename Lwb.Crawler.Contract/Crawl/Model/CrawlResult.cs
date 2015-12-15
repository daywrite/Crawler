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
    public class CrawlResult
    {      
        [DataMember]
        public Int128 TaskID { get; set; }//任务标识
        [DataMember]
        public Int128 PlotKey { get; set; }//专案标识
        [DataMember]
        public int LineID { get; set; }  //生产线标识                         
        [DataMember]
        public List<CrawlResultDetail> List = new List<CrawlResultDetail>();
    }

    [DataContract]
    public class CrawlResultDetail
    {
        public CrawlResultDetail()
        {
            Result = true;
        }
        public CrawlResultDetail(bool pResult)
        {
            Result = pResult;
        }
        public CrawlResultDetail(bool pResult, string pErrInfo)
        {
            Result = pResult;
            Info = pErrInfo;
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public string Ext { get; set; }
    }
}
