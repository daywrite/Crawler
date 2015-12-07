namespace Lwb.Crawler.Center.Crawl.Design
{
    partial class FrmRuntime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRuntime));
            this.label12 = new System.Windows.Forms.Label();
            this.TxtPlugCode = new System.Windows.Forms.ComboBox();
            this.tabLinePage = new System.Windows.Forms.TabPage();
            this.TView = new System.Windows.Forms.TreeView();
            this.img2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.NumBagLifeSpan = new System.Windows.Forms.NumericUpDown();
            this.NumBagSize = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.Img = new System.Windows.Forms.ImageList(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.Menu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.num重试次数 = new System.Windows.Forms.NumericUpDown();
            this.ChkCanUseExistData = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkAuto = new System.Windows.Forms.CheckBox();
            this.panelAuto = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumPeriod = new System.Windows.Forms.NumericUpDown();
            this.NumMaxThread = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ChkAllowCache = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtMemo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.ChkAllowUrlRepeatable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NumMinDelay = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.NumMaxDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbPRI = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CmbUserAgent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLinePage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumBagLifeSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBagSize)).BeginInit();
            this.Menu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num重试次数)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxThread)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxDelay)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "出错重试：";
            // 
            // TxtPlugCode
            // 
            this.TxtPlugCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtPlugCode.FormattingEnabled = true;
            this.TxtPlugCode.Location = new System.Drawing.Point(76, 11);
            this.TxtPlugCode.Name = "TxtPlugCode";
            this.TxtPlugCode.Size = new System.Drawing.Size(143, 20);
            this.TxtPlugCode.TabIndex = 43;
            // 
            // tabLinePage
            // 
            this.tabLinePage.Controls.Add(this.TView);
            this.tabLinePage.Location = new System.Drawing.Point(4, 32);
            this.tabLinePage.Name = "tabLinePage";
            this.tabLinePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabLinePage.Size = new System.Drawing.Size(407, 461);
            this.tabLinePage.TabIndex = 1;
            this.tabLinePage.Text = "生产线配置";
            this.tabLinePage.UseVisualStyleBackColor = true;
            // 
            // TView
            // 
            this.TView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TView.FullRowSelect = true;
            this.TView.HideSelection = false;
            this.TView.ImageIndex = 0;
            this.TView.ImageList = this.img2;
            this.TView.ItemHeight = 16;
            this.TView.Location = new System.Drawing.Point(3, 3);
            this.TView.Name = "TView";
            this.TView.SelectedImageIndex = 0;
            this.TView.Size = new System.Drawing.Size(401, 455);
            this.TView.TabIndex = 2;
            // 
            // img2
            // 
            this.img2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img2.ImageStream")));
            this.img2.TransparentColor = System.Drawing.Color.Transparent;
            this.img2.Images.SetKeyName(0, "");
            this.img2.Images.SetKeyName(1, "");
            this.img2.Images.SetKeyName(2, "");
            this.img2.Images.SetKeyName(3, "");
            this.img2.Images.SetKeyName(4, "");
            this.img2.Images.SetKeyName(5, "");
            this.img2.Images.SetKeyName(6, "");
            this.img2.Images.SetKeyName(7, "");
            this.img2.Images.SetKeyName(8, "");
            this.img2.Images.SetKeyName(9, "");
            this.img2.Images.SetKeyName(10, "");
            this.img2.Images.SetKeyName(11, "");
            this.img2.Images.SetKeyName(12, "");
            this.img2.Images.SetKeyName(13, "");
            this.img2.Images.SetKeyName(14, "");
            this.img2.Images.SetKeyName(15, "");
            this.img2.Images.SetKeyName(16, "");
            this.img2.Images.SetKeyName(17, "");
            this.img2.Images.SetKeyName(18, "");
            this.img2.Images.SetKeyName(19, "");
            this.img2.Images.SetKeyName(20, "");
            this.img2.Images.SetKeyName(21, "");
            this.img2.Images.SetKeyName(22, "");
            this.img2.Images.SetKeyName(23, "");
            this.img2.Images.SetKeyName(24, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.NumBagLifeSpan);
            this.groupBox1.Controls.Add(this.NumBagSize);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(5, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 57);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任 务 包：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "大小：";
            // 
            // NumBagLifeSpan
            // 
            this.NumBagLifeSpan.Location = new System.Drawing.Point(201, 22);
            this.NumBagLifeSpan.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.NumBagLifeSpan.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumBagLifeSpan.Name = "NumBagLifeSpan";
            this.NumBagLifeSpan.Size = new System.Drawing.Size(59, 21);
            this.NumBagLifeSpan.TabIndex = 32;
            this.NumBagLifeSpan.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NumBagSize
            // 
            this.NumBagSize.Location = new System.Drawing.Point(77, 22);
            this.NumBagSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumBagSize.Name = "NumBagSize";
            this.NumBagSize.Size = new System.Drawing.Size(59, 21);
            this.NumBagSize.TabIndex = 31;
            this.NumBagSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(142, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "生存期：";
            // 
            // Img
            // 
            this.Img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img.ImageStream")));
            this.Img.TransparentColor = System.Drawing.Color.Transparent;
            this.Img.Images.SetKeyName(0, "");
            this.Img.Images.SetKeyName(1, "");
            this.Img.Images.SetKeyName(2, "");
            this.Img.Images.SetKeyName(3, "NET14.ICO");
            this.Img.Images.SetKeyName(4, "");
            this.Img.Images.SetKeyName(5, "文件.png");
            this.Img.Images.SetKeyName(6, "");
            this.Img.Images.SetKeyName(7, "");
            this.Img.Images.SetKeyName(8, "");
            this.Img.Images.SetKeyName(9, "div.bmp");
            this.Img.Images.SetKeyName(10, "");
            this.Img.Images.SetKeyName(11, "");
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(295, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(101, 29);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "关闭窗口";
            // 
            // Menu2
            // 
            this.Menu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEdit,
            this.toolStripMenuItem1,
            this.MenuDelete});
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(101, 54);
            // 
            // MenuEdit
            // 
            this.MenuEdit.Name = "MenuEdit";
            this.MenuEdit.Size = new System.Drawing.Size(100, 22);
            this.MenuEdit.Text = "编辑";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(100, 22);
            this.MenuDelete.Text = "删除";
            // 
            // num重试次数
            // 
            this.num重试次数.Location = new System.Drawing.Point(77, 64);
            this.num重试次数.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num重试次数.Name = "num重试次数";
            this.num重试次数.Size = new System.Drawing.Size(61, 21);
            this.num重试次数.TabIndex = 20;
            // 
            // ChkCanUseExistData
            // 
            this.ChkCanUseExistData.AutoSize = true;
            this.ChkCanUseExistData.Checked = true;
            this.ChkCanUseExistData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkCanUseExistData.Location = new System.Drawing.Point(236, 40);
            this.ChkCanUseExistData.Name = "ChkCanUseExistData";
            this.ChkCanUseExistData.Size = new System.Drawing.Size(96, 16);
            this.ChkCanUseExistData.TabIndex = 27;
            this.ChkCanUseExistData.Text = "优先使用缓存";
            this.ChkCanUseExistData.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ChkAuto);
            this.groupBox2.Controls.Add(this.panelAuto);
            this.groupBox2.Location = new System.Drawing.Point(5, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 84);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // ChkAuto
            // 
            this.ChkAuto.AutoSize = true;
            this.ChkAuto.Location = new System.Drawing.Point(6, 0);
            this.ChkAuto.Name = "ChkAuto";
            this.ChkAuto.Size = new System.Drawing.Size(72, 16);
            this.ChkAuto.TabIndex = 18;
            this.ChkAuto.Text = "允许调度";
            this.ChkAuto.UseVisualStyleBackColor = true;
            // 
            // panelAuto
            // 
            this.panelAuto.Controls.Add(this.label8);
            this.panelAuto.Controls.Add(this.dateTimePicker1);
            this.panelAuto.Controls.Add(this.label7);
            this.panelAuto.Controls.Add(this.label1);
            this.panelAuto.Controls.Add(this.NumPeriod);
            this.panelAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuto.Enabled = false;
            this.panelAuto.Location = new System.Drawing.Point(3, 17);
            this.panelAuto.Name = "panelAuto";
            this.panelAuto.Size = new System.Drawing.Size(388, 64);
            this.panelAuto.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "分钟";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(110, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(158, 21);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "循环周期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "许可时刻：";
            // 
            // NumPeriod
            // 
            this.NumPeriod.Location = new System.Drawing.Point(110, 37);
            this.NumPeriod.Maximum = new decimal(new int[] {
            10080,
            0,
            0,
            0});
            this.NumPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPeriod.Name = "NumPeriod";
            this.NumPeriod.Size = new System.Drawing.Size(54, 21);
            this.NumPeriod.TabIndex = 1;
            this.NumPeriod.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // NumMaxThread
            // 
            this.NumMaxThread.Location = new System.Drawing.Point(77, 121);
            this.NumMaxThread.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.NumMaxThread.Name = "NumMaxThread";
            this.NumMaxThread.Size = new System.Drawing.Size(61, 21);
            this.NumMaxThread.TabIndex = 38;
            this.NumMaxThread.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "分发限制：";
            // 
            // ChkAllowCache
            // 
            this.ChkAllowCache.AutoSize = true;
            this.ChkAllowCache.Checked = true;
            this.ChkAllowCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAllowCache.Location = new System.Drawing.Point(146, 39);
            this.ChkAllowCache.Name = "ChkAllowCache";
            this.ChkAllowCache.Size = new System.Drawing.Size(72, 16);
            this.ChkAllowCache.TabIndex = 36;
            this.ChkAllowCache.Text = "缓存页面";
            this.ChkAllowCache.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TxtMemo);
            this.groupBox3.Location = new System.Drawing.Point(5, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 103);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "备注说明：";
            // 
            // TxtMemo
            // 
            this.TxtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMemo.Location = new System.Drawing.Point(3, 17);
            this.TxtMemo.Multiline = true;
            this.TxtMemo.Name = "TxtMemo";
            this.TxtMemo.Size = new System.Drawing.Size(388, 83);
            this.TxtMemo.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtPlugCode);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 499);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 41);
            this.panel2.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 42;
            this.label11.Text = "插件代码：";
            // 
            // ChkAllowUrlRepeatable
            // 
            this.ChkAllowUrlRepeatable.AutoSize = true;
            this.ChkAllowUrlRepeatable.Checked = true;
            this.ChkAllowUrlRepeatable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAllowUrlRepeatable.Location = new System.Drawing.Point(146, 64);
            this.ChkAllowUrlRepeatable.Name = "ChkAllowUrlRepeatable";
            this.ChkAllowUrlRepeatable.Size = new System.Drawing.Size(72, 16);
            this.ChkAllowUrlRepeatable.TabIndex = 26;
            this.ChkAllowUrlRepeatable.Text = "允许重抓";
            this.ChkAllowUrlRepeatable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "延时范围：";
            // 
            // NumMinDelay
            // 
            this.NumMinDelay.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumMinDelay.Location = new System.Drawing.Point(77, 92);
            this.NumMinDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.NumMinDelay.Name = "NumMinDelay";
            this.NumMinDelay.Size = new System.Drawing.Size(61, 21);
            this.NumMinDelay.TabIndex = 8;
            this.NumMinDelay.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(140, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "-";
            // 
            // NumMaxDelay
            // 
            this.NumMaxDelay.Location = new System.Drawing.Point(154, 92);
            this.NumMaxDelay.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.NumMaxDelay.Name = "NumMaxDelay";
            this.NumMaxDelay.Size = new System.Drawing.Size(61, 21);
            this.NumMaxDelay.TabIndex = 10;
            this.NumMaxDelay.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "毫秒";
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.Location = new System.Drawing.Point(77, 9);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(322, 21);
            this.TxtName.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "名    称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "优 先 级：";
            // 
            // CmbPRI
            // 
            this.CmbPRI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPRI.FormattingEnabled = true;
            this.CmbPRI.Items.AddRange(new object[] {
            "低",
            "中",
            "高"});
            this.CmbPRI.Location = new System.Drawing.Point(77, 37);
            this.CmbPRI.Name = "CmbPRI";
            this.CmbPRI.Size = new System.Drawing.Size(61, 20);
            this.CmbPRI.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.NumMaxThread);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.ChkAllowCache);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.ChkCanUseExistData);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.num重试次数);
            this.tabPage1.Controls.Add(this.ChkAllowUrlRepeatable);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.NumMinDelay);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.NumMaxDelay);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TxtName);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CmbUserAgent);
            this.tabPage1.Controls.Add(this.CmbPRI);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CmbUserAgent
            // 
            this.CmbUserAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbUserAgent.FormattingEnabled = true;
            this.CmbUserAgent.Items.AddRange(new object[] {
            "mozilla/4.0 (compatible; msie 8.0; windows nt 5.1; trident/4.0; .net clr 1.1.4322" +
                "; .net clr 2.0.50727; .net4.0c)",
            "mozilla/5.0 (compatible; baiduspider/2.0; +http://www.baidu.com/search/spider.htm" +
                "l)",
            "mozilla/5.0 (compatible; googlebot/2.1; +http://www.google.com/bot.html)",
            "mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)",
            "mozilla/5.0 (compatible; easouspider; +http://www.easou.com/search/spider.html)",
            "mozilla/5.0 (compatible; ahrefsbot/5.0; +http://ahrefs.com/robot/)",
            "sogou web spider/4.0(+http://www.sogou.com/docs/help/webmasters.htm#07)"});
            this.CmbUserAgent.Location = new System.Drawing.Point(77, 150);
            this.CmbUserAgent.Name = "CmbUserAgent";
            this.CmbUserAgent.Size = new System.Drawing.Size(318, 20);
            this.CmbUserAgent.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户代理：";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabLinePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 28);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(415, 538);
            this.tabControl1.TabIndex = 42;
            // 
            // FrmRuntime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 542);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(421, 544);
            this.Name = "FrmRuntime";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产流水线设置";
            this.tabLinePage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumBagLifeSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBagSize)).EndInit();
            this.Menu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num重试次数)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelAuto.ResumeLayout(false);
            this.panelAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxThread)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxDelay)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox TxtPlugCode;
        private System.Windows.Forms.TabPage tabLinePage;
        private System.Windows.Forms.TreeView TView;
        private System.Windows.Forms.ImageList img2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown NumBagLifeSpan;
        private System.Windows.Forms.NumericUpDown NumBagSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ImageList Img;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenuStrip Menu2;
        private System.Windows.Forms.ToolStripMenuItem MenuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.NumericUpDown num重试次数;
        private System.Windows.Forms.CheckBox ChkCanUseExistData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkAuto;
        private System.Windows.Forms.Panel panelAuto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumPeriod;
        private System.Windows.Forms.NumericUpDown NumMaxThread;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkAllowCache;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtMemo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ChkAllowUrlRepeatable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumMinDelay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NumMaxDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbPRI;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox CmbUserAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
    }
}