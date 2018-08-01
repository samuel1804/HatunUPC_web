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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPresupuestoMOWS" in both code and config file together.
    [ServiceContract]
    public interface IPresupuestoMOWS
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Insertar", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int InsertarPresupuesto(PresupuestoMOBE PresupuestoMOBE);

    }
}
