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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProveedorWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProveedorWS.svc or ProveedorWS.svc.cs at the Solution Explorer and start debugging.
    public class ProveedorWS : IProveedorWS
    {
        private ProveedorDAO dao = new ProveedorDAO();
        public List<HatunsolBE.ProveedorBE> Listar()
        {
            return dao.Listar();
        }

        public ProveedorBE Obtener(int IdProveedor)
        {
            return dao.Obtener(IdProveedor);
        }
    }
}
