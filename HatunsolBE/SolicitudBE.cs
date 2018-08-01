using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class SolicitudBE
    {
        [DataMember]
        public int IdSolicitud { get; set; }
        [DataMember]
        public List<PersonaBE> Personas { get; set; }
        [DataMember]
        public decimal MontoEfectivoProp { get; set; }
        [DataMember]
        public decimal MontoMaterialProp { get; set; }
        
        [DataMember]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public string Obra { get; set; }
        [DataMember]
        public EstablecimientoBE Establecimiento { get; set; }
    }
}
