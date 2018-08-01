using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    public class VwOrdenCompra
    {
        public string NumeroOrden { get; set; }
        public string Proveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string FormaPago { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SubTo { get; set; }
        public decimal Tot { get; set; }


    }
}
