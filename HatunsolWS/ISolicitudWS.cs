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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISolicitud" in both code and config file together.
    [ServiceContract]
    public interface ISolicitudWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Solicitud?Nombre={Nombre}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<SolicitudBE> Listar(string Nombre);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Insertar", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        PersonaBE Insertar(List<PersonaBE> persons);


    }
}
