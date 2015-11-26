using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ComponentModel;

using Lwb.Crawler.Contract;

namespace Lwb.Crawler.Server
{
    public partial class FrmCrawler : Form
    {
        public FrmCrawler()
        {
            InitializeComponent();
        }

        private void FrmCrawler_Load(object sender, EventArgs e)
        {
            using (ChannelFactory<ICrawler> channelFactory = new ChannelFactory<ICrawler>("crawlerservice"))
            {
                ICrawler proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    Console.WriteLine(proxy.Add(1, 1).ToString());
                }
            }
        }
    }
}
