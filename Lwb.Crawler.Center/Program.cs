using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwb.Crawler.Center.Scheme;
using Lwb.Crawler.Center.Server;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CrawlServer.InitServer(Application.StartupPath);

            Application.Run(new FrmServer());
        }
    }
}
