using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class ParametroDAO
    {
        SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<ParametroBE> Listar(int DominioId) { 
        var lista=(from t in db.SG_Parametro
                       where t.DominioId==DominioId
                       select new ParametroBE(){
                       ParametroId=t.ParametroId,
                       NombreCorto=t.NombreCorto,
                       NombreLargo = t.NombreLargo,
                       }).ToList();
        return lista;
        }
    }
}
