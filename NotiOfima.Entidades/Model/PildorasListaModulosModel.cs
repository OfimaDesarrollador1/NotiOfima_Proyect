using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiOfima.Entidades.Model
{
    public class PildorasListaModulosModel
    {
        public PildorasListaModulosModel()
        {

        }

        [DisplayName("CodigoModulo")]
        public string CodigoModulo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }


        //Consultar los mudulos 
        public static BindingList<PildorasListaModulosModel> ConsultarListaModulos()
        {
            BindingList<PildorasListaModulosModel> listadoModulosModel = new BindingList<PildorasListaModulosModel>();

            string stringSQL = "spPildoras_vOfimaERP_ModulosConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtModulos = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            foreach (DataRow row in dtModulos.Rows)
            {
                PildorasListaModulosModel registroModulos = new PildorasListaModulosModel();
                registroModulos.CodigoModulo = row["CodigoModulo"].ToString();
                registroModulos.Nombre = row["Nombre"].ToString();
                listadoModulosModel.Add(registroModulos);

            }
            return listadoModulosModel;
        }

    }
}
