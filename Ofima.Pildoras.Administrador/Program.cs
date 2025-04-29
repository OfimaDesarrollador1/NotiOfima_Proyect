using Infragistics.Win.AppStyling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofima.Pildoras.Administrador
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Cargar los stylos de los controles
            string archivoStylos = Application.StartupPath.Trim() + @"\nautilus.isl";
            Stream streamStyle = new MemoryStream(Properties.Resources.Office2007Black);
            StyleManager.Load(streamStyle);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Administrador());
        }
    }
}
