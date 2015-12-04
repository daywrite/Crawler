using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Service.Crawl
{
    public class OpenPlot
    {
        private object mLocker = new object();
        public PlotWaterLine Line = new PlotWaterLine();//专案生产线
        public List<PlotWaterLine> Lines = new List<PlotWaterLine>();                  //专案生产线  
        public string FileName;                                                        //专案存储的文件
        private Dictionary<int, PlotWaterLine> mLineDic = new Dictionary<int, PlotWaterLine>();  //生产线字典
        public CrawlTask GetCrawlTask()
        {
            CrawlTask crawlTask=Line.GetCrawlTask();

            return crawlTask;
        }

        #region 生产线相关操作
        /// <summary>
        /// 创建新的生产线
        /// </summary>
        /// <param name="pIsFileLine"></param>
        /// <returns></returns>
        public PlotWaterLine CreateWaterLine(bool pIsFileLine, string pBaseName)
        {
            lock (mLocker)
            {
                PlotWaterLine sPlotWaterLine = new PlotWaterLine();
                sPlotWaterLine.Plot = this;
                sPlotWaterLine.ID = GetLineID();
                sPlotWaterLine.InitWaterLine();
                sPlotWaterLine.IsFileLine = pIsFileLine;
                sPlotWaterLine.Name = GetNewLineName(pBaseName);
                Lines.Add(sPlotWaterLine);
                mLineDic[sPlotWaterLine.ID] = sPlotWaterLine;
                return sPlotWaterLine;
            }
        }
        /// <summary>
        /// 获取新的生产线标识
        /// </summary>
        /// <returns></returns>
        private int GetLineID()
        {
            lock (mLocker)
            {
                int sId = 1;
                for (int i = 0; i < Lines.Count; i++)
                {
                    if (Lines[i].ID >= sId)
                    {
                        sId++;
                    }
                }
                return sId;
            }
        }

        /// <summary>
        /// 获取新的生产线名称
        /// </summary>
        /// <returns></returns>
        internal string GetNewLineName(string pNewBaseName)
        {
            lock (mLocker)
            {
                bool sIsRepeat;
                int x = 0;
                string sBaseName;
                if (pNewBaseName == null || pNewBaseName.Length == 0) { sBaseName = "生产线"; } else { sBaseName = pNewBaseName; }
                //名称重复Bug  tjz-2015-3-10
                string sName;
                do
                {
                    x++;
                    sName = sBaseName + x.ToString();
                    sIsRepeat = false;     //假设不重复
                    for (int j = 0; j < Lines.Count; j++)
                    {
                        if (Lines[j].Name == sName) { sIsRepeat = true; break; } //验证重复
                    }
                }
                while (sIsRepeat); //如果重复
                return sName;
            }
        }
        #endregion
    }
}
