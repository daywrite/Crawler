using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwb.Crawler.Contract.Crawl.Model;

namespace Lwb.Crawler.Center.Custom
{
    class CustomBaseServer
    {
        public static string Root;
        public static Dictionary<string, string> CustomPlotDic = new Dictionary<string, string>();    //定制专案
        public static List<string> PlugCodeList = new List<string>();
        /// <summary>
        /// 构造函数
        /// </summary>
        static CustomBaseServer()
        {
            CustomPlotDic["搜房网"] = "soufun.com";
            CustomPlotDic["安居客"] = "anjuke.com";
            CustomPlotDic["新浪乐居"] = "esf.sina.com";
            CustomPlotDic["58同城"] = "58.com";
            CustomPlotDic["淘房网"] = "taofang.com";
            CustomPlotDic["易居网"] = "eeju.com/";
            CustomPlotDic["列表网"] = "liebiao.com";
            CustomPlotDic["房途网"] = "fangtu.com";
            CustomPlotDic["腾讯房产"] = "qq.com";

            PlugCodeList.Add("");
            PlugCodeList.Add("搜房网1");
            PlugCodeList.Add("搜房网2");
            PlugCodeList.Add("安居客");
            PlugCodeList.Add("新浪乐居");
            PlugCodeList.Add("新浪乐居BTS");
            PlugCodeList.Add("58同城");
            PlugCodeList.Add("淘房网");
            PlugCodeList.Add("易居网");
            PlugCodeList.Add("列表网");
            PlugCodeList.Add("房途网");
            PlugCodeList.Add("租房房天下");
            PlugCodeList.Add("租房安居客");
            PlugCodeList.Add("租房新浪乐居");
            PlugCodeList.Add("租房赶集");
            PlugCodeList.Add("租房58");
            PlugCodeList.Add("租金房途网");
            PlugCodeList.Add("租金淘房网");
            PlugCodeList.Add("租金列表网");
            PlugCodeList.Add("租金满堂红");
            PlugCodeList.Add("租金Q房网");
            PlugCodeList.Add("租金链家");
            PlugCodeList.Add("租金21世纪");
            PlugCodeList.Add("租金房探网");
            PlugCodeList.Add("租金置家网");
            PlugCodeList.Add("租金快点8");
            PlugCodeList.Add("租金芒果在线");
            PlugCodeList.Add("租金搜狐焦点");
            PlugCodeList.Add("租金淘房屋");
            PlugCodeList.Add("租金推推99");
            PlugCodeList.Add("租金我爱我家");
            PlugCodeList.Add("租金中原地产");
            PlugCodeList.Add("租金老客网");
            PlugCodeList.Add("二手房吉屋网");
            PlugCodeList.Add("二手房快点8");
            PlugCodeList.Add("二手房推推99");
            PlugCodeList.Add("二手房淘房屋");
            PlugCodeList.Add("二手房置家网");
            PlugCodeList.Add("二手房芒果在线");
            PlugCodeList.Add("二手房赶集网");
            PlugCodeList.Add("二手房求购58同城");
            PlugCodeList.Add("二手房求购搜房网");
            PlugCodeList.Add("二手房求购赶集网");
            PlugCodeList.Add("二手房21世纪不动产");
            PlugCodeList.Add("二手房满堂红");
            PlugCodeList.Add("二手房搜狐焦点");
            PlugCodeList.Add("二手房我爱我家");
            PlugCodeList.Add("二手房中原地产");
            PlugCodeList.Add("二手房链家");
            PlugCodeList.Add("二手房腾讯房产");
            PlugCodeList.Add("出租商铺搜房网");
            PlugCodeList.Add("出售商铺搜房网");
            PlugCodeList.Add("出租商铺赶集网");
            PlugCodeList.Add("出售商铺赶集网");
            PlugCodeList.Add("出租写字楼搜房网");
            PlugCodeList.Add("出售写字楼搜房网");
            PlugCodeList.Add("出租写字楼赶集网");
            PlugCodeList.Add("出售写字楼赶集网");
            PlugCodeList.Add("租金腾讯房产");
        }

