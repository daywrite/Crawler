using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;
using DotNet.Utilities;
using System.IO;
using System.Xml.Serialization;
using Haina.Base;
namespace Lwb.Crawler.Service.Crawl
{
    public class CrawlServer
    {
        private static object mLocker = new object();
        private static int mStartPos;
        public static string Root { get; set; }//根目录
        public static string CaseRoot { get; set; }//专案目录


        public static OpenPlot openPlot = new OpenPlot();
        public static List<OpenPlot> PlotList = new List<OpenPlot>();
        private static Dictionary<Int128, OpenPlot> mPlotPool = new Dictionary<Int128, OpenPlot>();
        public static bool InitServer(string root)
        {
            Root = root;

            CaseRoot = Root + "\\Cases";
            DirFileHelper.CreateDirectory(CaseRoot);

            return false;
        }
        internal static List<CrawlTask> GetCrawlTasks(Dictionary<string, string> pHostDic, uint pIp, int pMax)
        {
            List<CrawlTask> sList = new List<CrawlTask>();
            CrawlTask sCrawlTask;
            for (int i = 2; i >= 0; i--)
            {
                OpenPlot sOpenPlot;
                int sStartPos = mStartPos;
                for (int j = sStartPos; j < PlotList.Count; j++)
                {
                    try { sOpenPlot = PlotList[j]; }
                    catch { break; }      //防止mPlotList的变化，导致出错
                    sCrawlTask = sOpenPlot.GetCrawlTask(i, pHostDic, pIp);
                    if (sCrawlTask != null)
                    {
                        sList.Add(sCrawlTask);
                        if (sList.Count >= pMax)
                        {
                            if (j + 1 < PlotList.Count)
                            {
                                mStartPos = j + 1;
                            }
                            else
                            {
                                mStartPos = 0;
                            }
                            return sList;
                        }
                    }
                }
                for (int j = 0; j < sStartPos; j++)
                {
                    try { sOpenPlot = PlotList[j]; }
                    catch { break; }       //防止mPlotList的变化，导致出错
                    sCrawlTask = sOpenPlot.GetCrawlTask(i, pHostDic, pIp);
                    if (sCrawlTask != null)
                    {
                        sList.Add(sCrawlTask);
                        if (sList.Count >= pMax)
                        {
                            mStartPos = j + 1;
                            return sList;
                        }
                    }
                }
            }

            return sList;
        }

        internal static void ReceiveCrawlResult(CrawlResult pCrawlResult)
        {
            OpenPlot sOpenPlot;
            lock (mLocker)
            {
                if (mPlotPool.TryGetValue(pCrawlResult.PlotKey, out sOpenPlot) == false)
                {
                    return;
                }
            }
            sOpenPlot.RecieveCrawlResult(pCrawlResult);
        }

        #region Server-保存专案

        /// <summary>
        /// 保存专案
        /// </summary>
        /// <returns></returns>
        public static bool Save(OpenPlot pPlot)
        {
            return SaveAs(pPlot.FileName, pPlot);
        }
        public static bool SaveAs(string pFileName, OpenPlot pPlot)
        {
            try
            {
                using (FileStream sFileStream = new FileStream(pFileName, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    MemoryStream sMemoryStream = new MemoryStream();
                    StreamWriter sStream = new StreamWriter(sMemoryStream, Encoding.UTF8);
                    XmlSerializer sXmlSerializer = new XmlSerializer(typeof(OpenPlot));
                    sXmlSerializer.Serialize(sStream, pPlot);
                    byte[] sData = SecurityProvider.ZipEncrypt(sMemoryStream.ToArray());
                    sFileStream.WriteByte(2);
                    sFileStream.Write(sData, 0, sData.Length);
                    pPlot.FileName = pFileName.ToLower();
                }
                return true;
            }
            catch (Exception E)
            {
                //MessageBox.Show(E.Message);
                return false;
            }
        }

        /// <summary>
        /// 将专案添加到专案缓冲池子
        /// </summary>
        /// <param name="pPlot"></param>
        public static void AddPlot2Pool(OpenPlot pPlot)
        {
            lock (mLocker)
            {
                if (pPlot.Key.IsZero) { pPlot.Key = new Int128(Guid.NewGuid().ToByteArray()); }
                OpenPlot sTmpPlot;
                if (mPlotPool.TryGetValue(pPlot.Key, out sTmpPlot) == false)
                {
                    pPlot.Prepare();
                    mPlotPool[pPlot.Key] = pPlot;
                    PlotList.Add(pPlot);
                }
                else if (sTmpPlot != pPlot) //重Key对象
                {
                    pPlot.Key = new Int128(Guid.NewGuid().ToByteArray());
                    pPlot.Prepare();
                    mPlotPool[pPlot.Key] = pPlot;
                    PlotList.Add(pPlot);
                }
            }
        }

        #endregion

        
        /// <summary>
        /// 打开专案文件
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static OpenPlot Open(string pFileName)
        {
            try
            {
                using (FileStream sFileStream = new FileStream(pFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] sData = new byte[sFileStream.Length];
                    sFileStream.Read(sData, 0, sData.Length);
                    if (sData[0] == 2)
                    {
                        byte[] sDat = new byte[sData.Length - 1];
                        Array.Copy(sData, 1, sDat, 0, sDat.Length);
                        sData = SecurityProvider.ZipDecrypt(sDat);  //解密
                    }
                    MemoryStream sReader = new MemoryStream(sData);
                    XmlSerializer sXmlSerializer = new XmlSerializer(typeof(OpenPlot));
                    OpenPlot sPlot = (OpenPlot)sXmlSerializer.Deserialize(sReader);
                    sPlot.FileName = pFileName;
                    return sPlot;
                }
            }
            catch (Exception E)
            {
                return null;
            }
        }
    }
}
