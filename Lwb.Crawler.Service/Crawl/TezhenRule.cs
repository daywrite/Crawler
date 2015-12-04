using System;
using System.Collections.Generic;
using System.Text;
using Haina.Base.Html;
using Haina.Base;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 特征提取
    /// </summary>
    [Serializable]
    public class TezhenRule
    {
        public HtmlSearchRule Path;
        /// <summary>
        /// 结果特征模式
        /// 0-键值对模式，FName=字段前缀，Spliter=分隔标签
        /// 1-单字段模式，FName=字段名
        /// </summary>
        public int ResultMode;     
        public string FName;
        public string Spliter;
        public string Script;     //暂时没用

        /// <summary>
        /// 执行特征筛选，并添加到缓冲区
        /// </summary>
        public void Exe(Dictionary<string, string> pDic, HtmlTree pTree, HtmlNodeList pHtmlNodeList)
        {
            List<HtmlNode> sList =Path.Exe(  pTree,  pHtmlNodeList) ;
            if (sList != null)       //
            {
                for (int i = 0; i < sList.Count; i++)
                {
                    HtmlNode sHtmlNode = sList[i];
                    if (ResultMode == 0) //
                    {
                        #region 键值对模式
                        List<HtmlNodeList> sSubList = sHtmlNode.Nodes.Split(Spliter);
                        for (int j = 0; j < sSubList.Count; j++)
                        {
                            HtmlNodeList sTextNodes = sSubList[j].GetTextNodes(false);
                            if (sTextNodes.Count > 0)
                            {
                                for (int k = sTextNodes.Count-1; k >=0; k--)
                                {
                                    if (sTextNodes[k].TextDecoded.Trim().Length == 0) { sTextNodes.RemoveAt(k); }
                                }
                                if (sTextNodes.Count > 0)
                                {
                                    string[] sNameSpan = sTextNodes[0].TextDecoded.Trim().Replace(" ","").Split(new char[] { ':', '：' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (sNameSpan.Length > 0)
                                    {
                                        string sName = CommonService.ClearStr(sNameSpan[0]);
                                        StringBuilder Sb = new StringBuilder();
                                        for (int k = 1; k < sNameSpan.Length; k++)
                                        {
                                            Sb.Append(sNameSpan[k]);
                                        }
                                        for (int k = 1; k < sTextNodes.Count; k++)
                                        {
                                            Sb.Append(sTextNodes[k].TextDecoded.Trim());
                                        }
                                        if (FName != null && FName.Length > 0)
                                        {
                                            pDic[FName + "_" + sName] = Sb.ToString();
                                        }
                                        else
                                        {
                                            pDic[sName] = Sb.ToString();
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else if (ResultMode == 1)
                    {
                        string  sValue = sHtmlNode.TextDecoded.Trim();
                        if (  sValue.Length > 0)
                        {
                            pDic[FName] = sValue;
                        }
                    }
                }
            }
        }
        public TezhenRule Clone()
        {
            TezhenRule sTezhenRule = new TezhenRule();
            if (Path != null) { sTezhenRule.Path = Path.Clone(); }
            sTezhenRule.FName = FName;
            sTezhenRule.ResultMode = ResultMode;
            sTezhenRule.Script = Script;
            sTezhenRule.Spliter = Spliter;
            return sTezhenRule;
        }
    }
    [Serializable]
    public class TagKey
    {
        public string TagName;      //标签名
        public string TzKey;        //确认特征值，如果为空则表示不交验

        public TagKey()
        {
        }
        public TagKey(string pTagName, string pTzKey)
        {
            TagName = pTagName;
            TzKey = pTzKey;
        }

        public TagKey Clone()
        {
            TagKey sTagKey = new TagKey();
            sTagKey.TagName=TagName;
            sTagKey.TzKey = TzKey;
            return sTagKey;
        }
    }
}
