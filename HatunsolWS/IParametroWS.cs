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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IParametroWS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IParametroWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Listar?DominioId={DominioId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<ParametroBE> Listar(int DominioId);
    }
}
