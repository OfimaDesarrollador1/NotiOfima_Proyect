using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotiOfima.Entidades.Model
{
    /// <summary>
    /// Clase que permite interactuar con la tabla NotiOfima
    /// </summary>
    public class NotiOfimaTable
    {
        /// <summary>
        /// Constructor de la clase NotiOfimaTable
        /// </summary>
        public NotiOfimaTable()
        {
        }

        /// <summary>
        /// Propiedades de la clase NotiOfimaTable, Coinciden con los campos de la estructura de datos
        /// Se definen con DisplayName y Description para mostrar en la ventana de propiedades
        /// </summary>
        #region Propiedades
        [Category("General"), Description("Indica si la nota será borrada."),
        DisplayName("Eliminar")]
        public bool Eliminar { get; set; }

        [Category("General"), Description("Campo indice primario único que permite identificar un registro único en la tabla."),
        DisplayName("idNota"), ReadOnly(true)]
        public Guid idNota { get; set; }

        [Category("General"), Description("Titulo de la nota."),
        DisplayName("Titulo")]
        public string Titulo { get; set; }

        [Category("General"), Description("Número de veces que se muestra la nota."),
        DisplayName("Cantidad Mostrar")]
        public int CantidadMostrar { get; set; }

        [Category("General"), Description("Número de veces que se ha mostrado la nota."),
        DisplayName("Veces Mostrada"), ReadOnly(true)]
        public decimal FrecuenciaMostrar { get; set; }

        [Category("General"), Description("URL de la nota."),
        DisplayName("Link")]
        public string Link { get; set; }

        [Category("General"), Description("Indica la fecha de publicación de la nota."),
        DisplayName("Fecha Publicación")]
        public DateTime FechaCreacion { get; set; }

        [Category("General"), Description("Indica la fecha de la última vez que se muestra la nota."),
        DisplayName("Fecha Expiración")]
        public DateTime FechaExpiracion { get; set; }

        [Category("General"), Description("Almacena la imagen asociada a la nota, esta se muestra en las ventanas ingresando al módulo."),
        DisplayName("Imagen")]
        public byte[] Imagen { get; set; }

        [Category("General"), Description("Campo que indica el país en el que se debe mostrar la nota."),
        DisplayName("País")]
        public string CodigoPais { get; set; }

        #endregion

        /// <summary>
        /// Metodos de la clase NotiOfimaTable
        /// </summary>
        #region Metodos

        // Clase para Actualizar los datos de NotiOfimaTable. 
        // Si no existe lo inserta, si existe lo actualiza
        public static void Actualizar(BindingList<NotiOfimaTable> notasOfima)
        {
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();
                foreach (NotiOfimaTable nota in notasOfima)
                {
                    //Por medio de Linq se consulta la tabla que coincide con el Id de la clase
                    var listado = entidadDatos.NotiOfimaDatos.FirstOrDefault(c => c.idNota == nota.idNota);

                    // Si es nuevo y nota.eliminar == false Guarda, sino no guarda
                    // si ya existe lo actualiza, si esta marcado como eliminar lo elimina
                    if (listado != null)
                    {
                        if (nota.Eliminar == false)
                        {
                            listado.Titulo = nota.Titulo;
                            listado.CantidadMostrar = nota.CantidadMostrar;
                            listado.FrecuenciaMostrar = nota.FrecuenciaMostrar;
                            listado.Link = nota.Link;
                            listado.FechaExpiracion = nota.FechaExpiracion;
                            listado.FechaCreacion = nota.FechaCreacion;
                            listado.Imagen = nota.Imagen;
                            listado.CodigoPais = nota.CodigoPais;
                        }
                        else
                        {
                            entidadDatos.NotiOfimaDatos.DeleteObject(listado);
                        }
                    }
                    else
                    {
                        if (nota.Eliminar == false)
                        {
                            NotiOfimaDatos notaOf = new NotiOfimaDatos();
                            notaOf.idNota = nota.idNota;
                            notaOf.Titulo = nota.Titulo;
                            notaOf.CantidadMostrar = nota.CantidadMostrar;
                            notaOf.FrecuenciaMostrar = nota.FrecuenciaMostrar;
                            notaOf.Link = nota.Link;
                            notaOf.FechaCreacion = nota.FechaCreacion;
                            notaOf.FechaExpiracion = nota.FechaExpiracion;
                            notaOf.Imagen = nota.Imagen;
                            notaOf.CodigoPais = nota.CodigoPais;

                            // el metodo .AddToNotiOfimaDatos(notaOf) es la que me permite insertar nuevo registro en la tabla notasOfima.
                            entidadDatos.AddToNotiOfimaDatos(notaOf);
                        }
                    }

                    // Hasta el momento todos los cambios se han hecho en el contexto
                    // Se debe actualizar la BD para esto se usa el metodo SaveChanges()
                    entidadDatos.SaveChanges();

                }
            }
            catch (System.Data.UpdateException e)
            {
                MessageBox.Show(e.InnerException.Message, "Actualizar Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.ConstraintException e)
            {
                MessageBox.Show(e.Message, "Actualizar Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Clase para mostrar todas las notas
        // Por medio de este metodo se llena la información a mostrar de las notas
        public static List<NotiOfimaTable> Consultar()
        {
            List<NotiOfimaTable> listadoNotas = null;
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();

                // Traer las notas ordenadas por la última que se público
                listadoNotas = (from c in entidadDatos.NotiOfimaDatos
                                  orderby c.FechaCreacion descending
                                  select c).Select(a => new NotiOfimaTable
                                       {
                                           Eliminar = false,
                                           idNota = (Guid)a.idNota,
                                           Titulo = a.Titulo,
                                           CantidadMostrar = (int)a.CantidadMostrar,
                                           FrecuenciaMostrar = (int)a.FrecuenciaMostrar,
                                           Link = a.Link,
                                           FechaCreacion = (DateTime)a.FechaCreacion,
                                           FechaExpiracion = (DateTime)a.FechaExpiracion,
                                           Imagen = (byte[])a.Imagen,
                                           CodigoPais = a.CodigoPais
                                       }).ToList();

                //crearArchivoSeguimiento("OK"+listadoNotas.Count.ToString());

            }
            catch (Exception e)
            {
                crearArchivoSeguimiento(e.Message);
                MessageBox.Show(e.Message, "Cosultar Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listadoNotas;
        }

        /// <summary>
        /// Clase para mostrar las notas disponibles para mostrar, son las notas que no han vencido
        /// </summary>
        /// <returns></returns>
        public static List<NotiOfimaTable> ConsultarNotasActivas()
        {
            List<NotiOfimaTable> listadoNotas = null;
            try
            {
                //Obtener contexto de los datos
                NotiOfimaEntities entidadDatos = new NotiOfimaEntities();
                DateTime FechaActual = DateTime.Now;

                // Traer las notas ordenadas por la última que se público
                listadoNotas = (from c in entidadDatos.NotiOfimaDatos
                                where EntityFunctions.TruncateTime(c.FechaExpiracion) >= EntityFunctions.TruncateTime(FechaActual)
                                orderby c.FechaCreacion descending
                                select c).Select(a => new NotiOfimaTable
                                {
                                    Eliminar = false,
                                    idNota = (Guid)a.idNota,
                                    Titulo = a.Titulo,
                                    CantidadMostrar = 0,
                                    FrecuenciaMostrar = 0,
                                    Link = a.Link,
                                    FechaCreacion = (DateTime)a.FechaCreacion,
                                    FechaExpiracion = (DateTime)a.FechaExpiracion,
                                    Imagen = (byte[])a.Imagen,
                                    CodigoPais=a.CodigoPais
                                }).ToList();
            }
            catch (Exception e)
            {
                crearArchivoSeguimiento(e.Message);
                MessageBox.Show(e.Message, "Cosultar Notas Activas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listadoNotas;
        }

        /// <summary>
        /// Metodo para ir creando archivo con el seguimiento
        /// </summary>
        /// <param name="p"></param>
        private static void crearArchivoSeguimiento(string texto, string path=@"C:\Ofimatica\", string nombreArchivo = "seguimientoNotas.txt")
        {
            Directory.CreateDirectory(path);
            string archivoSeguimiento = System.IO.Path.Combine(path, nombreArchivo);

            using (System.IO.StreamWriter writerCliente = new System.IO.StreamWriter(archivoSeguimiento, true))
            {
                string fecha = DateTime.Now.ToString();
                writerCliente.WriteLine("\r\n\r\n" + fecha + "\r\n" + texto);
            }
        }

        #endregion
    }
}
