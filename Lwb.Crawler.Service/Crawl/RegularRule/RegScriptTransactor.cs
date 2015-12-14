using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Lwb.Crawler.Service.Crawl
{
    public class RegScriptTransactor
    {
        private static Regex mRegexScript = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
        private static Regex mRegexHtml = new Regex("(?:<[^<]*>)", RegexOptions.IgnoreCase);
        private string mOriHtml;
        private Dictionary<string, int> mGroupTagDic = new Dictionary<string, int>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOriStr"></param>
        public RegScriptTransactor(string pOriStr)
        {
            mOriHtml = pOriStr;
        }
        /// <summary>
        /// 获取记录区Html片段
        /// </summary>
        /// <param name="pRule"></param>
        /// <returns></returns>
        public string[] GetRecordHtmls(DrillRegularRule pRule)
        {
            if (pRule.DrillType == 2)
            {
                string sRegionHtml = GetRegion(pRule.StartTag, pRule.EndTag);
                if (sRegionHtml != null && sRegionHtml.Length > 0)
                {
                    if (pRule.Splitter.Length > 0)
                    {
                        return sRegionHtml.Split(new string[] { pRule.Splitter }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        return new string[] { sRegionHtml };
                    }
                }
            }
            return null;   //不符合要求
        }
        /// <summary>
        /// 执行字段提取
        /// </summary>
        /// <param name="pFeildRule"></param>
        /// <returns></returns>
        public string Exe(RegularFeildRule pFeildRule)
        {
            int sStart = 0;
            if (pFeildRule.GroupTag != null && pFeildRule.GroupTag.Length > 0)
            {
                if (mGroupTagDic.TryGetValue(pFeildRule.GroupTag, out sStart) == false)
                {
                    sStart = mOriHtml.IndexOf(pFeildRule.GroupTag, 0, StringComparison.OrdinalIgnoreCase);
                    mGroupTagDic[pFeildRule.GroupTag] = sStart;
                }
            }
            if (sStart < 0) { return ""; }    //组标记未找到，该组数据自动丧失
            int sEnd = mOriHtml.Length;
            if (pFeildRule.GroupEndTag != null && pFeildRule.GroupEndTag.Length > 0)
            {
                int sTmpEnd = mOriHtml.IndexOf(pFeildRule.GroupEndTag, sStart + (pFeildRule.GroupEndTag == null ? 0 : pFeildRule.GroupEndTag.Length), StringComparison.OrdinalIgnoreCase);
                if (sTmpEnd > 0) { sEnd = sTmpEnd; }
            }
            StringBuilder sSb = new StringBuilder();
            if (pFeildRule.Repeatable)
            {
                sStart = Exe(sStart, pFeildRule, sSb, sEnd);
                while (sStart > 0)
                {
                    sSb.Append("\n");
                    sStart = Exe(sStart, pFeildRule, sSb, sEnd);
                }
            }
            else
            {
                Exe(sStart, pFeildRule, sSb, sEnd);
            }
            return sSb.ToString();
        }

        /// <summary>
        /// 哈尔滨修改--通配符--过滤通配符(*)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<string> ExeStringList(string s)
        {
            List<string> list = new List<string>();
            bool b = true;
            int iListIndex = 0;
            int iIndex = 0;
            while (b)
            {
                iIndex = s.IndexOf("(*)", iListIndex, s.Length - iListIndex, StringComparison.OrdinalIgnoreCase);
                if (iIndex == -1)
                {
                    b = false;
                    iIndex = s.Length;
                }
                if (s.Substring(iListIndex, iIndex - iListIndex) != "")
                    list.Add(s.Substring(iListIndex, iIndex - iListIndex));
                iListIndex = iIndex + 3;
            }

            return list;
        }

        public int Exe(int pStart, RegularFeildRule pFeildRule, StringBuilder pSb, int pEnd)
        {
            int x = pStart;
            int y = pEnd;

            #region 哈尔滨修改--通配符--修改前
            //if (pFeildRule.StartTag != null && pFeildRule.StartTag.Length > 0)
            //{
            //    x = mOriHtml.IndexOf(pFeildRule.StartTag, pStart, pEnd - pStart, StringComparison.OrdinalIgnoreCase);
            //}
            //if (x >= pStart)
            //{
            //    x = x + (pFeildRule.StartTag == null ? 0 : pFeildRule.StartTag.Length);
            //    if (pFeildRule.EndTag != null && pFeildRule.EndTag.Length > 0)
            //    {
            //        y = mOriHtml.IndexOf(pFeildRule.EndTag, x, pEnd - x, StringComparison.OrdinalIgnoreCase);
            //    }
            //}
            #endregion

            #region 哈尔滨修改--通配符--修改后
            if (pFeildRule.StartTag != null && pFeildRule.StartTag.Length > 0)
            {
                List<string> list = new List<string>();
                list = ExeStringList(pFeildRule.StartTag);
                int xIndex = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    x = mOriHtml.IndexOf(list[i], x, pEnd - x, StringComparison.OrdinalIgnoreCase);
                    if (x != -1)
                        x += list[i].Length;
                    if (i == 0)
                    {
                        if (x == -1)
                            break;
                        else
                            xIndex = x;
                    }
                    else
                    {
                        if (x == -1)
                        {
                            i = -1;
                            x = xIndex;
                        }
                    }
                }
            }
            if (x >= pStart)
            {
                if (pFeildRule.EndTag != null && pFeildRule.EndTag.Length > 0)
                {
                    List<string> list = new List<string>();
                    list = ExeStringList(pFeildRule.EndTag);
                    int yIndex = 0;
                    y = x;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i != 0)
                            y += list[i - 1].Length;
                        y = mOriHtml.IndexOf(list[i], y, pEnd - y, StringComparison.OrdinalIgnoreCase);

                        if (i == 0)
                        {
                            if (y == -1)
                                break;
                            else
                                yIndex = y;
                        }
                        else
                        {
                            if (y == -1)
                            {
                                i = -1;
                                y = yIndex + list[0].Length;
                            }
                        }
                    }
                }
            }
            #endregion


            if (x >= pStart && y > x)
            {
                string s = mOriHtml.Substring(x, y - x);  //取得原始资料
                if (pFeildRule.ClearHtml)
                {
                    s = mRegexScript.Replace(s, "");       //清除脚本
                    s = mRegexHtml.Replace(s, "");         //清除Html标签
                }
                if (pFeildRule.ReplacePairs != null && pFeildRule.ReplacePairs.Length > 0)
                {
                    for (int i = 0; i < pFeildRule.ReplacePairs.Length; i++)
                    {
                        string[] sSpan = pFeildRule.ReplacePairs[i].Split('\t');
                        if (sSpan.Length > 1)
                        {
                            s = s.Replace(sSpan[0], sSpan[1]);
                        }
                        else
                        {
                            s = s.Replace(sSpan[0], "");
                        }
                    }
                }
                s = WebUtility.HtmlDecode(s);
                if (pFeildRule.RemoveWhiteSpace)
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        char c = s[i];
                        if (c == 12288)
                        {
                            c = (char)32;
                        }
                        else if (c > 65280 && c < 65375)
                        {
                            c = (char)(c - 65248);
                        }
                        if (!char.IsWhiteSpace(c))
                        {
                            pSb.Append(c);
                        }
                    }
                }
                else
                {
                    pSb.Append(s.Trim());
                }
                return y + (pFeildRule.EndTag == null ? 0 : pFeildRule.EndTag.Length);
            }
            return -1;   //不符合要求
        }
        /// <summary>
        /// 构造为Html完整的数据
        /// </summary>
        /// <param name="pRule"></param>
        /// <returns></returns>
        public string[] GetUrls(DrillRegularRule pRule, string pSourceUrl)
        {
            if (pRule.DrillType == 0)
            {
                string sRegionHtml = GetRegion(pRule.StartTag, pRule.EndTag);
                if (sRegionHtml != null && sRegionHtml.Length > 0)
                {
                    string sDomain;
                    string sUrlBase = GetUrlBase(pSourceUrl, out sDomain);
                    string[] sUrlList;
                    if (pRule.FeatureType == 0)
                    {
                        sUrlList = GetLinks(sRegionHtml, sDomain, sUrlBase);
                    }
                    else
                    {
                        sUrlList = GetImgs(sRegionHtml, sDomain, sUrlBase);
                    }
                    if (pRule.Feature != null && pRule.Feature.Length > 0)
                    {
                        List<string> sList = new List<string>();
                        for (int i = 0; i < sUrlList.Length; i++)
                        {
                            if (sUrlList[i].IndexOf(pRule.Feature, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                sList.Add(sUrlList[i]);
                            }
                        }
                        return sList.ToArray();
                    }
                    return sUrlList;
                }
            }
            return null;
        }

        #region 内部函数
        /// <summary>
        /// 获取有效区段
        /// </summary>
        /// <param name="pStartTag"></param>
        /// <param name="pEndTag"></param>
        /// <returns></returns>
        public string GetRegion(string pStartTag, string pEndTag)
        {
            int x = 0;
            int y = mOriHtml.Length;
            if (pStartTag != null && pStartTag.Length > 0)
            {
                x = mOriHtml.IndexOf(pStartTag, StringComparison.OrdinalIgnoreCase);
            }
            if (x >= 0 && pEndTag != null && pEndTag.Length > 0)
            {
                y = mOriHtml.IndexOf(pEndTag, x + (pStartTag == null ? 0 : pStartTag.Length), StringComparison.OrdinalIgnoreCase);
            }
            if (x >= 0 && y > x)
            {
                return mOriHtml.Substring(x, y - x);
            }
            return "";
        }
        /// <summary>
        /// 解析URL基地址
        /// </summary>
        /// <param name="pSourceUrl"></param>
        /// <param name="pDomain"></param>
        /// <returns></returns>
        public string GetUrlBase(string pSourceUrl, out string pDomain)
        {
            string sUrlBase = pSourceUrl;
            string sDomain = pSourceUrl;
            if (pSourceUrl.Length > 7)
            {
                int k = pSourceUrl.IndexOf('?', 7);
                if (k > 8)
                {
                    k = pSourceUrl.LastIndexOf('/', k - 1, k - 8);
                    if (k > 8)
                    {
                        sUrlBase = pSourceUrl.Substring(0, k);
                        k = pSourceUrl.IndexOf('/', 7);
                        sDomain = pSourceUrl.Substring(0, k);
                    }
                }
                else
                {
                    k = pSourceUrl.LastIndexOf('/');
                    if (k > 7)
                    {
                        sUrlBase = pSourceUrl.Substring(0, k);
                        k = pSourceUrl.IndexOf('/', 7);
                        sDomain = pSourceUrl.Substring(0, k);
                    }
                }
            }
            pDomain = sDomain;
            return sUrlBase;
        }
        /// <summary>
        /// 获取链接集合
        /// </summary>
        /// <param name="pReferUrl"></param>
        /// <returns></returns>
        public string[] GetLinks(string pRegionHtml, string pHost, string pUrlBase)
        {
            Dictionary<string, string> sLabelDic = new Dictionary<string, string>();
            int x = pRegionHtml.IndexOf("<a ", StringComparison.OrdinalIgnoreCase);
            while (x >= 0)
            {
                string sDat;
                int y = GetLabelEnd(pRegionHtml, out sDat, x + 2, "href");
                if (sDat != null && sDat.Length > 0)
                {
                    sLabelDic[sDat.ToLower()] = sDat;
                }
                x = pRegionHtml.IndexOf("<a ", y, StringComparison.OrdinalIgnoreCase);
            }
            List<string> sUrlList = new List<string>(sLabelDic.Count);
            foreach (KeyValuePair<string, string> sKp in sLabelDic)
            {
                string sHref = GetAbsoluteUrl(sKp.Value, pHost, pUrlBase);
                if (sHref != null && sHref.Length > 7)
                {
                    sUrlList.Add(sHref);
                }
            }
            return sUrlList.ToArray();
        }
        /// <summary>
        /// 获取链接集合
        /// </summary>
        /// <param name="pReferUrl"></param>
        /// <returns></returns>
        public string[] GetImgs(string pRegionHtml, string pHost, string pUrlBase)
        {
            Dictionary<string, string> sLabelDic = new Dictionary<string, string>();
            int x = pRegionHtml.IndexOf("<img ", StringComparison.OrdinalIgnoreCase);
            while (x >= 0)
            {
                string sDat;
                int y = GetLabelEnd(pRegionHtml, out sDat, x + 4, "src");
                if (sDat != null && sDat.Length > 0)
                {
                    sLabelDic[sDat.ToLower()] = sDat;
                }
                x = pRegionHtml.IndexOf("<img ", y, StringComparison.OrdinalIgnoreCase);
            }
            List<string> sUrlList = new List<string>(sLabelDic.Count);
            foreach (KeyValuePair<string, string> sKp in sLabelDic)
            {
                string sUrl = GetAbsoluteUrl(sKp.Value, pHost, pUrlBase);
                if (sUrl != null && sUrl.Length > 7)
                {
                    sUrlList.Add(sUrl);
                }
            }
            return sUrlList.ToArray();
        }

        /// <summary>
        /// 获取一个Html标签的结束符位置
        /// </summary>
        /// <param name="pStart"></param>
        /// <returns></returns>
        public int GetLabelEnd(string pRegionHtml, out string pDat, int pStart, string pPropertyName)
        {
            pDat = null;
            int sP1 = pStart;
            for (int i = pStart; i < pRegionHtml.Length; i++)
            {
                if (pRegionHtml[i] == ' ')
                {
                    sP1 = i;
                }
                else if (pRegionHtml[i] == '=' && i > sP1 + 1 && pRegionHtml.Length > i + 1)
                {
                    string sName = pRegionHtml.Substring(sP1 + 1, i - sP1 - 1);
                    sP1 = i + 1;
                    if (pRegionHtml[sP1] == '\'')
                    {
                        i = FindMach(pRegionHtml, sP1, '\'');
                    }
                    else if (pRegionHtml[sP1] == '\"')
                    {
                        i = FindMach(pRegionHtml, sP1, '\"');
                    }
                    else
                    {
                        i = FindMach(pRegionHtml, sP1, ' ');
                    }
                    if (i > sP1)
                    {
                        if (sName.Equals(pPropertyName, StringComparison.OrdinalIgnoreCase))
                        {
                            pDat = pRegionHtml.Substring(sP1, i - sP1).Trim(new char[] { ' ', '\'', '\"', '\t', '\n', '\r', '　' });
                        }
                        sP1 = i;
                    }
                }
                if (pRegionHtml[i] == '>')
                {
                    return i;
                }
            }
            return pRegionHtml.Length - 1;
        }
        /// <summary>
        /// 查找匹配字符,作为一个标签
        /// </summary>
        public int FindMach(string pRegionHtml, int pStart, char pChr)
        {
            int sX = 0;
            for (int i = pStart + 1; i < pRegionHtml.Length; i++)
            {
                if (pRegionHtml[i] == pChr)
                {
                    return i;
                }
                else if (char.IsWhiteSpace(pRegionHtml[i]))
                {
                    sX = i;
                }
                else if (pRegionHtml[i] == '=')
                {
                    if (sX > 0)
                    {
                        return sX;
                    }
                }
                else if (pRegionHtml[i] == '>' || pRegionHtml[i] == '<')
                {
                    return i;
                }
            }
            return pStart;
        }
        #endregion

        /// <summary>
        /// 生成绝对化链接
        /// </summary>
        /// <param name="pUrl"></param>
        /// <returns></returns>
        public string GetAbsoluteUrl(string pUrl, string pHost, string pUrlBase)
        {
            string sUrl = pUrl;
            if (sUrl != null && sUrl.Length > 0 && (sUrl.Length < 8 || (sUrl.Substring(0, 7).Equals("http://", StringComparison.OrdinalIgnoreCase) == false && sUrl.Substring(0, 8).Equals("https://", StringComparison.OrdinalIgnoreCase) == false)))
            {
                if (sUrl[0] == '/')
                {
                    return pHost + sUrl;
                }
                else
                {
                    string sUrlBase = pUrlBase;
                    sUrl = sUrl.Replace(".../", "../");
                    while (sUrl.IndexOf("../") == 0)
                    {
                        sUrl = sUrl.Substring(3).Trim();
                        if (sUrlBase.Length > pHost.Length)
                        {
                            int x = sUrlBase.LastIndexOf('/');
                            sUrlBase = sUrlBase.Substring(0, x);
                        }
                    }
                    return sUrlBase + "/" + sUrl;
                }
            }
            return sUrl;
        }

        /// <summary>
        /// 记录区-判断规则是否完备
        /// </summary>
        /// <param name="pDrillRule"></param>
        /// <returns></returns>
        public bool CanExe(DrillRegularRule pDrillRule)
        {
            if (pDrillRule.ConditionType == 0)
            {
                return true;
            }
            else if (pDrillRule.ConditionType == 1)
            {
                if (pDrillRule.ConditionTag == null || pDrillRule.ConditionTag.Length == 0 || mOriHtml.IndexOf(pDrillRule.ConditionTag, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            else if (pDrillRule.ConditionType == 2)
            {
                if (pDrillRule.ConditionTag != null && pDrillRule.ConditionTag.Length > 0 && mOriHtml.IndexOf(pDrillRule.ConditionTag, StringComparison.OrdinalIgnoreCase) == -1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
