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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceNotiOfima" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceNotiOfima
    {
        [OperationContract]
        List<NotiOfimaTable> consultarNotas();

        [OperationContract]
        int consultarFrecuenciaMostrar();

        [OperationContract]
        int consultarTiempoInactivo();

        [OperationContract]
        List<PildoraOfimaModel> consultarPildoras(string codigoModulo);
    }
}
