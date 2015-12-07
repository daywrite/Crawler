using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwb.Crawler.Center.Custom;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center.Crawl.Design
{
    public partial class FrmRuntime : Form
    {
        private Dictionary<TreeNode, string> mEditTypesDic = new Dictionary<TreeNode, string>();
        PlotWaterLine mPlotLine;
        public FrmRuntime(PlotWaterLine pPlotLine)
        {
            InitializeComponent();
            mPlotLine = pPlotLine;
            TxtPlugCode.Items.Clear();
            TxtPlugCode.Items.AddRange(CustomBaseServer.PlugCodeList.ToArray());
        }
    }
}
