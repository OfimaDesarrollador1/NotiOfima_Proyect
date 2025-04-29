
namespace Ofima.Pildoras.VisorERP
{
    partial class VisorModulo
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
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorModulo));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            this.pnlEncabezado = new Infragistics.Win.Misc.UltraPanel();
            this.LblDescripcioModulo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPictureBox3 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.lblTitulo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEncabezado.ClientArea.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            appearance44.BackColor = System.Drawing.Color.Transparent;
            appearance44.ImageAlpha = Infragistics.Win.Alpha.Transparent;
            appearance44.ImageBackground = global::Ofima.Pildoras.VisorERP.Properties.Resources.BANNER_FONDO_1;
            this.pnlEncabezado.Appearance = appearance44;
            // 
            // pnlEncabezado.ClientArea
            // 
            this.pnlEncabezado.ClientArea.Controls.Add(this.LblDescripcioModulo);
            this.pnlEncabezado.ClientArea.Controls.Add(this.ultraPictureBox3);
            this.pnlEncabezado.ClientArea.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.ClientArea.Controls.Add(this.ultraPictureBox1);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1008, 125);
            this.pnlEncabezado.TabIndex = 125;
            this.pnlEncabezado.UseAppStyling = false;
            // 
            // LblDescripcioModulo
            // 
            this.LblDescripcioModulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.FontData.BoldAsString = "True";
            appearance7.FontData.Name = "Calibri Light";
            appearance7.FontData.SizeInPoints = 20F;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.LblDescripcioModulo.Appearance = appearance7;
            this.LblDescripcioModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescripcioModulo.Location = new System.Drawing.Point(345, 73);
            this.LblDescripcioModulo.Name = "LblDescripcioModulo";
            this.LblDescripcioModulo.Size = new System.Drawing.Size(249, 44);
            this.LblDescripcioModulo.TabIndex = 132;
            this.LblDescripcioModulo.Text = "Descripción Modulo";
            // 
            // ultraPictureBox3
            // 
            appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraPictureBox3.Appearance = appearance12;
            this.ultraPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox3.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox3.Image = ((object)(resources.GetObject("ultraPictureBox3.Image")));
            this.ultraPictureBox3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox3.Location = new System.Drawing.Point(12, 3);
            this.ultraPictureBox3.Name = "ultraPictureBox3";
            this.ultraPictureBox3.Size = new System.Drawing.Size(167, 119);
            this.ultraPictureBox3.TabIndex = 129;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "Calibri Light";
            appearance1.FontData.SizeInPoints = 45F;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTitulo.Appearance = appearance1;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(196, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(546, 60);
            this.lblTitulo.TabIndex = 127;
            this.lblTitulo.Text = "Visualizador pildoras";
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance47.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraPictureBox1.Appearance = appearance47;
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.Location = new System.Drawing.Point(731, 32);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(244, 50);
            this.ultraPictureBox1.TabIndex = 126;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoScroll = true;
            this.tableLayoutPanel.BackgroundImage = global::Ofima.Pildoras.VisorERP.Properties.Resources.FONDO_INTERFAZ_1362x769;
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 125);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1008, 221);
            this.tableLayoutPanel.TabIndex = 126;
            // 
            // VisorModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 346);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.pnlEncabezado);
            this.Name = "VisorModulo";
            this.Text = "Visualizador pildoras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisorModulo_Load);
            this.pnlEncabezado.ClientArea.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlEncabezado;
        private Infragistics.Win.Misc.UltraLabel lblTitulo;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Infragistics.Win.Misc.UltraLabel LblDescripcioModulo;
    }
}

