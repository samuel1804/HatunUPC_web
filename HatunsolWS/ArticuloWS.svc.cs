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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ArticuloWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ArticuloWS.svc or ArticuloWS.svc.cs at the Solution Explorer and start debugging.
    public class ArticuloWS : IArticuloWS
    {
        private ArticuloDAO dao = new ArticuloDAO();
        public List<ArticuloBE> Listar()
        {
            return dao.Listar();
        }

        public ArticuloBE ObtenerporProveedor(int IdProveedor, int IdArticulo)
        {
            return dao.ObtenerporProveedor(IdProveedor, IdArticulo);
        }
        public ArticuloBE ObtenerporEstablecimiento(int IdEstablecimiento, int IdArticulo)
        {
            return dao.ObtenerporEstablecimiento(IdEstablecimiento, IdArticulo);
        }

        public List<ArticuloBE> ArticulosBajaRotacion(string FechaInicio, string FechaFin, int IdEstablecimiento)
        {
            return dao.ArticulosBajaRotacion(FechaInicio,FechaFin,IdEstablecimiento);
        }
    }
}
