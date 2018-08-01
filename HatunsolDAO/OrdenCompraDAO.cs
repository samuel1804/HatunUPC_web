using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class OrdenCompraDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<OrdenCompraBE> Listar(string RazonSocial, int Estado, DateTime FechaInicio, DateTime FechaFin, int IdEstablecimiento)
        {
            var lista = (from t in db.SG_OrdenCompra
                         join e in db.SG_Establecimiento on t.IdEstablecimiento equals e.IdEstablecimiento
                         join p in db.SG_Parametro on t.Estado equals p.ParametroId
                         where e.RazonSocial.Contains(RazonSocial) && (t.Estado == Estado || Estado == 0) && (p.DominioId == 86)
                         && t.Fecha_Ped >= FechaInicio && t.Fecha_Ped < FechaFin && (t.IdEstablecimiento == IdEstablecimiento || IdEstablecimiento == 0)
                         select new OrdenCompraBE()
                         {
                             IdOrdenCompra = t.IdOrdenCompra,
                             Establecimiento = new EstablecimientoBE()
                             {
                                 IdEstablecimiento = t.IdEstablecimiento,
                                 NombreComercial = e.NombreComercial,
                                 RUC = e.RUC,
                                 RazonSocial = e.RazonSocial,
                                 Direccion = e.Direccion,

                             },
                             Fecha_Ped = t.Fecha_Ped,
                             EstadoNombre = p.NombreLargo,
                             Fecha_Req = t.Fecha_Req,
                             Total = (decimal)t.Total,


                         }).ToList();
            return lista;
        }

        public OrdenCompraBE Insertar(OrdenCompraBE orden)
        {
            int IdOrden = db.SG_OrdenCompra.OrderByDescending(t => t.IdOrdenCompra).FirstOrDefault() == null ? 1 : db.SG_OrdenCompra.OrderByDescending(t => t.IdOrdenCompra).FirstOrDefault().IdOrdenCompra + 1;
            var order = new SG_OrdenCompra()
            {
                IdOrdenCompra = IdOrden,
                Fecha_Ped = DateTime.Now,
                NroOrden = "000" + IdOrden,
                IdProveedor = orden.IdProveedor,
                IdEstablecimiento = orden.IdEstablecimiento,

                SubTotal = orden.SubTotal,
                IGV = orden.IGV,
                Total = orden.Total,
                Estado = (int)ConstantesBE.EstadoOrden.Pendiente,

                FormaPago = (int)ConstantesBE.FormaPago.Efectivo,

            };

            db.SG_OrdenCompra.Add(order);

            foreach (var item in orden.Articulos)
            {
                var order_detalle = new SG_OrdenCompra_Articulo()
                {
                    IdOrdenCompra = IdOrden,
                    IdArticulo = item.IdArticulo,
                    Cantidad = item.Cantidad,
                    Costo = (decimal)item.Costo,
                    SubTotal = item.SubTotal


                };

                db.SG_OrdenCompra_Articulo.Add(order_detalle);
            }

            db.SaveChanges();
            orden.IdOrdenCompra = IdOrden;
            return orden;
        }



        public OrdenCompraBE Obtener(int IdOrdenCompra)
        {
            var orden = (from t in db.SG_OrdenCompra
                         join e in db.SG_Establecimiento on t.IdEstablecimiento equals e.IdEstablecimiento
                         join prov in db.SG_Proveedor on t.IdProveedor equals prov.IdProveedor
                         join p in db.SG_Parametro on t.Estado equals p.ParametroId
                         where p.DominioId == 86 && t.IdOrdenCompra == IdOrdenCompra
                         select new OrdenCompraBE()
                         {
                             IdOrdenCompra = t.IdOrdenCompra,
                             Establecimiento = new EstablecimientoBE()
                             {
                                 IdEstablecimiento = t.IdEstablecimiento,
                                 NombreComercial = e.NombreComercial,
                                 RUC = e.RUC,
                                 RazonSocial = e.RazonSocial,
                                 Direccion = e.Direccion,

                             },
                             Estado = t.Estado,
                             Fecha_Ped = t.Fecha_Ped,
                             EstadoNombre = p.NombreLargo,
                             Proveedor=new ProveedorBE(){IdProveedor=prov.IdProveedor, Direccion=prov.Direccion, RazonSocial=prov.RazonSocial,RUC=prov.RUC},
                             Fecha_Req = t.Fecha_Req,
                             Total = (decimal)t.Total,
                             Articulos = (from a in db.SG_OrdenCompra_Articulo
                                          join art in db.SG_Articulo on a.IdArticulo equals art.IdArticulo
                                          join um in db.SG_Parametro on art.UnidadMedida equals um.ParametroId 
                                          where a.IdOrdenCompra == t.IdOrdenCompra && um.DominioId==(int)ConstantesBE.Dominio.UnidadMedida
                                          select new ArticuloBE() { 
                                          IdArticulo=a.IdArticulo,
                                          Cantidad=a.Cantidad,
                                          Costo=a.Costo,
                                          SubTotal=a.SubTotal,
                                          Nombre=art.Nombre,
                                          UnidadMedida=um.NombreLargo
                                          }).ToList()

                         }).FirstOrDefault();
            return orden;
        }

        public List<VwOrdenCompra> Imprimir(int IdOrdenCompra)
        {
            string NroOrden = "00" + IdOrdenCompra;
            var orden = (from t in db.SG_OrdenCompra
                         join e in db.SG_Establecimiento on t.IdEstablecimiento equals e.IdEstablecimiento
                         join prov in db.SG_Proveedor on t.IdProveedor equals prov.IdProveedor
                         join par in db.SG_Parametro on t.FormaPago equals par.ParametroId
                         join oca in db.SG_OrdenCompra_Articulo on t.IdOrdenCompra equals oca.IdOrdenCompra
                         join a in db.SG_Articulo on oca.IdArticulo equals a.IdArticulo
                         where t.IdOrdenCompra == IdOrdenCompra && par.DominioId == (int)ConstantesBE.Dominio.FormaPago
                         select new VwOrdenCompra()
                         {
                             NumeroOrden = NroOrden,
                             Proveedor = prov.RazonSocial,
                             DireccionProveedor = prov.Direccion,
                             TelefonoProveedor = prov.Direccion,
                             FechaPedido = (DateTime)t.Fecha_Ped,
                             FechaEntrega = (DateTime)t.Fecha_Req,
                             NombreCliente = e.RazonSocial,
                             DireccionCliente = e.Direccion,
                             TelefonoCliente = e.Telefono,
                             FormaPago = par.NombreLargo,
                             Cantidad = oca.Cantidad,
                             Descripcion = a.Nombre,
                             Costo = oca.Costo,
                             SubTotal = oca.SubTotal,
                             SubTo = (decimal)t.SubTotal,
                             Tot = t.Total

                         }).ToList();
            return orden;
        }


    }
}
