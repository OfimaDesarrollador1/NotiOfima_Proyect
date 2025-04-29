using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace NotiOfima.Entidades.Model
{
    public class PildoraMotivoModel
    {


        /// <summary>
        /// Propiedades de la clase Motivo
        /// </summary>
        #region Propiedades
        [Description("Codigo Motivo .")]
        public string Codigo { get; set; }

        [Description("Nombre Motivo .")]
        public string Nombre { get; set; }



        #endregion


        /// <summary>
        /// Metodos de la clase Pildoras Motivo
        /// </summary>
        #region Metodos
        public static List<PildoraMotivoModel> ConsultarTodo()
        {
            List<PildoraMotivoModel> listadoDevolver = null;
            try
            {
                string stringSQL = "spPildoraOF_ConsultarMotivo";

                //Valores de los parametros
                Dictionary<string, object> parametroSQL = new Dictionary<string, object>();
                //parametroSQL.Add("@pidRegistroIncidente", idRegistroIncidente);

                DataTable dtRegistroData = AccesoSQL.EjecutarSP(stringSQL, parametroSQL);

                foreach (DataRow filaDato in dtRegistroData.Rows)
                {
                    PildoraMotivoModel registro = new PildoraMotivoModel()
                    {
                        Codigo = filaDato["IdMotivo"].ToString(),
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
