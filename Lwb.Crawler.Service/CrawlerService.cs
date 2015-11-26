using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lwb.Crawler.Contract;

namespace Lwb.Crawler.Service
{
    public class CrawlerService : ICrawler
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
