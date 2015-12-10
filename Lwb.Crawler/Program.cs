using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lwb.Crawler.Server;

namespace Lwb.Crawler
{
    static class Program
    {
        private static System.Timers.Timer mTimer;    

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mTimer = new System.Timers.Timer(10000);
            mTimer.Elapsed += new System.Timers.ElapsedEventHandler(mTimer_Elapsed);
            mTimer.Start();
            //CrawlerManager.Adapter();

            Application.Run(new FrmCrawler());
        }

        /// <summary>
        /// 指定时间间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void mTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CrawlerManager.DbAdapter();
        }
    }
}
