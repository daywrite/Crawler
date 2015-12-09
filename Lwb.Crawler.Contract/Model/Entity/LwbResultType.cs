using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    /// <summary>
    /// 表示业务操作结果的枚举
    /// </summary>
    public enum LwbResultType
    {
        /// <summary>
        ///   指定参数的数据为null
        /// </summary>
        [Description("指定参数的数据为null。")]
        QueryNull,

        /// <summary>
        ///   操作成功
        /// </summary>
        [Description("操作成功。")]
        Success,

        /// <summary>
        ///   操作引发错误
        /// </summary>
        [Description("操作引发错误。")]
        Error
    }
}
