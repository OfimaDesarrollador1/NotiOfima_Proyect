namespace NotiOfima.Visualizador
{
    partial class FrmNotiOfimaListado
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotiOfimaListado));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn1 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn2 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn3 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn4 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn5 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn6 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn7 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn8 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            this.notiOfimaTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.footer1 = new NotiOfima.Visualizador.Footer();
            this.header1 = new NotiOfima.Visualizador.Header();
            this.arbolNotiOfima = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.notiOfimaTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbolNotiOfima)).BeginInit();
            this.SuspendLayout();
            // 
            // notiOfimaTableBindingSource
            // 
            this.notiOfimaTableBindingSource.DataSource = typeof(NotiOfima.Entidades.Model.NotiOfimaTable);
            // 
            // footer1
            // 
            this.footer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("footer1.BackgroundImage")));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 509);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(682, 26);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header1.BackgroundImage")));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(682, 61);
            this.header1.TabIndex = 0;
            this.header1.titulo = "Lista Notas publicadas";
            // 
            // arbolNotiOfima
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.ItalicAsString = "False";
            appearance1.FontData.Name = "Verdana";
            appearance1.FontData.SizeInPoints = 12F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.DimGray;
            this.arbolNotiOfima.Appearance = appearance1;
            this.arbolNotiOfima.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraTreeNodeColumn1.DataType = typeof(bool);
            ultraTreeNodeColumn1.Key = "Eliminar";
            ultraTreeNodeColumn1.Visible = false;
            ultraTreeNodeColumn2.DataType = typeof(System.Guid);
            ultraTreeNodeColumn2.Key = "idNota";
            ultraTreeNodeColumn2.Visible = false;
            ultraTreeNodeColumn3.DataType = typeof(string);
            ultraTreeNodeColumn3.Key = "Titulo";
            ultraTreeNodeColumn4.DataType = typeof(int);
            ultraTreeNodeColumn4.Key = "CantidadMostrar";
            ultraTreeNodeColumn4.Visible = false;
            ultraTreeNodeColumn5.DataType = typeof(decimal);
            ultraTreeNodeColumn5.Key = "FrecuenciaMostrar";
            ultraTreeNodeColumn5.Visible = false;
            ultraTreeNodeColumn6.DataType = typeof(string);
            ultraTreeNodeColumn6.Key = "Link";
            ultraTreeNodeColumn6.Visible = false;
            ultraTreeNodeColumn7.DataType = typeof(System.DateTime);
            ultraTreeNodeColumn7.Key = "FechaCreacion";
            ultraTreeNodeColumn7.Visible = false;
            ultraTreeNodeColumn8.DataType = typeof(System.DateTime);
            ultraTreeNodeColumn8.Key = "FechaExpiracion";
            ultraTreeNodeColumn8.Visible = false;
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn1);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn2);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn3);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn4);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn5);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn6);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn7);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn8);
            ultraTreeColumnSet1.IsAutoGenerated = true;
            ultraTreeColumnSet1.NodeTextColumnIndex = 2;
            this.arbolNotiOfima.ColumnSettings.ColumnSets.Add(ultraTreeColumnSet1);
            this.arbolNotiOfima.DataSource = this.notiOfimaTableBindingSource;
            this.arbolNotiOfima.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista;
            this.arbolNotiOfima.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arbolNotiOfima.ExpansionIndicatorPadding = 10;
            this.arbolNotiOfima.HideSelection = false;
            this.arbolNotiOfima.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.arbolNotiOfima.Location = new System.Drawing.Point(0, 61);
            this.arbolNotiOfima.Name = "arbolNotiOfima";
            this.arbolNotiOfima.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.arbolNotiOfima.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None;
            this.arbolNotiOfima.SaveSettingsFormat = Infragistics.Win.SaveSettingsFormat.Xml;
            this.arbolNotiOfima.Size = new System.Drawing.Size(682, 448);
            this.arbolNotiOfima.TabIndex = 2;
            this.arbolNotiOfima.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
            this.arbolNotiOfima.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.arbolNotiOfima_AfterSelect);
            // 
            // FrmNotiOfimaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 535);
            this.Controls.Add(this.arbolNotiOfima);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNotiOfimaListado";
            this.Text = "NotiOfima";
            this.Load += new System.EventHandler(this.FrmNotiOfima_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notiOfimaTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arbolNotiOfima)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Header header1;
        private Footer footer1;
        private System.Windows.Forms.BindingSource notiOfimaTableBindingSource;
        private Infragistics.Win.UltraWinTree.UltraTree arbolNotiOfima;

    }
}

