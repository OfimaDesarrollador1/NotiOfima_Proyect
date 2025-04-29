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
    public partial class FrmNotiOfima : Form
    {
        /// <summary>
        /// Contiene las variables usadas para almacenar la información.
        /// </summary>
        #region Campos
        private BindingList<NotiOfimaTable> notas = null;
        #endregion

        #region Constructor
        public FrmNotiOfima()
        {
            InitializeComponent();

            // Ocultar la opción de administrador cuando es cliente
            if (Properties.Settings.Default.EsServidor == false)
            {
                btnAdmin.Visible = false;
            }

            // Inicializar Notas
            RefrescarInfo();

            // Inicializar metodos del formulario y del control de navegacion
            this.Load += new EventHandler(FrmNotiOfima_Load);
            this.controlNavegador.Navigated += new WebBrowserNavigatedEventHandler(controlNavegador_Navigated);
        }
        #endregion

        /// <summary>
        /// Evento que actualizar la pagina al darle clic en el boton de actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controlNavegador.Navigate(txtLink.Text);
        }

        /// <summary>
        /// Cargar la página inicial. Es la primera nota que se muestra. se muestran las notas de manera aleatoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmNotiOfima_Load(object sender, EventArgs e)
        {
            // Seleccionar nodo al azar

            // solo generamos el aleatorio si tiene notas configuradas
            if (notas.Count>0)
            {
                // Creamos el objeto Random
                Random numeroAleatorio = new Random(DateTime.Now.Millisecond);

                // Queremos un número entre el 1 y el máximo de notas configuradas
                int notaAleatoria = numeroAleatorio.Next(0, notas.Count-1);

                // Seleccionar del arbol creado el nodo aleatorio
                arbolNotiOfima.ActiveNode = arbolNotiOfima.Nodes[notaAleatoria];
                arbolNotiOfima.ActiveNode.Selected = true;
                arbolNotiOfima.Select();

                //header1.titulo = notas[notaAleatoria].Titulo;
                //controlNavegador.Navigate(notas[notaAleatoria].Link);                
            }
            else
            {
                // Ejecutar la URL seleccionada
                controlNavegador.Navigate(@"www.ofima.com");
            }            
        }

        /// <summary>
        /// metodo que se activa al navegar por el control, si se selecciona algun link se actualiza el texto con el link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlNavegador_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtLink.Text = controlNavegador.Url.ToString();
        }

        /// <summary>
        /// Ejecutar el administrador de notas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Administrador administradorNotas = new Administrador();
            administradorNotas.ShowDialog();
            RefrescarInfo();
        }

        /// <summary>
        /// Metodo para cargar la informacion almacenada
        /// </summary>
        private void RefrescarInfo()
        {
            // Cargar Notas
            this.notas = new BindingList<NotiOfimaTable>(NotiOfimaTable.Consultar());
            this.notiOfimaTableBindingSource.DataSource = this.notas;
        }

        /// <summary>
        /// Cuando selecciona un ndo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arbolNotiOfima_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            string url = arbolNotiOfima.ActiveNode.Cells["Link"].Text;
            header1.titulo = arbolNotiOfima.ActiveNode.Cells["Titulo"].Text;
            controlNavegador.Navigate(url);
        }
    }
}
