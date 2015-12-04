using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Haina.Base.Html;

namespace Lwb.Crawler.Center.Scheme.Drill
{
    public partial class FrmRegularGuide : Form
    {
        HtmlTree mTree;
        public FrmRegularGuide()
        {
            InitializeComponent();
        }
        public FrmRegularGuide(HtmlTree pTree)
        {
            InitializeComponent();
            mTree = pTree;
        }
        /// <summary>
        /// 加载Html树
        /// </summary>
        private void LoadHtml()
        {
            WebBrowser1.DocumentText = mTree.GetHtml();
            TxtHtml.Text = mTree.Html;
            TView1.Nodes.Clear();
            for (int i = 0; i < mTree.Nodes.Count; i++)
            {
                HtmlNode sHtmlNode = mTree.Nodes[i];
                TreeNode sTreeNode = null;
                if (sHtmlNode.TagName != "TEXT")
                {
                    sTreeNode = new TreeNode("<" + sHtmlNode.TagName + ">", sHtmlNode.ImageIndex, sHtmlNode.ImageIndex);
                }
                else
                {
                    if (sHtmlNode.TextDecoded.Trim().Length > 0)
                    {
                        sTreeNode = new TreeNode("<" + sHtmlNode.TagName + ">:" + sHtmlNode.TextDecoded, sHtmlNode.ImageIndex, sHtmlNode.ImageIndex);
                    }
                }
                if (sTreeNode != null)
                {
                    sTreeNode.Tag = sHtmlNode;
                    sHtmlNode.Tag = sTreeNode;
                    TView1.Nodes.Add(sTreeNode);
                    AddTreeNode(sTreeNode, sHtmlNode);
                    ConditionExpand(sTreeNode);
                }
            }
        }

        /// <summary>
        /// 加载树节点
        /// </summary>
        /// <param name="pTreeNode"></param>
        /// <param name="pHtmlNode"></param>
        private void AddTreeNode(TreeNode pTreeNode, HtmlNode pHtmlNode)
        {
            for (int i = 0; i < pHtmlNode.Nodes.Count; i++)
            {
                HtmlNode sHtmlNode = pHtmlNode.Nodes[i];
                TreeNode sTreeNode = null;
                if (sHtmlNode.TagName != "TEXT")
                {
                    sTreeNode = new TreeNode("<" + sHtmlNode.TagName + ">", sHtmlNode.ImageIndex, sHtmlNode.ImageIndex);
                }
                else
                {
                    if (sHtmlNode.TextDecoded.Trim().Length > 0)
                    {
                        sTreeNode = new TreeNode("<" + sHtmlNode.TagName + ">:" + sHtmlNode.TextDecoded, sHtmlNode.ImageIndex, sHtmlNode.ImageIndex);
                    }
                }
                if (sTreeNode != null)
                {
                    sTreeNode.Tag = sHtmlNode;
                    sHtmlNode.Tag = sTreeNode;
                    pTreeNode.Nodes.Add(sTreeNode);
                    if (sHtmlNode.Nodes.Count > 0)
                    {
                        AddTreeNode(sTreeNode, sHtmlNode);
                    }
                }
            }
        }

        /// <summary>
        /// 条件展开
        /// </summary>
        /// <param name="pNode"></param>
        /// <returns></returns>
        private bool ConditionExpand(TreeNode pNode)
        {
            bool sCanExpand = false;
            for (int i = 0; i < pNode.Nodes.Count; i++)
            {
                if (((HtmlNode)pNode.Nodes[i].Tag).TagName == "TEXT")
                {
                    sCanExpand = true;
                }
                else if (pNode.Nodes[i].Nodes.Count > 0)
                {
                    if (ConditionExpand(pNode.Nodes[i]))
                    {
                        sCanExpand = true;
                    }
                }
            }
            if (sCanExpand)
            {
                pNode.Expand();
            }
            return sCanExpand;
        }
    }
}
