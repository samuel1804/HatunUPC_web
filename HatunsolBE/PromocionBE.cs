using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    public class PromocionBE
    {
        public int IdPromocion{get;set;}
        public int IdEstablecimiento { get; set; }
        public int Estado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        //Campos Adicionales
        public string EstadoNombre { get; set; }

        public List<ArticuloBE> Articulos { get; set; }
    }
}
