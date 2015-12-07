using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center.Scheme
{
    public partial class FrmPlotInfo : Form
    {
        OpenPlot mPlot;
        bool mIsNew;
        public FrmPlotInfo(OpenPlot pPlot, bool pNew)
        {
            InitializeComponent();
            mPlot = pPlot;
            mIsNew = pNew;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPlotInfo_Load(object sender, EventArgs e)
        {
            TxtName.Enabled = mIsNew;
            this.TxtName.Text = mPlot.Name;
            this.TxtHomePage.Text = mPlot.HomePage;
            this.TxtInfo.Text = mPlot.Info;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            StringBuilder sSb = new StringBuilder();
            for (int i = 0; i < TxtName.Text.Length; i++)
            {
                if (char.IsLetterOrDigit(TxtName.Text[i]))
                {
                    sSb.Append(TxtName.Text[i]);
                }
            }
            TxtName.Text = sSb.ToString();
            if (TxtName.Text.Length == 0)
            {
                MessageBox.Show("请填写专案名称！");
                return;
            }
            if (mIsNew)
            {
                string sFileName = mPlot.Path + "\\" + TxtName.Text + ".opp";
                if (File.Exists(sFileName))
                {
                    MessageBox.Show("存在同名的专案！");
                    return;
                }
            }
            TxtHomePage.Text = TxtHomePage.Text.Trim();
            if (TxtHomePage.Text.Length == 0)
            {
                MessageBox.Show("请填写主页地址！");
                return;
            }
            mPlot.Name = this.TxtName.Text;
            mPlot.HomePage = this.TxtHomePage.Text;
            mPlot.Info = this.TxtInfo.Text;
            for (int i = 0; i < mPlot.Lines.Count; i++)
            {
                mPlot.Lines[i].DbName = null;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
