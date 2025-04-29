namespace NotiOfima.Visualizador
{
    partial class Header2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header2));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.upIcon = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.upLogo = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.SuspendLayout();
            // 
            // upIcon
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.upIcon.Appearance = appearance2;
            this.upIcon.BackColor = System.Drawing.Color.Transparent;
            this.upIcon.BorderShadowColor = System.Drawing.Color.Empty;
            this.upIcon.Image = ((object)(resources.GetObject("upIcon.Image")));
            this.upIcon.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.upIcon.Location = new System.Drawing.Point(11, 9);
            this.upIcon.Name = "upIcon";
            this.upIcon.Size = new System.Drawing.Size(84, 51);
            this.upIcon.TabIndex = 5;
            // 
            // upLogo
            // 
            this.upLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.upLogo.Appearance = appearance1;
            this.upLogo.BackColor = System.Drawing.Color.Transparent;
            this.upLogo.BorderShadowColor = System.Drawing.Color.Empty;
            this.upLogo.Image = ((object)(resources.GetObject("upLogo.Image")));
            this.upLogo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.upLogo.Location = new System.Drawing.Point(663, 6);
            this.upLogo.Name = "upLogo";
            this.upLogo.Size = new System.Drawing.Size(244, 50);
            this.upLogo.TabIndex = 6;
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraPictureBox1.Appearance = appearance4;
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.Location = new System.Drawing.Point(117, 10);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(540, 56);
            this.ultraPictureBox1.TabIndex = 7;
            // 
            // Header2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.ultraPictureBox1);
            this.Controls.Add(this.upLogo);
            this.Controls.Add(this.upIcon);
            this.Name = "Header2";
            this.Size = new System.Drawing.Size(908, 69);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraPictureBox upIcon;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox upLogo;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;

    }
}
