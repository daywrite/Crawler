using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Haina.Client;

namespace Lwb.Crawler.Center.Server.Main
{
    public partial class FrmPageDataBase : Form
    {
        FrmHainaDbTool mFrmHainaDbTool;
        public FrmPageDataBase()
        {
            InitializeComponent();
        }

        #region 元数据管理工具
        /// <summary>
        /// 元数据仓储管理工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbarGxd_Click(object sender, EventArgs e)
        {
            try
            {
                if (mFrmHainaDbTool == null)
                {
                    mFrmHainaDbTool = new FrmHainaDbTool();
                    mFrmHainaDbTool.FormClosed += new FormClosedEventHandler(mFrmHainaDbTool_FormClosed);
                    mFrmHainaDbTool.Show();
                }
                else
                {
                    mFrmHainaDbTool.BringToFront();
                    mFrmHainaDbTool.Activate();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        void mFrmHainaDbTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            mFrmHainaDbTool = null;
        }
        #endregion
    }
}
