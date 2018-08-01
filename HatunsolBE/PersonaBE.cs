using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    [DataContract]
    public class PersonaBE
    {
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApePaterno { get; set; }
        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string CodUbigeo { get; set; }
        [DataMember]
        public int EstadoCivil { get; set; }
        [DataMember]
        public string Telefonos { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Establecimiento { get; set; }
        
                 [DataMember]
        public int TipoEstablecimiento { get; set; }
        [DataMember]
        public int TrabajoDepend { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public string CargoLaboral { get; set; }
        [DataMember]
        public int TipoTrabajo{ get; set; }
        [DataMember]
        public string GiroNegocio { get; set; }
        [DataMember]
        public string NombreEmpresa { get; set; }
     
        [DataMember]
        public string RUCEmpresa { get; set; }
        [DataMember]
        public decimal IngresoNeto { get; set; }
        [DataMember]
        public int SustentoIngreso { get; set; }
        [DataMember]
        public int SexoId { get; set; }

        //Campos Extras
        [DataMember]
        public int TipoPersona { get; set; }
        [DataMember]
        public int ResultadoFiltro { get; set; }

        [DataMember]
        public int IdEstablecimiento { get; set; }
        [DataMember]
        public decimal MontoEfectivoProp { get; set; }
        [DataMember]
        public decimal MontoMaterialProp { get; set; }
        [DataMember]
        public string Obra { get; set; }

        [DataMember]
        public int IdSolicitud { get; set; }

    }
}
