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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IArticuloWS" in both code and config file together.
    [ServiceContract]
    public interface IArticuloWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Listar", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<ArticuloBE> Listar();

        [WebInvoke(Method = "GET", UriTemplate = "ObtenerporProveedor?IdProveedor={IdProveedor}&IdArticulo={IdArticulo}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        ArticuloBE ObtenerporProveedor(int IdProveedor,int IdArticulo);
    }
}
