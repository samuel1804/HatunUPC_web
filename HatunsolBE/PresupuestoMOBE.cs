using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class PresupuestoMOBE
    {
        [DataMember]
        public int IdPresupuestoMO { get; set; }
         [DataMember]
        public int IdPersona { get; set; }
         [DataMember]
        public int IdObra { get; set; }
         [DataMember]
        public decimal Area { get; set; }
         [DataMember]
        public int Dias { get; set; }
         [DataMember]
        public decimal Total { get; set; }
         [DataMember]
        public int IdMaestro { get; set; }

    }
}
