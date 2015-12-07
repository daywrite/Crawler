using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using Haina.Common;
using Haina.Base;
using Lwb.Crawler.Service.Crawl;


namespace Haina.Crawl.OpenCase.Meta
{
    /// <summary>
    /// Parameter 的摘要说明。
    /// </summary>
    [Serializable]
    public class Parameter
    {
        public string Name;							      //参数名
        public string Value;							  //参数默认值
        public string Byname;							  //参数别名
        public ParameterType Type = ParameterType.Fixed;  //参数的类型
        public List<ParaRefer> ParaRefers=new List<ParaRefer>();

        internal string[] GetParaReferSource()
        {
            if (ParaRefers != null && ParaRefers.Count>0)
            {
                string[] sData = new string[ParaRefers.Count];
                for (int i = 0; i < ParaRefers.Count; i++)
                {
                    sData[i] = ParaRefers[i].Value;
                }
                return sData;
            }
            return null;
        }
        /// <summary>
        /// 专门用于BaseUrl拼装
        /// </summary>
        public int Begin
        {
            get
            {
                int sValue;
                if (Name != null && Name.StartsWith("var:") && int.TryParse(Name.Substring(4).Split('-')[0], out sValue))
                {
                    return sValue;
                }
                return -1;
            }
        }
        /// <summary>
        /// 专门用于BaseUrl拼装
        /// </summary>
        public int End
        {
            get
            {
                int sValue;
                if (Name != null && Name.StartsWith("var:"))
                {
                    string[] sSpans = Name.Substring(4).Split('-');
                    if (sSpans.Length == 2 && int.TryParse(sSpans[1], out sValue))
                    {
                        return sValue;
                    }
                }
                return -1;
            }
        }
   
        /// <summary>
        /// 构造函数
        /// </summary>
        public Parameter()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pNameValue">参数名值对</param>
        public Parameter(string pNameValue)
        {
            int k = pNameValue.IndexOf('=');
            if (k > 0)
            {
                Name = pNameValue.Substring(0, k);
                if (k < pNameValue.Length - 1)
                {
                    Value = pNameValue.Substring(k + 1);
                }
            }
            else
            {
                Name = pNameValue;
                Type = ParameterType.NoValue;
            }
        }
        /// <summary>
        /// 构造函数，如果pValue==null，则该参数默认视为无值参数
        /// </summary>
        /// <param name="pName">参数名</param>
        /// <param name="pValue">参数值</param>
        public Parameter(string pName, string pValue)
        {
            Name = pName;
            if (Value != null)
            {
                Value = pValue;
            }
            else
            {
                Type = ParameterType.NoValue;
            }
        }
        /// <summary>
        /// 获取可选值数组
        /// </summary>
        /// <returns></returns>
        public string[] GetReferDataQArray()
        {
            if ( ParaRefers!=null)
            {
                string[] mStrs = new string[ ParaRefers.Count];
                for (int i = 0; i <  ParaRefers.Count; i++)
                {
                    mStrs[i] = ParaRefers[i].Value;
                }
                return mStrs;
            }
            return null;
        }

