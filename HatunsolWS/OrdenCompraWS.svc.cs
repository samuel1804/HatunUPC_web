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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OrdenCompraWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OrdenCompraWS.svc o OrdenCompraWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OrdenCompraWS : IOrdenCompraWS
    {

        private OrdenCompraDAO dao = new OrdenCompraDAO();
        public List<OrdenCompraBE> Listar(string RazonSocial, int Estado, DateTime FechaInicio, DateTime FechaFin, int IdEstablecimiento)
        {
            return dao.Listar(RazonSocial, Estado, FechaInicio, FechaFin, IdEstablecimiento);
        }

        public OrdenCompraBE Insertar(OrdenCompraBE orden)
        {
            return dao.Insertar(orden);
        }
        public OrdenCompraBE Obtener(int IdOrdenCompra)
        {
            return dao.Obtener(IdOrdenCompra);
        }
        public List<VwOrdenCompra> Imprimir(int IdOrdenCompra)
        {
            return dao.Imprimir(IdOrdenCompra);
        }

    }
}
