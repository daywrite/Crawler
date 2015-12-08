using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    /// <summary>
    /// 流水线状态
    /// </summary>
    public enum WaterLineState
    {
        [Description("启动")]
        Start = 1,
        [Description("停止")]
        Stop = 0
    }
}
