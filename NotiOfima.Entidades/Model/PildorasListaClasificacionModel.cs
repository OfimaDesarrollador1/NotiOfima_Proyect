using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiOfima.Entidades.Model
{
    public class PildorasListaClasificacionModel
    {
        public PildorasListaClasificacionModel()
        {

        }

        [DisplayName("IdClasificacion")]
        public Guid IdClasificacion { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }


        //Consultar los mudulos 
        public static BindingList<PildorasListaClasificacionModel> ConsultarListaClasificacion()
        {
            BindingList<PildorasListaClasificacionModel> ListaClasificacion = new BindingList<PildorasListaClasificacionModel>();

            string stringSQL = "spPildoras_PildoraClasificacionConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtClasificacion = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            foreach (DataRow row in dtClasificacion.Rows)
            {
                PildorasListaClasificacionModel RegistroClasificacion = new PildorasListaClasificacionModel();
                RegistroClasificacion.IdClasificacion = (Guid)row["IdClasificacion"];
                RegistroClasificacion.Nombre = row["Nombre"].ToString();
                ListaClasificacion.Add(RegistroClasificacion);

            }
            return ListaClasificacion;
        }



    }
}

