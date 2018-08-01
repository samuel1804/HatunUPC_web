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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GuiaRemisionWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione GuiaRemisionWS.svc o GuiaRemisionWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class GuiaRemisionWS : IGuiaRemisionWS
    {
        GuiaRemisionDAO dao = new GuiaRemisionDAO();
        public GuiaRemisionBE Insertar(OrdenCompraBE orden, GuiaRemisionBE guia) {
            return dao.Insertar(orden, guia);
        }

        public List<VwGuiaRemision> ImprimirGuia(int IdGuiaRemision)
        {
            return dao.ImprimirGuia(IdGuiaRemision);
        }


        public GuiaRemisionBE ObtenerporOrden(int IdOrden)
        {
            return dao.ObtenerporOrden(IdOrden);
        }

        public void DoWork()
        {
        }
    }
}
