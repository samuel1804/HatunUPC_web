using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HatunsolDAO;
namespace HatunsolWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ParametroWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ParametroWS.svc o ParametroWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ParametroWS : IParametroWS
    {
        private ParametroDAO dao = new ParametroDAO();
        public List<HatunsolBE.ParametroBE> Listar(int DominioId)
        {
            return dao.Listar(DominioId);
        }
    }
}
