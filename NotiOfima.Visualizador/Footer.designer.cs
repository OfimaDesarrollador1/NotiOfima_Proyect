namespace NotiOfima.Visualizador
{
    partial class Footer
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lblWeb = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // lblWeb
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.FontData.Name = "Verdana";
            appearance1.FontData.SizeInPoints = 11F;
            appearance1.ForeColor = System.Drawing.Color.White;
            this.lblWeb.Appearance = appearance1;
            this.lblWeb.Location = new System.Drawing.Point(24, 3);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(164, 23);
            this.lblWeb.TabIndex = 1;
            this.lblWeb.Text = "www.ofima.com";
            // 
            // Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NotiOfima.Visualizador.Properties.Resources.banner;
            this.Controls.Add(this.lblWeb);
            this.Name = "Footer";
            this.Size = new System.Drawing.Size(779, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblWeb;

    }
}
