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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OrdenCompraArticuloWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OrdenCompraArticuloWS.svc o OrdenCompraArticuloWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OrdenCompraArticuloWS : IOrdenCompraArticuloWS
    {
        OrdenCompraArticuloDAO dao = new OrdenCompraArticuloDAO();
        public List<ArticuloBE> ObtenerporOrden(int IdOrden) {
            return dao.ObtenerporOrden(IdOrden);
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
