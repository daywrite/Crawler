using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Unitity.Data
{
    /// <summary>
    /// OSharp操作结果
    /// </summary>
    /// <typeparam name="TResultType"></typeparam>
    public interface IOSharpResult<TResultType> : IOSharpResult<TResultType, object>
    { }


    /// <summary>
    /// OSharp操作结果
    /// </summary>
    public interface IOSharpResult<TResultType, TData>
    {
        /// <summary>
        /// 获取或设置 结果类型
        /// </summary>
        TResultType ResultType { get; set; }

        /// <summary>
        /// 获取或设置 返回消息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 获取或设置 结果数据
        /// </summary>
        TData Data { get; set; }
    }
}