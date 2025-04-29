using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiOfima.Entidades.Model
{
    public class PildorasListaPerfilModel
    {
        public PildorasListaPerfilModel()
        {

        }

        [DisplayName("IdPerfil")]
        public Guid IdPerfil { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }


        //Consultar los mudulos 
        public static BindingList<PildorasListaPerfilModel> ConsultarListaPerfil()
        {
            BindingList<PildorasListaPerfilModel> ListaPerfil = new BindingList<PildorasListaPerfilModel>();

            string stringSQL = "spPildoras_PildoraPerfilConsultar";

            //Valores de los parametros
            Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
            //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

            DataTable dtPerfil = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

            foreach (DataRow row in dtPerfil.Rows)
            {
                PildorasListaPerfilModel RegistroPerfil = new PildorasListaPerfilModel();
                RegistroPerfil.IdPerfil = (Guid)row["IdPerfil"];
                RegistroPerfil.Nombre = row["Nombre"].ToString();
                ListaPerfil.Add(RegistroPerfil);
            }
            return ListaPerfil;
        }
    }
}

