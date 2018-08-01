using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{


    public class ObraDAO
    {
        private String url_Sistema = "http://www.hatunsol.com.pe/hatunsolws/";
        public List<ObraBE> Listar(string Descripcion)
        {
            var db = new SG_FerreteriaEntities();
            var lista = (from t in db.SG_Obra
                         join p in db.SG_Parametro on t.UnidadMedidaId equals p.ParametroId
                         where p.DominioId == 28 && t.Nombre.Contains(@Descripcion)
                         select new ObraBE
                        {
                            IdObra = t.IdObra,
                            Nombre = t.Nombre,
                            UnidadMedidaNombre = p.NombreLargo,
                            UnidadMedidaCorto = p.NombreCorto,
                            Foto = (t.Foto == null ? null : url_Sistema + t.Foto.Substring(2, t.Foto.Length - 2)),
                            Descripcion = t.Descripcion
                        }
                           ).ToList();

            return lista;
        }
    }
}
