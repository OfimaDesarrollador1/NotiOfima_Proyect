using Infragistics.Win.UltraWinGrid;
using NotiOfima.Entidades.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using NotiOfima.Entidades;

namespace Ofima.Pildoras.Administrador
{
    public partial class Administrador : Form
    {
        
        BindingList<PildorasDetalleAdministracionModel> ListadoDetalleAdministradorPildoras;

        List<string> listadoDropDown = new List<string>();
        string infoBuscar { get; set; }
        
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------
            //cargar el grid 
            ListadoDetalleAdministradorPildoras = PildorasDetalleAdministracionModel.ConsultarDetalleAdministradorPildoras();
            this.DetalleAdministracionPildorasModelbindingSource.DataSource = ListadoDetalleAdministradorPildoras;
            this.grdDetallePildorasOfima.DataSource = DetalleAdministracionPildorasModelbindingSource;

            // redimensionar la fila para que muestre la imagen visible
            RedimensionarFilaMostrarImagen();

            //-------------------------------------------------------------------------------------------
            //Cargar los ListaEmpresasModel
            BindingList<PildorasListaModulosModel> listadoEmpresasModel = PildorasListaModulosModel.ConsultarListaModulos();
            this.PildorasListaModulosModelbindingSource.DataSource = listadoEmpresasModel;

            //-------------------------------------------------------------------------------------------
            //Cargar los ListaEmpresasModel
            BindingList<PildorasListaMenuModel> ListaMenuModel = PildorasListaMenuModel.ConsultarListaMenu();
            this.PildorasListaMenuModelbindingSource.DataSource = ListaMenuModel;

            //-------------------------------------------------------------------------------------------
            //Cargar los ListaEmpresasModel
            BindingList<PildorasListaPaisModel> ListaPaisModel = PildorasListaPaisModel.ConsultarListaPais();
            this.PildorasListaPaisModelbindingSource.DataSource = ListaPaisModel;

            //-------------------------------------------------------------------------------------------
            //Cargar los ListaEmpresasModel
            BindingList<PildorasListaClasificacionModel> ListaClasificacionModel = PildorasListaClasificacionModel.ConsultarListaClasificacion();
            this.PildorasListaClasificacionModelbindingSource.DataSource = ListaClasificacionModel;

            //-------------------------------------------------------------------------------------------
            //Cargar los ListaEmpresasModel
            BindingList<PildorasListaMotivoModel> ListaMotivoModel = PildorasListaMotivoModel.ConsultarListaMotivo();
            this.PildorasListaMotivoModelbindingSource.DataSource = ListaMotivoModel;

            //-------------------------------------------------------------------------------------------
            //Cargar los ListaEmpresasModel
            BindingList<PildorasListaPerfilModel> ListaPerfilModel = PildorasListaPerfilModel.ConsultarListaPerfil();
            this.PildorasListaPerfilModelbindingSource.DataSource = ListaPerfilModel;
        }

        
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //Guardar los datos                                    
            GuardarPildorasDetalleAdministracion();

            //Refrescar Grid
            RefrescarGrid();
            
