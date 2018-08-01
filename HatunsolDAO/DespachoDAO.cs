using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
using System.Data.Entity.Validation;
namespace HatunsolDAO
{
    public class DespachoDAO
    {
        SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<DespachoBE> Pendientes(string DNI, int IdEstablecimiento)
        {
            var lista = (from pm in db.SG_PresupuestoMaterial
                         join p in db.SG_Persona on pm.IdPersona equals p.IdPersona
                         where pm.EstadoDespacho == (int)ConstantesBE.EstadoDespacho.Pendiente
                         && p.DNI == DNI && pm.IdEstablecimiento == IdEstablecimiento
                         select new DespachoBE()
                         {
                             IdOrden = pm.IdPresupuestoMaterial,
                             TipoOrden = (int)ConstantesBE.TipoOrden.PresupuestoMaterial,
                             Fecha = pm.Fecha,
                             Descripcion = "Presupuesto de Material",
                             Monto = pm.Total
                         }).Union(
                         from s in db.SG_Solicitud
                         join sp in db.SG_Solicitud_Persona on s.IdSolicitud equals sp.IdSolicitud
                         join p in db.SG_Persona on sp.IdPersona equals p.IdPersona
                         where s.EstadoDespacho == (int)ConstantesBE.EstadoDespacho.Pendiente
                         && p.DNI == DNI && sp.TipoPersona == (int)ConstantesBE.TipoPersona.Titular && s.IdEstablecimiento == IdEstablecimiento
                         select new DespachoBE()
                         {
                             IdOrden = s.IdSolicitud,
                             TipoOrden = (int)ConstantesBE.TipoOrden.SolicitudCredito,
                             Fecha = s.FechaSolicitud,
                             Descripcion = "Solicitud de Crédito",
                             Monto = s.MontoMaterialProp
                         }).ToList();
            return lista;
        }


        public DespachoBE CargarDetalle(int IdOrden, int TipoOrden)
        {
            DespachoBE despacho = new DespachoBE();
            if (TipoOrden == (int)ConstantesBE.TipoOrden.PresupuestoMaterial)
            {
                despacho = (from pm in db.SG_PresupuestoMaterial
                            join p in db.SG_Persona on pm.IdPersona equals p.IdPersona
                            where pm.IdPresupuestoMaterial == IdOrden
                            select new DespachoBE()
                            {
                                IdOrden = pm.IdPresupuestoMaterial,
                                TipoOrden = (int)ConstantesBE.TipoOrden.PresupuestoMaterial,
                                Fecha = pm.Fecha,
                                Descripcion = "Presupuesto de Material",
                                Monto = pm.Total,
                                Nombres = p.Nombre + " " + p.ApePaterno + " " + p.ApeMaterno,
                                Telefono = p.Telefonos,
                                DireccionDestino = p.Direccion,
                                Articulos = (from pma in db.SG_PresupuestoMaterial_Articulo
                                             join a in db.SG_Articulo on pma.IdArticulo equals a.IdArticulo
                                             join um in db.SG_Parametro on a.UnidadMedida equals um.ParametroId
                                             where pma.IdPresupuestoMaterial == pm.IdPresupuestoMaterial && um.DominioId == 28
                                             select new ArticuloBE()
                                             {
                                                 IdArticulo = a.IdArticulo,
                                                 Nombre = a.Nombre,
                                                 Cantidad = pma.Cantidad,
                                                 Precio = pma.Precio,
                                                 SubTotal = pma.SubTotal,
                                                 UnidadMedida = um.NombreCorto
                                             }).ToList()
                            }).FirstOrDefault();
            }
            else if (TipoOrden == (int)ConstantesBE.TipoOrden.SolicitudCredito)
            {
                despacho = (from s in db.SG_Solicitud
                            join sp in db.SG_Solicitud_Persona on s.IdSolicitud equals sp.IdSolicitud
                            join p in db.SG_Persona on sp.IdPersona equals p.IdPersona
                            where s.IdSolicitud == IdOrden && sp.TipoPersona == (int)ConstantesBE.TipoPersona.Titular
                            select new DespachoBE()
                            {
                                IdOrden = s.IdSolicitud,
                                TipoOrden = (int)ConstantesBE.TipoOrden.PresupuestoMaterial,
                                Fecha = s.FechaSolicitud,
                                Descripcion = "Solicitud de Crédito",
                                Monto = s.MontoMaterialProp,
                                Nombres = p.Nombre + " " + p.ApePaterno + " " + p.ApeMaterno,
                                Telefono = p.Telefonos,
                                DireccionDestino = p.Direccion,

                            }).FirstOrDefault();

            }
            return despacho;

        }
        public List<DespachoBE> Listar(string Nombre, int Estado, int IdEstablecimiento)
        {
            var despachos = (from gd in db.SG_GuiaDespacho
                             from pm in db.SG_PresupuestoMaterial
                             join p in db.SG_Persona on pm.IdPersona equals p.IdPersona
                             join e in db.SG_Parametro on gd.Estado equals e.ParametroId
                             where pm.IdPresupuestoMaterial == gd.IdOrden && gd.TipoOrden == (int)ConstantesBE.TipoOrden.PresupuestoMaterial
                             && gd.IdEstablecimiento == IdEstablecimiento
                             && e.DominioId == (int)ConstantesBE.Dominio.EstadoDespacho && p.Nombre.Contains(Nombre) && (gd.Estado == Estado || Estado == 0)
                             select new DespachoBE()
                             {
                                 IdGuiaDespacho = gd.IdGuiaDespacho,
                                 Nombres = p.Nombre + " " + p.ApePaterno + " " + p.ApeMaterno,
                                 Telefono = p.Telefonos,
                                 DireccionDestino = gd.DireccionDestino,
                                 FechaTraslado = gd.FechaTraslado,
                                 EstadoNombre = e.NombreLargo
                             }).Union(
                             from gd in db.SG_GuiaDespacho
                             join sp in db.SG_Solicitud_Persona on gd.IdOrden equals sp.IdSolicitud
                             join p in db.SG_Persona on sp.IdPersona equals p.IdPersona
                             join e in db.SG_Parametro on gd.Estado equals e.ParametroId
                             where sp.IdSolicitud == gd.IdOrden && gd.TipoOrden == (int)ConstantesBE.TipoOrden.SolicitudCredito
                             && gd.IdEstablecimiento == IdEstablecimiento  && e.DominioId == (int)ConstantesBE.Dominio.EstadoDespacho && p.Nombre.Contains(Nombre) && (gd.Estado == Estado || Estado == 0)
                             select new DespachoBE()
                             {
                                 IdGuiaDespacho = gd.IdGuiaDespacho,
                                 Nombres = p.Nombre + " " + p.ApePaterno + " " + p.ApeMaterno,
                                 Telefono = p.Telefonos,
                                 DireccionDestino = gd.DireccionDestino,
                                 FechaTraslado = gd.FechaTraslado,
                                 EstadoNombre = e.NombreLargo
                             }).ToList();
            return despachos;
        }

