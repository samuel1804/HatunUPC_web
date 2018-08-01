using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class UbigeoDAO
    {
        SG_FerreteriaEntities db=new SG_FerreteriaEntities();
        public List<UbigeoBE> Listar() {
            List<UbigeoBE> Lista = (from t in db.SG_Ubigeo
                                     where t.CodDpto.Equals("15") && !t.CodProv.Equals("00") && !t.CodDist.Equals("00")
                                    select new UbigeoBE(){
                                        CodDist=t.CodDist,
                                        CodDpto=t.CodDpto,
                                        CodProv = t.CodProv,
                                        CodUbigeo=t.CodUbigeo,
                                        Nombre=t.Nombre,
                                        NombreCorto=t.NombreCorto
                                        }).ToList();
            return Lista;
        }
    }
}
