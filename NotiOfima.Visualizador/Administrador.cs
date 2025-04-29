using Infragistics.Win.UltraWinGrid;
using NotiOfima.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotiOfima.Visualizador
{
    public partial class Administrador : Form
    {
        /// <summary>
        /// Contiene las variables usadas para almacenar la información.
        /// </summary>
        #region Campos
        private BindingList<NotiOfimaTable> notas = null;
        #endregion

        #region Constructor

        public Administrador()
        {
            InitializeComponent();

            // Cargar los paises
            this.paisesModelBindingSource.DataSource = PaisesModel.Consultar();

            // cargar informacion de notas
            RefrescarInfo();
        }
        #endregion

        #region metodos

        /// <summary>
        /// Cuando se inserta un nuevo registro ingresa el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notiOfimaTableBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new NotiOfimaTable()
            {
                Eliminar = false,
                idNota = Guid.NewGuid(),
                Titulo = "",
                CantidadMostrar = 0,
                FrecuenciaMostrar = 0,
                Link = "",
                FechaCreacion = DateTime.Now,
                FechaExpiracion = DateTime.Now.AddDays(30)
            };
        }

        /// <summary>
        /// Metodo para guardar la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            uTabNotas.Focus();

            //Finalizar edición de todos los Grid
            ExitEditMode();

            // validar que la frecuencia y el tiempoInactivo configurada sea válida
            int frecuencia = 24;
            bool frecuenciaValida = Int32.TryParse(txtFrecuencia.Text.Trim(), out frecuencia);

            int tiempoInactivo = 3;
            bool tiempoInactivoValido = Int32.TryParse(txtInactividad.Text.Trim(), out tiempoInactivo);

            if (frecuenciaValida == true && tiempoInactivoValido == true)
            {
                // Actualizar Frecuencia mostrar
                NotiOfimaConfiguracionTable notiOfimaConfiguracion = new NotiOfimaConfiguracionTable();
                notiOfimaConfiguracion.FrecuenciaMostrar = frecuencia;
                notiOfimaConfiguracion.tiempoInactivo = tiempoInactivo;
                notiOfimaConfiguracion.UltimaEjecucion = DateTime.Now;
                NotiOfimaConfiguracionTable.Actualizar(notiOfimaConfiguracion);

                // Actualizar notas
                NotiOfimaTable.Actualizar(this.notas);
                MessageBox.Show("Datos actualizados correctamente", "Administrador Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarInfo();
            }
            else
            {
                MessageBox.Show("Tiempo de Inactividad o Frecuencia inválida");
            }
        }

        /// <summary>
        /// Metodo que me permite salir del modo de edicion de todos los grids para refresacar la información
        /// </summary>
        public void ExitEditMode()
        {
            grdNotas.PerformAction(UltraGridAction.ExitEditMode, false, false);
        }

        /// <summary>
        /// Metodo para cargar la informacion almacenada
        /// </summary>
        private void RefrescarInfo()
        {
            // cargar frecuencia mostrar
            txtFrecuencia.Text = NotiOfimaConfiguracionTable.ConsultarFrecuenciaMostrar().ToString();

            // cargar tiempo Inactividad
            txtInactividad.Text = NotiOfimaConfiguracionTable.ConsultarTiempoInactivo().ToString();

            // Cargar Notas
            this.notas = new BindingList<NotiOfimaTable>(NotiOfimaTable.Consultar());
            this.notiOfimaTableBindingSource.DataSource = this.notas;
        }

        /// <summary>
        /// Cerrar el administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo para cargar la imagen, se ejecuta cada que se presiona botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdNotas_ClickCellButton(object sender, CellEventArgs e)
        {
            //grdNotas.DisplayLayout.Bands[0].Columns["Imagen"].Editor = new Infragistics.Win.EmbeddableImageRenderer();

            // Mostrar para seleccionar archivo
            string rutaImagen = string.Empty;

            //Utilizamos el openFileDialog, el cual es el componente utilizado en los formularios de windows, 
            //con el cual normalmente se abren los archivos.
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                //Verificamos de una manera sencilla si se ha entrado un valor. (Si se ha seleccionado un archivo)
                if (openFileDialog.FileName != string.Empty)
                {
                    // cargar la imagen al origen de datos
                    rutaImagen = openFileDialog.FileName.Trim();
                    e.Cell.Row.Cells["Imagen"].Value = File.ReadAllBytes(rutaImagen);

                    // redimensionar la fila para que muestre la imagen visible
                    grdNotas.DisplayLayout.Override.RowSizing = RowSizing.Default;
                    grdNotas.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;

                    //grdNotas.DisplayLayout.Rows[0].Height = 80;
                    //Image.FromFile(rutaImagen);
                }

            }
        }

        #endregion



    }
}
