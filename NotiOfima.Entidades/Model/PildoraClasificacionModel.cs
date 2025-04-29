using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NotiOfima.Entidades.Model
{
    public class PildoraClasificacionModel
    {
        public PildoraClasificacionModel()
        {

        }


        /// <summary>
        /// Propiedades de la clase Clasificacion
        /// </summary>
        #region Propiedades
        [Description("Codigo Clasificacion .")]
        public string Codigo { get; set; }

        [Description("Nombre Clasifiacion .")]
        public string Nombre { get; set; }



        #endregion

    }
}