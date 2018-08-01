using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class MaestroBE
    {
        [DataMember]
        public int IdMaestro { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApePaterno { get; set; }
        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public int Especialidad { get; set; }
        [DataMember]
        public string EspecialidadNombre { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public int Estado { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int Calificacion { get; set; }

        //Campo Adicionales
        [DataMember]
        public int Dias { get; set; }

        [DataMember]
        public decimal SubTotal { get; set; }
    }
}
