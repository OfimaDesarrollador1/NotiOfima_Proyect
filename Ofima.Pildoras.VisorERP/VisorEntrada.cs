using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofima.Pildoras.VisorERP
{
    public partial class VisorEntrada : Form
    {
        string mConexionDataSQL = string.Empty;
        string mModulo = string.Empty;
        string mUsuario = string.Empty;
        string pais = string.Empty;
        
        public VisorEntrada(string conexionSQL, string pModulo, string pUsuario, string pDescripcionModulo, string pPais)
        {
            InitializeComponent();

            this.mConexionDataSQL = conexionSQL;
            this.mModulo = pModulo;
            this.mUsuario = pUsuario;
            this.LblDescripcioModulo.Text = pDescripcionModulo;
            this.pais = pPais;
        }
              
        private void VisorEntrada_Load(object sender, EventArgs e)
        {

            try
            {
                //string mConsultaPildoras = "SELECT Imagen,Titulo,Link FROM dbo.PildoraOfima where EsPildoraNueva = 1 and Modulo = @pModulo";

                string mConsultaPildoras = " SELECT Imagen,Titulo,Link,IdPildoraOfima           " +
                                           "     FROM dbo.PildoraOfima                          "+
                                           "     where EsPildoraNueva = 1 and Modulo IN (@pModulo,'TODOS') And CodigoPais IN (@pPais,'0') " +
                                           "     and FechaExpiracion >= GETDATE()               " +
                                           "     and Fechacreacion >= '20230101'               " +
                                           "     AND idPildoraOfima NOT IN(select idPildoraOfima from PildoraVisualizaUsuario where CodigoUsuario = @pUsuario)";

                //Valores de los parametros 
                Dictionary<string, object> parametrosSqlPildoras = new Dictionary<string, object>();
                parametrosSqlPildoras.Add("@pModulo", mModulo);
                parametrosSqlPildoras.Add("@pUsuario", mUsuario);
                parametrosSqlPildoras.Add("@pPais", pais);

                //Crear datatable 
                DataTable dtPildoras = AccesoSQL.EjecutarQuery(mConsultaPildoras, parametrosSqlPildoras, this.mConexionDataSQL);
                //Pasar el datatable a un datarider 
                DataTableReader r = dtPildoras.CreateDataReader();

                int x = 1, y = 1;
                while (r.Read())
                {
                    //leer la foto y convertirla a imagen 
                    byte[] mFoto = (byte[])r[0];
                    Image mImagen = ConvertirByteArrayToImage(mFoto);

                    //Titulo 
                    string mTitulo = r[1].ToString().Trim();
                    //Link 
                    string mLink = r[2].ToString().Trim();

                    string mIdPildoraOfima = r[3].ToString().Trim();

                    //Ejecutar el formulario FrmMostrarImagen y enviarle los parametros 
                    FrmMostrarImagen obj = new FrmMostrarImagen(mImagen, mTitulo, mLink, mIdPildoraOfima, this.mConexionDataSQL, this.mModulo, this.mUsuario);

                    //llenar el control tableLayoutPanel
                    tableLayoutPanel.Controls.Add(obj, y, x);
                    y++;
                    if (y >= 4)
                    {
                        y = 1;
                        x++;
                    }
                }
                r.Close();
                dtPildoras.Clone();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Metodo para convertir una Imagen tipo byte a Image y retornar el valor  
        public Image ConvertirByteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        

    }
}
