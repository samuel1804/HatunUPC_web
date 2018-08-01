using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HatunsolBE;
using HatunsolDAO;
namespace HatunsolWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UserWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UserWS.svc o UserWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UserWS : IUserWS
    {

        public UserBE ObtenerUsuario(string strLogin)
        {
            var UserDAO = new UserDAO();
            return UserDAO.ObtenerUsuario(strLogin);
        }
    }
}
