using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ofima.Pildoras.VisorERP
{
    public partial class FrmMostrarImagen : UserControl
    {
        public FrmMostrarImagen()
        {
            InitializeComponent();

            //Poner transparentes los controles del formulario 
            txtNombre.BackColor = Color.Transparent;
            ImagenaMostrar.BackColor = Color.Transparent;
        }

        public FrmMostrarImagen(Image pImagen, string pNombre, string pLink, string pIdPildoraOfima, string pConexionSQL, string pModulo, string pUsuario)
        {
            InitializeComponent();
            
            mNombre = pNombre;
            mLink = pLink;
            mImagen = pImagen;
            mIdPildoraOfima = pIdPildoraOfima;
            mConexionSQL = pConexionSQL;
            mModulo = pModulo;
            mUsuario = pUsuario;

            //Que no se selecione el texto 
            txtNombre.SelectionStart = 0;            
        }

        public string mConexionSQL { get; set; }
        public string mModulo { get; set; }
        public string mUsuario { get; set; }



        public string mNombre
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }

        public string mLink { get; set; }

        public string mIdPildoraOfima { get; set; }

        public Image mImagen
        {
            get => ImagenaMostrar.Image;
            set => ImagenaMostrar.Image = value;
        }

        private void ImagenaMostrar_Click(object sender, EventArgs e)
        {
            //Insertar
            Insertar();
            //Start y abrir hipervinculo 
            System.Diagnostics.Process.Start(mLink);
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            //Insertar
            Insertar();
            //Start y abrir hipervinculo 
            System.Diagnostics.Process.Start(mLink);
            
        }

        //Insertar
        public void Insertar()
        {
            string mConsultaPildoras = " If not Exists(select CodigoUsuario,idPildoraOfima " +
                                       "             from PildoraVisualizaUsuario           " +
                                       "             where CodigoUsuario=@pCodigoUsuario and IdPildoraOfima=@pIdPildoraOfima) " +
                                       " Begin                                              " +
                                       "     INSERT INTO dbo.PildoraVisualizaUsuario        " +
                                       "            (CodigoUsuario                          " +
                                       "            ,idPildoraOfima)                        " +
                                       "      VALUES                                        " +
                                       "            (@pCodigoUsuario                        " +
                                       "            ,@pIdPildoraOfima)                      " +
                                       " End                                                ";

            //Valores de los parametros 
            Dictionary<string, object> parametrosSqlPildoras = new Dictionary<string, object>();
            parametrosSqlPildoras.Add("@pCodigoUsuario", mUsuario);
            parametrosSqlPildoras.Add("@pIdPildoraOfima", mIdPildoraOfima);
            //Crear datatable 
            DataTable dtPildoras = AccesoSQL.EjecutarQuery(mConsultaPildoras, parametrosSqlPildoras, this.mConexionSQL);
        }

    }

    

}
