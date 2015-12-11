namespace Lwb.Crawler.Center.Scheme
{
    partial class FrmPlotWaterLineGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlotWaterLineGuide));
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtHtml = new System.Windows.Forms.RichTextBox();
            this.tPIE = new System.Windows.Forms.TabPage();
            this.MyBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Tab1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DlgNew = new System.Windows.Forms.SaveFileDialog();
            this.DlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.CmbChaset = new System.Windows.Forms.ToolStripComboBox();
            this.CmbMethod = new System.Windows.Forms.ToolStripComboBox();
            this.TbarStart = new System.Windows.Forms.ToolStripButton();
            this.Tbar清洗规则 = new System.Windows.Forms.ToolStripButton();
            this.TbarDrill = new System.Windows.Forms.ToolStripButton();
            this.TBarRuntime = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TBarOk = new System.Windows.Forms.ToolStripButton();
            this.TbarCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabPage1.SuspendLayout();
            this.tPIE.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtAddress
            // 
            this.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAddress.Location = new System.Drawing.Point(70, 5);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(241, 21);
            this.TxtAddress.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtHtml);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(919, 494);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "HTML视图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TxtHtml
            // 
            this.TxtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtHtml.Location = new System.Drawing.Point(3, 3);
            this.TxtHtml.Name = "TxtHtml";
            this.TxtHtml.Size = new System.Drawing.Size(913, 488);
            this.TxtHtml.TabIndex = 0;
            this.TxtHtml.Text = "";
            // 
            // tPIE
            // 
            this.tPIE.BackColor = System.Drawing.SystemColors.Control;
            this.tPIE.Controls.Add(this.MyBrowser1);
            this.tPIE.Location = new System.Drawing.Point(4, 25);
            this.tPIE.Name = "tPIE";
            this.tPIE.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tPIE.Size = new System.Drawing.Size(919, 494);
            this.tPIE.TabIndex = 0;
            this.tPIE.Text = "浏览器视图";
            // 
            // MyBrowser1
            // 
            this.MyBrowser1.AllowNavigation = false;
            this.MyBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyBrowser1.Location = new System.Drawing.Point(0, 2);
            this.MyBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.MyBrowser1.Name = "MyBrowser1";
            this.MyBrowser1.ScriptErrorsSuppressed = true;
            this.MyBrowser1.Size = new System.Drawing.Size(919, 492);
            this.MyBrowser1.TabIndex = 0;
            // 
            // Tab1
            // 
            this.Tab1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Tab1.Controls.Add(this.tabPage1);
            this.Tab1.Controls.Add(this.tPIE);
            this.Tab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab1.ItemSize = new System.Drawing.Size(72, 21);
            this.Tab1.Location = new System.Drawing.Point(0, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.SelectedIndex = 0;
            this.Tab1.ShowToolTips = true;
            this.Tab1.Size = new System.Drawing.Size(927, 523);
            this.Tab1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Tab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 523);
            this.panel1.TabIndex = 29;
            // 
            // DlgNew
            // 
            this.DlgNew.DefaultExt = "plot";
            this.DlgNew.Filter = "专案配置文件(*.plot)|*.plot";
            this.DlgNew.Title = "保存专案配置文件";
            // 
            // DlgOpen
            // 
            this.DlgOpen.DefaultExt = "Okb";
            this.DlgOpen.Filter = "专案配置文件(*.plot)|*.plot";
            this.DlgOpen.Title = "打开专案配置文件";
            // 
            // CmbChaset
            // 
            this.CmbChaset.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CmbChaset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbChaset.Items.AddRange(new object[] {
            "GB2312",
            "UTF-8"});
            this.CmbChaset.Name = "CmbChaset";
            this.CmbChaset.Size = new System.Drawing.Size(75, 32);
            // 
            // CmbMethod
            // 
            this.CmbMethod.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CmbMethod.DropDownWidth = 70;
            this.CmbMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.CmbMethod.Name = "CmbMethod";
            this.CmbMethod.Size = new System.Drawing.Size(75, 32);
            // 
            // TbarStart
            // 
            this.TbarStart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TbarStart.Image = ((System.Drawing.Image)(resources.GetObject("TbarStart.Image")));
            this.TbarStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbarStart.Name = "TbarStart";
            this.TbarStart.Size = new System.Drawing.Size(76, 29);
            this.TbarStart.Text = "请求数据";
            this.TbarStart.Click += new System.EventHandler(this.TbarStart_Click);
            // 
            // Tbar清洗规则
            // 
            this.Tbar清洗规则.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Tbar清洗规则.Image = ((System.Drawing.Image)(resources.GetObject("Tbar清洗规则.Image")));
            this.Tbar清洗规则.ImageTransparentColor = System.Drawing.Color.White;
            this.Tbar清洗规则.Name = "Tbar清洗规则";
            this.Tbar清洗规则.Size = new System.Drawing.Size(76, 29);
            this.Tbar清洗规则.Text = "清洗规则";
            this.Tbar清洗规则.Click += new System.EventHandler(this.Tbar清洗规则_Click);
            // 
            // TbarDrill
            // 
            this.TbarDrill.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TbarDrill.Image = ((System.Drawing.Image)(resources.GetObject("TbarDrill.Image")));
            this.TbarDrill.ImageTransparentColor = System.Drawing.Color.White;
            this.TbarDrill.Name = "TbarDrill";
            this.TbarDrill.Size = new System.Drawing.Size(76, 29);
            this.TbarDrill.Text = "数据提取";
            this.TbarDrill.Click += new System.EventHandler(this.TbarDrill_Click);
            // 
            // TBarRuntime
            // 
            this.TBarRuntime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TBarRuntime.Image = ((System.Drawing.Image)(resources.GetObject("TBarRuntime.Image")));
            this.TBarRuntime.ImageTransparentColor = System.Drawing.Color.White;
            this.TBarRuntime.Name = "TBarRuntime";
            this.TBarRuntime.Size = new System.Drawing.Size(88, 29);
            this.TBarRuntime.Text = "运行时设置";
            this.TBarRuntime.Click += new System.EventHandler(this.TBarRuntime_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 29);
            this.toolStripLabel1.Text = "地址：";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // TBarOk
            // 
            this.TBarOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TBarOk.Image = ((System.Drawing.Image)(resources.GetObject("TBarOk.Image")));
            this.TBarOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TBarOk.ImageTransparentColor = System.Drawing.Color.White;
            this.TBarOk.Name = "TBarOk";
            this.TBarOk.Size = new System.Drawing.Size(76, 29);
            this.TBarOk.Text = "完成配置";
            this.TBarOk.ToolTipText = "完成配置";
            this.TBarOk.Click += new System.EventHandler(this.TBarOk_Click);
            // 
            // TbarCancel
            // 
            this.TbarCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TbarCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TbarCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TbarCancel.ImageTransparentColor = System.Drawing.Color.White;
            this.TbarCancel.Name = "TbarCancel";
            this.TbarCancel.Size = new System.Drawing.Size(60, 29);
            this.TbarCancel.Text = "取消配置";
            this.TbarCancel.ToolTipText = "取消配置";
            this.TbarCancel.Click += new System.EventHandler(this.TbarCancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TbarCancel,
            this.TBarOk,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.TBarRuntime,
            this.TbarDrill,
            this.Tbar清洗规则,
            this.TbarStart,
            this.CmbMethod,
            this.CmbChaset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(927, 32);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FrmPlotWaterLineGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 555);
            this.ControlBox = false;
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmPlotWaterLineGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产线配置向导";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabPage1.ResumeLayout(false);
            this.tPIE.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox TxtHtml;
        private System.Windows.Forms.TabPage tPIE;
        private System.Windows.Forms.WebBrowser MyBrowser1;
        private System.Windows.Forms.TabControl Tab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog DlgNew;
        private System.Windows.Forms.OpenFileDialog DlgOpen;
        private System.Windows.Forms.ToolStripComboBox CmbChaset;
        private System.Windows.Forms.ToolStripComboBox CmbMethod;
        private System.Windows.Forms.ToolStripButton TbarStart;
        private System.Windows.Forms.ToolStripButton Tbar清洗规则;
        private System.Windows.Forms.ToolStripButton TbarDrill;
        private System.Windows.Forms.ToolStripButton TBarRuntime;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TBarOk;
        private System.Windows.Forms.ToolStripButton TbarCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;


    }
}