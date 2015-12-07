using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 参数参照值。
    /// </summary>
    [Serializable]
    public class ParaRefer
    {
        public string Name;          //参数可选值显示名，在原始资源中是给用户选择的值
        public string Value;         //参数可选值传递值，实际在URL中发送的值
        /// <summary>
        /// 构造函数
        /// </summary>
        public ParaRefer()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pElement"></param>
        public ParaRefer(HtmlElement pElement)
        {
            if ("option".Equals(pElement.TagName, StringComparison.OrdinalIgnoreCase))
            {
                Name = pElement.InnerText;
                Value = pElement.GetAttribute("value");
            }
            else
            {
                Name = pElement.GetAttribute("value");
                Value = Name;
            }
            if (Value != null)
            {
                Value = Name.Replace(" ", "+");
            }
        }
        /// <summary>
        /// 串行化
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        internal ParaRefer Clone()
        {
            ParaRefer sParaRefer = new ParaRefer();
            sParaRefer.Name = Name;
            sParaRefer.Value = Value;
            return sParaRefer;
        }
    }
}
