using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNet4.Utilities;
using Haina.Base.Html;
using Lwb.Crawler.Center.Crawl.Design;
using Lwb.Crawler.Center.Scheme.Drill;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center.Scheme
{
    public partial class FrmPlotWaterLineGuide : Form
    {
        private bool mCanNavigate = false;
        PlotWaterLine mPlotLine;
        private HttpHelper httpHelper;

        public FrmPlotWaterLineGuide(PlotWaterLine pPlotLine)
        {
            
            InitializeComponent();
            httpHelper = new HttpHelper();

            mPlotLine = pPlotLine;
            
        }
       
        #region 工具栏菜单项时间

        /// <summary>
        /// 请求数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbarStart_Click(object sender, EventArgs e)
        {
            mCanNavigate = true;
            TxtHtml.Text = httpHelper.GetHtml(new HttpItem { URL = TxtAddress.Text, Method = CmbMethod.Text.ToLower() }).Html;

            if (TxtHtml.Text.Length > 0)
            {
                MyBrowser1.AllowNavigation = true;
                MyBrowser1.DocumentText = TxtHtml.Text;
            }
            //mPlotLine.Url = TxtAddress.Text;
            //mPlotLine.Chaset = CmbChaset.Text;
        }

        /// <summary>
        /// 清洗规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tbar清洗规则_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 数据提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbarDrill_Click(object sender, EventArgs e)
        {
            if (TxtHtml.Text == "")
            {
                MessageBox.Show("请先请求数据");
            }
            else
            {
                HtmlTree sTree = new HtmlTree(TxtHtml.Text, TxtAddress.Text, null);
                if (sTree.LoadSuccess)
                {
                    FrmRegularGuide mFrmRegularGuide = new FrmRegularGuide(TxtHtml.Text, sTree, mPlotLine);
                    mFrmRegularGuide.ShowDialog();     
                }
                else
                {
                    MessageBox.Show(sTree.Info);
                }
            }
        }

        /// <summary>
        /// 取消配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbarCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion              

        private void TBarOk_Click(object sender, EventArgs e)
        {
            if (TxtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("");
                return;
            }
            try
            {
                Uri sUri = new Uri(TxtAddress.Text);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                return;
            }
            if (mPlotLine.Name == null || mPlotLine.Name.Length == 0)
            {
                FrmRuntime sFrmRuntime = new FrmRuntime(mPlotLine);
                if (sFrmRuntime.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }
            mPlotLine.Method = CmbMethod.Text;
            mPlotLine.Chaset = CmbChaset.Text;
            mPlotLine.Url = TxtAddress.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
