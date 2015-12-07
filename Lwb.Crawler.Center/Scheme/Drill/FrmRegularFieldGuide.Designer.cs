namespace Lwb.Crawler.Center.Scheme.Drill
{
    partial class FrmRegularFieldGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegularFieldGuide));
            this.MenuField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuFieldDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtResult = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtReplace = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Chk清理Html标签 = new System.Windows.Forms.CheckBox();
            this.Chk移除空白 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkEndTag = new System.Windows.Forms.LinkLabel();
            this.linkStartTag = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkFindGroupEndTag = new System.Windows.Forms.LinkLabel();
            this.linkFindGroupTag = new System.Windows.Forms.LinkLabel();
            this.CmbGroupEndTag = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkRepeatable = new System.Windows.Forms.CheckBox();
            this.CmbGroupTag = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtEndTag = new System.Windows.Forms.TextBox();
            this.TxtStartTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.TabWindow = new System.Windows.Forms.TabControl();
            this.TxtHtml = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnHtmlNext = new System.Windows.Forms.Button();
            this.btnHtmlFirst = new System.Windows.Forms.Button();
            this.TxtFindWord = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.TxtCurrent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.linkMeta = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.TxtMeta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TViewFeild = new System.Windows.Forms.TreeView();
            this.Img = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MenuField.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.TabWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuField
            // 
            this.MenuField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFieldDelete});
            this.MenuField.Name = "MenuHtml";
            this.MenuField.Size = new System.Drawing.Size(153, 48);
            // 
            // MenuFieldDelete
            // 
            this.MenuFieldDelete.Name = "MenuFieldDelete";
            this.MenuFieldDelete.Size = new System.Drawing.Size(152, 22);
            this.MenuFieldDelete.Text = "删除";
            // 
            // TxtResult
            // 
            this.TxtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtResult.Location = new System.Drawing.Point(2, 2);
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(345, 328);
            this.TxtResult.TabIndex = 0;
            this.TxtResult.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(354, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "提取设置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtReplace);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 175);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内容替换处理：(每行一对，Tab分隔)";
            // 
            // TxtReplace
            // 
            this.TxtReplace.AcceptsTab = true;
            this.TxtReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtReplace.EnableAutoDragDrop = true;
            this.TxtReplace.Location = new System.Drawing.Point(3, 49);
            this.TxtReplace.Name = "TxtReplace";
            this.TxtReplace.Size = new System.Drawing.Size(348, 123);
            this.TxtReplace.TabIndex = 0;
            this.TxtReplace.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Chk清理Html标签);
            this.panel1.Controls.Add(this.Chk移除空白);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 32);
            this.panel1.TabIndex = 1;
            // 
            // Chk清理Html标签
            // 
            this.Chk清理Html标签.AutoSize = true;
            this.Chk清理Html标签.Checked = true;
            this.Chk清理Html标签.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk清理Html标签.Location = new System.Drawing.Point(17, 10);
            this.Chk清理Html标签.Name = "Chk清理Html标签";
            this.Chk清理Html标签.Size = new System.Drawing.Size(132, 16);
            this.Chk清理Html标签.TabIndex = 42;
            this.Chk清理Html标签.Text = "替换前清理Html标签";
            this.Chk清理Html标签.UseVisualStyleBackColor = true;
            // 
            // Chk移除空白
            // 
            this.Chk移除空白.AutoSize = true;
            this.Chk移除空白.Location = new System.Drawing.Point(155, 10);
            this.Chk移除空白.Name = "Chk移除空白";
            this.Chk移除空白.Size = new System.Drawing.Size(132, 16);
            this.Chk移除空白.TabIndex = 44;
            this.Chk移除空白.Text = "替换后移除空白字符";
            this.Chk移除空白.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.linkEndTag);
            this.panel3.Controls.Add(this.linkStartTag);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.linkFindGroupEndTag);
            this.panel3.Controls.Add(this.linkFindGroupTag);
            this.panel3.Controls.Add(this.CmbGroupEndTag);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.ChkRepeatable);
            this.panel3.Controls.Add(this.CmbGroupTag);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.TxtEndTag);
            this.panel3.Controls.Add(this.TxtStartTag);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.TxtName);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 157);
            this.panel3.TabIndex = 86;
            // 
            // linkEndTag
            // 
            this.linkEndTag.AutoSize = true;
            this.linkEndTag.Location = new System.Drawing.Point(263, 98);
            this.linkEndTag.Name = "linkEndTag";
            this.linkEndTag.Size = new System.Drawing.Size(23, 12);
            this.linkEndTag.TabIndex = 98;
            this.linkEndTag.TabStop = true;
            this.linkEndTag.Text = "(*)";
            // 
            // linkStartTag
            // 
            this.linkStartTag.AutoSize = true;
            this.linkStartTag.Location = new System.Drawing.Point(263, 69);
            this.linkStartTag.Name = "linkStartTag";
            this.linkStartTag.Size = new System.Drawing.Size(23, 12);
            this.linkStartTag.TabIndex = 97;
            this.linkStartTag.TabStop = true;
            this.linkStartTag.Text = "(*)";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 1);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(290, 68);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(17, 12);
            this.linkLabel1.TabIndex = 94;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "⊙";
            // 
            // linkFindGroupEndTag
            // 
            this.linkFindGroupEndTag.AutoSize = true;
            this.linkFindGroupEndTag.LinkArea = new System.Windows.Forms.LinkArea(0, 1);
            this.linkFindGroupEndTag.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkFindGroupEndTag.Location = new System.Drawing.Point(332, 127);
            this.linkFindGroupEndTag.Name = "linkFindGroupEndTag";
            this.linkFindGroupEndTag.Size = new System.Drawing.Size(17, 12);
            this.linkFindGroupEndTag.TabIndex = 93;
            this.linkFindGroupEndTag.TabStop = true;
            this.linkFindGroupEndTag.Text = "⊙";
            // 
            // linkFindGroupTag
            // 
            this.linkFindGroupTag.AutoSize = true;
            this.linkFindGroupTag.LinkArea = new System.Windows.Forms.LinkArea(0, 1);
            this.linkFindGroupTag.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkFindGroupTag.Location = new System.Drawing.Point(332, 41);
            this.linkFindGroupTag.Name = "linkFindGroupTag";
            this.linkFindGroupTag.Size = new System.Drawing.Size(17, 12);
            this.linkFindGroupTag.TabIndex = 92;
            this.linkFindGroupTag.TabStop = true;
            this.linkFindGroupTag.Text = "⊙";
            // 
            // CmbGroupEndTag
            // 
            this.CmbGroupEndTag.FormattingEnabled = true;
            this.CmbGroupEndTag.Location = new System.Drawing.Point(101, 123);
            this.CmbGroupEndTag.Name = "CmbGroupEndTag";
            this.CmbGroupEndTag.Size = new System.Drawing.Size(228, 20);
            this.CmbGroupEndTag.TabIndex = 91;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 90;
            this.label8.Text = "区块终止标记：";
            // 
            // ChkRepeatable
            // 
            this.ChkRepeatable.Location = new System.Drawing.Point(292, 75);
            this.ChkRepeatable.Name = "ChkRepeatable";
            this.ChkRepeatable.Size = new System.Drawing.Size(60, 29);
            this.ChkRepeatable.TabIndex = 89;
            this.ChkRepeatable.Text = "循环滚动提取多行数据";
            this.ChkRepeatable.UseVisualStyleBackColor = true;
            // 
            // CmbGroupTag
            // 
            this.CmbGroupTag.FormattingEnabled = true;
            this.CmbGroupTag.Location = new System.Drawing.Point(101, 37);
            this.CmbGroupTag.Name = "CmbGroupTag";
            this.CmbGroupTag.Size = new System.Drawing.Size(228, 20);
            this.CmbGroupTag.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 86;
            this.label7.Text = "区块起始标记：";
            // 
            // TxtEndTag
            // 
            this.TxtEndTag.AllowDrop = true;
            this.TxtEndTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEndTag.Location = new System.Drawing.Point(101, 94);
            this.TxtEndTag.Name = "TxtEndTag";
            this.TxtEndTag.Size = new System.Drawing.Size(159, 21);
            this.TxtEndTag.TabIndex = 85;
            // 
            // TxtStartTag
            // 
            this.TxtStartTag.AllowDrop = true;
            this.TxtStartTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtStartTag.Location = new System.Drawing.Point(101, 65);
            this.TxtStartTag.Name = "TxtStartTag";
            this.TxtStartTag.Size = new System.Drawing.Size(159, 21);
            this.TxtStartTag.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 83;
            this.label3.Text = "字段终止标记：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 82;
            this.label4.Text = "字段起始标记：";
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.Location = new System.Drawing.Point(75, 7);
            this.TxtName.Name = "TxtName";
            this.TxtName.ReadOnly = true;
            this.TxtName.Size = new System.Drawing.Size(270, 21);
            this.TxtName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "字 段 名：";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.TxtResult);
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage10.Size = new System.Drawing.Size(349, 332);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "测试输出";
            // 
            // TabWindow
            // 
            this.TabWindow.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabWindow.Controls.Add(this.tabPage10);
            this.TabWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabWindow.ItemSize = new System.Drawing.Size(60, 21);
            this.TabWindow.Location = new System.Drawing.Point(362, 0);
            this.TabWindow.Name = "TabWindow";
            this.TabWindow.SelectedIndex = 0;
            this.TabWindow.Size = new System.Drawing.Size(357, 361);
            this.TabWindow.TabIndex = 34;
            // 
            // TxtHtml
            // 
            this.TxtHtml.BackColor = System.Drawing.Color.White;
            this.TxtHtml.DetectUrls = false;
            this.TxtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtHtml.EnableAutoDragDrop = true;
            this.TxtHtml.HideSelection = false;
            this.TxtHtml.Location = new System.Drawing.Point(0, 29);
            this.TxtHtml.Name = "TxtHtml";
            this.TxtHtml.ReadOnly = true;
            this.TxtHtml.ShowSelectionMargin = true;
            this.TxtHtml.Size = new System.Drawing.Size(893, 164);
            this.TxtHtml.TabIndex = 27;
            this.TxtHtml.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl4);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(905, 633);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl3
            // 
            this.tabControl3.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.ItemSize = new System.Drawing.Size(60, 24);
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.MinimumSize = new System.Drawing.Size(232, 200);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(905, 226);
            this.tabControl3.TabIndex = 32;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.TxtHtml);
            this.tabPage9.Controls.Add(this.panel5);
            this.tabPage9.Location = new System.Drawing.Point(4, 28);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tabPage9.Size = new System.Drawing.Size(897, 194);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "HTML源码";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnHtmlNext);
            this.panel5.Controls.Add(this.btnHtmlFirst);
            this.panel5.Controls.Add(this.TxtFindWord);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.TxtTotal);
            this.panel5.Controls.Add(this.TxtCurrent);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnNext);
            this.panel5.Controls.Add(this.btnPrevious);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(897, 26);
            this.panel5.TabIndex = 26;
            // 
            // btnHtmlNext
            // 
            this.btnHtmlNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHtmlNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHtmlNext.Location = new System.Drawing.Point(843, 3);
            this.btnHtmlNext.Name = "btnHtmlNext";
            this.btnHtmlNext.Size = new System.Drawing.Size(52, 22);
            this.btnHtmlNext.TabIndex = 28;
            this.btnHtmlNext.Text = "下一个";
            this.btnHtmlNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnHtmlFirst
            // 
            this.btnHtmlFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHtmlFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHtmlFirst.Location = new System.Drawing.Point(787, 3);
            this.btnHtmlFirst.Name = "btnHtmlFirst";
            this.btnHtmlFirst.Size = new System.Drawing.Size(52, 22);
            this.btnHtmlFirst.TabIndex = 27;
            this.btnHtmlFirst.Text = "第一个";
            this.btnHtmlFirst.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TxtFindWord
            // 
            this.TxtFindWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFindWord.Location = new System.Drawing.Point(295, 3);
            this.TxtFindWord.Name = "TxtFindWord";
            this.TxtFindWord.Size = new System.Drawing.Size(490, 21);
            this.TxtFindWord.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(253, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "查找：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.SystemColors.Window;
            this.TxtTotal.Location = new System.Drawing.Point(40, 3);
            this.TxtTotal.MaxLength = 3;
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(26, 21);
            this.TxtTotal.TabIndex = 14;
            this.TxtTotal.Text = "10";
            // 
            // TxtCurrent
            // 
            this.TxtCurrent.BackColor = System.Drawing.SystemColors.Window;
            this.TxtCurrent.Location = new System.Drawing.Point(106, 3);
            this.TxtCurrent.MaxLength = 3;
            this.TxtCurrent.Name = "TxtCurrent";
            this.TxtCurrent.ReadOnly = true;
            this.TxtCurrent.Size = new System.Drawing.Size(26, 21);
            this.TxtCurrent.TabIndex = 13;
            this.TxtCurrent.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "总计：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "当前：";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(176, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 21);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "-->>";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(135, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(39, 21);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "<<--";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnRunScript);
            this.panel2.Controls.Add(this.linkMeta);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.TxtMeta);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(77, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 31);
            this.panel2.TabIndex = 44;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(725, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 25);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "关闭窗口";
            // 
            // btnRunScript
            // 
            this.btnRunScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunScript.Location = new System.Drawing.Point(623, 3);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(95, 25);
            this.btnRunScript.TabIndex = 40;
            this.btnRunScript.Text = "执行测试";
            // 
            // linkMeta
            // 
            this.linkMeta.AutoSize = true;
            this.linkMeta.Location = new System.Drawing.Point(395, 8);
            this.linkMeta.Name = "linkMeta";
            this.linkMeta.Size = new System.Drawing.Size(29, 12);
            this.linkMeta.TabIndex = 57;
            this.linkMeta.TabStop = true;
            this.linkMeta.Text = "选择";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(521, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 81;
            this.btnSave.Text = "保存字段配置";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // TxtMeta
            // 
            this.TxtMeta.Location = new System.Drawing.Point(92, 4);
            this.TxtMeta.Name = "TxtMeta";
            this.TxtMeta.ReadOnly = true;
            this.TxtMeta.Size = new System.Drawing.Size(297, 21);
            this.TxtMeta.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 55;
            this.label5.Text = "元数据模板：";
            // 
            // tabControl4
            // 
            this.tabControl4.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl4.Controls.Add(this.tabPage3);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.ItemSize = new System.Drawing.Size(60, 28);
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(905, 403);
            this.tabControl4.TabIndex = 43;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.tabPage3.Size = new System.Drawing.Size(897, 367);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "字段提取";
            this.tabPage3.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(2, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TViewFeild);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TabWindow);
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(893, 361);
            this.splitContainer2.SplitterDistance = 170;
            this.splitContainer2.TabIndex = 43;
            // 
            // TViewFeild
            // 
            this.TViewFeild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TViewFeild.FullRowSelect = true;
            this.TViewFeild.HideSelection = false;
            this.TViewFeild.ImageIndex = 0;
            this.TViewFeild.ImageList = this.Img;
            this.TViewFeild.Indent = 19;
            this.TViewFeild.ItemHeight = 20;
            this.TViewFeild.Location = new System.Drawing.Point(0, 0);
            this.TViewFeild.Name = "TViewFeild";
            this.TViewFeild.SelectedImageIndex = 0;
            this.TViewFeild.Size = new System.Drawing.Size(170, 361);
            this.TViewFeild.TabIndex = 53;
            // 
            // Img
            // 
            this.Img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img.ImageStream")));
            this.Img.TransparentColor = System.Drawing.Color.Transparent;
            this.Img.Images.SetKeyName(0, "");
            this.Img.Images.SetKeyName(1, "");
            this.Img.Images.SetKeyName(2, "");
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Enabled = false;
            this.tabControl1.ItemSize = new System.Drawing.Size(48, 21);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(362, 361);
            this.tabControl1.TabIndex = 43;
            // 
            // FrmRegularFieldGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 633);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmRegularFieldGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文本特征字段提取设置";
            this.MenuField.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.TabWindow.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuField;
        private System.Windows.Forms.ToolStripMenuItem MenuFieldDelete;
        private System.Windows.Forms.RichTextBox TxtResult;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox TxtReplace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox Chk清理Html标签;
        private System.Windows.Forms.CheckBox Chk移除空白;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel linkEndTag;
        private System.Windows.Forms.LinkLabel linkStartTag;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkFindGroupEndTag;
        private System.Windows.Forms.LinkLabel linkFindGroupTag;
        private System.Windows.Forms.ComboBox CmbGroupEndTag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChkRepeatable;
        private System.Windows.Forms.ComboBox CmbGroupTag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtEndTag;
        private System.Windows.Forms.TextBox TxtStartTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabControl TabWindow;
        private System.Windows.Forms.RichTextBox TxtHtml;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnHtmlNext;
        private System.Windows.Forms.Button btnHtmlFirst;
        private System.Windows.Forms.TextBox TxtFindWord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.TextBox TxtCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView TViewFeild;
        private System.Windows.Forms.ImageList Img;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.LinkLabel linkMeta;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox TxtMeta;
        private System.Windows.Forms.Label label5;
    }
}