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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "DespachoWS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione DespachoWS.svc o DespachoWS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class DespachoWS : IDespachoWS
    {
        DespachoDAO dao = new DespachoDAO();
        public List<DespachoBE> Pendientes(string DNI, int IdEstablecimiento)
        {
            return dao.Pendientes(DNI, IdEstablecimiento);
        }


        public List<DespachoBE> Listar(string Nombre, int Estado, int IdEstablecimiento)
        {
            return dao.Listar(Nombre, Estado, IdEstablecimiento);
        }
        public DespachoBE CargarDetalle(int IdOrden,int TipoOrden)
        {
            return dao.CargarDetalle(IdOrden, TipoOrden);
        }

        public DespachoBE Insertar(DespachoBE despachoBE)
        {
            return dao.Insertar(despachoBE);
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