        public DespachoBE Insertar(DespachoBE despachoBE)
        {
            try
            {
                int IdGuiaDespacho = (db.SG_GuiaDespacho.OrderByDescending(t => t.IdGuiaDespacho).FirstOrDefault() == null ? 1 : db.SG_GuiaDespacho.OrderByDescending(t => t.IdGuiaDespacho).FirstOrDefault().IdGuiaDespacho + 1);
                var guia = new SG_GuiaDespacho()
                {
                    IdGuiaDespacho = IdGuiaDespacho,
                    DireccionDestino = despachoBE.DireccionDestino,
                    DireccionOrigen = despachoBE.DireccionOrigen,
                    FechaCrea = DateTime.Now,
                    IdEstablecimiento = despachoBE.IdEstablecimieto,
                    IdOrden = despachoBE.IdOrden,
                    TipoOrden = despachoBE.TipoOrden,
                    FechaTraslado = despachoBE.FechaTraslado,
                    Estado = (int)ConstantesBE.EstadoDespacho.Pendiente
                };
                db.SG_GuiaDespacho.Add(guia);

                foreach (ArticuloBE item in despachoBE.Articulos)
                {
                    var articulo = new SG_GuiaDespacho_Articulo()
                    {
                        IdArticulo = item.IdArticulo,
                        Cantidad = item.Cantidad,
                        IdGuiaDespacho = IdGuiaDespacho
                    };
                    db.SG_GuiaDespacho_Articulo.Add(articulo);
                }

                if (despachoBE.TipoOrden == (int)ConstantesBE.TipoOrden.PresupuestoMaterial)
                {
                    var presupuesto = db.SG_PresupuestoMaterial.Where(t => t.IdPresupuestoMaterial == despachoBE.IdOrden).FirstOrDefault();
                    presupuesto.EstadoDespacho = (int)ConstantesBE.EstadoDespacho.Despachado;
                }
                else if (despachoBE.TipoOrden == (int)ConstantesBE.TipoOrden.SolicitudCredito)
                {
                    var solicitud = db.SG_Solicitud.Where(t => t.IdSolicitud == despachoBE.IdOrden).FirstOrDefault();
                    solicitud.EstadoDespacho = (int)ConstantesBE.EstadoDespacho.Despachado;
                }

                db.SaveChanges();
                despachoBE.IdGuiaDespacho = IdGuiaDespacho;
                return despachoBE;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
    }
}
