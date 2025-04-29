namespace NotiOfima.Visualizador
{
    partial class FrmNotiOfima
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotiOfima));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.arbolNotiOfima = new Infragistics.Win.UltraWinTree.UltraTree();
            this.notiOfimaTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlNavegador = new WebKit.WebKitBrowser();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.btnAdmin = new Infragistics.Win.Misc.UltraButton();
            this.btnActualizar = new Infragistics.Win.Misc.UltraButton();
            this.txtLink = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.footer1 = new NotiOfima.Visualizador.Footer();
            this.header1 = new NotiOfima.Visualizador.Header();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arbolNotiOfima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notiOfimaTableBindingSource)).BeginInit();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.arbolNotiOfima);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.controlNavegador);
            this.splitContainer1.Panel2.Controls.Add(this.ultraPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(754, 448);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 2;
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
            this.arbolNotiOfima.HideSelection = false;
            this.arbolNotiOfima.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.arbolNotiOfima.Location = new System.Drawing.Point(0, 0);
            this.arbolNotiOfima.Name = "arbolNotiOfima";
            this.arbolNotiOfima.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.arbolNotiOfima.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None;
            this.arbolNotiOfima.SaveSettingsFormat = Infragistics.Win.SaveSettingsFormat.Xml;
            this.arbolNotiOfima.Size = new System.Drawing.Size(155, 448);
            this.arbolNotiOfima.TabIndex = 0;
            this.arbolNotiOfima.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
            this.arbolNotiOfima.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.arbolNotiOfima_AfterSelect);
            // 
            // notiOfimaTableBindingSource
            // 
            this.notiOfimaTableBindingSource.DataSource = typeof(NotiOfima.Entidades.Model.NotiOfimaTable);
            // 
            // controlNavegador
            // 
            this.controlNavegador.BackColor = System.Drawing.Color.White;
            this.controlNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlNavegador.Location = new System.Drawing.Point(0, 35);
            this.controlNavegador.Name = "controlNavegador";
            this.controlNavegador.Size = new System.Drawing.Size(595, 413);
            this.controlNavegador.TabIndex = 1;
            this.controlNavegador.Url = null;
            this.controlNavegador.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.controlNavegador_Navigated);
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.btnAdmin);
            this.ultraPanel1.ClientArea.Controls.Add(this.btnActualizar);
            this.ultraPanel1.ClientArea.Controls.Add(this.txtLink);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(595, 35);
            this.ultraPanel1.TabIndex = 0;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ImageAlpha = Infragistics.Win.Alpha.Opaque;
            this.btnAdmin.Appearance = appearance2;
            this.btnAdmin.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ButtonSoft;
            this.btnAdmin.Location = new System.Drawing.Point(540, 5);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(51, 26);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseAppStyling = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = global::NotiOfima.Visualizador.Properties.Resources.actualizar;
            appearance3.ImageAlpha = Infragistics.Win.Alpha.Opaque;
            this.btnActualizar.Appearance = appearance3;
            this.btnActualizar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ButtonSoft;
            this.btnActualizar.Location = new System.Drawing.Point(508, 5);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(28, 26);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.UseAppStyling = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLink.Location = new System.Drawing.Point(7, 5);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(495, 25);
            this.txtLink.TabIndex = 0;
            this.txtLink.Text = "http://www.ofima.com/notiofima";
            // 
            // footer1
            // 
            this.footer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("footer1.BackgroundImage")));
            this.footer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer1.Location = new System.Drawing.Point(0, 509);
            this.footer1.Name = "footer1";
            this.footer1.Size = new System.Drawing.Size(754, 26);
            this.footer1.TabIndex = 1;
            // 
            // header1
            // 
            this.header1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header1.BackgroundImage")));
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(754, 61);
            this.header1.TabIndex = 0;
            this.header1.titulo = "NotiOfima 60";
            // 
            // FrmNotiOfima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 535);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.footer1);
            this.Controls.Add(this.header1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNotiOfima";
            this.Text = "NotiOfima";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmNotiOfima_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arbolNotiOfima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notiOfimaTableBindingSource)).EndInit();
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLink)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Header header1;
        private Footer footer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.UltraWinTree.UltraTree arbolNotiOfima;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtLink;
        private Infragistics.Win.Misc.UltraButton btnActualizar;
        private WebKit.WebKitBrowser controlNavegador;
        private Infragistics.Win.Misc.UltraButton btnAdmin;
        private System.Windows.Forms.BindingSource notiOfimaTableBindingSource;

    }
}

