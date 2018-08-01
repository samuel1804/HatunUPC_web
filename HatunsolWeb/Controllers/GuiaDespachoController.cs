using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatunsolWS;
using HatunsolBE;
namespace HatunsolWeb.Controllers
{
    public class GuiaDespachoController : Controller
    {
        //
        // GET: /GuiaDespacho/
        public ActionResult Index()
        {
            int IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
            var Guias = new DespachoWS().Listar("", 0, IdEstablecimiento);
            var Parametros = new ParametroWS().Listar((int)ConstantesBE.Dominio.EstadoDespacho);
            ViewBag.ListaEstado = Parametros;
            return View(Guias);
        }

        [HttpGet]
        public ActionResult CargarProducto(int IdArticulo)
        {
            var ArticuloWS = new ArticuloWS();
            int IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
            var articulo = ArticuloWS.ObtenerporEstablecimiento(IdEstablecimiento, IdArticulo);

            return Json(articulo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var db = new ProveedorWS();
            ViewBag.Proveedores = db.Listar();
            var articulo = new ArticuloWS();
            ViewBag.Articulos = articulo.Listar();
            int IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;

            /*var OrdenCompra = new OrdenCompraBE();
              var EstablecimientoWS = new EstablecimientoWS();
              OrdenCompra.Establecimiento = EstablecimientoWS.Obtener(IdEstablecimiento);*/

            Session["detalle"] = null;
            //var detalle = (List<ArticuloBE>)Session["detalle"];
            //OrdenCompraBE orden = new OrdenCompraBE();



            return View();
        }

        public JsonResult Pendientes(string DNI)
        {
            try
            {

                DespachoWS despacho = new DespachoWS();
                int IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
                List<DespachoBE> data = despacho.Pendientes(DNI.Trim(), IdEstablecimiento);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(RedirectToAction("Error"));
            }
        }
        [HttpPost]
        public ActionResult GuardarGuia(int IdOrden, int TipoOrden, string FechaTraslado)
        {
            try
            {
                var despachoWS = new DespachoWS();
                DespachoBE despachobe = despachoWS.CargarDetalle(IdOrden, TipoOrden);
                despachobe.FechaTraslado = DateTime.Parse(FechaTraslado);
                var Userbe = ((UserBE)Session["Usuario"]);
                var Establecimiento = new EstablecimientoWS().Obtener(Userbe.EmpleadoId);
                despachobe.DireccionOrigen = Establecimiento.Direccion;
                despachobe.IdEstablecimieto = Establecimiento.IdEstablecimiento;
                despachoWS.Insertar(despachobe);

                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
        }

        public JsonResult CargarDetalle(int IdOrden, int TipoOrden)
        {
            try
            {

                DespachoWS despacho = new DespachoWS();
                DespachoBE data = despacho.CargarDetalle(IdOrden, TipoOrden);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(RedirectToAction("Error"));
            }
        }
    }
}