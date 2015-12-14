using System;
using System.Collections.Generic;
using System.Text;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 基础提取规则
    /// </summary>
    [Serializable]
    public class DrillRegularRule : DrillBaseRule
    {
        /// <summary>
        /// 记录区-执行条件
        /// 【0-无条件执行|1-包含条件，包含指定的特征才执行|2-排除条件 ，不包含指定的特征才执行】
        /// </summary>
        public byte ConditionType { get; set; }
        public string ConditionTag;            //条件字符串

        public string StartTag;                                 //起始特征
        public string EndTag;                                   //终止特征

        #region 链接特征提取
        /// <summary>
        /// 链接or图片
        /// 【0-HREF,来自A节点|1-SRC,来自IMG】
        /// </summary>
        public int FeatureType { get; set; }
        public string Feature;                                  //通过特征串提取，元数据是固定的链接模式
        #endregion

        #region 自定义提取
        public string Splitter;							        //记录区内的分割
        public List<RegularMetaFeild> Feilds = new List<RegularMetaFeild>();   //记录区内每一循环记录的元数据提取集合
        #endregion

        internal RegularMetaFeild GetByName(string pName)
        {
            for (int i = 0; i < Feilds.Count; i++)
            {
                if (Feilds[i].Name == pName)
                {
                    return Feilds[i];
                }
            }
            return null;
        }
    }
    [Serializable]
    public class RegularMetaFeild : BaseFeild
    {
        public RegularFeildRule Rule;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal RegularMetaFeild Clone()
        {
            RegularMetaFeild sMetaFeild = new RegularMetaFeild();
            sMetaFeild.BindType = BindType;
            sMetaFeild.Name = Name;
            if (Rule != null)
            {
                sMetaFeild.Rule = Rule.Clone();
            }
            return sMetaFeild;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RegularFeildRule
    {
        public string GroupTag;                 //内容的起始搜索标记
        public string GroupEndTag;              //内容的终止搜索标记
        public string StartTag;				    //起始标记，包含
        public string EndTag;				    //终止标记，不包含

        public bool Repeatable;                 //循环提取
        public bool ClearHtml = true;           //清理Html代码
        public string[] ReplacePairs;			//替换字符串
        public bool RemoveWhiteSpace;          //移除空白


        internal RegularFeildRule Clone()
        {
            RegularFeildRule sMetaFeild = new RegularFeildRule();
            sMetaFeild.GroupTag = GroupTag;
            sMetaFeild.GroupEndTag = GroupEndTag;
            sMetaFeild.Repeatable = Repeatable;
            sMetaFeild.ClearHtml = ClearHtml;
            sMetaFeild.EndTag = EndTag;
            sMetaFeild.RemoveWhiteSpace = RemoveWhiteSpace;
            sMetaFeild.ReplacePairs = (string[])ReplacePairs.Clone();
            sMetaFeild.StartTag = StartTag;
            return sMetaFeild;
        }
    }
}
