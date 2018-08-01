using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class Obra_MaterialBE
    {
        [DataMember]
        public ObraBE ObraBE { get; set; }
        [DataMember]
        public ArticuloBE ArticuloBE { get; set; }
        [DataMember]
        public decimal Factor { get; set; }
    }
}
