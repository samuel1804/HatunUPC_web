using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Globalization;
namespace HatunsolDAO
{
    public class PresupuestoMaterialDAO
    {

        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<PresupuestoMaterialBE> PresupuestosFerreterias(int IdObra, decimal Area, string Latitud, string Longitud, int IdEstablecimiento)
        {

            try
            {
                var lista = new List<PresupuestoMaterialBE>();
                var reader = db.Database.SqlQuery<sp_PresupuestoMaterial_Result>("sp_PresupuestoMaterial @param1, @param2, @param3,@param4",
                    new SqlParameter("param1", Area),
                    new SqlParameter("param2", IdObra),
                    new SqlParameter("param3", Latitud),
                    new SqlParameter("param4", Longitud)
                    );
                foreach (var item in reader)
                {
                    var PresupuestoMaterialBE = new PresupuestoMaterialBE()
                    {
                        EstablecimientoBE = new EstablecimientoBE() { IdEstablecimiento = item.IdEstablecimiento, NombreComercial = item.NombreComercial, RazonSocial = item.RazonSocial, Direccion = item.Direccion, Latitud = item.Latitud, Longitud = item.Longitud, RUC = item.RUC },
                        SubTotal = (decimal)item.SubTotal,

                    };

                    lista.Add(PresupuestoMaterialBE);
                }

                List<PresupuestoMaterialBE> lista2 = new List<PresupuestoMaterialBE>();

                if (IdEstablecimiento == 0)
                {
                    float lat = float.Parse(Latitud, CultureInfo.InvariantCulture);
                    float longit = float.Parse(Longitud, CultureInfo.InvariantCulture);
                    lista2 = lista.OrderBy(t => Extensiones.DistanciaKm(new Posicion(lat, longit), new Posicion(float.Parse(t.EstablecimientoBE.Latitud, CultureInfo.InvariantCulture), float.Parse(t.EstablecimientoBE.Longitud, CultureInfo.InvariantCulture)))).Take(5).ToList();
                }
                else
                {
                    lista2 = lista.Where(t => t.EstablecimientoBE.IdEstablecimiento == IdEstablecimiento).ToList();
                }



                return lista2.OrderBy(t => t.SubTotal).ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<PresupuestoMaterial_ArticuloBE> PresupuestoFerreteriaDetalle(int IdObra, decimal Area, int IdEstablecimiento)
        {

            try
            {

                var reader = db.Database.SqlQuery<sp_Presupuesto_Material_Detalle_Result>("sp_Presupuesto_Material_Detalle @param1, @param2,@param3",
                    new SqlParameter("param1", Area),
                    new SqlParameter("param2", IdObra),
                    new SqlParameter("param3", IdEstablecimiento)
                    );
                var lista = new List<PresupuestoMaterial_ArticuloBE>();
                PresupuestoMaterial_ArticuloBE pm;
                foreach (var item in reader)
                {
                    pm = new PresupuestoMaterial_ArticuloBE()
                    {
                        ArticuloBE = new ArticuloBE() { IdArticulo = item.IdArticulo },
                        Cantidad = (decimal)item.Cantidad,
                        Precio = (decimal)item.Precio,
                        SubTotal = (decimal)item.SubTotal
                    };


                    lista.Add(pm);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<ArticuloBE> PresupuestarMaterial(int IdObra, Decimal Area)
        {

            try
            {
                var lista = new List<ArticuloBE>();
                var reader = db.Database.SqlQuery<sp_PresupuestoArticulo_Result>("sp_PresupuestoArticulo @param1, @param2",
                    new SqlParameter("param1", Area),
                    new SqlParameter("param2", IdObra)
                    );
                foreach (var item in reader)
                {
                    var PresupuestoMaterialBE = new ArticuloBE()
                    {
                        IdArticulo = item.IdArticulo,
                        CategoriaBE = new CategoriaBE() { Nombre = item.Categoria },
                        UnidadMedida = item.UnidadMedidaNombre,
                        Cantidad = (Decimal)item.Cantidad,
                        Nombre = item.Nombre
                    };
                    lista.Add(PresupuestoMaterialBE);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public int InsertarPresupuesto(PresupuestoMaterialBE presupuestoMaterialBE)
        {
            try
            {
                var presupuesto = new SG_PresupuestoMaterial()
                {
                    IdPresupuestoMaterial = db.SG_PresupuestoMaterial.OrderByDescending(t => t.IdPresupuestoMaterial).FirstOrDefault() == null ? 1 : db.SG_PresupuestoMaterial.OrderByDescending(t => t.IdPresupuestoMaterial).FirstOrDefault().IdPresupuestoMaterial + 1,
                    IdEstablecimiento = presupuestoMaterialBE.IdEstablecimiento,
                    IdPersona = presupuestoMaterialBE.IdPersona,
                    IdObra = presupuestoMaterialBE.IdObra,
                    Fecha = DateTime.Now,
                    SubTotal = presupuestoMaterialBE.SubTotal,
                    Area = presupuestoMaterialBE.Area,
                    IGV = 0,
                    Total = presupuestoMaterialBE.SubTotal,
                    EstadoDespacho = (int)ConstantesBE.EstadoDespacho.Pendiente
                };

                db.SG_PresupuestoMaterial.Add(presupuesto);

                SG_PresupuestoMaterial_Articulo presupuestomaterial;
                foreach (var item in PresupuestoFerreteriaDetalle(presupuestoMaterialBE.IdObra, presupuestoMaterialBE.Area, presupuestoMaterialBE.IdEstablecimiento))
                {
                    presupuestomaterial = new SG_PresupuestoMaterial_Articulo()
                   {
                       IdPresupuestoMaterial = presupuesto.IdPresupuestoMaterial,
                       IdArticulo = item.ArticuloBE.IdArticulo,
                       Cantidad = item.Cantidad,
                       Precio = item.Precio,
                       SubTotal = item.SubTotal
                   };
                    db.SG_PresupuestoMaterial_Articulo.Add(presupuestomaterial);
                    presupuestomaterial = null;
                }

                db.SaveChanges();

                return presupuesto.IdPresupuestoMaterial;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
