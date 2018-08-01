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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UbigeoWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UbigeoWS.svc or UbigeoWS.svc.cs at the Solution Explorer and start debugging.
    public class UbigeoWS : IUbigeoWS
    {

        UbigeoDAO dao = new UbigeoDAO();
   

        public List<UbigeoBE> Listar()
        {
            return dao.Listar();
        }
    }
}
