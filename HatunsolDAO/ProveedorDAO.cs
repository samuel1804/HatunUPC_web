using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class ProveedorDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<ProveedorBE> Listar() {
            var lista = (from t in db.SG_Proveedor
                         select new ProveedorBE()
                         {
                             IdProveedor=t.IdProveedor,
                             RazonSocial=t.RazonSocial
                         }).ToList();
            return lista;
        }
        public ProveedorBE Obtener(int IdProveedor)
        {
            var proveedor = (from t in db.SG_Proveedor
                             where t.IdProveedor==IdProveedor
                         select new ProveedorBE()
                         {
                             IdProveedor = t.IdProveedor,
                             RazonSocial = t.RazonSocial,
                             RUC = t.RUC,
                             Direccion = t.Direccion,
                            
                         }).FirstOrDefault();
            return proveedor;
        }
    }
}
