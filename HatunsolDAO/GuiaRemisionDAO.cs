using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;

namespace HatunsolDAO
{
    public class GuiaRemisionDAO
    {
        SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public GuiaRemisionBE Insertar(OrdenCompraBE orden, GuiaRemisionBE guia)
        {
            int IdGuia = db.SG_GuiaRemision.OrderByDescending(t => t.IdGuiaRemision).FirstOrDefault() == null ? 1 : db.SG_GuiaRemision.OrderByDescending(t => t.IdGuiaRemision).FirstOrDefault().IdGuiaRemision + 1;
            var order = new SG_GuiaRemision()
            {
                IdGuiaRemision = IdGuia,
                Fecha = DateTime.Now,
                IdOrdenCompra = orden.IdOrdenCompra,
                DireccionOrigen = guia.DireccionOrigen,
                DireccionDestino = guia.DireccionDestino,
                ModalidadPago = (int)ConstantesBE.FormaPago.Efectivo,
                FechaTraslado=guia.FechaTraslado
            };

            db.SG_GuiaRemision.Add(order);

            foreach (var item in orden.Articulos)
            {
                var order_detalle = new SG_GuiaRemision_Articulo()
                {
                    IdGuiaRemision = IdGuia,
                    IdArticulo = item.IdArticulo,
                    Cantidad = item.Cantidad,
                };

                db.SG_GuiaRemision_Articulo.Add(order_detalle);
            }


            var oc = (from t in db.SG_OrdenCompra
                      where t.IdOrdenCompra == orden.IdOrdenCompra
                      select t).FirstOrDefault();
            oc.Estado = (int)ConstantesBE.EstadoOrden.Aprobada;


            db.SaveChanges();
            guia.IdGuiaRemision = IdGuia;
            return guia;
        }
        public List<VwGuiaRemision> ImprimirGuia(int IdGuiaRemision)
        {
            string NroGuia="00"+IdGuiaRemision;
            var guias = (from t in db.SG_GuiaRemision
                         join oc in db.SG_OrdenCompra on t.IdOrdenCompra equals oc.IdOrdenCompra
                         join e in db.SG_Establecimiento on oc.IdEstablecimiento equals e.IdEstablecimiento
                         join p in db.SG_Proveedor on oc.IdProveedor equals p.IdProveedor
                         join ga in db.SG_GuiaRemision_Articulo on t.IdGuiaRemision equals ga.IdGuiaRemision
                         join a in db.SG_Articulo on ga.IdArticulo equals a.IdArticulo
                         join um in db.SG_Parametro on a.UnidadMedida equals um.ParametroId
                         where t.IdGuiaRemision == IdGuiaRemision && um.DominioId == (int)ConstantesBE.Dominio.UnidadMedida
                         select new VwGuiaRemision()
                         {
                             RazonSocial = p.RazonSocial,
                             FechaTraslado = (DateTime)t.FechaTraslado,
                             Destinatario = e.RazonSocial,
                             RucDestinatario = e.RUC,
                             DireccionOrigen = t.DireccionOrigen,
                             DireccionDestino = t.DireccionDestino,
                             IdArticulo = ga.IdArticulo,
                             Nombre = a.Nombre,
                             Cantidad = ga.Cantidad,
                             UnidadMedida = um.NombreLargo,
                             NroGuia=NroGuia,
                             Ruc = p.RUC,
                         }).ToList();

            return guias;
        }


        public GuiaRemisionBE ObtenerporOrden(int IdOrden)
        {
              var guia = (from t in db.SG_GuiaRemision
                          where t.IdOrdenCompra == IdOrden
                          select new GuiaRemisionBE()
                          {
                              IdGuiaRemision=t.IdGuiaRemision
                          }).FirstOrDefault();
              return guia;
        }
    }
}
