using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
using HatunsolDAO;
namespace HatunsolDAO
{
    public class UserDAO
    {
        SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public UserBE ObtenerUsuario(string strLogin) {
            var userbe = (from t in db.SG_User
                          from e in db.SG_Establecimiento.Where(e => e.IdEstablecimiento == t.EmpleadoId && t.RolId == (int)ConstantesBE.Rol.Establecimiento).DefaultIfEmpty()
                          join r in db.SG_Rol on t.RolId equals r.RolId
                          from p in db.SG_Proveedor.Where(p => p.IdProveedor == t.EmpleadoId && t.RolId == (int)ConstantesBE.Rol.Proveedores).DefaultIfEmpty()
                          where t.UserLogin.Equals(strLogin)
                          select new UserBE()
                          {
                              UserId = t.UserId,
                              UserLogin = t.UserLogin,
                              UserPassword = t.UserPassword,
                              Rol = new RolBE { RolId = r.RolId, RolDes = r.RolDes },
                              IsActive = t.IsActive,
                              EmpleadoId = t.EmpleadoId,
                              Nombre = e.NombreComercial ?? p.RazonSocial,
                              Options = (from ro in db.SG_Rol_Option
                                        join op in db.SG_Option on ro.IdOption equals op.IdOption
                                        where ro.RolId == t.RolId
                                        select new OptionBE()
                                        {
                                            IdOption=ro.IdOption,
                                            Nombre=op.Nombre,
                                            Action=op.Action,
                                            Controller=op.Controller
                                        }).ToList(),

                          }).FirstOrDefault();


            return userbe;
        }
       
    }
}
