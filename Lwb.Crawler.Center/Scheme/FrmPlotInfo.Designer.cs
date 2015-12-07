namespace Lwb.Crawler.Center.Scheme
{
    partial class FrmPlotInfo
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
            this.btnCancal = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.TxtHomePage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancal
            // 
            this.btnCancal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancal.Location = new System.Drawing.Point(240, 355);
            this.btnCancal.Name = "btnCancal";
            this.btnCancal.Size = new System.Drawing.Size(82, 24);
            this.btnCancal.TabIndex = 77;
            this.btnCancal.Text = "取消";
            this.btnCancal.Click += new System.EventHandler(this.btnCancal_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(152, 355);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 24);
            this.btnOk.TabIndex = 76;
            this.btnOk.Text = "确认";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // TxtHomePage
            // 
            this.TxtHomePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtHomePage.Location = new System.Drawing.Point(58, 39);
            this.TxtHomePage.MaxLength = 64;
            this.TxtHomePage.Name = "TxtHomePage";
            this.TxtHomePage.Size = new System.Drawing.Size(293, 21);
            this.TxtHomePage.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "主页：";
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.Location = new System.Drawing.Point(58, 10);
            this.TxtName.MaxLength = 60;
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(293, 21);
            this.TxtName.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 73;
            this.label2.Text = "名称：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 70;
            this.label8.Text = "简介：";
            // 
            // TxtInfo
            // 
            this.TxtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtInfo.Location = new System.Drawing.Point(58, 69);
            this.TxtInfo.MaxLength = 1024;
            this.TxtInfo.Multiline = true;
            this.TxtInfo.Name = "TxtInfo";
            this.TxtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtInfo.Size = new System.Drawing.Size(293, 276);
            this.TxtInfo.TabIndex = 71;
            // 
            // FrmPlotInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 388);
            this.Controls.Add(this.btnCancal);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.TxtHomePage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlotInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPlotInfo";
            this.Load += new System.EventHandler(this.FrmPlotInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox TxtHomePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtInfo;
    }
}