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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EstablecimientoWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EstablecimientoWS.svc or EstablecimientoWS.svc.cs at the Solution Explorer and start debugging.
    public class EstablecimientoWS : IEstablecimientoWS
    {
        private EstablecimientoDAO EstablecimientoDAO = new EstablecimientoDAO();
        public List<EstablecimientoBE> Listar(string Latitud, string Longitud)
        {
            return EstablecimientoDAO.Listar(Latitud,Longitud);
        }
        public List<EstablecimientoBE> ListarTodos()
        {
            return EstablecimientoDAO.ListarTodos();
        }
        public EstablecimientoBE Obtener(int IdEstablecimiento)
        {
            return EstablecimientoDAO.Obtener(IdEstablecimiento);
        }
    }
}
