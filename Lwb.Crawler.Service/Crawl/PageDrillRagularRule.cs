using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Lwb.Crawler.Service.Crawl
{
    [Serializable]
    public class PageDrillRagularRule : DrillRegularRule
    {
        public string Url;
        public string Chaset;

        /// <summary>
        /// 打开专案文件
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PageDrillRagularRule Open(string pFileName)
        {
            try
            {
                using (StreamReader sReader = new StreamReader(pFileName,Encoding.UTF8))
                {
                    XmlSerializer sXmlSerializer = new XmlSerializer(typeof(PageDrillRagularRule));
                    PageDrillRagularRule sPlot = (PageDrillRagularRule)sXmlSerializer.Deserialize(sReader);
                    return sPlot;
                }
            }
            catch (Exception E)
            {
                return null;
            }
        }
        /// <summary>
        /// 另存为
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pPlot"></param>
        /// <returns></returns>
        public static bool SaveAs(string pFileName, PageDrillRagularRule pPlot)
        {
            try
            {
                using (StreamWriter  sWriter = new  StreamWriter(pFileName,false,Encoding.UTF8 ))
                {
                    XmlSerializer sXmlSerializer = new XmlSerializer(typeof(PageDrillRagularRule));
                    sXmlSerializer.Serialize(sWriter, pPlot);
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public DrillRegularRule ToDrillRegularRule()
        {
            DrillRegularRule sDrillRegularRule = new DrillRegularRule();
            sDrillRegularRule.DbID=DbID;
            sDrillRegularRule.DbName=DbName;
            sDrillRegularRule.DrillType=DrillType;
            sDrillRegularRule.EndTag=EndTag;
            sDrillRegularRule.Feature=Feature;
            sDrillRegularRule.FeatureType=FeatureType;
            sDrillRegularRule.Feilds=Feilds;
            sDrillRegularRule.MetaModalID=MetaModalID;
            sDrillRegularRule.Name=Name;
            sDrillRegularRule.Splitter=Splitter;
            sDrillRegularRule.StartTag = StartTag;
            return sDrillRegularRule;
        }
    }
}
