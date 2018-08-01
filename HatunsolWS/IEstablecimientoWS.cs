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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEstablecimientoWS" in both code and config file together.
    [ServiceContract]
    public interface IEstablecimientoWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Establecimiento?Latitud={Latitud}&Longitud={Longitud}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<EstablecimientoBE> Listar(string Latitud,string Longitud);

        [WebInvoke(Method = "GET", UriTemplate = "ListarTodos", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<EstablecimientoBE> ListarTodos();

    }
}
