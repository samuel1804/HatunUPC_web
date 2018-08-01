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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOrdenCompraWS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOrdenCompraWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "Listar?RazonSocial={RazonSocial}&Estado={Estado}&FechaInicio={FechaInicio}&FechaFin={FechaFin}&IdEstablecimiento={IdEstablecimiento}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<OrdenCompraBE> Listar(string RazonSocial,int Estado,DateTime FechaInicio,DateTime FechaFin, int IdEstablecimiento);
        
    }
}
