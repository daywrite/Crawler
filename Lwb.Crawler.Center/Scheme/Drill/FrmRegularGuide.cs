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
using Haina.Client;
using Haina.Common;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center.Scheme.Drill
{
    public partial class FrmRegularGuide : Form
    {
        PlotWaterLine mWaterLine;
        HtmlTree mTree;
        string mHtml;
        bool mCanNav = false;
        TreeNode mRegionTreeNode;
        DrillRegularRule mDrillRule;
        string[] mRecordHtmls;
        
        public FrmRegularGuide(string pOriHtml, HtmlTree pTree, PlotWaterLine pPlotLine)
        {
            InitializeComponent();
            mWaterLine = pPlotLine;
            mTree = pTree;
            mHtml = pOriHtml;
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
                if (mWaterLine.DrillRegularRules.Count > i)
                {
                    sNode = new TreeNode("记录区" + (i + 1).ToString(), 1, 1);
                    sNode.Tag = mWaterLine.DrillRegularRules[i];
                }
                else
                {
                    sNode = new TreeNode("记录区" + (i + 1).ToString(), 0, 0);
                }
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
        private void FrmRegularGuide_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
        private void TView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mCanNav = true;
            HtmlNode sHtmlNode = (HtmlNode)e.Node.Tag;
            TxtHtml.Text = sHtmlNode.Html;
            WebBrowser1.DocumentText = TxtHtml.Text;
        }

        private void TView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode sTreeNode = TView1.GetNodeAt(e.X, e.Y);
            if (sTreeNode != null)
            {
                TView1.SelectedNode = sTreeNode;
                if (e.Button == MouseButtons.Right)
                {
                    MenuHtml.Show(TView1, e.X, e.Y);
                }
            }
        }
        private void TxtUrlFeatrue_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TxtUrlFeatrue_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                ((TextBox)sender).Text = (string)e.Data.GetData(typeof(string));
            }
        }
        /// <summary>
        /// 加载提取规则
        /// </summary>
        private void LoadDrillRule(DrillRegularRule pRule)
        {
            if (pRule != null)
            {
                mDrillRule = pRule;
            }
            else
            {
                mDrillRule = new DrillRegularRule();
            }
            CmbConditionType.SelectedIndex = mDrillRule.ConditionType;
            TxtConditionTag.Text = mDrillRule.ConditionTag;

            TxtStartTag.Text = mDrillRule.StartTag;
            TxtEndTag.Text = mDrillRule.EndTag;
            if (mDrillRule.DrillType == 0)
            {
                tabControl3.SelectedIndex = 0;   //提取类型
            }
            else
            {
                tabControl3.SelectedIndex = 1;   //提取类型
            }
            #region 链接提取模式
            CmbLinkType.SelectedIndex = mDrillRule.FeatureType;
            TxtUrlFeatrue.Text = mDrillRule.Feature;
            #endregion

            #region 高级提取模式
            CDbDefine sCDbDefine = CommonDbServer.GetModalDbByID(mDrillRule.MetaModalID);
            TxtMeta.Text = sCDbDefine.DbName;
            TxtMeta.Tag = sCDbDefine;
            TxtSpliter.Text = mDrillRule.Splitter;
            SplitRecord(null, null);
            #endregion
        }
        /// <summary>
        /// 分隔记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitRecord(object sender, System.EventArgs e)
        {
            try
            {
                DrillRegularRule sDrillRule = new DrillRegularRule();
                sDrillRule.StartTag = TxtStartTag.Text.Trim();
                sDrillRule.EndTag = TxtEndTag.Text.Trim();
                sDrillRule.DrillType = 2;
                sDrillRule.Splitter = TxtSpliter.Text.Trim();
                mRecordHtmls = new RegScriptTransactor(mHtml).GetRecordHtmls(sDrillRule);
                if (mRecordHtmls != null && mRecordHtmls.Length > 0)
                {
                    TxtTotal.Text = mRecordHtmls.Length.ToString();
                    ShowRecord(0);
                }
                else
                {
                    TxtTotal.Text = "0";
                    ShowRecord(-1);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "提示信息");
            }
        }
        /// <summary>
        ///  显示记录
        /// </summary>
        /// <param name="pIndex"></param>
        private void ShowRecord(int pIndex)
        {
            TxtResult.Clear();
            TxtRecordHtml.Clear();
            if (pIndex >= 0)
            {
                if (mRecordHtmls != null && mRecordHtmls.Length > pIndex)
                {
                    TxtCurrent.Text = pIndex.ToString();
                    TxtRecordHtml.Text = mRecordHtmls[pIndex];
                    RegScriptTransactor sSe = new RegScriptTransactor(TxtRecordHtml.Text);
                    if (mDrillRule.Feilds != null)
                    {
                        for (int i = 0; i < mDrillRule.Feilds.Count; i++)
                        {
                            RegularMetaFeild sFeild = mDrillRule.Feilds[i];
                            if (sFeild.Rule != null)
                            {
                                try
                                {
                                    TxtResult.AppendText(sFeild.Name);
                                    TxtResult.AppendText(" ： ");
                                    TxtResult.AppendText(sSe.Exe(sFeild.Rule));
                                    TxtResult.AppendText("\n");
                                }
                                catch (Exception E)
                                {
                                    MessageBox.Show(E.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                TxtCurrent.Text = "0";
            }
        }




        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int k = int.Parse(TxtCurrent.Text) - 1;
            if (k < 0)
            {
                k = int.Parse(TxtTotal.Text) - 1;
            }
            ShowRecord(k);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int k = int.Parse(TxtCurrent.Text) + 1;
            if (k >= int.Parse(TxtTotal.Text))
            {
                TxtCurrent.Text = "0";
                k = 0;
            }
            ShowRecord(k);
        }

        private void btnFeildGuide_Click(object sender, EventArgs e)
        {
            if (mRecordHtmls != null && mRecordHtmls.Length > 0)
            {
                FrmRegularFieldGuide sFrmGetFieldGuide = new FrmRegularFieldGuide();
                sFrmGetFieldGuide.ShowDialog();
                CDbDefine sCDbDefine = CommonDbServer.GetModalDbByID(mDrillRule.MetaModalID);
                TxtMeta.Text = sCDbDefine.DbName;
                TxtMeta.Tag = sCDbDefine;
            }
        }

        private void linkMeta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChoiseModal sFrmChoiseModal = new FrmChoiseModal(TxtMeta);
            if (sFrmChoiseModal.ShowDialog() == DialogResult.OK)
            {
                CDbDefine sCDbDefine = (CDbDefine)TxtMeta.Tag;
                mDrillRule.MetaModalID = sCDbDefine.DbModelID;
            }
        }

        private void TxtSpliter_TextChanged(object sender, EventArgs e)
        {
            SplitRecord(sender, e);
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

            mWaterLine.DrillRegularRules = new List<DrillRegularRule>();
            for (int i = 0; i < TViewRegion.Nodes.Count; i++)
            {
                if (TViewRegion.Nodes[i].Tag != null)
                {
                    mWaterLine.DrillRegularRules.Add((DrillRegularRule)TViewRegion.Nodes[i].Tag);
                }
            }
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

        private void TViewRegion_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode sNode = TViewRegion.GetNodeAt(e.X, e.Y);
                if (sNode != null)
                {
                    MenuRegion.Tag = sNode;
                    MenuRegion.Show(TViewRegion, e.X, e.Y);
                }
            }
        }

        private void TViewRegion_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (TViewRegion.SelectedNode != null)
            {
                if (TxtStartTag.Text.Trim().Length == 0 && TxtStartTag.Text.Trim().Length == 0)
                {
                    return;
                }
                btnSave_Click(sender, e);
            }
        }

        private void MenuRegionDelete_Click(object sender, EventArgs e)
        {
            if (MenuRegion.Tag != null)
            {
                TreeNode sNode = (TreeNode)MenuRegion.Tag;
                sNode.Tag = null;
                sNode.ImageIndex = 0;
                sNode.SelectedImageIndex = 0;
                if (sNode == TViewRegion.SelectedNode)
                {
                    TViewRegion_AfterSelect(TViewRegion, new TreeViewEventArgs(sNode));
                }
            }
        }

        private void link选择提取模板_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (TViewRegion.SelectedNode != null && DlgOpen.ShowDialog() == DialogResult.OK)
            {
                PageDrillRagularRule sPageDrillRule = PageDrillRagularRule.Open(DlgOpen.FileName);
                DrillRegularRule sDrillRagularRule = sPageDrillRule.ToDrillRegularRule();
                TViewRegion.SelectedNode.Tag = sDrillRagularRule;
                LoadDrillRule(sDrillRagularRule);
            }
        }

        private void link导出提取模板_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtName.Text = TxtName.Text.Trim();
            if (TxtName.Text.Length == 0)
            {
                MessageBox.Show("记录区名称不能为空！");
                return;
            }
            if (DlgNew.ShowDialog() == DialogResult.OK)
            {
                PageDrillRagularRule sPageDrillRule = new PageDrillRagularRule();
                sPageDrillRule.Url = mWaterLine.Url;
                sPageDrillRule.Chaset = mWaterLine.Chaset;

                #region 提取类型
                sPageDrillRule.ConditionType = (byte)CmbConditionType.SelectedIndex;
                sPageDrillRule.ConditionTag = TxtConditionTag.Text.Trim();
                sPageDrillRule.StartTag = TxtStartTag.Text.Trim();
                sPageDrillRule.EndTag = TxtEndTag.Text.Trim();
                if (tabControl3.SelectedIndex == 0)
                {
                    sPageDrillRule.DrillType = 0;
                }
                else
                {
                    sPageDrillRule.DrillType = 2;
                }
                CDbDefine sCDbDefine;
                if (sPageDrillRule.DrillType == 0)
                {
                    sCDbDefine = SysDbDefines.下载链接;
                }
                else
                {
                    if (TxtMeta.Tag != null) { sCDbDefine = ((CDbDefine)TxtMeta.Tag); } else { sCDbDefine = SysDbDefines.实时资讯数据库; }
                }
                sPageDrillRule.MetaModalID = sCDbDefine.DbModelID;             //确定元数据
                sPageDrillRule.Feilds = mDrillRule.Feilds;
                #endregion

                #region 下载链接
                sPageDrillRule.FeatureType = CmbLinkType.SelectedIndex;
                sPageDrillRule.Feature = TxtUrlFeatrue.Text;
                #endregion

                #region 自定义高级提取
                sPageDrillRule.Splitter = TxtSpliter.Text.Trim();
                sPageDrillRule.Name = TxtName.Text;
                #endregion
                PageDrillRagularRule.SaveAs(DlgNew.FileName, sPageDrillRule);
                MessageBox.Show("导出成功！");
            }



        }

        private void TViewRegion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mRegionTreeNode = e.Node;
            TxtName.Text = mRegionTreeNode.Text;
            if (e.Node.Tag == null)
            {
                LoadDrillRule(null);
            }
            else
            {
                LoadDrillRule((DrillRegularRule)e.Node.Tag);
            }
        }
    }
}
