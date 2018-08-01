using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class OrdenCompraBE
    {
        [DataMember]
        public int IdOrdenCompra { get; set; }
        [DataMember]
        public int IdEstablecimiento { get; set; }
        [DataMember]
        public int IdProveedor { get; set; }
        [DataMember]
        public string NroOrden { get; set; }
        [DataMember]
        public string FormaPago { get; set; }
        [DataMember]
        public DateTime? Fecha_Ped { get; set; }
        [DataMember]
        public DateTime? Fecha_Req { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal IGV { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public int Estado { get; set; }


        public string EstadoNombre { get; set; }

        //Lista de Articulos
        [DataMember]
        public List<ArticuloBE> Articulos { get; set; }

        //Datos Establecimiento
        [DataMember]
        public EstablecimientoBE Establecimiento { get; set; }
        [DataMember]
        public ProveedorBE Proveedor { get; set; }



    }
}
