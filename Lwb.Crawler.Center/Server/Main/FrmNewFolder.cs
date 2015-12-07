using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lwb.Crawler.Center.Server.Main
{
    public partial class FrmNewFolder : Form
    {
        TreeNode mTreeNode;
        public FrmNewFolder(TreeNode pNode)
        {
            InitializeComponent();
            mTreeNode = pNode;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            StringBuilder sSb = new StringBuilder();
            for (int i = 0; i < TxtFolder.Text.Length; i++)
            {
                if (char.IsLetterOrDigit(TxtFolder.Text[i]))
                {
                    sSb.Append(TxtFolder.Text[i]);
                }
            }
            TxtFolder.Text = sSb.ToString();
            if (TxtFolder.Text.Length == 0)
            {
                MessageBox.Show("请填写组名称！");
                return;
            }
            else
            {
                mTreeNode.Text = TxtFolder.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
