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
    
    public partial class SG_Maestro
    {
        public SG_Maestro()
        {
            this.SG_Maestro_Obra = new HashSet<SG_Maestro_Obra>();
            this.SG_PresupuestoMo_Maestro = new HashSet<SG_PresupuestoMo_Maestro>();
        }
    
        public int IdMaestro { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string DNI { get; set; }
        public string CodUbigeo { get; set; }
        public Nullable<int> Especialidad { get; set; }
        public Nullable<int> Estado { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public Nullable<int> Calificacion { get; set; }
    
        public virtual SG_Especialidad SG_Especialidad { get; set; }
        public virtual ICollection<SG_Maestro_Obra> SG_Maestro_Obra { get; set; }
        public virtual ICollection<SG_PresupuestoMo_Maestro> SG_PresupuestoMo_Maestro { get; set; }
    }
}
