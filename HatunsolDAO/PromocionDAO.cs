using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class PromocionDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<PromocionBE> Listar(string Nombre)
        {
            var lista = (from t in db.SG_Promocion
                         where Nombre.Contains(Nombre)
                         select new PromocionBE()
                         {
                             IdPromocion = t.IdPromocion,
                             Nombre = t.Nombre,
                             IdEstablecimiento = t.IdEstablecimiento,
                             FechaInicio = t.FechaInicio,
                             FechaFin = t.FechaFin
                         }).ToList();
            return lista;
        }
        public PromocionBE Insertar(PromocionBE promocion)
        {
            int IdPromocion = db.SG_Promocion.OrderByDescending(t => t.IdPromocion).FirstOrDefault() == null ? 1 : db.SG_Promocion.OrderByDescending(t => t.IdPromocion).FirstOrDefault().IdPromocion + 1;
            var promo = new SG_Promocion()
            {
                IdPromocion = IdPromocion,
                Nombre = promocion.Nombre,
                Descripcion = promocion.Descripcion,
                FechaInicio = promocion.FechaInicio,
                FechaFin = promocion.FechaFin,
                Estado = promocion.Estado
            };

            db.SG_Promocion.Add(promo);


            foreach (var item in promocion.Articulos)
            {
                var detalle = new SG_Promocion_Articulo()
                {
                    IdPromocion = promo.IdPromocion,
                    IdArticulo = item.IdArticulo,
                    PrecioNuevo = item.PrecioNuevo
                };

                db.SG_Promocion_Articulo.Add(detalle);
            }


            db.SaveChanges();
            promocion.IdPromocion = promo.IdPromocion;
            return promocion;
        }
    }
}
