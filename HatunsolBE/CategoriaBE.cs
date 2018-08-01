using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class CategoriaBE
    {
        [DataMember]
        public int IdCategoria { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}
