using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HatunsolDAO;
using HatunsolBE;
namespace HatunsolWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MaestroWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MaestroWS.svc o MaestroWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MaestroWS : IMaestroWS
    {
        private MaestroDAO dao = new MaestroDAO();

        public List<HatunsolBE.MaestroBE> ListarparaObra(int IdObra, decimal Area)
        {
            return dao.ListarparaObra(IdObra,  Area);
        }
    }
}
