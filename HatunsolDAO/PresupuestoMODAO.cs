using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class PresupuestoMODAO
    {
        SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public int InsertarPresupuesto(PresupuestoMOBE presupuestoMOBE)
        {
            try
            {
                var PresupuestoMO = new SG_PresupuestoMo()
                {
                    IdPresupuestoMo = db.SG_PresupuestoMo.OrderByDescending(t => t.IdPresupuestoMo).FirstOrDefault() == null ? 1 : db.SG_PresupuestoMo.OrderByDescending(t => t.IdPresupuestoMo).FirstOrDefault().IdPresupuestoMo+1,
                    Area = presupuestoMOBE.Area,
                    Dias = presupuestoMOBE.Dias,
                    IdObra = presupuestoMOBE.IdObra,
                    IdPersona = presupuestoMOBE.IdPersona,
                    Total = presupuestoMOBE.Total
                };
                db.SG_PresupuestoMo.Add(PresupuestoMO);

                var PresupuestoMO_Maestro = new SG_PresupuestoMo_Maestro()
                {
                    IdPresupuestoMo = PresupuestoMO.IdPresupuestoMo,
                    IdMaestro = presupuestoMOBE.IdMaestro,
                    Dias = presupuestoMOBE.Dias,
                    SubTotal = presupuestoMOBE.Total
                };
                db.SG_PresupuestoMo_Maestro.Add(PresupuestoMO_Maestro);

                db.SaveChanges();

                return PresupuestoMO.IdPresupuestoMo;
            }
            catch (Exception ex) {
                return 0;
            }
        }
    }
}
