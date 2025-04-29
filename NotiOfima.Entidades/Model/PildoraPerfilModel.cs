using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NotiOfima.Entidades.Model
{
    public class PildoraPerfilModel
    {

        public PildoraPerfilModel()
        {

        }

        /// <summary>
        /// Propiedades de la clase ¨Perfil
        /// </summary>
        #region Propiedades
        [Description("Codigo  .")]
        public string Codigo { get; set; }

        [Description("Nombre  .")]
        public string Nombre { get; set; }

        #endregion

    }

}
