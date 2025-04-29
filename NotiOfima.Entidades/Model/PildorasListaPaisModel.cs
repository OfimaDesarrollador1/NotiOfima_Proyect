using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiOfima.Entidades.Model
{
    public class PildorasListaPaisModel
    {
        public PildorasListaPaisModel()
        {

        }

        [DisplayName("Codigo")]
        public string Codigo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }


        //Consultar los mudulos 
        public static BindingList<PildorasListaPaisModel> ConsultarListaPais()
        {
            BindingList<PildorasListaPaisModel> listadoMtPaissModel = new BindingList<PildorasListaPaisModel>();

            string stringSQL = "spPildoras_MtPaisConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtMtPais = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            foreach (DataRow row in dtMtPais.Rows)
            {
                PildorasListaPaisModel registroMtPais = new PildorasListaPaisModel();
                registroMtPais.Codigo = row["Codigo"].ToString();
                registroMtPais.Nombre = row["Nombre"].ToString();
                listadoMtPaissModel.Add(registroMtPais);

            }
            return listadoMtPaissModel;
        }



    }
}
