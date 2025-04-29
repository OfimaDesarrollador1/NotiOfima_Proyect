using Infragistics.Win.AppStyling;
using NotiOfima.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using System.Xml;

namespace NotiOfima.Visualizador
{
    static class Program
    {
        private static System.Timers.Timer aTimer = new System.Timers.Timer();
        private static System.Timers.Timer aTimerInactividad = new System.Timers.Timer();

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] parametros)
        {
            try
            {
                //Cargar los stylos de los controles
                string archivoStylos = Application.StartupPath.Trim() + @"\nautilus.isl";
                StyleManager.Load(archivoStylos);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // si es servidor muestra el administrador    
                // si es cliente valida el parametro para definir si se muestra el listado de notas o si se entra al timer para mostrar las notas
                if (Properties.Settings.Default.EsServidor)
                {
                    Application.Run(new Administrador());
                }
                else
                {
                    // si recibe parametro es porque requiere mostrar el listado de notas o el visor de CampusOfima
                    // sino entra al timer para mostrar las notas en el navegador
                    if (parametros.Length > 0)
                    {
                        // Variables para mostrar el visor de CampusOfima inicializadas por defecto
                        string pais = "CO";
                        bool esPyme = true;

                        // Si los parametros son mayores a 1, indica que se visualiza CampusOfima
                        if (parametros.Length > 1)
                        {
                            // Se captura el pais, y la versión del ERP (Enterprise, Pyme)
                            // True = Enterprise, False = Pyme
                            pais = parametros[0].Trim();
                            esPyme = bool.Parse(parametros[1].Trim().ToString());

                            // Variable que captura la consulta de la url, para el CampusOfima
                            string url = Consultar(pais, esPyme);

                            // Sea abre el navegador por defecto
                            Process.Start(url);
                            //Process.Start(@"Chrome.exe", "http://campus.ofimapyme.com/");
                        }
                        else
                        {
                            // Listado Notas
                            Application.Run(new FrmNotiOfimaListado());
                        }
                    }
                    else
                    {
                        // Validar que si el proceso ya esta en ejecución no vuelva a ejecutar
                        // se usa  Process.GetCurrentProcess.ProcessName para averiguar el nombre del proceso actual 
                        // después lo usamos con el método Process.GetProcessesByName para saber si está en ejecución.
                        // Este método devuelve un array del tipo Process con cada uno de los procesos que coincidan con ese nombre
                        // por tanto lo que hacemos es comprobar si el valor devuelto (que es un array) contiene más de un elemento 
                        // ya que debemos tener en cuenta que ese método devolverá un elementos porque habrá "contado" el proceso actual, y si tiene más de uno... es que hay otra copia

                        // comprobando la cantidad de elementos del array
                        bool enEjecucion;
                        enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;
                        if (!enEjecucion)
                        {
                            // Inmediatamente se muestra la primera nota 
                            // ya que el timer se ejecuta despues del tiempo estipulado y este tiempo esta en horas
                            mostrarNota();

                            // Creamos un Timer para ejecutar segun intervalo configurado en las notas                            
                            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                            // la frecuencia a mostrar esta dada en horas por lo que se multiplica por su equivalente en milisegundos
                            aTimer.Interval = 3600000 * NotiOfimaConfiguracionTable.ConsultarFrecuenciaMostrar();
                            //aTimer.Interval = 6000;
                            aTimer.Enabled = true;

                            // crear un timer para el tiempo de inactividad
                            aTimerInactividad.Elapsed += new ElapsedEventHandler(OnTimeEventInactividad);
                            aTimerInactividad.Interval = 1000;
                            aTimerInactividad.Enabled = true;
                            aTimerInactividad.Stop();

                            // Se utiliza un auxiliar para que el proceso continue en ejecucion infinita y no se salga al ejecutar la primera vez
                            int notasMostrar = 1;
                            do
                            {
                                notasMostrar++;
                                if (notasMostrar > 100)
                                {
                                    notasMostrar = 1;
                                }
                            } while (notasMostrar > 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string excepcionInterna = "";

                if (ex.InnerException != null)
                {
                    excepcionInterna = "\r\n Inner Exception: " + ex.InnerException.ToString().Trim();
                }

                MessageBox.Show("Se han presentado inconsistencias al mostrar NotiOfima" + ex.Message + excepcionInterna, "NotiOfima", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // Validar el tiempo de inactividad para mostrar la nota   
            // solo reinicia el conteo cuando se muestra la nota
            aTimer.Stop();
            aTimerInactividad.Start();
        }


        /// <summary>
        /// Se ejecuta continuamente para verificar si esta inactivo
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimeEventInactividad(object source, ElapsedEventArgs e)
        {
            int tiempoInactivo = 60 * NotiOfimaConfiguracionTable.ConsultarTiempoInactivo();
            TiempoInactivo _TiempoInactivo = new TiempoInactivo();
            var inactiveTime = _TiempoInactivo.GetInactiveTime();
            if (inactiveTime == null)
            {
                aTimerInactividad.Stop();
                mostrarNota();
                aTimer.Start();
            }
            else if (inactiveTime.Value.TotalSeconds > tiempoInactivo)
            {
                //label1.Text = string.Format("el usuario esta inactivo -Tiempo inactivo {0}s", (int)inactiveTime.Value.TotalSeconds);
                aTimerInactividad.Stop();
                mostrarNota();
                aTimer.Start();
            }
            else
            {
                //label1.Text = "el usuario esta activo trabajando en el pc";
            }
        }


        /// <summary>
        /// metodo encargado de validar si debe mostrar la nota
        /// </summary>
        private static void mostrarNota()
        {

            //// Actualizar Frecuencia mostrar y tiempo de inactividad
            NotiOfimaService.ServiceNotiOfimaClient servicioWebNotiOfima = new NotiOfimaService.ServiceNotiOfimaClient();

            NotiOfimaConfiguracionTable notiOfimaConfiguracion = new NotiOfimaConfiguracionTable();
            notiOfimaConfiguracion.FrecuenciaMostrar = servicioWebNotiOfima.consultarFrecuenciaMostrar(); ;
            notiOfimaConfiguracion.tiempoInactivo = servicioWebNotiOfima.consultarTiempoInactivo(); ;
            notiOfimaConfiguracion.UltimaEjecucion = DateTime.Now;
            NotiOfimaConfiguracionTable.Actualizar(notiOfimaConfiguracion);

            // Actualizar notas
            BindingList<NotiOfimaTable> listadoNotas = new BindingList<NotiOfimaTable>(servicioWebNotiOfima.consultarNotas());
            NotiOfimaTable.Actualizar(listadoNotas);


            // Cargar Notas que estan disponibles para mostrar
            BindingList<NotiOfimaTable> notas = null;
            notas = new BindingList<NotiOfimaTable>(NotiOfimaTable.ConsultarNotasActivas());

            // solo generamos el aleatorio si tiene notas configuradas
            if (notas.Count > 0)
            {
                // Creamos el objeto Random
                Random numeroAleatorio = new Random(DateTime.Now.Millisecond);

                // Queremos un número entre el 1 y el máximo de notas configuradas
                int notaAleatoria = numeroAleatorio.Next(0, notas.Count - 1);

                // Ejecutar el navegador con la nota a mostrar  
                Process.Start(notas[notaAleatoria].Link);
            }
            else
            {
                Application.Exit();
            }
        }


        /// <summary>
        /// Método consultar, encargado de retornar la url según el archivo XML y los parámetros
        /// indicados
        /// </summary>
        /// <param name="pais">País recibido Colombia = CO, México = Mx ...</param>
        /// <param name="esPyme">Versión del ERP, Pyme = True, Enterprise = False</param>
        /// <returns></returns>
        private static string Consultar(string pais, bool esPyme)
        {
            // Variable que retorna la URL del CampusOfima
            string urlCampusOfima = "";

            try
            {
                // Si se ha indicó el país, se consulta la información
                if (!string.IsNullOrWhiteSpace(pais))
                {
                    // Captura el nombre del Archivo en el directorio por defecto
                    string nombreArchivoXML = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).ToUpper().Trim(), "SitiosCampusOfima.xml");


                    // Valida si el archivo existe en la ruta
                    if (File.Exists(nombreArchivoXML))
                    {
                        // cargar el archivo de configuración
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(nombreArchivoXML);

                        // cargar el nodo SitiosCampusOfimaC
                        XmlNodeList nodoOfimabot = xDoc.GetElementsByTagName("SitiosCampusOfimaC");
                        XmlNodeList campusNodo = ((XmlElement)nodoOfimabot[0]).GetElementsByTagName(@"SitiosCampusOfima");

                        // Cargar la información configurada
                        foreach (XmlElement nodo in campusNodo)
                        {
                            // Captura la URL, el País, y la Versión del registro leido del XML
                            string urlCampus = nodo.GetElementsByTagName("urlCampus")[0].InnerText;
                            string paisConfigurado = nodo.GetElementsByTagName("pais")[0].InnerText;
                            bool esEnterpriseConfigurado = bool.Parse(nodo.GetElementsByTagName("esPyme")[0].InnerText);

                            // Si el pais y la versión leidas, son iguales a los parámetros recibidos, indica que
                            // se debe tomar la url de ese nodo para mostrarlo en el navegador
                            if (paisConfigurado == pais && esEnterpriseConfigurado == esPyme)
                            {
                                // Captura la URL del Campus
                                urlCampusOfima = urlCampus;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error si se ha presentado
                MessageBox.Show(ex.Message, "Consultar URL Campus Ofima", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retorna la URL
            return urlCampusOfima;
        }
    }
}
