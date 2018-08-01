using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    public class GuiaDespachoBE
    {
        public int IdGuiaDespacho { get; set; }
        public int IdOrden { get; set; }
        public int TipoOrden { get; set; }
        public int IdEstablecimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
    }
}
