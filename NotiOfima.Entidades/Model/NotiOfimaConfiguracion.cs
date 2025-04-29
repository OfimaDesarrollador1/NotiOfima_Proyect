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
    /// Clase que permite interactuar con la tabla NotiOfimaConfiguracion
    /// </summary>
    public class NotiOfimaConfiguracionTable
    {
        /// <summary>
        /// Constructor de la clase NotiOfimaConfiguracionTable
        /// </summary>
        public NotiOfimaConfiguracionTable()
        {
        }

        [Category("General"), Description("Cada cuantas horas se desea mostrar las notas en el cliente."),
        DisplayName("Frecuencia Mostrar"), ReadOnly(true)]
        public int FrecuenciaMostrar { get; set; }

        [Category("General"), Description("Indica la ultima fecha de ejecucion de notiOfima."),
        DisplayName("Ultima Ejecución")]
        public DateTime UltimaEjecucion { get; set; }

        [Category("General"), Description("Campo que indica el tiempo de inactividad antes de mostrar la nota."),
        DisplayName("Tiempo Inactividad"), ReadOnly(true)]
        public int tiempoInactivo { get; set; }
        


        /// <summary>
        /// Metodos de la clase NotiOfimaConfiguracionTable
        /// </summary>
        #region Metodos

        // Clase para Actualizar los datos de NotiOfimaConfiguracion. 
        // Si no existe lo inserta, si existe lo actualiza
        public static void Actualizar(NotiOfimaConfiguracionTable configuracionNota)
        {
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();

                //Por medio de Linq se consulta si la tabla tiene información, esta tabla solo guarda un registro
                var listado = entidadDatos.NotiOfimaConfiguracions.FirstOrDefault();

                // Si es nuevo Guarda
                // si ya existe lo actualiza
                if (listado != null)
                {
                    listado.FrecuenciaMostrar = configuracionNota.FrecuenciaMostrar;
                    listado.UltimaEjecucion = configuracionNota.UltimaEjecucion;
                    listado.tiempoInactivo = configuracionNota.tiempoInactivo;              

                }
                else
                {
                    NotiOfimaConfiguracion notaOf = new NotiOfimaConfiguracion();
                    notaOf.FrecuenciaMostrar = configuracionNota.FrecuenciaMostrar;
                    notaOf.UltimaEjecucion = configuracionNota.UltimaEjecucion;
                    notaOf.tiempoInactivo = configuracionNota.tiempoInactivo;

                    // el metodo .AddToNotiOfimaConfiguracions(notaOf) es la que me permite insertar nuevo registro en la tabla notasOfimaConfiguracion.
                    entidadDatos.AddToNotiOfimaConfiguracions(notaOf);
                }

                // Hasta el momento todos los cambios se han hecho en el contexto
                // Se debe actualizar la BD para esto se usa el metodo SaveChanges()
                entidadDatos.SaveChanges();
            }
            catch (System.Data.UpdateException e)
            {
                string excepcionInterna = "";

                if (e.InnerException != null)
                {
                    excepcionInterna = "\r\n Inner Exception: " + e.InnerException.ToString().Trim();
                }

                MessageBox.Show("Inconveniente al actualizar configuración:"+e.Message + excepcionInterna, "Actualizar Configuración Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.ConstraintException e)
            {
                MessageBox.Show(e.Message, "Actualizar Configuración Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Tiempo para indicar cada cuanto se muestra una nota
        /// </summary>
        /// <returns></returns>
        public static int ConsultarFrecuenciaMostrar()
        {
            // por defecto la frecuencia es cada día
            int frecuenciaMostrar = 24;
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();

                // Traer las notas ordenadas por la última que se público
                frecuenciaMostrar = (from c in entidadDatos.NotiOfimaConfiguracions
                                     select c.FrecuenciaMostrar).FirstOrDefault();

                // Si no esta configurada la frecuencia retorna 24, equivale a un dia
                if (frecuenciaMostrar == 0)
                {
                    frecuenciaMostrar = 24;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cosultar Frecuencia Mostrar Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return frecuenciaMostrar;
        }

       
        /// <summary>
        /// Tiempo para mostrar el tiempo de inactividad configurado
        /// </summary>
        /// <returns></returns>
        public static int ConsultarTiempoInactivo()
        {
            // por defecto la frecuencia es cada 3 minutos
            int tiempoInactivo = 3;
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();

                // Traer las notas ordenadas por la última que se público
                tiempoInactivo = (from c in entidadDatos.NotiOfimaConfiguracions
                                     select c.tiempoInactivo).FirstOrDefault();

                // Si no esta configurado el tiempoInactivo retorna 3 minutos
                if (tiempoInactivo == 0)
                {
                    tiempoInactivo = 3;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cosultar Tiempo Inactividad Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tiempoInactivo;
        }

        #endregion
    }
}
