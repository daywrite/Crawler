using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Crawl
{
    public class SRecord
    {
        /// <summary>
        /// 专案的名称
        /// </summary>
        public string PlotName { get; set; }

        /// <summary>
        /// 下载链接类型
        /// 【链接|图片】
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// 存储的Url
        /// </summary>
        public string Url { get; set; }
    }
}
