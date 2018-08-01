using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class ParametroBE
    {
        [DataMember]
        public int ParametroId { get; set; }
        [DataMember]
        public string NombreCorto { get; set; }
        [DataMember]
        public string NombreLargo { get; set; }
        [DataMember]
        public bool Estado { get; set; }
    }
}
