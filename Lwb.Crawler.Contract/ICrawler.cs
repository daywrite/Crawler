﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using Lwb.Crawler.Contract.Model;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Contract
{
    [ServiceContract]
    public interface ICrawler
    {       
        [OperationContract]
        List<CrawlTask> QueryCrawlTask(Input input);

        [OperationContract]
        void ReceiveCrawlResult(CrawlResult pCrawlResult);
    }
}
