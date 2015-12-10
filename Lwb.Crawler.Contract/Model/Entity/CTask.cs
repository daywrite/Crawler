using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    /// <summary>
    /// 注入任务类
    /// </summary>
    [DataContract]
    public class CTask
    {
        /// <summary>
        /// 任务自增标识
        /// </summary>
        [DataMember]
        public int Id { get; set; }       

        /// <summary>
        /// 任务url
        /// </summary>
        [DataMember]
        public string Url { get; set; }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        [DataMember]
        public bool IsDeleted  { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }
    }
}

