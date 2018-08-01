using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HatunsolBE;
using System.ServiceModel.Web;

namespace HatunsolWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMaestroWS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMaestroWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Maestro?IdObra={IdObra}&Area={Area}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<MaestroBE> ListarparaObra(int IdObra, decimal Area);
    }
}
