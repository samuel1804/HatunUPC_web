using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
using System.Data.SqlClient;
namespace HatunsolDAO
{
    public class MaestroDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<MaestroBE> ListarparaObra(int IdObra, decimal Area)
        {
          

             var reader = db.Database.SqlQuery<sp_Maestro_Obra_Listar_Result>("sp_Maestro_Obra_Listar @param1, @param2",
              new SqlParameter("param1", IdObra)      ,
            new SqlParameter("param2", Area)
                    );
            var lista=new List<MaestroBE>();


            foreach (var item in reader)
            {
                var MaestroBE = new MaestroBE()
                {
                    IdMaestro = item.IdMaestro,
                    Nombre = item.Nombre,
                    ApePaterno = item.ApePaterno,
                    ApeMaterno = item.ApeMaterno,
                    DNI = item.DNI,
                    EspecialidadNombre = item.EspecialidadNombre,
                    Precio = (Decimal)item.PrecioDia,
                    Celular = item.Celular,
                    Dias = (int)item.Dias,
                    SubTotal = (decimal)item.SubTotal,
                    Calificacion = (int)item.Calificacion,



                };
                lista.Add(MaestroBE);
            }
                                       

                                        

            return lista.OrderByDescending(t=>t.Calificacion).ToList();

        }
    }
}
