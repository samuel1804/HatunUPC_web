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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPresupuestoMaterial" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPresupuestoMaterialWS
    {
        [WebInvoke(Method = "GET", UriTemplate = "PresupuestosCercanos?IdObra={IdObra}&Area={Area}&Latitud={Latitud}&Longitud={Longitud}&IdEstablecimiento={IdEstablecimiento}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<PresupuestoMaterialBE> PresupuestosFerreterias(int IdObra, decimal Area, string Latitud, string Longitud, int IdEstablecimiento);

        [WebInvoke(Method = "GET", UriTemplate = "PresupuestoMaterial?IdObra={IdObra}&Area={Area}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<ArticuloBE> PresupuestarMaterial(int IdObra, Decimal Area);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Insertar", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int InsertarPresupuesto(PresupuestoMaterialBE PresupuestoMOBE);

    }
}