        public static void InitServer(string pRoot)
        {

        }

        internal static void CallCustomMethord(string pPlugCode, List<CrawlTaskDetail> pCrawlTaskDetailList)
        {
            //if (pPlugCode == "搜房网1")
            //{
            //    SoufunServer.ProduceMoniterTask1(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "搜房网2")
            //{
            //    SoufunServer.ProduceMoniterTask2(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "安居客")
            //{
            //    AnjukeServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "新浪乐居")
            //{
            //    SinaServer.ProduceMoniterTask1(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "新浪乐居BTS")
            //{
            //    SinaServer.ProduceMoniterTask2(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "58同城")
            //{
            //    City58Server.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "淘房网")
            //{
            //    TaoFangServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "易居网")
            //{
            //    YijuServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "列表网")
            //{
            //    LiebiaoServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "房途网")
            //{
            //    FangtuServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租房房天下")
            //{
            //    ChuzuFangServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租房安居客")
            //{
            //    ChuzuAnjukeServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租房新浪乐居")
            //{
            //    ChuzuSinaServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租房赶集")
            //{
            //    ChuzuGanjiServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租房58")
            //{
            //    ChuzuCity58Server.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金房途网")
            //{
            //    ChuzuFangtu.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金淘房网")
            //{
            //    ChuzuTaofang.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金列表网")
            //{
            //    ChuzuLiebiao.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金满堂红")
            //{
            //    ChuzuManTH.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金Q房网")
            //{
            //    ChuzuQfang.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金链家")
            //{
            //    ChuzuLianjia.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金21世纪")
            //{
            //    ChuzuShiji21.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金房探网")
            //{
            //    ChuzuFangtan.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金置家网")
            //{
            //    ChuzuZhijia.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金快点8")
            //{
            //    ChuzuKuaidian8.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金老客网")
            //{
            //    ChuzuLaoke.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金芒果在线")
            //{
            //    ChuzuMangguo.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金搜狐焦点")
            //{
            //    ChuzuSouhu.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金淘房屋")
            //{
            //    ChuzuTaoFW.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金推推99")
            //{
            //    ChuzuTuitui99.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金我爱我家")
            //{
            //    ChuzuWoaiwojia.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金中原地产")
            //{
            //    ChuzuZhongYDC.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房吉屋网")
            //{
            //    JiwuServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房快点8")
            //{
            //    Kuaidian8Server.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房推推99")
            //{
            //    Tuitui99Server.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房淘房屋")
            //{
            //    TaoFWServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房置家网")
            //{
            //    ZhijiaServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房芒果在线")
            //{
            //    MangguoServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房赶集网")
            //{
            //    GanjiServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房求购58同城")
            //{
            //    QiugouCity58.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房求购搜房网")
            //{
            //    QiugouSoufun.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房求购赶集网")
            //{
            //    QiugouGanji.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房21世纪不动产")
            //{
            //    Shiji21Server.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房满堂红")
            //{
            //    ManTHServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房搜狐焦点")
            //{
            //    SouhuServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房我爱我家")
            //{
            //    WoaiwojiaServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房中原地产")
            //{
            //    ZhongYDCServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房链家")
            //{
            //    LianjiaServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "二手房腾讯房产")
            //{
            //    QQServer.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出租商铺搜房网")
            //{
            //    ChuzuSPSoufun.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出售商铺搜房网")
            //{
            //    ChushouSPSoufun.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出租商铺赶集网")
            //{
            //    ChuzuSPGanji.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出售商铺赶集网")
            //{
            //    ChushouSPGanji.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出租写字楼搜房网")
            //{
            //    ChuzuXZLSoufun.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出售写字楼搜房网")
            //{
            //    ChushouXZLSoufun.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出租写字楼赶集网")
            //{
            //    ChuzuXZLGanji.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "出售写字楼赶集网")
            //{
            //    ChushouXZLGanji.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
            //else if (pPlugCode == "租金腾讯房产")
            //{
            //    ChuzuQQ.ProduceMoniterTask(DateTime.Now, pCrawlTaskDetailList);
            //}
        }
    }
}
