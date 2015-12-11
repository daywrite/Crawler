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
using DotNet.Utilities;
using Haina.Base;
using Lwb.Crawler.Center.Scheme;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Service.Crawl;

namespace Lwb.Crawler.Center.Server.Main
{
    public partial class frmPageManage : Form
    {
        Dictionary<string, TreeNode> mTreeNodeDic = new Dictionary<string, TreeNode>();                   // 站点用户组树

        public frmPageManage()
        {
            InitializeComponent();
        }

        private void frmPageManage_Load(object sender, EventArgs e)
        {
            LoadTree();
        }

        /// <summary>
        /// 加载左侧专案树
        /// </summary>
        private void LoadTree()
        {
            treeV.Nodes.Clear();
            TreeNode node = new TreeNode("全部专案", 0, 0);
            node.Tag = CrawlServer.CaseRoot;
            treeV.Nodes.Add(node);
            LoadDir(CrawlServer.CaseRoot, node, mTreeNodeDic);
        }

        /// <summary>
        /// 加载专案目录
        /// </summary>
        /// <param name="path"></param>
        /// <param name="node"></param>
        /// <param name="nodeDic"></param>
        private void LoadDir(string path, TreeNode node, Dictionary<string, TreeNode> nodeDic)
        {
            string[] dir = DirFileHelper.GetDirectories(path);
            int k = path.Length + 1;
            if (dir != null)
            {
                for (int i = 0; i < dir.Length; i++)
                {
                    TreeNode sNode = new TreeNode(dir[i].Substring(k), 1, 1);
                    sNode.Tag = dir[i];
                    node.Nodes.Add(sNode);
                    nodeDic[dir[i]] = sNode;
                    LoadDir(dir[i], sNode, nodeDic);
                }
            }
            LoadFile(path, node, nodeDic);
            node.Expand();
        }

        /// <summary>
        /// 加载专案文件
        /// </summary>
        /// <param name="pPath"></param>
        /// <param name="pNode"></param>
        /// <param name="pNodeDic"></param>
        public void LoadFile(string pPath, TreeNode pNode, Dictionary<string, TreeNode> pNodeDic)
        {
            string[] sFiles = DirFileHelper.GetFileNames(pPath);
            int k = pPath.Length + 1;
            if (sFiles != null)
            {
                for (int i = 0; i < sFiles.Length; i++)
                {
                    OpenPlot sPlot = CrawlServer.Open(sFiles[i]);
                    if (sPlot == null) { continue; }
                    TreeNode sNode = new TreeNode(sPlot.Name, 2, 2);
                    sNode.Tag = sPlot;
                    CrawlServer.AddPlot2Pool(sPlot);
                    pNodeDic[sFiles[i]] = sNode;
                    pNode.Nodes.Add(sNode);
                }
            }
        }
        

        #region 左侧菜单树操作

        /// <summary>
        /// 新建组-一般组是必要的环节，更好的区分生茶先
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuGroupFloderNew_Click(object sender, EventArgs e)
        {
            if (treeV.SelectedNode != null && treeV.SelectedNode.ImageIndex <= 1)
            {
                TreeNode sNode = new TreeNode("", 1, 1);
                FrmNewFolder sFrmNewFolder = new FrmNewFolder(sNode);
                if (sFrmNewFolder.ShowDialog() == DialogResult.OK)
                {
                    string sPath = treeV.SelectedNode.Tag.ToString() + "\\" + sNode.Text;
                    if (Directory.Exists(sPath))
                    {
                        MessageBox.Show("已存在同名的组！");
                    }
                    else
                    {
                        sNode.Tag = CommonService.CreateDir(sPath);
                        treeV.SelectedNode.Nodes.Add(sNode);
                        mTreeNodeDic[sPath] = sNode;
                        treeV.SelectedNode = sNode;
                    }
                }
            }
        }

