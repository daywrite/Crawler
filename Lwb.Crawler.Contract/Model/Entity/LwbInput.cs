﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Contract.Model
{
    [DataContract]
    [KnownType(typeof(Input获取生产线任务列表))]
    [KnownType(typeof(CrawlResult))]
    public class LwbInput
    {

        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public object Data { get; set; }
    }
    [DataContract]
    public class Input获取生产线任务列表
    {
        [DataMember]
        public int TaskMax { get; set; }
        [DataMember]
        public List<string> RuningTaskHost { get; set; }
    }
}
