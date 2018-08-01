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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUserWS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUserWS
    {
        //Prueba
        [WebInvoke(Method = "GET" , UriTemplate = "Usuario/{strLogin}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        UserBE ObtenerUsuario(string strLogin);
    }
}
