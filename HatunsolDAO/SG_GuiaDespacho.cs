//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HatunsolDAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class SG_GuiaDespacho
    {
        public SG_GuiaDespacho()
        {
            this.SG_GuiaDespacho_Articulo = new HashSet<SG_GuiaDespacho_Articulo>();
        }
    
        public int IdGuiaDespacho { get; set; }
        public int IdOrden { get; set; }
        public int TipoOrden { get; set; }
        public int IdEstablecimiento { get; set; }
        public System.DateTime FechaCrea { get; set; }
        public System.DateTime FechaTraslado { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual SG_Establecimiento SG_Establecimiento { get; set; }
        public virtual ICollection<SG_GuiaDespacho_Articulo> SG_GuiaDespacho_Articulo { get; set; }
    }
}