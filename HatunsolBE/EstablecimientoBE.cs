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
    public class EstablecimientoBE
    {
        [DataMember]
        public int IdEstablecimiento { get; set; }
        [DataMember]
     
        public string RazonSocial { get; set; }
        [DataMember]
        public string NombreComercial { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Latitud { get; set; }
        [DataMember]
        public string Longitud { get; set; }
        [DataMember]
        public string RUC { get; set; }

        [DataMember]
        public float Distancia { get; set; }
    }
}
