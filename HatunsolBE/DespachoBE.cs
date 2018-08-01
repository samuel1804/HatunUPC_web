using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    public class DespachoBE
    {
        public int IdGuiaDespacho { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaTraslado { get; set; }
        public int IdOrden { get; set; }
        public int TipoOrden { get; set; }
        public int IdPersona { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int IdEstablecimieto { get; set; }

        public List<ArticuloBE> Articulos { get; set; }

        //Extras

        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string EstadoNombre { get; set; }
    }
}
