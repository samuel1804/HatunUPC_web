using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class PresupuestoMaterial_ArticuloBE
    {
        [DataMember]
        public int IdPresupuestoMaterial { get; set; }
        [DataMember]
        public ArticuloBE ArticuloBE { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }

    }
}
