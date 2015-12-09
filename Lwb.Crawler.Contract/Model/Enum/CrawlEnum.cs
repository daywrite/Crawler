using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    public enum CrawlCmd
    {
        获取生产线任务 = 1,
        发送爬行任务 = 2,
        获取生产线任务列表 = 3,
        汇报爬虫状态 = 4
    }
}
