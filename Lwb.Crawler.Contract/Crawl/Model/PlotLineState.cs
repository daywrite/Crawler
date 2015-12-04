using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Crawl.Model
{
    public class PlotLineState
    {
        public int State;                 //生产线状态
        public long WaitTaskCount;        //待发任务
        public int OnlineTaskCount;       //已发待收
        public int ErrCount;              //错误计数
        public int LocalWaitCount;        //本缓待处
        public int WaitDrillCount;        //已收待处
        public DateTime LastProduceDt;    //最近提交任务的时间
        public int TotalRecieved;         //累计完成
        public int DrillWaitSaveCount;    //待存储的信息
        public List<WaterLineDayStat> DayStat;
    }
    public class WaterLineDayStat
    {
        public DateTime StatDate;
        public int RecievedTotal;                  //累计接收到的处理结果
        public int ErrCount;                       //出错信息数
    }
}

