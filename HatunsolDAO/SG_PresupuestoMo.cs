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
    
    public partial class SG_PresupuestoMo
    {
        public SG_PresupuestoMo()
        {
            this.SG_PresupuestoMo_Maestro = new HashSet<SG_PresupuestoMo_Maestro>();
        }
    
        public int IdPresupuestoMo { get; set; }
        public int IdPersona { get; set; }
        public int IdObra { get; set; }
        public decimal Area { get; set; }
        public int Dias { get; set; }
        public decimal Total { get; set; }
    
        public virtual SG_Obra SG_Obra { get; set; }
        public virtual ICollection<SG_PresupuestoMo_Maestro> SG_PresupuestoMo_Maestro { get; set; }
        public virtual SG_Persona SG_Persona { get; set; }
    }
}
