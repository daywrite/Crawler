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
using Lwb.Crawler.Center.Server.Main;
using CCWin;
namespace Lwb.Crawler.Center.Server
{
    /// <summary>
    /// 采集管理中心
    /// </summary>
    public partial class FrmServer : CCSkinMain
    {
        #region 构造函数

        public FrmServer()
        {
            InitializeComponent();
        }

        #endregion

        private ServiceHost host = null;                                       //寄宿服务对象
        public frmPageGet _frmPageGet;
        public frmPageManage _frmPageManage;
        private void FrmServer_Load(object sender, EventArgs e)
        {
            frmLoad();
            HostInit();
        }

        private void frmLoad()
        {
            if (_frmPageGet == null)
            {
                _frmPageGet = new frmPageGet();
                setStyle(tabPage1, _frmPageGet);
            }
            if (_frmPageManage == null)
            {
                _frmPageManage = new frmPageManage();
                setStyle(tabPage2, _frmPageManage);
            }
        }
        /// <summary>
        /// 设置选项卡样式
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="frm"></param>
        private void setStyle(Control parent, Form frm)
        {
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            parent.Controls.Add(frm);
        }
        /// <summary>
        /// WCF服务对象寄宿
        /// </summary>
        private void HostInit()
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
