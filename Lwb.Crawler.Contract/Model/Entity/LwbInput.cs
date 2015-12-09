using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    [DataContract]
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
