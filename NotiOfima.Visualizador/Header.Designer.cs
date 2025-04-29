namespace NotiOfima.Visualizador
{
    partial class Header
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.lblTitulo = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // ultraPictureBox1
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraPictureBox1.Appearance = appearance4;
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.Location = new System.Drawing.Point(6, 6);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(244, 50);
            this.ultraPictureBox1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.FontData.Name = "Verdana";
            appearance3.FontData.SizeInPoints = 15F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblTitulo.Appearance = appearance3;
            this.lblTitulo.Location = new System.Drawing.Point(350, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(339, 37);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "NotiOfima";
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NotiOfima.Visualizador.Properties.Resources.banner;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.ultraPictureBox1);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(769, 61);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
        private Infragistics.Win.Misc.UltraLabel lblTitulo;
    }
}
