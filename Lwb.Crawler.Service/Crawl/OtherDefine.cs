using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Service.Crawl
{
    internal delegate void NotifyHandler();
    /// <summary>
    /// 监视异常信息
    /// </summary>
    //internal delegate void CrawlMessageHandler(CrawlMessage e);
    /// <summary>
    /// 中间结果监视
    /// </summary>
    /// <param name="pResult"></param>
    //internal delegate void ResultWatchHandler(ReqResult pResult);
    /// <summary>
    /// 参数的类型
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// 固定的参数
        /// </summary>
        Fixed = 0,
        /// <summary>
        /// 无值的参数，一般是基础URL的附加参数
        /// </summary>
        NoValue = 1,
        /// <summary>
        /// 遗传参数
        /// </summary>
        Inherit = 2,
        /// <summary>
        /// 输入参数
        /// </summary>
        Input = 3,
        /// <summary>
        /// 选择参数
        /// </summary>
        Choice = 4
    }

    /// <summary>
    /// 请求返回有效性检测方式
    /// </summary>
    public enum RequestVerifyType
    {
        /// <summary>
        /// 保守的一般性检测
        /// </summary>
        Default = 0,
        /// <summary>
        /// 严格地成功检测，返回页面的标题必须包含指定的成功标志
        /// </summary>
        Success = 1,
        /// <summary>
        /// 不检测成功与失败
        /// </summary>
        None = 2
    }
}

