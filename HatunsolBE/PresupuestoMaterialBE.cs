using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class PresupuestoMaterialBE
    {
        [DataMember]
        public int IdPresupuestoMaterial { get; set; }

        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public int IdObra { get; set; }
        [DataMember]
        public EstablecimientoBE EstablecimientoBE { get; set; }
        [DataMember]
        public List<PresupuestoMaterial_ArticuloBE> Lista_Articulos { get; set; }
        [DataMember]
        public ObraBE ObraBE { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string DireccionOrigen { get; set; }
        [DataMember]
        public string DireccionDestino { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal Area { get; set; }
        [DataMember]
        public decimal IGV { get; set; }
        [DataMember]
        public decimal Total { get; set; }

        //Campos Adicionales
        [DataMember]
        public int IdEstablecimiento { get; set; }
    }
}
