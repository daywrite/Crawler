using System;
using System.Collections.Generic;
using System.Text;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 基础提取规则
    /// </summary>
    [Serializable]
    public class DrillBaseRule
    {
        public string Name = "新板块";						             //请求结果处理的名称
        public int MetaModalID;
        public int DbID;                                                 //输出数据库标识
        public string DbName;                                            //输出数据库名称   
        /// <summary>
        /// 记录区-提取规则
        /// 【默认为配置的高级提取】
        /// 【0-通过特征串提取链接|1-自动提取新闻全文|2-配置的高级提取】
        /// </summary>
        public byte DrillType { get; set; }

    }
}
