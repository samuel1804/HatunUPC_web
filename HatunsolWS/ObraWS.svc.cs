using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HatunsolBE;
using HatunsolDAO;
namespace HatunsolWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ObraWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ObraWS.svc o ObraWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ObraWS : IObraWS
    {

       private ObraDAO ObraDAO = new ObraDAO();
        public List<ObraBE> Listar(string Descripcion)
        {
            return ObraDAO.Listar(Descripcion);
        }
    }
}
