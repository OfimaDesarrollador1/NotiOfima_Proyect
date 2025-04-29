
namespace Ofima.Pildoras.VisorERP
{
    partial class FrmMostrarImagen
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.ImagenaMostrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenaMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Blue;
            this.txtNombre.Location = new System.Drawing.Point(26, 254);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(321, 65);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Click += new System.EventHandler(this.txtNombre_Click);
            // 
            // ImagenaMostrar
            // 
            this.ImagenaMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImagenaMostrar.Image = global::Ofima.Pildoras.VisorERP.Properties.Resources.noImage;
            this.ImagenaMostrar.Location = new System.Drawing.Point(26, 3);
            this.ImagenaMostrar.Name = "ImagenaMostrar";
            this.ImagenaMostrar.Size = new System.Drawing.Size(321, 241);
            this.ImagenaMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagenaMostrar.TabIndex = 0;
            this.ImagenaMostrar.TabStop = false;
            this.ImagenaMostrar.Click += new System.EventHandler(this.ImagenaMostrar_Click);
            // 
            // FrmMostrarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.ImagenaMostrar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "FrmMostrarImagen";
            this.Size = new System.Drawing.Size(367, 334);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenaMostrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagenaMostrar;
        private System.Windows.Forms.TextBox txtNombre;
    }
}
