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
    
    public partial class SG_OrdenCompra
    {
        public SG_OrdenCompra()
        {
            this.SG_OrdenCompra_Articulo = new HashSet<SG_OrdenCompra_Articulo>();
            this.SG_GuiaRemision = new HashSet<SG_GuiaRemision>();
        }
    
        public int IdOrdenCompra { get; set; }
        public int IdEstablecimiento { get; set; }
        public int IdProveedor { get; set; }
        public string NroOrden { get; set; }
        public int FormaPago { get; set; }
        public Nullable<System.DateTime> Fecha_Ped { get; set; }
        public Nullable<System.DateTime> Fecha_Req { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public decimal Total { get; set; }
        public int Estado { get; set; }
    
        public virtual SG_Establecimiento SG_Establecimiento { get; set; }
        public virtual ICollection<SG_OrdenCompra_Articulo> SG_OrdenCompra_Articulo { get; set; }
        public virtual SG_Proveedor SG_Proveedor { get; set; }
        public virtual ICollection<SG_GuiaRemision> SG_GuiaRemision { get; set; }
    }
}
