using System;
using System.Collections.Generic;
using System.Text;
using Haina.Base;
using Haina.Html;
using Haina.Common;
using System.IO;
using System.IO.Compression;
using Haina.Base.Html;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Haina.Crawl.OpenCase.Meta
{
    public class CrawlOriData
    {
        private static Dictionary<string, byte> mDataTypeDic = new Dictionary<string, byte>();
        private static Dictionary<string, byte> mCompressDataDic = new Dictionary<string, byte>();
        /// <summary>
        /// 构造函数
        /// </summary>
        static CrawlOriData()
        {
            mDataTypeDic["jpg"] = 1;
            mDataTypeDic["png"] = 2;
            mDataTypeDic["bmp"] = 3;
            mDataTypeDic["gif"] = 4;
            mDataTypeDic["html"] = 5;
            mDataTypeDic["xml"] = 6;
            mDataTypeDic["js"] = 7;
            mDataTypeDic["css"] = 8;
            mDataTypeDic["mp3"] = 9;
            mDataTypeDic["mp4"] = 10;
            mDataTypeDic["mpg"] = 11;
            mDataTypeDic["flv"] = 12;
            mDataTypeDic["zip"] = 13;
            mDataTypeDic["rar"] = 14;
            mDataTypeDic["doc"] = 15;
            mDataTypeDic["docx"] = 16;
            mDataTypeDic["xsl"] = 17;
            mDataTypeDic["xslx"] = 18;
            mDataTypeDic["ppt"] = 19;
            mDataTypeDic["pptx"] = 20;
            mDataTypeDic["txt"] = 21;
            mDataTypeDic["javascript"] = 7;

            mCompressDataDic["html"] = 5;
            mCompressDataDic["xml"] = 6;
            mCompressDataDic["js"] = 7;
            mCompressDataDic["css"] = 8;
            mCompressDataDic["doc"] = 15;
            mCompressDataDic["xsl"] = 17;
            mCompressDataDic["txt"] = 21;
            mCompressDataDic["javascript"] = 7;
        }
        public string Host;
        public Int128 Key;
        public string Title;
        public string Url;
        public string Ext;
        public string Data;
        public DateTime Dt;
        public int ID;
        public byte DataType;
        public byte Chaset;
        public byte State;

        public bool CanCompress
        {
            get
            {
                return Data != null && Data.Length > 4096 && mCompressDataDic.ContainsKey(Ext);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CrawlOriData()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pTaskDetail"></param>
        /// <param name="pResultDetail"></param>
        public CrawlOriData(CrawlTaskDetail pTaskDetail, CrawlResultDetail pResultDetail, byte pChaset)
        {
            Host = pTaskDetail.Host;
            Title = pTaskDetail.Title;
            Url = pTaskDetail.Url;
            Ext = pResultDetail.Ext;
            Data = pResultDetail.Content;
            Dt = DateTime.Now;
            if (Ext == null) { Ext = "html"; }

            mDataTypeDic.TryGetValue(Ext, out DataType);

            Key = pTaskDetail.Key;
            Chaset = pChaset;
        }

        //public CrawlOriData(DownloadTaskDeail pTaskDetail, CrawlResultDetail pResultDetail)
        //{
        //    Host = pTaskDetail.Host;
        //    Title = pTaskDetail.Title;
        //    Url = pTaskDetail.Url;
        //    Ext = pResultDetail.Ext;
        //    Data = pResultDetail.Data;
        //    Dt = DateTime.Now;
        //    if (Ext == null) { Ext = "html"; }
        //    mDataTypeDic.TryGetValue(Ext, out DataType);
        //    Key = pTaskDetail.ID;
        //}

        //internal CImage GetCImage(int pMetaID)
        //{
        //    CImage sCImage = new CImage();
        //    sCImage.CreateDt = Dt;
        //    sCImage.Data = Data;
        //    sCImage.Ext = Ext;
        //    sCImage.Length = Data.Length;
        //    sCImage.MetaID = pMetaID;
        //    return sCImage;
        //}

        //internal CObject GetCObject(int pMetaID)
        //{
        //    CObject sCObject = new CObject();
        //    sCObject.CreateDt = Dt;
        //    sCObject.Data = Data;
        //    sCObject.Ext = Ext;
        //    sCObject.Length = (int)Data.Length;
        //    sCObject.Title = Title;
        //    sCObject.MetaID = pMetaID;
        //    return sCObject;
        //}

        /// <summary>
        /// 获取元数据
        /// </summary>
        /// <returns></returns>
        internal byte[] GetMeta()
        {
            StringBuilder sSb = new StringBuilder();
            sSb.AppendLine(Title == null ? "" : Title.Replace("\n", "").Replace("\r", ""));
            sSb.AppendLine(Url == null ? "" : Url.Replace("\n", "").Replace("\r", ""));
            sSb.AppendLine(Ext == null ? "" : Ext.Replace("\n", "").Replace("\r", ""));
            sSb.AppendLine(Host == null ? "" : Host.Replace("\n", "").Replace("\r", ""));
            return Encoding.UTF8.GetBytes(sSb.ToString());
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="pDat"></param>
        internal void Load(byte[] pDat)
        {
            string[] sData = Encoding.UTF8.GetString(pDat).Split('\n');
            Title = sData[0].Trim();
            Url = sData[1].Trim();
            Ext = sData[2].Trim();
            Host = sData[3].Trim();
        }
        /// <summary>
        /// URl基础
        /// </summary>
        public string UrlBase
        {
            get
            {
                int k = Url.Split('?')[0].LastIndexOf('/');
                if (k >= -1)
                {
                    return Url.Substring(0, k) + "/";
                }
                return Url + "/";
            }
        }

        //internal HtmlTree CreateHtmlTree(string pCleanRule)
        //{
        //    string sHtml = Encoding.GetEncoding(Chaset == 0 ? "utf-8" : "gb18030").GetString(Data);
        //    return new HtmlTree(sHtml, UrlBase + "/", pCleanRule);
        //}


    }
}