            //Mensaje de terminado 
            MessageBox.Show("OK, Registro Guardado Correctamente", "Guardar Registro");

        }

        //Guardar los datos     
        public void GuardarPildorasDetalleAdministracion()
        {
            //Recorer el para asigunar las columnas nuevas 
            foreach (UltraGridRow row in this.grdDetallePildorasOfima.Rows)
            {

                string stringSQL = "spPildoras_DetalleAdministradorGuardar";

                //Valores de los parametros
                Dictionary<string, object> parametroSQL = new Dictionary<string, object>();



                //idDetalleModuloIncidente esta nulo                 
                if (Guid.Parse(row.Cells["idPildoraOfima"].Value.ToString()) == Guid.Empty)
                {
                    row.Cells["idPildoraOfima"].Value = Guid.NewGuid();
                }

                parametroSQL.Add("@pidPildoraOfima", (Guid.Parse(row.Cells["idPildoraOfima"].Value.ToString())));
                parametroSQL.Add("@pTitulo", row.Cells["Titulo"].Value.ToString());
                parametroSQL.Add("@pIdModulo", row.Cells["IdModulo"].Value.ToString());
                parametroSQL.Add("@pIdMenuERP", row.Cells["IdMenuERP"].Value.ToString());
                parametroSQL.Add("@pLink", row.Cells["Link"].Value.ToString());
                parametroSQL.Add("@pFechaCreacion", DateTime.Parse(row.Cells["FechaCreacion"].Value.ToString()));
                parametroSQL.Add("@pFechaExpiracion", DateTime.Parse(row.Cells["FechaExpiracion"].Value.ToString()));
                parametroSQL.Add("@pImagen", (byte[])row.Cells["Imagen"].Value);
                parametroSQL.Add("@pCodigoPais", row.Cells["CodigoPais"].Value.ToString());
                parametroSQL.Add("@pIdClasificacion", Guid.Parse(row.Cells["IdClasificacion"].Value.ToString()));
                parametroSQL.Add("@pIdMotivo", Guid.Parse(row.Cells["IdMotivo"].Value.ToString()));
                parametroSQL.Add("@pIdPerfil", Guid.Parse(row.Cells["IdPerfil"].Value.ToString()));
                parametroSQL.Add("@pEliminar", Boolean.Parse(row.Cells["Eliminar"].Value.ToString()));

                AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            }
        }

        //Metodo para refrescar el grid 
        public void RefrescarGrid()
        {
            string mCampoBusqueda = "";

            // se crea el filtro con el que se busca el numero de documento StartsWith
            ListadoDetalleAdministradorPildoras = PildorasDetalleAdministracionModel.ConsultarDetalleAdministradorPildoras();

            var mFiltro = (from Temp in ListadoDetalleAdministradorPildoras
                           where (((Temp.FechaCreacion.ToUpper() != null) && (Temp.FechaCreacion.ToUpper().Contains(mCampoBusqueda))))
                           select Temp).ToList();
            this.DetalleAdministracionPildorasModelbindingSource.DataSource = mFiltro;
            this.grdDetallePildorasOfima.DataSource = DetalleAdministracionPildorasModelbindingSource;
        }

        //// redimensionar la fila para que muestre la imagen visible
        public void RedimensionarFilaMostrarImagen()
        {
            grdDetallePildorasOfima.DisplayLayout.Override.RowSizing = RowSizing.Default;
            grdDetallePildorasOfima.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
        }

        private void grdDetallePildorasOfima_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
                       
            //grdNotas.DisplayLayout.Bands[0].Columns["Imagen"].Editor = new Infragistics.Win.EmbeddableImageRenderer();

            // Mostrar para seleccionar archivo
            string rutaImagen = string.Empty;

            //Utilizamos el openFileDialog, el cual es el componente utilizado en los formularios de windows, 
            //con el cual normalmente se abren los archivos.
            OpenFileDialog mAbrirExploradorDeArchivos = new OpenFileDialog();

            mAbrirExploradorDeArchivos.FileName = string.Empty;
            if (mAbrirExploradorDeArchivos.ShowDialog() != DialogResult.Cancel)
            {
                //Verificamos de una manera sencilla si se ha entrado un valor. (Si se ha seleccionado un archivo)
                if (mAbrirExploradorDeArchivos.FileName != string.Empty)
                {
                    // cargar la imagen al origen de datos
                    rutaImagen = mAbrirExploradorDeArchivos.FileName.Trim();
                    e.Cell.Row.Cells["Imagen"].Value = System.IO.File.ReadAllBytes(rutaImagen);

                    // redimensionar la fila para que muestre la imagen visible                   
                    RedimensionarFilaMostrarImagen();

                    //grdNotas.DisplayLayout.Rows[0].Height = 80;
                    //Image.FromFile(rutaImagen);
                }

            }            
        }

  
        //Boton Cerrar 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CboModulos_FilterRow(object sender, FilterRowEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hola");
            // se obtiene el valor digitado en el grid 
            string valorActual = this.grdDetallePildorasOfima.ActiveCell.Text;

            // Se almacena este valor en la propiedad Presentacion.infoBuscar para mostrar correctamente el DropDown
            infoBuscar = valorActual;

            // Buscar en todas las columnas si encuentra el valor digitado
            bool filterRow = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.CboModulos.DisplayLayout.Bands[0].Columns)
            {
                // solo filtra si la columna se muestra en el DropDown
                if (column.IsVisibleInLayout)
                {
                    // validar que la propiedad valorActual posea información
                    // Buscar que la columna contenga el valor
                    if (valorActual != null)
                    {
                        if (e.Row.Cells[column].Text.ToUpper().Contains(valorActual.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
            }

            // Si la columna contiene el valor se muestra en los resultados de lo contrario no
            if (filterRow)
            {
                e.Row.Hidden = true;
                // remover registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Remove(e.Row.Cells[0].Value.ToString());
                }
            }
            else
            {
                e.Row.Hidden = false;
                // Adicionar registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (!listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Add(e.Row.Cells[0].Value.ToString());
                }

            }

        }

        private void grdDetallePildorasOfima_CellChange(object sender, CellEventArgs e)
        {
            //Este proceso se realiza para la busuqueda de las columnas que tienen el combobox   
            if (e.Cell.Column.Key == "IdModulo" || e.Cell.Column.Key == "IdMenuERP" || e.Cell.Column.Key == "CodigoPais" ||
               e.Cell.Column.Key == "idPildoraOfima" || e.Cell.Column.Key == "IdMotivo" || e.Cell.Column.Key == "IdClasificacion" ||
               e.Cell.Column.Key == "IdPerfil")
            {

                this.grdDetallePildorasOfima.ActiveCell.DroppedDown = true;
                int longInfoBuscar = 0;
                if (infoBuscar != null)
                {
                    longInfoBuscar = infoBuscar.Length;
                }

                this.grdDetallePildorasOfima.ActiveCell.SelStart = longInfoBuscar;
                if (this.grdDetallePildorasOfima.ActiveCell.Text.Length > 0 & this.grdDetallePildorasOfima.ActiveCell.Text.Length >= longInfoBuscar)
                {
                    this.grdDetallePildorasOfima.ActiveCell.SelLength = this.grdDetallePildorasOfima.ActiveCell.Text.Length - longInfoBuscar;
                }

                // si solo encontro un registro lo selecciona automaticamente.
                if (listadoDropDown.Count == 1)
                {
                    SendKeys.Send("{DOWN}");
                }
                listadoDropDown = new List<string>();
            }
        }

        private void CboMenu_FilterRow(object sender, FilterRowEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hola");
            // se obtiene el valor digitado en el grid 
            string valorActual = this.grdDetallePildorasOfima.ActiveCell.Text;

            // Se almacena este valor en la propiedad Presentacion.infoBuscar para mostrar correctamente el DropDown
            infoBuscar = valorActual;

            // Buscar en todas las columnas si encuentra el valor digitado
            bool filterRow = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.CboMenu.DisplayLayout.Bands[0].Columns)
            {
                // solo filtra si la columna se muestra en el DropDown
                if (column.IsVisibleInLayout)
                {
                    // validar que la propiedad valorActual posea información
                    // Buscar que la columna contenga el valor
                    if (valorActual != null)
                    {
                        if (e.Row.Cells[column].Text.ToUpper().Contains(valorActual.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
            }

            // Si la columna contiene el valor se muestra en los resultados de lo contrario no
            if (filterRow)
            {
                e.Row.Hidden = true;
                // remover registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Remove(e.Row.Cells[0].Value.ToString());
                }
            }
            else
            {
                e.Row.Hidden = false;
                // Adicionar registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (!listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Add(e.Row.Cells[0].Value.ToString());
                }

            }
        }

        private void CboPais_FilterRow(object sender, FilterRowEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hola");
            // se obtiene el valor digitado en el grid 
            string valorActual = this.grdDetallePildorasOfima.ActiveCell.Text;

            // Se almacena este valor en la propiedad Presentacion.infoBuscar para mostrar correctamente el DropDown
            infoBuscar = valorActual;

            // Buscar en todas las columnas si encuentra el valor digitado
            bool filterRow = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.CboPais.DisplayLayout.Bands[0].Columns)
            {
                // solo filtra si la columna se muestra en el DropDown
                if (column.IsVisibleInLayout)
                {
                    // validar que la propiedad valorActual posea información
                    // Buscar que la columna contenga el valor
                    if (valorActual != null)
                    {
                        if (e.Row.Cells[column].Text.ToUpper().Contains(valorActual.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
            }

            // Si la columna contiene el valor se muestra en los resultados de lo contrario no
            if (filterRow)
            {
                e.Row.Hidden = true;
                // remover registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Remove(e.Row.Cells[0].Value.ToString());
                }
            }
            else
            {
                e.Row.Hidden = false;
                // Adicionar registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (!listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Add(e.Row.Cells[0].Value.ToString());
                }

            }
        }

        private void CboPildoraClasificacion_FilterRow(object sender, FilterRowEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hola");
            // se obtiene el valor digitado en el grid 
            string valorActual = this.grdDetallePildorasOfima.ActiveCell.Text;

            // Se almacena este valor en la propiedad Presentacion.infoBuscar para mostrar correctamente el DropDown
            infoBuscar = valorActual;

            // Buscar en todas las columnas si encuentra el valor digitado
            bool filterRow = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.CboPildoraClasificacion.DisplayLayout.Bands[0].Columns)
            {
                // solo filtra si la columna se muestra en el DropDown
                if (column.IsVisibleInLayout)
                {
                    // validar que la propiedad valorActual posea información
                    // Buscar que la columna contenga el valor
                    if (valorActual != null)
                    {
                        if (e.Row.Cells[column].Text.ToUpper().Contains(valorActual.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
            }

            // Si la columna contiene el valor se muestra en los resultados de lo contrario no
            if (filterRow)
            {
                e.Row.Hidden = true;
                // remover registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Remove(e.Row.Cells[0].Value.ToString());
                }
            }
            else
            {
                e.Row.Hidden = false;
                // Adicionar registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (!listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Add(e.Row.Cells[0].Value.ToString());
                }

            }
        }

        private void CboMotivo_FilterRow(object sender, FilterRowEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hola");
            // se obtiene el valor digitado en el grid 
            string valorActual = this.grdDetallePildorasOfima.ActiveCell.Text;

            // Se almacena este valor en la propiedad Presentacion.infoBuscar para mostrar correctamente el DropDown
            infoBuscar = valorActual;

            // Buscar en todas las columnas si encuentra el valor digitado
            bool filterRow = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.CboMotivo.DisplayLayout.Bands[0].Columns)
            {
                // solo filtra si la columna se muestra en el DropDown
                if (column.IsVisibleInLayout)
                {
                    // validar que la propiedad valorActual posea información
                    // Buscar que la columna contenga el valor
                    if (valorActual != null)
                    {
                        if (e.Row.Cells[column].Text.ToUpper().Contains(valorActual.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
            }

            // Si la columna contiene el valor se muestra en los resultados de lo contrario no
            if (filterRow)
            {
                e.Row.Hidden = true;
                // remover registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Remove(e.Row.Cells[0].Value.ToString());
                }
            }
            else
            {
                e.Row.Hidden = false;
                // Adicionar registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (!listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Add(e.Row.Cells[0].Value.ToString());
                }

            }
        }

        private void CboPerfil_FilterRow(object sender, FilterRowEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hola");
            // se obtiene el valor digitado en el grid 
            string valorActual = this.grdDetallePildorasOfima.ActiveCell.Text;

            // Se almacena este valor en la propiedad Presentacion.infoBuscar para mostrar correctamente el DropDown
            infoBuscar = valorActual;

            // Buscar en todas las columnas si encuentra el valor digitado
            bool filterRow = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.CboPerfil.DisplayLayout.Bands[0].Columns)
            {
                // solo filtra si la columna se muestra en el DropDown
                if (column.IsVisibleInLayout)
                {
                    // validar que la propiedad valorActual posea información
                    // Buscar que la columna contenga el valor
                    if (valorActual != null)
                    {
                        if (e.Row.Cells[column].Text.ToUpper().Contains(valorActual.ToUpper()))
                        {
                            filterRow = false;
                            break;
                        }
                    }
                }
            }

            // Si la columna contiene el valor se muestra en los resultados de lo contrario no
            if (filterRow)
            {
                e.Row.Hidden = true;
                // remover registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Remove(e.Row.Cells[0].Value.ToString());
                }
            }
            else
            {
                e.Row.Hidden = false;
                // Adicionar registro del listado. El listado se usa para que cuando sea un solo registro encontrado lo seleccione inmediatamente.
                if (!listadoDropDown.Contains(e.Row.Cells[0].Value.ToString()))
                {
                    listadoDropDown.Add(e.Row.Cells[0].Value.ToString());
                }

            }
        }

       
    }
}
