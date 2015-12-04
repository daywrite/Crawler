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
        public static string Root { get; set; }//根目录
        public static string CaseRoot { get; set; }//专案目录


        public static OpenPlot openPlot = new OpenPlot();

        public static bool InitServer(string root)
        {
            Root = root;

            CaseRoot = Root + "\\Cases";
            DirFileHelper.CreateDirectory(CaseRoot);

            return false;
        }
        internal static List<CrawlTask> GetCrawlTasks()
        {
            List<CrawlTask> sList = new List<CrawlTask>();


            CrawlTask crawlTask = openPlot.GetCrawlTask();
            if (crawlTask != null)
            {
                sList.Add(crawlTask);
            }
            
            return sList;
        }
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
    }
}
