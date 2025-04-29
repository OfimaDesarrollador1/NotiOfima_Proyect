using NotiOfima.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NotiOfima.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceNotiOfima" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceNotiOfima.svc o ServiceNotiOfima.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceNotiOfima : IServiceNotiOfima
    {
        public List<NotiOfimaTable> consultarNotas()
        {
            return NotiOfimaTable.Consultar();
        }
         
        public int consultarFrecuenciaMostrar()
        {
            return NotiOfimaConfiguracionTable.ConsultarFrecuenciaMostrar();
        }


        public int consultarTiempoInactivo()
        {
            return NotiOfimaConfiguracionTable.ConsultarTiempoInactivo();
        }

        public List<PildoraOfimaModel> consultarPildoras(string codigoModulo)
        {
            return PildoraOfimaModel.ConsultarPildoraAllServer(codigoModulo) ;
        }

    }
}