        /// <summary>
        /// 在组上，右键，获取列表添加专案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode sNode = treeV.GetNodeAt(e.X, e.Y);
                if (sNode != null)
                {
                    treeV.SelectedNode = sNode;
                    if (sNode.ImageIndex == 2)
                    {
                        OpenPlot sOpenPlot = (OpenPlot)sNode.Tag;
                        //MenuPlotDelete.Enabled = !CustomBaseServer.CustomPlotDic.ContainsKey(sOpenPlot.Name);
                        //MenuPlot.Show(treeV, e.X, e.Y);
                    }
                    else
                    {
                        MenuGroupFloderDelete.Enabled = (sNode.ImageIndex == 1 && sNode.Text == "关键专案");
                        MenuPlotGroup.Show(treeV, e.X, e.Y);
                    }
                }
            }
        }

        /// <summary>
        /// 新建专案
        /// 专案就是可以创建生产线的地方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuGroupPlotNew_Click(object sender, EventArgs e)
        {
            if (treeV.SelectedNode != null)
            {
                OpenPlot sPlot = OpenPlot.CreatePlot();
                sPlot.Path = treeV.SelectedNode.Tag.ToString();

                FrmPlotInfo sFrmPlotInfo = new FrmPlotInfo(sPlot, true);
                if (sFrmPlotInfo.ShowDialog() == DialogResult.OK)
                {
                    string sFileName = treeV.SelectedNode.Tag.ToString() + "\\" + sPlot.Name + ".opp";
                    //保存专案到本地文件
                    if (CrawlServer.SaveAs(sFileName, sPlot))
                    {
                        TreeNode sNode = new TreeNode(sPlot.Name, 2, 2);
                        sNode.Tag = sPlot;
                        //在给专案树Tag赋值完，将专案添加到缓冲池
                        CrawlServer.AddPlot2Pool(sPlot);
                        treeV.SelectedNode.Nodes.Add(sNode);
                        //专案树字典
                        mTreeNodeDic[sFileName] = sNode;
                        treeV.SelectedNode = sNode;
                    }
                }
            }
        }

        /// <summary>
        /// 专案节点选择完成后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 0 || e.Node.ImageIndex == 1)
            {
                #region 文件夹节点
                //panelPlot.Visible = false;
                //LView2.Visible = true;
                //LView2.Items.Clear();
                //LView2.Groups.Clear();
                LoadPlotItem(e.Node, null);
                #endregion
            }
            else
            {
                #region 专案
                //panelPlot.Visible = true;
                //LView2.Visible = false;
                listView1.Items.Clear();
                OpenPlot sPlot = (OpenPlot)e.Node.Tag;
                #region 加载专案的展示信息
                if (sPlot.Lines != null && sPlot.Lines.Count > 0)
                {
                    for (int i = 0; i < sPlot.Lines.Count; i++)
                    {
                        LoadPlotWaterLineItem(sPlot.Lines[i]);
                    }
                }
                #endregion
                #endregion
            }
        }

        /// <summary>
        /// 添加网页生产线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPlotLine添加网页生产线_Click(object sender, EventArgs e)
        {
            if (treeV.SelectedNode != null && treeV.SelectedNode.ImageIndex == 2)
            {
                OpenPlot sPlot = (OpenPlot)treeV.SelectedNode.Tag;
                PlotWaterLine sPlotLine = sPlot.CreateWaterLine(false, "网页生产线");
                FrmPlotWaterLineGuide sFrmPlotWaterLineGuide = new FrmPlotWaterLineGuide(sPlotLine);
                if (sFrmPlotWaterLineGuide.ShowDialog() == DialogResult.OK)
                {
                    sPlotLine.Plot = sPlot;
                    LoadPlotWaterLineItem(sPlotLine);
                    CrawlServer.Save(sPlot);
                }
                else
                {
                    //sPlot.Remove(sPlotLine);
                }
            }
        }

        #endregion

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            MenuPlotLine.Tag = null;
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem sItem = listView1.GetItemAt(e.X, e.Y);
                if (sItem != null)
                {
                    PlotWaterLine sPlotLine = (PlotWaterLine)sItem.Tag;
                    MenuPlotLine修改提取配置.Visible = !sPlotLine.IsFileLine;
                    if (sPlotLine.State == 1)                       //非启动状态才能编辑
                    {
                        MenuPlotLine修改提取配置.Enabled = false;
                        MenuPlotLine删除.Enabled = false;
                        MenuPlotLine任务.Enabled = true;
                        MenuPlotLine启动.Enabled = false;
                        MenuPlotLine停止.Enabled = true;
                    }
                    else
                    {
                        MenuPlotLine启动.Enabled = true;
                        MenuPlotLine删除.Enabled = true;
                        MenuPlotLine修改提取配置.Enabled = true;
                        MenuPlotLine停止.Enabled = false;
                        MenuPlotLine任务.Enabled = false;
                    }
                    MenuPlotLine.Tag = sItem;
                }
                MenuPlotLine.Show(listView1, e.X, e.Y);
            }
        }
        /// <summary>
        /// 加载流水线列表
        /// </summary>
        /// <param name="plotWaterLine"></param>
        private void LoadPlotWaterLineItem(PlotWaterLine pWaterLine)
        {
            PlotLineState sLineState = pWaterLine.LineState;
            ListViewItem sItem = new ListViewItem(pWaterLine.Name, sLineState.State);
            sItem.Group = listView1.Groups[pWaterLine.Group];
            sItem.SubItems.Add(pWaterLine.BaseURL);
            sItem.SubItems.Add(pWaterLine.Method);
            sItem.SubItems.Add(pWaterLine.Chaset);
            if (pWaterLine.PageFeild != null) { sItem.SubItems.Add("是"); } else { sItem.SubItems.Add(""); };
            if (pWaterLine.AutoStart)
            {
                sItem.SubItems.Add("是");
                sItem.SubItems.Add(pWaterLine.CanStartDate.ToString("yyyy-MM-dd HH:mm"));
                sItem.SubItems.Add(pWaterLine.RunSpan.ToString());
            }
            else
            {
                sItem.SubItems.Add("否");
                sItem.SubItems.Add("");
                sItem.SubItems.Add("");
            }
            sItem.SubItems.Add(sLineState.WaitTaskCount.ToString());       //待发任务
            sItem.SubItems.Add(sLineState.OnlineTaskCount.ToString());     //已发待收
            sItem.SubItems.Add(sLineState.LocalWaitCount.ToString());      //本缓待处
            sItem.SubItems.Add(sLineState.WaitDrillCount.ToString());      //已收待处
            sItem.SubItems.Add(sLineState.TotalRecieved.ToString());       //累计完成
            sItem.SubItems.Add(sLineState.DrillWaitSaveCount.ToString());  //已处待存
            sItem.SubItems.Add(sLineState.LastProduceDt.ToString("yyyy-MM-dd HH:mm:ss"));   //最近提交任务时间
            sItem.SubItems.Add(sLineState.ErrCount.ToString());            //诊断信息

            sItem.Tag = pWaterLine;

            listView1.Items.Add(sItem);
        }
        
        private void MenuPlotLine启动_Click(object sender, EventArgs e)
        {
            if (MenuPlotLine.Tag != null)
            {
                if (treeV.SelectedNode != null && treeV.SelectedNode.ImageIndex == 2)
                {
                    PlotWaterLine sPlotLine = (PlotWaterLine)((ListViewItem)MenuPlotLine.Tag).Tag;
                    sPlotLine.Start();
                }
            }
        }

        
        /// <summary>
        /// 加载专案列表
        /// </summary>
        /// <param name="pNode"></param>
        private void LoadPlotItem(TreeNode pNode, ListViewGroup pGroup)
        {
            if (pNode.ImageIndex == 2)
            {
                OpenPlot sPlot = (OpenPlot)pNode.Tag;
                ListViewItem sItem = new ListViewItem(sPlot.Name, 2);
                sItem.SubItems.Add(sPlot.HomePage);
                sItem.SubItems.Add(sPlot.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                sItem.SubItems.Add(sPlot.Creator);
                sItem.SubItems.Add(sPlot.Info);
                sItem.Tag = sPlot;
                //LView2.Items.Add(sItem);
                sItem.Group = pGroup;
            }
            else
            {
                ListViewGroup sListViewGroup = new ListViewGroup(pNode.FullPath);
                //LView2.Groups.Add(sListViewGroup);
                for (int i = 0; i < pNode.Nodes.Count; i++)
                {
                    LoadPlotItem(pNode.Nodes[i], sListViewGroup);
                }
            }
        }
    }
}
