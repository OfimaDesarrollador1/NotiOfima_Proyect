using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiOfima.Entidades.Model
{
    public class PildorasListaMotivoModel
    {
        public PildorasListaMotivoModel()
        {

        }

        [DisplayName("IdMotivo")]
        public Guid IdMotivo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }


        //Consultar los mudulos 
        public static BindingList<PildorasListaMotivoModel> ConsultarListaMotivo()
        {
            BindingList<PildorasListaMotivoModel> ListaMotivo = new BindingList<PildorasListaMotivoModel>();

            string stringSQL = "spPildoras_PildoraMotivoConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtMotivo = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            foreach (DataRow row in dtMotivo.Rows)
            {
                PildorasListaMotivoModel RegistroMotivo = new PildorasListaMotivoModel();
                RegistroMotivo.IdMotivo = (Guid)row["IdMotivo"];
                RegistroMotivo.Nombre = row["Nombre"].ToString();
                ListaMotivo.Add(RegistroMotivo);
            }
            return ListaMotivo;
        }
    }
}

