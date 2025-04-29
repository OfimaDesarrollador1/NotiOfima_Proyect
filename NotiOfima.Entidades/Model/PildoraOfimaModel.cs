using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace NotiOfima.Entidades.Model
{
    /// <summary>
    /// Clase que permite interactuar con la tabla de Pildoras
    /// </summary>
    public class PildoraOfimaModel
    {
        public PildoraOfimaModel()
        {

        }

        /// <summary>
        /// Propiedades de la clase Pildoras
        /// </summary>
        #region Propiedades
        [Description("Id Clave de pildora .")]
        public Guid IdPildora { get; set; }

        [Description("Titulo de la pildora")]
        public string Titulo { get; set; }

        [Description("Codigo del Modulo")]
        public string IdModulo { get; set; }

        [Description("Codigo programa del menu ERP")]
        public string IdMenuERP { get; set; }

        [Description("URL acceso video pildora")]
        public string LinkAcceso { get; set; }

        [Description("Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        [Description("Fecha Experirara")]
        public DateTime FechaExpiracion { get; set; }

        [Description("Imagen a Mostrar ")]
        public byte[] ImagenMostrar { get; set; }

        [Description("Codigo del pais")]
        public string CodigoPais { get; set; }

        [Description("Codigo Motivo")]
        public Guid IdMotivo { get; set; }

        [Description("Codigo Clasificacion")]
        public Guid IdClasificacion { get; set; }

        [Description("Codigo Perfil")]
        public Guid IdPerfil { get; set; }


        /// <summary>
        /// Propiedades para la descargar desde el ERP Cliente
        /// </summary>
        #region Propiedades para la descargar desde el ERP Cliente
        [Description("Motivo")]
        public PildoraMotivoModel Motivo { get; set; }

        [Description("Clasificacion")]
        public PildoraClasificacionModel Clasificacion { get; set; }

        [Description("Perfil")]
        public PildoraPerfilModel Perfil { get; set; }

        #endregion

        #endregion


        /// <summary>
        /// Metodos de la clase Pildoras Ofima
        /// </summary>
        #region Metodos
   

        /// <summary>
        /// Metodo para ir creando archivo con el seguimiento
        /// </summary>
        /// <param name="p"></param>
        public static void crearArchivoSeguimiento(string texto, string path = @"C:\Ofimatica\", string nombreArchivo = "seguimientoPildoras.txt")
        {
            Directory.CreateDirectory(path);
            string archivoSeguimiento = System.IO.Path.Combine(path, nombreArchivo);

            using (System.IO.StreamWriter writerCliente = new System.IO.StreamWriter(archivoSeguimiento, true))
            {
                string fecha = DateTime.Now.ToString();
                writerCliente.WriteLine("\r\n\r\n" + fecha + "\r\n" + texto);
            }
        }

        #endregion


        /// <summary>
        /// Metodos para la descargar desde el ERP Cliente
        /// </summary>
        #region Metodos para la descargar desde el ERP Cliente
        public static List<PildoraOfimaModel> ConsultarPildoraAllServer(string codigoModulo)
        {
            List<PildoraOfimaModel> listadoPildoras = new List<PildoraOfimaModel>();
            try
            {
                string stringSQL = "spPildoraOF_ConsultarPildoraServer";

                //Valores de los parametros
                Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
                parametroSQL.Add("@pCodigoModulo", codigoModulo);

                DataTable dtRegistroPildoras = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

                foreach (DataRow filaPildora in dtRegistroPildoras.Rows)
                {
                    PildoraOfimaModel pildora = new PildoraOfimaModel()
                    {
                        IdPildora = Guid.Parse(filaPildora["idPildoraOfima"].ToString()),
                        Titulo = filaPildora["Titulo"].ToString(),
                        IdModulo = filaPildora["idModulo"].ToString(),
                        IdMenuERP = filaPildora["IdMenuERP"].ToString(),
                        LinkAcceso = filaPildora["Link"].ToString(),
                        FechaCreacion = Convert.ToDateTime(filaPildora["FechaCreacion"]),
                        FechaExpiracion = Convert.ToDateTime(filaPildora["FechaExpiracion"]),
                        ImagenMostrar = (byte[])(filaPildora["Imagen"]),
                        CodigoPais = filaPildora["CodigoPais"].ToString(),
                        IdMotivo = Guid.Parse(filaPildora["IdMotivo"].ToString()),
                        IdClasificacion = Guid.Parse(filaPildora["IdClasificacion"].ToString()),
                        IdPerfil = Guid.Parse(filaPildora["IdPerfil"].ToString())
                    };

                    PildoraMotivoModel pildoraMotivo = new PildoraMotivoModel()
                    {
                        Codigo = filaPildora["IdMotivo"].ToString(),
                        Nombre = filaPildora["NombreMotivo"].ToString(),
                    };
                    pildora.Motivo = pildoraMotivo;

                    PildoraClasificacionModel pildoraClasificacion = new PildoraClasificacionModel()
                    {
                        Codigo = filaPildora["IdClasificacion"].ToString(),
                        Nombre = filaPildora["NombreClasificacion"].ToString()
                    };
                    pildora.Clasificacion = pildoraClasificacion;

                    PildoraPerfilModel pildoraPerfil = new PildoraPerfilModel()
                    {
                        Codigo = filaPildora["IdPerfil"].ToString(),
                        Nombre = filaPildora["NombrePerfil"].ToString()
                    };
                    pildora.Perfil = pildoraPerfil;

                    listadoPildoras.Add(pildora);
                }

                //crearArchivoSeguimiento("OK"+listadoNotas.Count.ToString());

            }
            catch (Exception e)
            {
                crearArchivoSeguimiento("Error Metodo ConsultarPildoraServer : " + e.Message);
                //MessageBox.Show(e.Message, "Cosultar Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listadoPildoras;
        }

        #endregion



    }
}
