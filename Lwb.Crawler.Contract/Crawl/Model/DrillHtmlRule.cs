using System;
using System.Collections;
using System.Collections.Generic;
using Haina.Html;
using Haina.Base.Html;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 对请求输出的结果的一个记录区进行设定，原则上一个请求可以包含多个有效地记录区。
    /// </summary>
    [Serializable]
    public class DrillHtmlRule : DrillBaseRule
    {
        public HtmlSearchRule RegionPath;					     //请求结果处理的记录区路径

        #region 链接特征提取
        public int FeatureType;                                 //0-HREF,来自A节点；1-SRC,来自IMG
        public string Feature;                                  //通过特征串提取，元数据是固定的链接模式
        public string Classify;                                 //分类标签
        public int TitleMinLen = 5;
        #endregion

        #region 全文提取特征
        public string[] StartTag;                               //起始特征
        public string[] EndTag;                                 //终止特征
        #endregion

        #region 自定义提取
        public string Splitter;							                //记录区内的分割表达式,格式： 起始无效标签数:分割标签名:标签跨度:截止无效标签数
        public FeildCollection Feilds = new FeildCollection();           //记录区内每一循环记录的元数据提取集合
        public List<TezhenRule> TezhenRules = new List<TezhenRule>();   //特征提取规则
        #endregion
        /// <summary>
        /// 获取字段ID
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public MetaFeild GetByID(int pID)
        {
            for (int i = 0; i < Feilds.Count; i++)
            {
                if (Feilds[i].ID >= pID)
                {
                    return Feilds[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 构造函数,结果处理的模板请求
        /// </summary>
        public DrillHtmlRule()
        {
        }


        internal DrillHtmlRule Clone()
        {
            DrillHtmlRule sDrillRule = new DrillHtmlRule();
            sDrillRule.Classify = Classify;
            sDrillRule.DbID = DbID;
            sDrillRule.DbName = DbName;
            sDrillRule.DrillType = DrillType;
            sDrillRule.EndTag = EndTag;
            sDrillRule.Feilds = Feilds.Clone();
            sDrillRule.MetaModalID = MetaModalID;
            sDrillRule.Name = Name;
            sDrillRule.RegionPath = RegionPath;
            sDrillRule.Splitter = Splitter;
            sDrillRule.StartTag = StartTag;
            sDrillRule.TitleMinLen = TitleMinLen;
            sDrillRule.Feature = Feature;
            for (int i = 0; i < TezhenRules.Count; i++)
            {
                sDrillRule.TezhenRules.Add(TezhenRules[i].Clone());
            }
            return sDrillRule;
        }
    }
}
