namespace Lwb.Crawler.Center.Server.Main
{
    partial class FrmNewFolder
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
            this.TxtFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancal
            // 
            this.btnCancal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancal.Location = new System.Drawing.Point(168, 69);
            this.btnCancal.Name = "btnCancal";
            this.btnCancal.Size = new System.Drawing.Size(82, 24);
            this.btnCancal.TabIndex = 74;
            this.btnCancal.Text = "取消";
            this.btnCancal.Click += new System.EventHandler(this.btnCancal_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(80, 69);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 24);
            this.btnOk.TabIndex = 73;
            this.btnOk.Text = "确认";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // TxtFolder
            // 
            this.TxtFolder.Location = new System.Drawing.Point(23, 25);
            this.TxtFolder.Name = "TxtFolder";
            this.TxtFolder.Size = new System.Drawing.Size(278, 21);
            this.TxtFolder.TabIndex = 72;
            // 
            // FrmNewFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 118);
            this.Controls.Add(this.btnCancal);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.TxtFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmNewFolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建组";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox TxtFolder;


    }
}