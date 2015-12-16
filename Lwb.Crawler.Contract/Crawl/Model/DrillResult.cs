using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haina.Common;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Contract.Crawl.Model
{
    public class DrillResult
    {
        public DrillResult()
        {
            Result = true;
            Records = new List<DrillCRecord>();
        }

        public bool Result { get; set; }
        public string Info { get; set; }
        public List<DrillCRecord> Records { get; set; }
    }

    public class DrillCRecord
    {
        public SRecord Record { get; set; }

        public DrillCRecord()
        {
            Record = new SRecord();
        }

        public DrillCRecord(string PlotName, string Type, string Url)
            : this()
        {
            Record.PlotName = PlotName;
            Record.Type = Type;
            Record.Url = Url;
        }

    }
}
