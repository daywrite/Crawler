using System;
using System.Collections ;
using System.Collections.Generic;
using Haina.Html;
using Haina.Base.Html;

namespace Lwb.Crawler.Service.Crawl
{
	/// <summary>
	/// ����������Ľ����һ����¼�������趨��ԭ����һ��������԰��������Ч�ؼ�¼����
	/// </summary>
    [Serializable]
    public class DrillHtmlRule : DrillBaseRule
	{
        public HtmlSearchRule RegionPath;					     //����������ļ�¼��·��
      
        #region ����������ȡ
        public int FeatureType;                                 //0-HREF,����A�ڵ㣻1-SRC,����IMG
        public string Feature;                                  //ͨ����������ȡ��Ԫ�����ǹ̶�������ģʽ
        public string Classify;                                 //�����ǩ
        public int TitleMinLen = 5;
        #endregion

        #region ȫ����ȡ����
        public string[] StartTag;                               //��ʼ����
        public string[] EndTag;                                 //��ֹ����
        #endregion

        #region �Զ�����ȡ
        public string Splitter;							                //��¼���ڵķָ���ʽ,��ʽ�� ��ʼ��Ч��ǩ��:�ָ��ǩ��:��ǩ���:��ֹ��Ч��ǩ��
        public FeildCollection Feilds =new FeildCollection();           //��¼����ÿһѭ����¼��Ԫ������ȡ����
        public List<TezhenRule> TezhenRules = new List<TezhenRule>();   //������ȡ����
        #endregion
        /// <summary>
        /// ��ȡ�ֶ�ID
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
        /// ���캯��,��������ģ������
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
            for(int i=0;i<TezhenRules.Count;i++)
            {
                sDrillRule.TezhenRules.Add(TezhenRules[i].Clone());
            }
            return sDrillRule;
        }
    }
}
