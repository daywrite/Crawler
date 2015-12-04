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
using Haina.Common;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center.Scheme.Drill
{
    public partial class FrmRegularGuide : Form
    {
        HtmlTree mTree;
        DrillRegularRule mDrillRule;
        TreeNode mRegionTreeNode;
        public FrmRegularGuide()
        {
            InitializeComponent();
        }
        public FrmRegularGuide(HtmlTree pTree)
        {
            InitializeComponent();
            mTree = pTree;
        }
        private void FrmRegularGuide_Load(object sender, EventArgs e)
        {
            #region 左侧html树
            LoadHtml();
            #endregion

            #region 加载记录区
            for (int i = 0; i < 10; i++)
            {
                TreeNode sNode = new TreeNode("记录区" + (i + 1).ToString(), 0, 0);
                //if (mWaterLine.DrillRegularRules.Count > i)
                //{
                //    sNode = new TreeNode("记录区" + (i + 1).ToString(), 1, 1);
                //    sNode.Tag = mWaterLine.DrillRegularRules[i];
                //}
                //else
                //{
                //    sNode = new TreeNode("记录区" + (i + 1).ToString(), 0, 0);
                //}
                TViewRegion.Nodes.Add(sNode);
            }
            TViewRegion.SelectedNode = TViewRegion.Nodes[0];
            #endregion
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

        private void FrmRegularGuide_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            RegScriptTransactor sRegScriptTransactor = new RegScriptTransactor(mTree.Html);
            DrillRegularRule sDrillRule = new DrillRegularRule();
            sDrillRule.StartTag = TxtStartTag.Text.Trim();
            sDrillRule.EndTag = TxtEndTag.Text.Trim();
            sDrillRule.DrillType = 0;
            sDrillRule.MetaModalID = SysDbDefines.下载链接.DbModelID;
            sDrillRule.FeatureType = CmbLinkType.SelectedIndex;
            sDrillRule.Feature = TxtUrlFeatrue.Text;
            string[] sUrls = sRegScriptTransactor.GetUrls(sDrillRule, mTree.URL);
            List<string> sList = new List<string>();
            for (int i = 0; i < sUrls.Length; i++)
            {
                sList.Add((i + 1).ToString() + "." + sUrls[i]);
            }
            TxtTestResult0.Lines = sList.ToArray();
        }

        private void linkStartTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int sCount = 0;
            string sTag = TxtStartTag.Text.Trim();
            if (sTag.Length > 0)
            {
                int x = mTree.Html.IndexOf(sTag);
                while (x >= 0)
                {
                    sCount++;
                    x = mTree.Html.IndexOf(sTag, x + sTag.Length);
                }
                if (sCount == 0)
                {
                    MessageBox.Show("没有找到起始标识字符串！");
                }
                else if (sCount > 1)
                {
                    MessageBox.Show("找到" + sCount + "个起始标识字符串，若使用该串，以第一个为准！");
                }
                else
                {
                    MessageBox.Show("只找到一个起始标识字符串，测试通过！");
                }
            }
        }

        private void linkEndTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int sCount = 0;
            string sTag = TxtStartTag.Text.Trim();
            int x = 0;
            if (sTag.Length > 0)
            {
                x = mTree.Html.IndexOf(sTag);
            }
            if (x < 0)
            {
                MessageBox.Show("如果设置了起始标识字符串，而且起始标识字符串没有找到，此时提取失败，不再考虑其他设置！");
            }
            else
            {
                string sEndTag = TxtEndTag.Text.Trim();
                if (sEndTag.Length > 0)
                {
                    int y = mTree.Html.IndexOf(sEndTag, x + sTag.Length);
                    while (y >= 0)
                    {
                        sCount++;
                        y = mTree.Html.IndexOf(sEndTag, y + sEndTag.Length);
                    }
                    if (sCount == 0)
                    {
                        MessageBox.Show("没有找到终止标识字符串！");
                    }
                    else if (sCount > 1)
                    {
                        MessageBox.Show("找到" + sCount + "个终止标识字符串，若使用该串，以第一个为准！");
                    }
                    else
                    {
                        MessageBox.Show("只找到一个终止标识字符串，测试通过！");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TxtName.Text = TxtName.Text.Trim();
            if (TxtName.Text.Length == 0)
            {
                MessageBox.Show("记录区名称不能为空！");
                return;
            }
            #region 提取类型
            mDrillRule.ConditionType = (byte)CmbConditionType.SelectedIndex;
            mDrillRule.ConditionTag = TxtConditionTag.Text.Trim();
            mDrillRule.StartTag = TxtStartTag.Text.Trim().ToLower();
            mDrillRule.EndTag = TxtEndTag.Text.Trim().ToLower();
            if (tabControl3.SelectedIndex == 0)
            {
                mDrillRule.DrillType = 0;
            }
            else
            {
                mDrillRule.DrillType = 2;
            }
            CDbDefine sCDbDefine;
            if (mDrillRule.DrillType == 0)
            {
                sCDbDefine = SysDbDefines.下载链接;
            }
            else
            {
                if (TxtMeta.Tag != null) { sCDbDefine = ((CDbDefine)TxtMeta.Tag); } else { sCDbDefine = SysDbDefines.实时资讯数据库; }
            }
            mDrillRule.MetaModalID = sCDbDefine.DbModelID;             //确定元数据
            if (mDrillRule.Feilds.Count == 0)
            {
                for (int i = 0; i < sCDbDefine.Fields.Length; i++)     //加载预定义字段
                {
                    RegularMetaFeild sFeild = new RegularMetaFeild();
                    sFeild.Name = sCDbDefine.Fields[i].Name;
                    mDrillRule.Feilds.Add(sFeild);
                }
            }
            #endregion

            #region 下载链接
            mDrillRule.FeatureType = CmbLinkType.SelectedIndex;
            mDrillRule.Feature = TxtUrlFeatrue.Text;
            #endregion

            #region 自定义高级提取
            mDrillRule.Splitter = TxtSpliter.Text.Trim();
            mDrillRule.Name = TxtName.Text;
            mRegionTreeNode.Text = TxtName.Text;
            #endregion

            mRegionTreeNode.Tag = mDrillRule;
            mRegionTreeNode.ImageIndex = 1;
            mRegionTreeNode.SelectedImageIndex = 1;

            //mWaterLine.DrillRegularRules = new List<DrillRegularRule>();
            //for (int i = 0; i < TViewRegion.Nodes.Count; i++)
            //{
            //    if (TViewRegion.Nodes[i].Tag != null)
            //    {
            //        mWaterLine.DrillRegularRules.Add((DrillRegularRule)TViewRegion.Nodes[i].Tag);
            //    }
            //}
        }
       
    }
}
