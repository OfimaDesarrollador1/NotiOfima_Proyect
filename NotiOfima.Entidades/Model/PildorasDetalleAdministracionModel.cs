using NotiOfima.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace NotiOfima.Entidades.Model
{
    public class PildorasDetalleAdministracionModel
    {
        public PildorasDetalleAdministracionModel()
        {

        }

        [DisplayName("Eliminar")]
        public Boolean Eliminar { get; set; }

        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [DisplayName("IdModulo")]
        public string IdModulo { get; set; }

        [DisplayName("IdMenuERP")]
        public string IdMenuERP { get; set; }

        [DisplayName("Link")]
        public string Link { get; set; }

        [DisplayName("FechaCreacion")]
        public string FechaCreacion { get; set; }

        [DisplayName("FechaExpiracion")]
        public string FechaExpiracion { get; set; }

        [DisplayName("Imagen")]
        public byte[] Imagen { get; set; }

        [DisplayName("btnSubirArchivo")]
        public string btnSubirArchivo { get; set; }

        [DisplayName("CodigoPais")]
        public string CodigoPais { get; set; }

        [DisplayName("idPildoraOfima")]
        public Guid idPildoraOfima { get; set; }

        [DisplayName("IdMotivo")]
        public Guid IdMotivo { get; set; }

        [DisplayName("IdClasificacion")]
        public Guid IdClasificacion { get; set; }

        [DisplayName("IdPerfil")]
        public Guid IdPerfil { get; set; }


        //Metodo para consultar la lista de los Auditor
        public static BindingList<PildorasDetalleAdministracionModel> ConsultarDetalleAdministradorPildoras()
        {
            BindingList<PildorasDetalleAdministracionModel> ListadoDetalleAdministradorPildoras = new BindingList<PildorasDetalleAdministracionModel>();

            string stringSQL = "spPildoras_DetalleAdministradorConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtListadoincidentes = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);


            foreach (DataRow row in dtListadoincidentes.Rows)
            {
                PildorasDetalleAdministracionModel RegistroDetalleAdministradorPildoras = new PildorasDetalleAdministracionModel();
                RegistroDetalleAdministradorPildoras.Eliminar = Boolean.Parse(row["Eliminar"].ToString()); 
                RegistroDetalleAdministradorPildoras.Titulo = row["Titulo"].ToString();
                RegistroDetalleAdministradorPildoras.IdModulo = row["IdModulo"].ToString();
                RegistroDetalleAdministradorPildoras.IdMenuERP = row["IdMenuERP"].ToString();
                RegistroDetalleAdministradorPildoras.Link = row["Link"].ToString();
                RegistroDetalleAdministradorPildoras.FechaCreacion = row["FechaCreacion"].ToString();
                RegistroDetalleAdministradorPildoras.FechaExpiracion = row["FechaExpiracion"].ToString();                                
                RegistroDetalleAdministradorPildoras.Imagen = (byte[])row["Imagen"];                
                RegistroDetalleAdministradorPildoras.btnSubirArchivo = row["btnSubirArchivo"].ToString(); 
                RegistroDetalleAdministradorPildoras.CodigoPais = row["CodigoPais"].ToString(); 
                RegistroDetalleAdministradorPildoras.idPildoraOfima = (Guid)row["idPildoraOfima"];
                RegistroDetalleAdministradorPildoras.IdMotivo = (Guid)row["IdMotivo"]; 
                RegistroDetalleAdministradorPildoras.IdClasificacion = (Guid)row["IdClasificacion"];
                RegistroDetalleAdministradorPildoras.IdPerfil = (Guid)row["IdPerfil"];
                ListadoDetalleAdministradorPildoras.Add(RegistroDetalleAdministradorPildoras);

            }
            return ListadoDetalleAdministradorPildoras;
        }

        /*
        //Guardar los campos Publicado Cliente Activo
        public static void GuardarPildorasDetalleAdministracion(BindingList<PildorasDetalleAdministracionModel> PildorasDetalleAdministracion)

        {
            foreach (PildorasDetalleAdministracionModel registroPildorasDetalleAdministracion in PildorasDetalleAdministracion)
            {
                string stringSQL = "spPildoras_DetalleAdministradorGuardar";

                //Valores de los parametros
                Dictionary<string, object> parametroSQL = new Dictionary<string, object>();

                //idDetalleModuloIncidente esta nulo                 
                if (registroPildorasDetalleAdministracion.idPildoraOfima == Guid.Empty)
                {
                    registroPildorasDetalleAdministracion.idPildoraOfima = Guid.NewGuid();
                }
                
                parametroSQL.Add("@pidPildoraOfima", (Guid)registroPildorasDetalleAdministracion.idPildoraOfima);
                parametroSQL.Add("@pTitulo", registroPildorasDetalleAdministracion.Titulo.ToString());
                parametroSQL.Add("@pIdModulo", registroPildorasDetalleAdministracion.IdModulo.ToString());
                parametroSQL.Add("@pIdMenuERP", registroPildorasDetalleAdministracion.IdMenuERP.ToString());
                parametroSQL.Add("@pLink", registroPildorasDetalleAdministracion.Link.ToString());
                parametroSQL.Add("@pFechaCreacion", DateTime.Parse(registroPildorasDetalleAdministracion.FechaCreacion));
                parametroSQL.Add("@pFechaExpiracion", DateTime.Parse(registroPildorasDetalleAdministracion.FechaExpiracion));
                parametroSQL.Add("@pImagen", registroPildorasDetalleAdministracion.Imagen);                               
                parametroSQL.Add("@pCodigoPais", registroPildorasDetalleAdministracion.CodigoPais.ToString());                                           
                parametroSQL.Add("@pIdClasificacion", (Guid)registroPildorasDetalleAdministracion.IdClasificacion);
                parametroSQL.Add("@pIdMotivo", registroPildorasDetalleAdministracion.IdMotivo);               
                parametroSQL.Add("@pIdPerfil", (Guid)registroPildorasDetalleAdministracion.IdPerfil);
                parametroSQL.Add("@pEliminar", Boolean.Parse(registroPildorasDetalleAdministracion.Eliminar.ToString()));
            
                AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            }

        }  
        */
    }
}
