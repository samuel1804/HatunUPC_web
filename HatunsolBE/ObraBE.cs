using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HatunsolBE
{
    [DataContract]
    public class ObraBE
    {
        [DataMember]
        public int IdObra { get; set; }
         [DataMember]
        public string Nombre { get; set; }
         [DataMember]
         public string UnidadMedidaNombre { get; set; }
         [DataMember]
         public string Foto { get; set; }
         [DataMember]
         public string Descripcion { get; set; }

        //Campos Adicionales

         [DataMember]
         public string UnidadMedidaCorto { get; set; }
    }
}