        /// <summary>
        /// 获得参数的"Name=Value"的表达式
        /// </summary>
        /// <returns></returns>
        public string ToNameValue()
        {
            if (Name != "")
            {
                if (Type == ParameterType.NoValue)
                {
                    return Name;
                }
                else
                {
                    return Name + "=" + Value;
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 设置参数的类型
        /// </summary>
        public void SetType(string pTypeName)
        {
            switch (pTypeName)
            {
                case "NoValue":
                    Type = ParameterType.NoValue;
                    break;
                case "Choice":
                    Type = ParameterType.Choice;
                    break;
                case "Inherit":
                    Type = ParameterType.Inherit;
                    break;
                case "Input":
                    Type = ParameterType.Input;
                    break;
                default:
                    Type = ParameterType.Fixed;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal Parameter Clone()
        {
            Parameter sParameter = new Parameter();
            sParameter.Byname = Byname;
            sParameter.Name = Name;
            sParameter.Type = Type;
            sParameter.Value = Value;
            if (ParaRefers != null)
            {
                for (int i = 0; i < ParaRefers.Count; i++)
                {
                    sParameter.ParaRefers.Add(ParaRefers[i].Clone());
                }
            }
            return sParameter;
        }
    }
    /// <summary>
    /// 参数集合。
    /// </summary>
    [Serializable]
    public class ParameterCollection : List<Parameter>
    {

        public bool Contains(string pName)
        {
            for (int i = 0; i < Count; i++)
            {
                if (base[i].Name != null && pName.Equals(base[i].Name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 通过参数名称获取参数
        /// </summary>
        /// <param name="pByName"></param>
        /// <returns></returns>
        public Parameter GetByName(string pByName)
        {
            if (pByName != null)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (base[i].Byname!=null && pByName.Equals(base[i].Byname, StringComparison.OrdinalIgnoreCase))
                    {
                        return base[i];
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 获取选择参数的可选值列表
        /// </summary>
        /// <param name="pParaName"></param>
        /// <returns></returns>
        internal string[] GetParaReferSource(string pParaName)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Name!=null && this[i].Name.Equals(pParaName, StringComparison.OrdinalIgnoreCase))
                {
                    return this[i].GetParaReferSource();
                }
            }
            return null;
        }
        /// <summary>
        /// 生成基础Url
        /// </summary>
        /// <param name="pCycNode"></param>
        /// <param name="pChaset"></param>
        /// <returns></returns>
        internal string ToBaseUrl(CycNode pCycNode, string pChaset)
        {
            StringBuilder sSb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                Parameter sPara = this[i];
                if (sPara.Type == ParameterType.Input)
                {
                    string sValue = null;
                    if (pCycNode == null || pCycNode.TryGetCurrentValue(sPara.Name, out sValue) == false) { sValue = sPara.Value; }
                    sSb.Append(CommonService.GetEncodeUrl(sValue, pChaset));
                }
                else
                {
                    sSb.Append(sPara.Value);
                }
            }
            return sSb.ToString();
        }
        /// <summary>
        /// 生成参数串
        /// </summary>
        /// <param name="pCycNode"></param>
        /// <param name="pChaset"></param>
        /// <returns></returns>
        internal string ToQuery(CycNode pCycNode, string pChaset)
        {
            StringBuilder sSb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (i > 0) { sSb.Append('&'); }
                Parameter sPara = this[i];
                if (sPara.Type == ParameterType.Input || sPara.Type == ParameterType.Choice)
                {
                    string sValue;
                    if (pCycNode == null || pCycNode.TryGetCurrentValue(sPara.Name, out sValue) == false) { sValue = sPara.Value; }
                    sSb.Append(sPara.Name).Append("=").Append(CommonService.GetEncodeUrl(sValue, pChaset));
                }
                else if (sPara.Type == ParameterType.NoValue)
                {
                    sSb.Append(sPara.Name);
                }
                else
                {
                    sSb.Append(sPara.Name).Append("=").Append(sPara.Value);
                }
            }
            return sSb.ToString();
        }

        internal string ToQuery()
        {
            StringBuilder sSb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (i > 0) { sSb.Append('&'); }
                Parameter sPara = this[i];
                if (sPara.Type == ParameterType.NoValue)
                {
                    sSb.Append(sPara.Name);
                }
                else
                {
                    sSb.Append(sPara.Name).Append("=").Append(sPara.Value);
                }
            }
            return sSb.ToString();
        }

        internal ParameterCollection Clone()
        {
            ParameterCollection sParameterCollection = new ParameterCollection();
            for (int i = 0; i < Count; i++)
            {
                sParameterCollection.Add(this[i].Clone());
            }
            return sParameterCollection;
        }

      
    }
}
