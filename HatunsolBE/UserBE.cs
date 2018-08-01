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
    public class UserBE
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        [Required]
        public string UserLogin { get; set; }
        [DataMember]
        [Required]
        public string UserPassword { get; set; }
        [DataMember]
        public RolBE Rol { get; set; }
        [DataMember]
        public int EmpleadoId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<OptionBE> Options { get; set; }

    }
}
