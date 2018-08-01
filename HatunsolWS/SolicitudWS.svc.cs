using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HatunsolDAO;
using HatunsolBE;
namespace HatunsolWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Solicitud" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Solicitud.svc or Solicitud.svc.cs at the Solution Explorer and start debugging.
    public class SolicitudWS : ISolicitudWS
    {
        private SolicitudDAO dao = new SolicitudDAO();
        public List<HatunsolBE.SolicitudBE> Listar(string Nombre)
        {
            return dao.Listar(Nombre);
        }


        public PersonaBE Insertar(List<PersonaBE> persons)
        {
            return dao.Insertar(persons);
        }
    }
}
