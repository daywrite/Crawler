using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 循环节点
    /// </summary>
    class CycNode
    {
        private ParaSourceRunTime[] mParaSources = null;	  //循环节点的参数参数工作队列
        private Dictionary<string, ParaSourceRunTime> mParaWorkerRunTimeDic = new Dictionary<string, ParaSourceRunTime>();

        private long mTotal;                                  //总数
        private long mCurrent;                                //当前游标，从0开始计数，小于mTotal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParaSources"></param>
        public CycNode(ParaSourceRunTime[] pParaSources)
        {
            mParaSources = pParaSources;
            Reset();
        }
        internal void Reset()
        {
            mParaWorkerRunTimeDic = new Dictionary<string, ParaSourceRunTime>();
            mTotal = 1;
            mCurrent = 0;
            if (mParaSources != null && mParaSources.Length > 0)
            {
                lock (mParaSources)
                {
                    for (int i = 0; i < mParaSources.Length; i++)
                    {
                        ParaSourceRunTime sParaSourceRunTime = mParaSources[i];
                        sParaSourceRunTime.Reset();  //重置

                        if (sParaSourceRunTime.Total > 0)
                        {
                            mTotal = mTotal * sParaSourceRunTime.Total;
                        }
                        if (sParaSourceRunTime.Current > 0)
                        {
                            mCurrent = mCurrent * sParaSourceRunTime.Total + sParaSourceRunTime.Current;
                        }
                        mParaWorkerRunTimeDic[sParaSourceRunTime.Name] = sParaSourceRunTime;
                    }
                }
            }
        }
        /// <summary>
        /// 获取总循环计数,仅指当层循环
        /// </summary>
        /// <returns></returns>
        public long Total
        {
            get
            {
                return mTotal;
            }
        }
        /// <summary>
        /// 获取已完成循环计数
        /// </summary>
        /// <returns></returns>
        public long Current
        {
            get
            {
                return mCurrent;
            }
        }
        /// <summary>
        /// 设置下一轮运行时参数，如果返回false，则表示设置失败
        /// </summary>
        public bool MoveNext()
        {
            if (mParaSources != null)
            {
                lock (mParaSources)
                {
                    for (int i = mParaSources.Length - 1; i >= 0; i--)
                    {
                        if (mParaSources[i].MoveNext())
                        {
                            mCurrent++;
                            for (int j = i + 1; j < mParaSources.Length; j++)
                            {
                                mParaSources[j].Reset();
                            }
                            return true; ;
                        }
                    }
                }
            }
            return false;
        }

        public string ProcessPercent
        {
            get
            {
                if (mTotal > 0)
                {
                    return (mCurrent * 100L / mTotal).ToString() + "%";
                }
                else
                {
                    return "0%";
                }
            }
        }
        /// <summary>
        /// 获取当前值
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        internal string GetCurrentValue(string pName)
        {
            if (mParaSources != null && pName != null && pName.Length > 0)
            {
                lock (mParaSources)
                {
                    ParaSourceRunTime sParaSourceRunTime;
                    if (mParaWorkerRunTimeDic.TryGetValue(pName, out sParaSourceRunTime))
                    {
                        return sParaSourceRunTime.GetCurrentValue();
                    }
                }
            }
            return null;
        }

        internal bool TryGetCurrentValue(string pName, out string pValue)
        {
            if (mParaSources != null && pName != null && pName.Length > 0)
            {
                lock (mParaSources)
                {
                    ParaSourceRunTime sParaSourceRunTime;
                    if (mParaWorkerRunTimeDic.TryGetValue(pName, out sParaSourceRunTime))
                    {
                        pValue = sParaSourceRunTime.GetCurrentValue();
                        return true;
                    }
                }
            }
            pValue = null;
            return false;
        }
    }
}

