using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiOfima.Entidades.Model
{
    public class PildorasListaMenuModel
    {
        public PildorasListaMenuModel()
        {

        }

        [DisplayName("idMenu")]
        public string idMenu { get; set; }

        [DisplayName("OpcionMenuERP")]
        public string OpcionMenuERP { get; set; }


        //Consultar los mudulos 
        public static BindingList<PildorasListaMenuModel> ConsultarListaMenu()
        {
            BindingList<PildorasListaMenuModel> listadoMenusModel = new BindingList<PildorasListaMenuModel>();

            string stringSQL = "spPildoras_vOfimaERP_MenuConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtMenus = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            foreach (DataRow row in dtMenus.Rows)
            {
                PildorasListaMenuModel registroMenus = new PildorasListaMenuModel();
                registroMenus.idMenu = row["idMenu"].ToString();
                registroMenus.OpcionMenuERP = row["OpcionMenuERP"].ToString();
                listadoMenusModel.Add(registroMenus);

            }
            return listadoMenusModel;
        }



    }
}
