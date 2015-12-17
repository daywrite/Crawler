namespace Lwb.Crawler.Center.Server
{
    partial class FrmServer
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
            CCWin.SkinControl.Animation animation2 = new CCWin.SkinControl.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.tabshow = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabshow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabshow
            // 
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 1F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.tabshow.Animation = animation2;
            this.tabshow.AnimationStart = false;
            this.tabshow.AnimatorType = CCWin.SkinControl.AnimationType.Leaf;
            this.tabshow.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabshow.Controls.Add(this.tabPage1);
            this.tabshow.Controls.Add(this.tabPage2);
            this.tabshow.Controls.Add(this.tabPage3);
            this.tabshow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabshow.ImageList = this.imageList;
            this.tabshow.ImgSize = new System.Drawing.Size(41, 41);
            this.tabshow.ImgTxtSpace = 0;
            this.tabshow.ItemSize = new System.Drawing.Size(73, 70);
            this.tabshow.Location = new System.Drawing.Point(4, 28);
            this.tabshow.Margin = new System.Windows.Forms.Padding(0);
            this.tabshow.Name = "tabshow";
            this.tabshow.Padding = new System.Drawing.Point(0, 0);
            this.tabshow.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabshow.PageArrowDown")));
            this.tabshow.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabshow.PageArrowHover")));
            this.tabshow.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabshow.PageCloseHover")));
            this.tabshow.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabshow.PageCloseNormal")));
            this.tabshow.PageDown = ((System.Drawing.Image)(resources.GetObject("tabshow.PageDown")));
            this.tabshow.PageHover = ((System.Drawing.Image)(resources.GetObject("tabshow.PageHover")));
            this.tabshow.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Top;
            this.tabshow.PageNorml = null;
            this.tabshow.PageTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tabshow.SelectedIndex = 0;
            this.tabshow.Size = new System.Drawing.Size(982, 702);
            this.tabshow.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabshow.TabIndex = 140;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(0, 70);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1023, 638);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "网页提取";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(0, 70);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1023, 638);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "系统设置";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "link_46.019646365422px_1190280_easyicon.net.png");
            this.imageList.Images.SetKeyName(1, "Settings_48px_1185170_easyicon.net.png");
            this.imageList.Images.SetKeyName(2, "Database_Active_48px_1093661_easyicon.net.png");
            // 
            // tabPage3
            // 
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(0, 70);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(982, 632);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "元数据";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FrmServer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.BackLayout = false;
            this.CanResize = false;
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(990, 734);
            this.CloseBoxSize = new System.Drawing.Size(29, 24);
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.tabshow);
            this.EffectCaption = CCWin.TitleType.None;
            this.EffectWidth = 0;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaxSize = new System.Drawing.Size(25, 24);
            this.MiniSize = new System.Drawing.Size(25, 24);
            this.Name = "FrmServer";
            this.Radius = 1;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据采集管理中心";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.tabshow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTabControl tabshow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabPage tabPage3;
    }
}