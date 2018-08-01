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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PromocionWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PromocionWS.svc or PromocionWS.svc.cs at the Solution Explorer and start debugging.
    public class PromocionWS : IPromocionWS
    {
        PromocionDAO dao = new PromocionDAO();
        public List<PromocionBE> Listar(string Nombre)
        {
            return dao.Listar(Nombre);
        }

        public PromocionBE Insertar(PromocionBE promocion) {
            return dao.Insertar(promocion);
        }
    }
}
