using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ofima.Pildoras.VisorERP
{
    public partial class VisorModulo : Form
    {
        string mConexionDataSQL = string.Empty;
        string mModulo = string.Empty;
        string mOpcionERP = string.Empty;
        string mCodUsuario = string.Empty;
        string pais = string.Empty;
        

        public VisorModulo(string conexionSQL,string pModulo, string pOpcionERP, string pCodUsuario, string pDescripcionModulo, string pPais)
        {
            InitializeComponent();

            this.mConexionDataSQL = conexionSQL;
            this.mModulo = pModulo;
            this.mOpcionERP = pOpcionERP;
            this.mCodUsuario = pCodUsuario;
            this.LblDescripcioModulo.Text  = pDescripcionModulo;
            this.pais = pPais;
        }

      

        private void VisorModulo_Load(object sender, EventArgs e)
        {
            
            try
            {


                //Valores de los parametros 
                Dictionary<string, object> parametrosSqlPildoras = new Dictionary<string, object>();
                
                string mConsultaPildoras = "";


                if (mOpcionERP == "EsPorModuloSinOpcionERP")
                {
                    mConsultaPildoras = " SELECT Imagen,Titulo,Link,IdPildoraOfima " +
                                                               "    FROM dbo.PildoraOfima where FechaExpiracion >= GETDATE() and " +
                                                               "        Modulo IN (@pModulo,'TODOS') And CodigoPais IN (@pPais,'0')  ";

                    parametrosSqlPildoras.Add("@pModulo", mModulo);
                    parametrosSqlPildoras.Add("@pPais", pais);

                }
                else
                {
                    mConsultaPildoras = " SELECT Imagen,Titulo,Link,IdPildoraOfima " +
                                               "    FROM dbo.PildoraOfima where FechaExpiracion >= GETDATE() and " +
                                               "        Modulo IN (@pModulo,'TODOS') And CodigoPais IN (@pPais,'0') and " +
                                               "    OpcionERP = @pOpcionERP";

                    parametrosSqlPildoras.Add("@pModulo", mModulo);
                    parametrosSqlPildoras.Add("@pOpcionERP", mOpcionERP);
                    parametrosSqlPildoras.Add("@pPais", pais);
                }



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
                    FrmMostrarImagen obj = new FrmMostrarImagen(mImagen, mTitulo, mLink, mIdPildoraOfima, this.mConexionDataSQL, this.mModulo, this.mCodUsuario);

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
