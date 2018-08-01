using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class RolBE
    {
        [DataMember]
        public int RolId { get; set; }
          [DataMember]
        public string RolDes{get;set;}





    
    }
}
