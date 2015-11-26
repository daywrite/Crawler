using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ServiceModel;

using Lwb.Crawler.Service;

namespace Lwb.Crawler.Center.Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
        }

        private ServiceHost host = null;                                       //寄宿服务对象
        private void FrmServer_Load(object sender, EventArgs e)
        {
            try
            {
                if (host != null)
                    host.Close();

                host = new ServiceHost(typeof(CrawlerService));
                host.Opened += delegate { };

                host.Open();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                if (host != null)
                    host.Close();
            }
        }
    }
}
