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
    
    public partial class SG_Promocion
    {
        public SG_Promocion()
        {
            this.SG_Promocion_Articulo = new HashSet<SG_Promocion_Articulo>();
        }
    
        public int IdPromocion { get; set; }
        public int IdEstablecimiento { get; set; }
        public int Estado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCrea { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
    
        public virtual SG_Establecimiento SG_Establecimiento { get; set; }
        public virtual ICollection<SG_Promocion_Articulo> SG_Promocion_Articulo { get; set; }
    }
}
