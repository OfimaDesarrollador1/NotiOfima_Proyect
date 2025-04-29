using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofima.Pildoras.VisorERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] parametros)
        {
            
            string cadenaSQLActual = parametros[0].Trim();
            string modulo = parametros[1].Trim();
            string mDescripcionModulo = parametros[2].Trim();
            string mOpcionERP = parametros[3].Trim();
            string mCodUsuario = parametros[4].Trim();
            string mEsModulo = parametros[5].Trim();
            string pais = parametros[6].Trim();

            /*
            var cadenaSQLActual = @"Data Source=DESKTOP-064QVQ4;Initial Catalog=CONTROL_OFIMAEnterprise;User ID=sa;Password=ofima;MultipleActiveResultSets=True;Connect Timeout=0";
            var modulo = "CARTE";
            var mDescripcionModulo = "Facturas";
            var mOpcionERP = "ABOCAR.SPX";
            var mCodUsuario = "GERMAN";
            var mEsModulo = "N";
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Si es Modulo 
            if (mEsModulo == "S")
            {
                //Se ejecuta el visor Modulo
                Application.Run(new VisorModulo(cadenaSQLActual, modulo, mOpcionERP, mCodUsuario, mDescripcionModulo,pais));
            }
            else
            {
                //Se ejecuta el visor entrada 
                Application.Run(new VisorEntrada(cadenaSQLActual, modulo, mCodUsuario, mDescripcionModulo, pais));
            }                       
        }
    }
}
