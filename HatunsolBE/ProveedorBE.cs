using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class ProveedorBE
    {
        [DataMember]
        public int IdProveedor { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string Direccion { get; set; }

    }
}
