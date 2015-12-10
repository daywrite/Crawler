using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Crawl.Model
{
    public class HostStatus
    {
        public string Host { get; set; }                   //主机地址
        public HostStatus(string pHost)
        {
            Host = pHost;
        }
        public int TaskCount { get; set; }                 //当前的任务计数
        public bool Busy
        {
            get { return TaskCount > 0; }
        }
    }
}
