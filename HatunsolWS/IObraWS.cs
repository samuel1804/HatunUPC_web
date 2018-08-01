using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HatunsolBE;
namespace HatunsolWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IObraWS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IObraWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Obra?Descripcion={Descripcion}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<ObraBE> Listar(string Descripcion);

    }
}
