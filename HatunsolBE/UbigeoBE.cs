using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class UbigeoBE
    {
        [DataMember]
        public string CodUbigeo { get; set; }
        [DataMember]
        public string CodDpto { get; set; }
        [DataMember]
        public string CodProv { get; set; }
        [DataMember]
        public string CodDist { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string NombreCorto { get; set; }
    }
}
