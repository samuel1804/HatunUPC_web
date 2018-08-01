using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;

namespace HatunsolDAO
{
    public class OrdenCompraArticuloDAO
    {
        SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<ArticuloBE> ObtenerporOrden(int IdOrden)
        {
            var articulo = (from t in db.SG_Articulo
                            join oca in db.SG_OrdenCompra_Articulo on t.IdArticulo equals oca.IdArticulo
                            join um in db.SG_Parametro on t.UnidadMedida equals um.ParametroId
                            where um.DominioId == (int)ConstantesBE.Dominio.UnidadMedida && oca.IdOrdenCompra==IdOrden
                            select new ArticuloBE()
                            {
                                IdArticulo = t.IdArticulo,
                                Nombre = t.Nombre,
                                Costo = oca.Costo,
                                UnidadMedida = um.NombreLargo,
                                Cantidad=oca.Cantidad,
                                SubTotal=oca.SubTotal

                            }).ToList();

            return articulo;
        }
    }
}
