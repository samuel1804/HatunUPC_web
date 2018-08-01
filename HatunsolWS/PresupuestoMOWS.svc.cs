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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PresupuestoMOWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PresupuestoMOWS.svc or PresupuestoMOWS.svc.cs at the Solution Explorer and start debugging.
    public class PresupuestoMOWS : IPresupuestoMOWS
    {
        private PresupuestoMODAO presupuestoMODAO = new PresupuestoMODAO();

        public int InsertarPresupuesto(HatunsolBE.PresupuestoMOBE PresupuestoMOBE)
        {
            return presupuestoMODAO.InsertarPresupuesto(PresupuestoMOBE);
        }
    }
}
