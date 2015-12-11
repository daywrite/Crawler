namespace Lwb.Crawler.Center.Server.Main
{
    partial class frmPageManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPageManage));
            CCWin.SkinControl.Animation animation1 = new CCWin.SkinControl.Animation();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("网页生产线", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("下载生产线", System.Windows.Forms.HorizontalAlignment.Left);
            CCWin.SkinControl.Animation animation2 = new CCWin.SkinControl.Animation();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeV = new System.Windows.Forms.TreeView();
            this.treeView = new System.Windows.Forms.ImageList(this.components);
            this.tabPlot = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column生产线名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column基础网址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column方法 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column字符集 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column动态页数 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column自动调度 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column最早启动时刻 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column循环周期 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column常规待发 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column已发待收 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column本缓待处 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column已收待处 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column累计完成 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column已处待存 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column最近提交任务时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column诊断信息 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListPlotLine = new System.Windows.Forms.ImageList(this.components);
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MenuPlotGroup = new CCWin.SkinControl.SkinContextMenuStrip();
            this.MenuGroupPlotNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuGroupFloderNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGroupFloderDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine = new CCWin.SkinControl.SkinContextMenuStrip();
            this.MenuPlotLine添加 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine添加网页生产线 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine添加下载生产线 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine修改提取配置 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPlotLine编辑 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine任务 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine批量注入 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine手动生成 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPlotLine启动 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine停止 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine重置 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPlotLine全部启动 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlotLine全部停止 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPlotLine删除 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPlot.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.skinTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.MenuPlotGroup.SuspendLayout();
            this.MenuPlotLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPlot);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 638);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeV
            // 
            this.treeV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeV.ImageIndex = 0;
            this.treeV.ImageList = this.treeView;
            this.treeV.Location = new System.Drawing.Point(0, 0);
            this.treeV.Name = "treeV";
            this.treeV.SelectedImageIndex = 0;
            this.treeV.Size = new System.Drawing.Size(177, 638);
            this.treeV.TabIndex = 0;
            this.treeV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeV_AfterSelect);
            this.treeV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeV_MouseDown);
            // 
            // treeView
            // 
            this.treeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeView.ImageStream")));
            this.treeView.TransparentColor = System.Drawing.Color.Transparent;
            this.treeView.Images.SetKeyName(0, "Project_2013_16px_1180167_easyicon.net.png");
            this.treeView.Images.SetKeyName(1, "download_folder_16px_1145712_easyicon.net.png");
            this.treeView.Images.SetKeyName(2, "file_download_16px_1181849_easyicon.net.png");
            // 
            // tabPlot
            // 
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 2F;
            animation1.TransparencyCoeff = 0F;
            this.tabPlot.Animation = animation1;
            this.tabPlot.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tabPlot.BackColor = System.Drawing.Color.MediumAquamarine;
            this.tabPlot.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabPlot.Controls.Add(this.tabPage1);
            this.tabPlot.Controls.Add(this.tabPage2);
            this.tabPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPlot.ItemSize = new System.Drawing.Size(70, 36);
            this.tabPlot.Location = new System.Drawing.Point(0, 0);
            this.tabPlot.Name = "tabPlot";
            this.tabPlot.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabPlot.PageArrowDown")));
            this.tabPlot.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabPlot.PageArrowHover")));
            this.tabPlot.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabPlot.PageCloseHover")));
            this.tabPlot.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabPlot.PageCloseNormal")));
            this.tabPlot.PageDown = ((System.Drawing.Image)(resources.GetObject("tabPlot.PageDown")));
            this.tabPlot.PageHover = ((System.Drawing.Image)(resources.GetObject("tabPlot.PageHover")));
            this.tabPlot.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tabPlot.PageNorml = null;
            this.tabPlot.SelectedIndex = 0;
            this.tabPlot.Size = new System.Drawing.Size(842, 638);
            this.tabPlot.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPlot.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(0, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(842, 602);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " 生产流水线";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.skinTabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(836, 596);
            this.splitContainer2.SplitterDistance = 281;
            this.splitContainer2.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column生产线名称,
            this.column基础网址,
            this.column方法,
            this.column字符集,
            this.column动态页数,
            this.column自动调度,
            this.column最早启动时刻,
            this.column循环周期,
            this.column常规待发,
            this.column已发待收,
            this.column本缓待处,
            this.column已收待处,
            this.column累计完成,
            this.column已处待存,
            this.column最近提交任务时间,
            this.column诊断信息});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            listViewGroup1.Header = "网页生产线";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "下载生产线";
            listViewGroup2.Name = "listViewGroup2";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(836, 281);
            this.listView1.SmallImageList = this.imageListPlotLine;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // column生产线名称
            // 
            this.column生产线名称.Text = "生产线名称";
            this.column生产线名称.Width = 200;
            // 
            // column基础网址
            // 
            this.column基础网址.Text = "基础网址";
            this.column基础网址.Width = 120;
            // 
            // column方法
            // 
            this.column方法.Text = "方法";
            this.column方法.Width = 40;
            // 
            // column字符集
            // 
            this.column字符集.Text = "字符集";
            this.column字符集.Width = 50;
            // 
            // column动态页数
            // 
            this.column动态页数.Text = "动态页数";
            this.column动态页数.Width = 65;
            // 
            // column自动调度
            // 
            this.column自动调度.Text = "自动调度";
            this.column自动调度.Width = 65;
            // 
            // column最早启动时刻
            // 
            this.column最早启动时刻.Text = "最早启动时刻";
            this.column最早启动时刻.Width = 120;
            // 
            // column循环周期
            // 
            this.column循环周期.Text = "循环周期";
            // 
            // column常规待发
            // 
            this.column常规待发.Text = "常规待发";
            this.column常规待发.Width = 70;
            // 
            // column已发待收
            // 
            this.column已发待收.Text = "已发待收";
            this.column已发待收.Width = 70;
            // 
            // column本缓待处
            // 
            this.column本缓待处.Text = "本缓待处";
            this.column本缓待处.Width = 70;
            // 
            // column已收待处
            // 
            this.column已收待处.Text = "已收待处";
            this.column已收待处.Width = 70;
            // 
            // column累计完成
            // 
            this.column累计完成.Text = "累计完成";
            this.column累计完成.Width = 80;
            // 
            // column已处待存
            // 
            this.column已处待存.Text = "已处待存";
            this.column已处待存.Width = 70;
            // 
            // column最近提交任务时间
            // 
            this.column最近提交任务时间.Text = "最近提交任务时间";
            this.column最近提交任务时间.Width = 140;
            // 
            // column诊断信息
            // 
            this.column诊断信息.Text = "诊断信息";
            this.column诊断信息.Width = 65;
            // 
            // imageListPlotLine
            // 
            this.imageListPlotLine.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPlotLine.ImageStream")));
            this.imageListPlotLine.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPlotLine.Images.SetKeyName(0, "start_24px_1069976_easyicon.net.png");
            this.imageListPlotLine.Images.SetKeyName(1, "stop_512px_568811_easyicon.net.png");
            // 
            // skinTabControl1
            // 
            animation2.AnimateOnlyDifferences = false;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 2F;
            animation2.TransparencyCoeff = 0F;
            this.skinTabControl1.Animation = animation2;
            this.skinTabControl1.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.skinTabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.skinTabControl1.Controls.Add(this.tabPage3);
            this.skinTabControl1.Controls.Add(this.tabPage4);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
            this.skinTabControl1.Location = new System.Drawing.Point(0, 0);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowDown")));
            this.skinTabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowHover")));
            this.skinTabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseHover")));
            this.skinTabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseNormal")));
            this.skinTabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageDown")));
            this.skinTabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageHover")));
            this.skinTabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.skinTabControl1.PageNorml = null;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(836, 311);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(0, 36);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(836, 275);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "诊断信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Margin = new System.Windows.Forms.Padding(0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(830, 269);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "诊断信息";
            this.columnHeader8.Width = 300;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "数量";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "状态";
            this.columnHeader10.Width = 100;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(0, 36);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(836, 275);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "生产线说明";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(842, 602);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预留";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MenuPlotGroup
            // 
            this.MenuPlotGroup.Arrow = System.Drawing.Color.Black;
            this.MenuPlotGroup.Back = System.Drawing.Color.White;
            this.MenuPlotGroup.BackRadius = 4;
            this.MenuPlotGroup.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.MenuPlotGroup.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MenuPlotGroup.Fore = System.Drawing.Color.Black;
            this.MenuPlotGroup.HoverFore = System.Drawing.Color.White;
            this.MenuPlotGroup.ItemAnamorphosis = true;
            this.MenuPlotGroup.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotGroup.ItemBorderShow = true;
            this.MenuPlotGroup.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotGroup.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotGroup.ItemRadius = 4;
            this.MenuPlotGroup.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.MenuPlotGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGroupPlotNew,
            this.toolStripSeparator1,
            this.MenuGroupFloderNew,
            this.MenuGroupFloderDelete});
            this.MenuPlotGroup.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotGroup.Name = "MenuPlotGroup";
            this.MenuPlotGroup.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.MenuPlotGroup.Size = new System.Drawing.Size(125, 76);
            this.MenuPlotGroup.SkinAllColor = true;
            this.MenuPlotGroup.TitleAnamorphosis = true;
            this.MenuPlotGroup.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.MenuPlotGroup.TitleRadius = 4;
            this.MenuPlotGroup.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // MenuGroupPlotNew
            // 
            this.MenuGroupPlotNew.Name = "MenuGroupPlotNew";
            this.MenuGroupPlotNew.Size = new System.Drawing.Size(124, 22);
            this.MenuGroupPlotNew.Text = "新建专案";
            this.MenuGroupPlotNew.Click += new System.EventHandler(this.MenuGroupPlotNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // MenuGroupFloderNew
            // 
            this.MenuGroupFloderNew.Name = "MenuGroupFloderNew";
            this.MenuGroupFloderNew.Size = new System.Drawing.Size(124, 22);
            this.MenuGroupFloderNew.Text = "新建组";
            this.MenuGroupFloderNew.Click += new System.EventHandler(this.MenuGroupFloderNew_Click);
            // 
            // MenuGroupFloderDelete
            // 
            this.MenuGroupFloderDelete.Name = "MenuGroupFloderDelete";
            this.MenuGroupFloderDelete.Size = new System.Drawing.Size(124, 22);
            this.MenuGroupFloderDelete.Text = "删除组";
            // 
            // MenuPlotLine
            // 
            this.MenuPlotLine.Arrow = System.Drawing.Color.Black;
            this.MenuPlotLine.Back = System.Drawing.Color.White;
            this.MenuPlotLine.BackRadius = 4;
            this.MenuPlotLine.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.MenuPlotLine.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.MenuPlotLine.Fore = System.Drawing.Color.Black;
            this.MenuPlotLine.HoverFore = System.Drawing.Color.White;
            this.MenuPlotLine.ItemAnamorphosis = true;
            this.MenuPlotLine.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotLine.ItemBorderShow = true;
            this.MenuPlotLine.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotLine.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotLine.ItemRadius = 4;
            this.MenuPlotLine.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.MenuPlotLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPlotLine添加,
            this.MenuPlotLine修改提取配置,
            this.toolStripSeparator2,
            this.MenuPlotLine编辑,
            this.MenuPlotLine任务,
            this.toolStripSeparator3,
            this.MenuPlotLine启动,
            this.MenuPlotLine停止,
            this.MenuPlotLine重置,
            this.toolStripSeparator4,
            this.MenuPlotLine全部启动,
            this.MenuPlotLine全部停止,
            this.toolStripSeparator5,
            this.MenuPlotLine删除});
            this.MenuPlotLine.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.MenuPlotLine.Name = "MenuPlotLine";
            this.MenuPlotLine.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.MenuPlotLine.Size = new System.Drawing.Size(149, 248);
            this.MenuPlotLine.SkinAllColor = true;
            this.MenuPlotLine.TitleAnamorphosis = true;
            this.MenuPlotLine.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.MenuPlotLine.TitleRadius = 4;
            this.MenuPlotLine.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // MenuPlotLine添加
            // 
            this.MenuPlotLine添加.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPlotLine添加网页生产线,
            this.MenuPlotLine添加下载生产线});
            this.MenuPlotLine添加.Name = "MenuPlotLine添加";
            this.MenuPlotLine添加.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine添加.Text = "添加";
            // 
            // MenuPlotLine添加网页生产线
            // 
            this.MenuPlotLine添加网页生产线.Name = "MenuPlotLine添加网页生产线";
            this.MenuPlotLine添加网页生产线.Size = new System.Drawing.Size(160, 22);
            this.MenuPlotLine添加网页生产线.Text = "添加网页生产线";
            this.MenuPlotLine添加网页生产线.Click += new System.EventHandler(this.MenuPlotLine添加网页生产线_Click);
            // 
            // MenuPlotLine添加下载生产线
            // 
            this.MenuPlotLine添加下载生产线.Name = "MenuPlotLine添加下载生产线";
            this.MenuPlotLine添加下载生产线.Size = new System.Drawing.Size(160, 22);
            this.MenuPlotLine添加下载生产线.Text = "添加下载生产线";
            // 
            // MenuPlotLine修改提取配置
            // 
            this.MenuPlotLine修改提取配置.Name = "MenuPlotLine修改提取配置";
            this.MenuPlotLine修改提取配置.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine修改提取配置.Text = "修改提取配置";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuPlotLine编辑
            // 
            this.MenuPlotLine编辑.Name = "MenuPlotLine编辑";
            this.MenuPlotLine编辑.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine编辑.Text = "运行时设置";
            // 
            // MenuPlotLine任务
            // 
            this.MenuPlotLine任务.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPlotLine批量注入,
            this.MenuPlotLine手动生成});
            this.MenuPlotLine任务.Name = "MenuPlotLine任务";
            this.MenuPlotLine任务.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine任务.Text = "任务";
            // 
            // MenuPlotLine批量注入
            // 
            this.MenuPlotLine批量注入.Name = "MenuPlotLine批量注入";
            this.MenuPlotLine批量注入.Size = new System.Drawing.Size(124, 22);
            this.MenuPlotLine批量注入.Text = "批量注入";
            // 
            // MenuPlotLine手动生成
            // 
            this.MenuPlotLine手动生成.Name = "MenuPlotLine手动生成";
            this.MenuPlotLine手动生成.Size = new System.Drawing.Size(124, 22);
            this.MenuPlotLine手动生成.Text = "手动生成";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuPlotLine启动
            // 
            this.MenuPlotLine启动.Name = "MenuPlotLine启动";
            this.MenuPlotLine启动.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine启动.Text = "启动";
            this.MenuPlotLine启动.Click += new System.EventHandler(this.MenuPlotLine启动_Click);
            // 
            // MenuPlotLine停止
            // 
            this.MenuPlotLine停止.Name = "MenuPlotLine停止";
            this.MenuPlotLine停止.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine停止.Text = "停止";
            this.MenuPlotLine停止.Click += new System.EventHandler(this.MenuPlotLine停止_Click);
            // 
            // MenuPlotLine重置
            // 
            this.MenuPlotLine重置.Name = "MenuPlotLine重置";
            this.MenuPlotLine重置.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine重置.Text = "重置";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuPlotLine全部启动
            // 
            this.MenuPlotLine全部启动.Name = "MenuPlotLine全部启动";
            this.MenuPlotLine全部启动.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine全部启动.Text = "全部启动";
            // 
            // MenuPlotLine全部停止
            // 
            this.MenuPlotLine全部停止.Name = "MenuPlotLine全部停止";
            this.MenuPlotLine全部停止.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine全部停止.Text = "全部停止";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuPlotLine删除
            // 
            this.MenuPlotLine删除.Name = "MenuPlotLine删除";
            this.MenuPlotLine删除.Size = new System.Drawing.Size(148, 22);
            this.MenuPlotLine删除.Text = "删除";
            // 
            // frmPageManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 638);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPageManage";
            this.Text = "frmPageManage";
            this.Load += new System.EventHandler(this.frmPageManage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPlot.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.skinTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.MenuPlotGroup.ResumeLayout(false);
            this.MenuPlotLine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeV;
        private System.Windows.Forms.ImageList treeView;
        private CCWin.SkinControl.SkinContextMenuStrip MenuPlotGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuGroupPlotNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuGroupFloderNew;
        private System.Windows.Forms.ToolStripMenuItem MenuGroupFloderDelete;
        private CCWin.SkinControl.SkinTabControl tabPlot;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageListPlotLine;
        private System.Windows.Forms.ColumnHeader column生产线名称;
        private System.Windows.Forms.ColumnHeader column基础网址;
        private System.Windows.Forms.ColumnHeader column方法;
        private System.Windows.Forms.ColumnHeader column字符集;
        private System.Windows.Forms.ColumnHeader column动态页数;
        private System.Windows.Forms.ColumnHeader column自动调度;
        private System.Windows.Forms.ColumnHeader column最早启动时刻;
        private System.Windows.Forms.ColumnHeader column循环周期;
        private System.Windows.Forms.ColumnHeader column常规待发;
        private System.Windows.Forms.ColumnHeader column已发待收;
        private System.Windows.Forms.ColumnHeader column本缓待处;
        private System.Windows.Forms.ColumnHeader column已收待处;
        private System.Windows.Forms.ColumnHeader column累计完成;
        private System.Windows.Forms.ColumnHeader column已处待存;
        private System.Windows.Forms.ColumnHeader column最近提交任务时间;
        private System.Windows.Forms.ColumnHeader column诊断信息;
        private CCWin.SkinControl.SkinTabControl skinTabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private CCWin.SkinControl.SkinContextMenuStrip MenuPlotLine;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine添加;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine修改提取配置;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine编辑;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine任务;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine启动;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine停止;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine重置;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine全部启动;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine全部停止;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine删除;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine添加网页生产线;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine添加下载生产线;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine批量注入;
        private System.Windows.Forms.ToolStripMenuItem MenuPlotLine手动生成;
    }
}