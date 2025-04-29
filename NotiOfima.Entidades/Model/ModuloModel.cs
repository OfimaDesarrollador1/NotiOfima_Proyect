using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace NotiOfima.Entidades.Model
{
    public class ModuloModel
    {

        /// <summary>
        /// Propiedades de la clase Modulo
        /// </summary>
        #region Propiedades
        [Description("Codigo Modulo .")]
        public string Codigo { get; set; }

        [Description("Nombre Modulo .")]
        public string Nombre { get; set; }



        #endregion


        /// <summary>
        /// Metodos de la clase Pildoras Ofima
        /// </summary>
        #region Metodos
        public static List<ModuloModel> ConsultarTodo()
        {
            List<ModuloModel> listadoDevolver = null;
            try
            {
                string stringSQL = "spPildoraOF_ConsultarModulo";

                //Valores de los parametros
                Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
                //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

                DataTable dtRegistroData = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

                foreach (DataRow filaDato in dtRegistroData.Rows)
                {
                    ModuloModel registro = new ModuloModel()
                    {
                        Codigo = filaDato["Codigo"].ToString(),
                        Nombre = filaDato["Nombre"].ToString()

                    };
                    listadoDevolver.Add(registro);
                }

                //crearArchivoSeguimiento("OK"+listadoNotas.Count.ToString());

            }
            catch (Exception e)
            {
                 PildoraOfimaModel.crearArchivoSeguimiento("Error Metodo ConsultarModulo : " + e.Message);
                //MessageBox.Show(e.Message, "Cosultar Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listadoDevolver;
        }
        #endregion

    }
}
