using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
using System.Data.SqlClient;
namespace HatunsolDAO
{

    public class ArticuloDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();

        public List<ArticuloBE> Listar()
        {
            var lista = (from t in db.SG_Articulo
                         select new ArticuloBE()
                         {
                             IdArticulo = t.IdArticulo,
                             Nombre = t.Nombre
                         }).ToList();

            return lista;
        }
        public ArticuloBE ObtenerporProveedor(int IdProveedor, int IdArticulo)
        {
            var articulo = (from t in db.SG_Articulo
                            join pa in db.SG_Proveedor_Articulo on t.IdArticulo equals pa.IdArticulo
                            join um in db.SG_Parametro on t.UnidadMedida equals um.ParametroId
                            where pa.IdProveedor == IdProveedor && pa.IdArticulo == IdArticulo
                            && um.DominioId == (int)ConstantesBE.Dominio.UnidadMedida
                            select new ArticuloBE()
                            {
                                IdArticulo = t.IdArticulo,
                                Nombre = t.Nombre,
                                Costo = pa.Costo,
                                UnidadMedida = um.NombreLargo,


                            }).FirstOrDefault();

            return articulo;
        }

        public ArticuloBE ObtenerporEstablecimiento(int IdEstablecimiento, int IdArticulo)
        {
            var articulo = (from t in db.SG_Articulo
                            join ea in db.SG_Establecimiento_Articulo on t.IdArticulo equals ea.IdArticulo
                            join um in db.SG_Parametro on t.UnidadMedida equals um.ParametroId
                            where ea.IdEstablecimiento == IdEstablecimiento && ea.IdArticulo == IdArticulo
                            && um.DominioId == (int)ConstantesBE.Dominio.UnidadMedida
                            select new ArticuloBE()
                            {
                                IdArticulo = t.IdArticulo,
                                Nombre = t.Nombre,
                                Precio = ea.Precio,
                                UnidadMedida = um.NombreLargo,
                            }).FirstOrDefault();

            return articulo;
        }


        public List<ArticuloBE> ArticulosBajaRotacion(string FechaInicio, string FechaFin, int IdEstablecimiento)
        {
            var lista = new List<ArticuloBE>();
            var reader = db.Database.SqlQuery<sp_ArticulosBajaRotacion_Result>("sp_ArticulosBajaRotacion @param1, @param2,@param3",
                new SqlParameter("param1", FechaInicio),
                new SqlParameter("param2", FechaFin),
                new SqlParameter("param3", IdEstablecimiento)
          );
            foreach (sp_ArticulosBajaRotacion_Result item in reader)
            {
                var articulo = new ArticuloBE()
                {
                    IdArticulo = item.IdArticulo,
                    Cantidad=item.Cantidad,
                    Costo=item.Costo,
                    Precio=item.Precio,
                    UnidadMedida=item.NombreLargo,
                    Nombre=item.Nombre
                    
                };

                lista.Add(articulo);
            }

            return lista;
        }
    }
}
