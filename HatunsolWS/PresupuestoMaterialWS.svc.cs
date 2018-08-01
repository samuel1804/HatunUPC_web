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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PresupuestoMaterial" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PresupuestoMaterial.svc o PresupuestoMaterial.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PresupuestoMaterialWS : IPresupuestoMaterialWS
    {
        private PresupuestoMaterialDAO PresupuestoMaterialDAO = new PresupuestoMaterialDAO();
        public List<HatunsolBE.PresupuestoMaterialBE> PresupuestosFerreterias(int IdObra, decimal Area, string Latitud, string Longitud,int IdEstablecimiento)
        {
            return PresupuestoMaterialDAO.PresupuestosFerreterias(IdObra, Area, Latitud, Longitud, IdEstablecimiento);
        }


        public List<ArticuloBE> PresupuestarMaterial(int IdObra, decimal Area)
        {
            return PresupuestoMaterialDAO.PresupuestarMaterial(IdObra, Area);
        }


        public int InsertarPresupuesto(PresupuestoMaterialBE PresupuestoMOBE)
        {
            return PresupuestoMaterialDAO.InsertarPresupuesto(PresupuestoMOBE);
        }
    }
}
