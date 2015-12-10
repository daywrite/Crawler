using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Unitity.Data;

namespace Lwb.Crawler.Contract.Model
{
    /// <summary>
    /// 业务操作结果信息类，对操作结果进行封装
    /// </summary>
    [DataContract]
    [KnownType(typeof(List<CrawlTask>))]
    public class LwbResult
    {

        public LwbResult()
        {
            ResultType = LwbResultType.Success;
        }

        public LwbResult(LwbResultType type)
        {
            ResultType = type;
        }
        public LwbResult(LwbResultType type, string message)
        {
            ResultType = type;
            Message = message;
        }
        public LwbResult(LwbResultType type, string message, object data)
        {
            ResultType = type;
            Message = message;
            Data = data;
        }
        /// <summary>
        /// 获取或设置 结果类型
        /// </summary>
        [DataMember]
        public LwbResultType ResultType { get; set; }

        /// <summary>
        /// 获取或设置 返回消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置 结果数据
        /// </summary>
        [DataMember]
        public object Data { get; set; }
    }
}
