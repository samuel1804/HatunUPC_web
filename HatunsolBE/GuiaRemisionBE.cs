using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class GuiaRemisionBE
    {
        [DataMember]
        public int IdGuiaRemision { get; set; }
        [DataMember]
        public int IdProveedor { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string DireccionOrigen { get; set; }
        [DataMember]
        public string DireccionDestino { get; set; }
        [DataMember]
        public int ModalidadPago { get; set; }
        [DataMember]
        public DateTime FechaTraslado { get; set; }
    }
}
