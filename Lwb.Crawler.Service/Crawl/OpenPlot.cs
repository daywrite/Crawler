using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haina.Base;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Service.Crawl
{
    [Serializable]
    public class OpenPlot
    {
        private object mLocker = new object();
        private int mStartPos;
        public Int128 Key;                                              //专案的标识 
        public string Path;										        //专案的存储路径
        public string Name;											    //专案的名字
        public string HomePage;										    //专案站点主页
        public DateTime CreateTime;						                //专案的创建时间
        public string Creator;											//专案创建者
        public string Info;											    //专案简介
        public string Version = "4.0";									//专案版本

        public List<PlotWaterLine> Lines = new List<PlotWaterLine>();                                   //专案生产线  
        public string FileName;                                                                         //专案存储的文件
        private Dictionary<int, PlotWaterLine> mLineDic = new Dictionary<int, PlotWaterLine>();         //生产线字典
        public CrawlTask GetCrawlTask(int pPRI, Dictionary<string, string> pHostDic, uint pIp)
        {
            int sStartPos = mStartPos;        //生产线机会均等
            for (int i = sStartPos; i < Lines.Count; i++)
            {
                try
                {
                    PlotWaterLine sPlotWaterLine = Lines[i];
                    if (sPlotWaterLine.PRI == pPRI)
                    {
                        CrawlTask sCrawlTask = sPlotWaterLine.GetCrawlTask();
                        if (sCrawlTask != null)
                        {
                            if (i + 1 < Lines.Count)
                            {
                                mStartPos = i + 1;
                            }
                            else
                            {
                                mStartPos = 0;
                            }
                            return sCrawlTask;
                        }
                    }
                }
                catch { }
            }
            for (int i = 0; i < sStartPos; i++)
            {
                try
                {
                    PlotWaterLine sPlotWaterLine = Lines[i];
                    if (sPlotWaterLine.PRI == pPRI)
                    {
                        CrawlTask sCrawlTask = sPlotWaterLine.GetCrawlTask();
                        if (sCrawlTask != null)
                        {
                            mStartPos = i + 1;
                            return sCrawlTask;
                        }
                    }
                }
                catch { }
            }
            return null;
        }

        #region 生产线相关操作
        /// <summary>
        /// 创建新的专案
        /// </summary>
        /// <param name="pNo"></param>
        /// <returns></returns>
        public static OpenPlot CreatePlot()
        {
            OpenPlot sPlot = new OpenPlot();
            sPlot.Key = new Int128(Guid.NewGuid().ToByteArray());
            sPlot.CreateTime = DateTime.Now;
            return sPlot;
        }

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
                //sPlotWaterLine.Plot = this;
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

        /// <summary>
        /// 预备工作
        /// </summary>
        internal void Prepare()
        {
            List<PlotWaterLine> sLines = new List<PlotWaterLine>();
            lock (mLocker)
            {
                mLineDic = new Dictionary<int, PlotWaterLine>();
                for (int i = Lines.Count - 1; i >= 0; i--)
                {
                    //Lines[i].Plot = this;                   //关联自身
                    if (mLineDic.ContainsKey(Lines[i].ID))
                    {
                        Lines.RemoveAt(i);                   //若生产线出现ID重复的情况，删除
                    }
                    else
                    {
                        mLineDic[Lines[i].ID] = Lines[i];
                        //将流水线初始化
                        Lines[i].InitWaterLine();
                    }
                }
            }
        }
        #endregion
    }
}
