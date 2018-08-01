using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class ArticuloBE
    {
        [DataMember]
        public int IdArticulo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public CategoriaBE CategoriaBE { get; set; }
        [DataMember]
        public MarcaBE MarcaE { get; set; }
        [DataMember]
        public string UnidadMedida { get; set; }



        //Campos Adicionales
        [DataMember]
        public Decimal Cantidad { get; set; }
        [DataMember]
        public Decimal? Costo { get; set; }
        [DataMember]
        public Decimal? Precio { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public Decimal PrecioNuevo { get; set; }

    }
}
