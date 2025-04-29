using NotiOfima.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NotiOfima.Visualizador
{
    public partial class FrmNotiOfimaListado : Form
    {
        /// <summary>
        /// Contiene las variables usadas para almacenar la información.
        /// </summary>
        #region Campos
        private BindingList<NotiOfimaTable> notas = null;
        #endregion

        #region Constructor
        public FrmNotiOfimaListado()
        {
            InitializeComponent();
                        
            // Inicializar Notas
            RefrescarInfo();
        }
        #endregion
               
        /// <summary>
        /// Cargar la página inicial. Es la primera nota que se muestra. se muestran las notas de manera aleatoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNotiOfima_Load(object sender, EventArgs e)
        {
            // si no hay notas configuradas muestra mensaje y cierra
            if (notas.Count<=0)
            {
                MessageBox.Show("El sistema no encuentra notas configuradas.","NotiOfima",MessageBoxButtons.OK,MessageBoxIcon.Information);                                         
            }           
        }
        
        /// <summary>
        /// Metodo para cargar la informacion almacenada
        /// </summary>
        private void RefrescarInfo()
        {
            // consultar al servicio web si hay nuevas notas




            // Cargar Notas
            this.notas = new BindingList<NotiOfimaTable>(NotiOfimaTable.Consultar());
            this.notiOfimaTableBindingSource.DataSource = this.notas;
        }

        /// <summary>
        /// Cuando selecciona un nodo ejecuta en el navegador la nota
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arbolNotiOfima_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            string url = arbolNotiOfima.ActiveNode.Cells["Link"].Text;            
            System.Diagnostics.Process.Start(url);
        }
    }
}
