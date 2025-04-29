using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotiOfima.Entidades.Model
{
    /// <summary>
    /// Me permite consultar los paises configurados para el sistema Ofimatica.
    /// </summary>
    public class PaisesModel
    {
        /// <summary>
        /// Constructor de la clase PaisesModel
        /// </summary>
        public PaisesModel()
        {
        }

        /// <summary>
        /// Propiedades de la clase PaisesModel, Coinciden con los campos de la estructura de datos
        /// </summary>
        #region Propiedades
        public string Codigo { get; set; }
        public string Pais { get; set; }
        #endregion

        /// <summary>
        /// Metodos de la clase PaisesModel
        /// </summary>
        #region Metodos


        // Clase para mostrar todos los paises
        // Por medio de este metodo se llena la información a mostrar en el combo de paises 
        public static List<PaisesModel> Consultar()
        {
            List<PaisesModel> listadoPaises = null;
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();

                listadoPaises = (from c in entidadDatos.MTPAIS
                                 select c).Select(a => new PaisesModel
                                 {
                                     Codigo = a.CODIGO,
                                     Pais = a.DESCRIPCIO
                                 }).ToList();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Consultar Paises", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            return listadoPaises;
        }

        /// <summary>
        /// El metodo ToString es el que me define lo que se muestra en la ventana de propiedades
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Codigo + " - " + Pais;
        }

        #endregion

    }
}
