using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Service.Crawl
{
    /// <summary>
    /// 参数工人工作状态
    /// </summary>
    class ParaSourceRunTime
    {
        public string Name;
        private int mStart;                        //起始位置
        private int mSpan = 1;                     //步长，默认是1
        private int mEnd;
        private int mTotal;                        //总数
        private int mCurrent;                      //当前游标，从0开始计数，小于mTotal
        private string[] mSources;                 //参数源，如果不存在参数源，就是自然数源，否则采用Source源
        /// <summary>
        /// 初始化参数运行时,自然数
        /// </summary>
        /// <returns></returns>
        public ParaSourceRunTime(string pName, int pStart, int pSpan, int pEnd)
        {
            Name = pName;
            if (pSpan < 1) { mSpan = 1; } else { mSpan = pSpan; }
            mStart = pStart;
            mEnd = pEnd;
            mTotal = (mEnd - pStart) / pSpan;
            if ((mEnd - pStart) > 0 && (mEnd - pStart) % pSpan > 0)
            {
                mTotal = mTotal + 1;
            }
        }
        /// <summary>
        /// 初始化参数运行时
        /// </summary>
        /// <returns></returns>
        public ParaSourceRunTime(string pName, string[] pSources, int pStart, int pEnd)
        {
            Name = pName;
            mSources = pSources;
            if (mSources != null && mSources.Length > 0)
            {
                if (pStart > 0) { mStart = pStart; }
                if (pEnd <= mSources.Length) { mEnd = pEnd; } else { mEnd = mSources.Length; }
            }
            if (mEnd > mStart) { mTotal = mEnd - mStart; }
        }
        /// <summary>
        /// 重置参数运行时
        /// </summary>
        /// <returns></returns>
        public void Reset()
        {
            mCurrent = mStart;
        }

        /// <summary>
        /// 设置运行时结束点,用于自动确定页码的情况，往往为自然数
        /// </summary>
        /// <param name="pEnd"></param>
        public void SetRunTimeEnd(int pEnd)
        {
            if (pEnd >= 0)
            {
                mEnd = pEnd;
                mTotal = (mEnd - mStart) / mSpan;
                if ((mEnd - mStart) > 0 && (mEnd - mStart) % mSpan > 0)
                {
                    mTotal = mTotal + 1;
                }
            }
        }

        /// <summary>
        /// 该参数的已经循环的次数
        /// </summary>
        public int Current
        {
            get
            {
                return mCurrent;
            }
        }

        /// <summary>
        /// 该参数的总计循环次数
        /// </summary>
        public int Total
        {
            get
            {
                return mTotal;
            }
        }

        /// <summary>
        /// 当前参数使用的数据产生器
        /// </summary>
        public string GetCurrentValue()
        {
            if (mStart < mTotal)
            {
                if (mSources == null)
                {
                    return (mStart + mCurrent * mSpan).ToString();
                }
                else
                {
                    return mSources[mCurrent];
                }
            }
            return "";
        }
        /// <summary>
        /// 移动至下一参数位置
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (mCurrent < mTotal - 1)
            {
                mCurrent++;
                return true;
            }
            return false;
        }
    }
}
