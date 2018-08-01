using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
using System.Globalization;
namespace HatunsolDAO
{
    public class EstablecimientoDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<EstablecimientoBE> Listar(string Latitud, string Longitud)
        {
            float lat = float.Parse(Latitud, CultureInfo.InvariantCulture);
            float longit = float.Parse(Longitud, CultureInfo.InvariantCulture);

            var lista = (from t in db.SG_Establecimiento
                         where (t.Latitud != null && !t.Latitud.Equals("")) && (t.Longitud != null && !t.Longitud.Equals(""))
                         select new EstablecimientoBE()
                         {
                             IdEstablecimiento = t.IdEstablecimiento,
                             RazonSocial = t.RazonSocial,
                             NombreComercial = t.NombreComercial,
                             Latitud = t.Latitud,
                             Longitud = t.Longitud,
                             Direccion = t.Direccion,
                           
                         }).ToList();

            var lista2 = lista.Where(t => Extensiones.DistanciaKm(new Posicion(lat, longit), new Posicion(float.Parse(t.Latitud, CultureInfo.InvariantCulture), float.Parse(t.Longitud, CultureInfo.InvariantCulture))) < 7).ToList();



            return lista2;
        }

        public List<EstablecimientoBE> ListarTodos()
        {
            
            var lista = (from t in db.SG_Establecimiento
                         select new EstablecimientoBE()
                         {
                             IdEstablecimiento = t.IdEstablecimiento,
                             RazonSocial = t.RazonSocial,
                             RUC=t.RUC,
                             NombreComercial = t.NombreComercial,
                             Latitud = t.Latitud,
                             Longitud = t.Longitud,
                             Direccion = t.Direccion,

                         }).ToList();

           

            return lista;
        }
        public EstablecimientoBE Obtener(int IdEstablecimiento)
        {


            var establecimiento = (from t in db.SG_Establecimiento
                         where t.IdEstablecimiento==IdEstablecimiento
                         select new EstablecimientoBE()
                         {
                             IdEstablecimiento = t.IdEstablecimiento,
                             RazonSocial = t.RazonSocial,
                             NombreComercial = t.NombreComercial,
                             RUC=t.RUC,
                             Direccion = t.Direccion,

                         }).FirstOrDefault();


            return establecimiento;
        }
    }
}
