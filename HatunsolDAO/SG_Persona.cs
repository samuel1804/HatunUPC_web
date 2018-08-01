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
    
    public partial class SG_Persona
    {
        public SG_Persona()
        {
            this.SG_PresupuestoMaterial = new HashSet<SG_PresupuestoMaterial>();
            this.SG_PresupuestoMo = new HashSet<SG_PresupuestoMo>();
            this.SG_Solicitud_Persona = new HashSet<SG_Solicitud_Persona>();
        }
    
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string DNI { get; set; }
        public string CodUbigeo { get; set; }
        public int EstadoCivil { get; set; }
        public string Telefonos { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public Nullable<int> TrabajoDepend { get; set; }
        public string Establecimiento { get; set; }
        public Nullable<int> TipoEstablecimiento { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public string CargoLaboral { get; set; }
        public string NombreEmpresa { get; set; }
        public Nullable<int> TipoTrabajo { get; set; }
        public string RUCEmpresa { get; set; }
        public Nullable<decimal> IngresoNeto { get; set; }
        public Nullable<int> SustentoIngreso { get; set; }
        public Nullable<int> SexoId { get; set; }
    
        public virtual SG_Ubigeo SG_Ubigeo { get; set; }
        public virtual ICollection<SG_PresupuestoMaterial> SG_PresupuestoMaterial { get; set; }
        public virtual ICollection<SG_PresupuestoMo> SG_PresupuestoMo { get; set; }
        public virtual ICollection<SG_Solicitud_Persona> SG_Solicitud_Persona { get; set; }
    }
}
