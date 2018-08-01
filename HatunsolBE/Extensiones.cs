using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{

    public static class Extensiones
    {

        public const float RadioTierraKm = 6378.0F;
        public static float DistanciaKm(this Posicion posOrigen, Posicion posDestino)
        { // TODO
        //Latitud 1 es Origen
            var difLatitud = (posDestino.Latitud - posOrigen.Latitud).EnRadianes();
            var difLongitud = (posDestino.Longitud - posOrigen.Longitud).EnRadianes();

            var a = Math.Pow(Math.Sin(difLatitud / 2),2) + Math.Cos(posOrigen.Latitud) * Math.Cos(posDestino.Latitud) * Math.Pow(Math.Sin(difLongitud / 2),2);
            var c = 2 * (float) Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = RadioTierraKm * c;

            return d;
        }

        static float EnRadianes(this float valor)
        {
            return Convert.ToSingle(Math.PI / 180) * valor;
        }
    }
}


