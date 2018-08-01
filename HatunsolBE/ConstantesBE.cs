using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatunsolBE
{
    public static class ConstantesBE
    {
        public enum Dominio
        {
            EstadoOrdenCompra = 86,
            UnidadMedida = 28,
            FormaPago = 87,
            EstadoDespacho = 88,
            EstadoPromocion=89,

        }
        public enum EstadoOrden
        {
            Pendiente = 1,
            Aprobada = 2,
            Atendida = 3,
            Rechazada = 4,


        }

        public enum ResultadoEvaluacion
        {
            SinEvaluar = 1,
            Aprueba = 2,
            Noaprueba = 3
        }
        public enum EstadoDespacho
        {
            Pendiente = 1,
            Despachado = 2,

        }
        public enum EstadoPromocion
        {
            Creada = 1,
            Activada = 2,

        }
        public enum TipoOrden
        {
            PresupuestoFerreteria = 1,
            SolicitudCredito = 2,
            PresupuestoMaterial = 3,

        }
        public enum TipoPersona
        {
            Titular = 1,
            Conyugue = 2,
            GarantePropiedad = 3,
            GaranteIngresos = 4,
            ConyugeGarantePropiedad = 5,
            ConyugeGaranteIngresos = 6
        }
        public enum FormaPago
        {
            Efectivo = 1,
            Factura15 = 2,
            Factura30 = 3,



        }
        public enum Rol
        {
            Establecimiento = 26,
            Cliente = 40,
            Proveedores = 15

        }



    }
}
