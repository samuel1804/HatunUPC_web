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
    
    public partial class SG_Establecimiento_Articulo
    {
        public int IdEstablecimiento { get; set; }
        public int IdArticulo { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> Stock { get; set; }
    
        public virtual SG_Articulo SG_Articulo { get; set; }
        public virtual SG_Establecimiento SG_Establecimiento { get; set; }
    }
}