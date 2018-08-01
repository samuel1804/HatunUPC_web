using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatunsolBE;
namespace HatunsolDAO
{
    public class SolicitudDAO
    {
        private SG_FerreteriaEntities db = new SG_FerreteriaEntities();
        public List<SolicitudBE> Listar(string Nombre)
        {
            var lista = (from t in db.SG_Solicitud
                         join sp in db.SG_Solicitud_Persona on t.IdSolicitud equals sp.IdSolicitud
                         join p in db.SG_Persona on sp.IdPersona equals p.IdPersona
                         select new SolicitudBE()
                         {
                             IdSolicitud = t.IdSolicitud,
                             MontoEfectivoProp = t.MontoEfectivoProp,
                             MontoMaterialProp = t.MontoMaterialProp,
                             FechaSolicitud = t.FechaSolicitud,
                             Obra = t.Obra,
                             Personas = new List<PersonaBE>() { new PersonaBE() { IdPersona = p.IdPersona, Nombre = p.Nombre + " " + p.ApeMaterno + " " + p.ApePaterno, DNI = p.DNI, Telefonos = p.Telefonos } }
                         }).ToList();

            return lista;
        }



        public PersonaBE Insertar(List<PersonaBE> persons)
        {
            foreach (var item in persons)
            {
                var person = db.SG_Persona.Where(t => t.DNI.Equals(item.DNI)).FirstOrDefault();
                //Si la persona no esta registrada la registra
                if (person == null)
                {

                    int IdPersona = db.SG_Persona.OrderByDescending(t => t.IdPersona).FirstOrDefault() == null ? 1 : db.SG_Persona.OrderByDescending(t => t.IdPersona).FirstOrDefault().IdPersona + 1;
                    person = new SG_Persona()
                    {
                        IdPersona = IdPersona,
                        Nombre = item.Nombre,
                        ApeMaterno = item.ApeMaterno,
                        ApePaterno = item.ApePaterno,
                        CodUbigeo = item.CodUbigeo,
                        Correo = item.Correo,
                        Direccion = item.Direccion,
                        DNI = item.DNI,
                        EstadoCivil = item.EstadoCivil,
                        SexoId = item.SexoId,
                        Telefonos = item.Telefonos,
                        TrabajoDepend = item.TrabajoDepend,
                        Establecimiento=item.Establecimiento,
                        TipoEstablecimiento=item.TipoEstablecimiento,
                        FechaInicio = item.FechaInicio,
                        CargoLaboral = item.CargoLaboral,
                        NombreEmpresa = item.NombreEmpresa,
                        TipoTrabajo=item.TipoTrabajo,
                        RUCEmpresa = item.RUCEmpresa,
                        IngresoNeto = item.IngresoNeto,
                        SustentoIngreso = item.SustentoIngreso,
                        
                    };
                    db.SG_Persona.Add(person);
                    db.SaveChanges();
                    
                }
                item.IdPersona = person.IdPersona;
            }
                //Inserta una Solicitud
                var titular = persons.Where(t => t.TipoPersona == (int)ConstantesBE.TipoPersona.Titular).FirstOrDefault();
                int IdSolicitud = db.SG_Solicitud.OrderByDescending(t => t.IdSolicitud).FirstOrDefault() == null ? 1 : db.SG_Solicitud.OrderByDescending(t => t.IdSolicitud).FirstOrDefault().IdSolicitud + 1;

                var Solicitud = new SG_Solicitud()
                {
                    IdSolicitud=IdSolicitud,
                    IdEstablecimiento = titular.IdEstablecimiento,
                    EstadoDespacho = (int)ConstantesBE.EstadoDespacho.Pendiente,
                    FechaSolicitud = DateTime.Now,
                    MontoEfectivoProp = titular.MontoEfectivoProp,
                    MontoMaterialProp = titular.MontoMaterialProp,
                    Obra = titular.Obra,

                };

                db.SG_Solicitud.Add(Solicitud);


                foreach (var pers in persons)
                {
                    //Igual la registra en la Solicitud de Credito
                    var SolicitudPersona = new SG_Solicitud_Persona()
                    {
                        IdSolicitud = Solicitud.IdSolicitud,
                        IdPersona = pers.IdPersona,
                        TipoPersona = pers.TipoPersona,
                        ResultadoFiltro = (int)ConstantesBE.ResultadoEvaluacion.SinEvaluar
                    };
                    db.SG_Solicitud_Persona.Add(SolicitudPersona);
                }



                db.SaveChanges();
                titular.IdSolicitud = Solicitud.IdSolicitud;
                return titular;

            

        }

    }
}
