using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatunsolWS;
using HatunsolBE;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
namespace HatunsolWeb.Controllers
{
    public class GuiaRemisionController : Controller
    {
        //
        // GET: /GuiaRemision/
        public ActionResult Index()
        {
            var daoOrden = new OrdenCompraWS();
            UserBE usuario = ((UserBE)Session["Usuario"]);


            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1);
            var lista = daoOrden.Listar("", 0, firstDayOfMonth, lastDayOfMonth, 0);

            var daoParametro = new ParametroWS();
            ViewBag.ListaEstado = daoParametro.Listar((int)ConstantesBE.Dominio.EstadoOrdenCompra);



            return View(lista);
        }

        //
        // GET: /GuiaRemision/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /GuiaRemision/Create
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult GuardarGuia(OrdenCompraBE orden, string DireccionOrigen, string DireccionDestino, string Articulos, int IdEstablecimiento, string FechaTraslado)
        {
            try
            {
                //var order = orden.ToObject<OrdenCompraBE>();
                var ordenws = new GuiaRemisionWS();
                List<ArticuloBE> articulos = new JavaScriptSerializer().Deserialize<List<ArticuloBE>>(Articulos);
                orden.IdProveedor = ((UserBE)Session["Usuario"]).EmpleadoId;
                orden.IdEstablecimiento = IdEstablecimiento;
                orden.Articulos = articulos;
                orden.SubTotal = articulos.Sum(t => t.SubTotal);
                orden.IGV = 0;
                orden.Total = orden.SubTotal;

                var guia = new GuiaRemisionBE()
                {
                    DireccionOrigen = DireccionOrigen,
                    DireccionDestino = DireccionDestino,
                    FechaTraslado = DateTime.Parse(FechaTraslado)
                };

                ordenws.Insertar(orden, guia);

                // TODO: Add insert logic here

                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
        }

        public CrystalReportPdfResult Imprimir(int IdGuia)
        {
            ReportDocument rd = new ReportDocument();
            var GuiaWS = new GuiaRemisionWS();
            var guias = GuiaWS.ImprimirGuia(IdGuia);
            string reportPath = Path.Combine(Server.MapPath("~/Reports/ReportGuiaRemision.rpt"));
            return new CrystalReportPdfResult(reportPath, guias);

        }




        [HttpGet]
        public ActionResult CargarProducto(int IdArticulo)
        {
            var ArticuloWS = new ArticuloWS();
            int IdProveedor = ((UserBE)Session["usuario"]).EmpleadoId;
            var articulo = ArticuloWS.ObtenerporProveedor(IdProveedor, IdArticulo);

            return Json(articulo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CargarProveedor(int IdProveedor)
        {
            var ProveedorWS = new ProveedorWS();
            var Proveedor = ProveedorWS.Obtener(IdProveedor);
            return Json(Proveedor, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Buscar(string RazonSocial, int Estado, string FechaInicio, string FechaFin)
        {
            var daoOrden = new OrdenCompraWS();
            DateTime Fechaf = DateTime.Parse(FechaFin).AddDays(1);
            UserBE usuario = ((UserBE)Session["Usuario"]);
            int IdEstablecimiento = 0;
            if (usuario.Rol.RolId == (int)ConstantesBE.Rol.Establecimiento)
            {
                IdEstablecimiento = usuario.EmpleadoId;
            }
            var lista = daoOrden.Listar(RazonSocial, Estado, DateTime.Parse(FechaInicio), Fechaf, IdEstablecimiento);
            var daoParametro = new ParametroWS();
            ViewBag.ListaEstado = daoParametro.Listar((int)ConstantesBE.Dominio.EstadoOrdenCompra);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }



        //
        // POST: /GuiaRemision/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GuiaRemision/Edit/5
        public ActionResult Edit(int id)
        {
            var ordenWS = new OrdenCompraWS();
            var ordenCompra = ordenWS.Obtener(id);

            var articulo = new ArticuloWS();
            ViewBag.Articulos = articulo.Listar();

            var usuario = ((UserBE)Session["Usuario"]);
            var proveedor = new ProveedorWS().Obtener(usuario.EmpleadoId);
            ViewBag.RazonSocial = proveedor.RazonSocial;
            ViewBag.Direccion = proveedor.Direccion;
            ViewBag.IdEstablecimiento = ordenCompra.Establecimiento.IdEstablecimiento;
            ViewBag.IdOrdenCompra = ordenCompra.IdOrdenCompra;
            ViewBag.Estado = ordenCompra.Estado;
            var ordendetalleWS = new OrdenCompraArticuloWS();
            ViewBag.Detalle = JsonConvert.SerializeObject(ordendetalleWS.ObtenerporOrden(id));

            ViewBag.IdGuia = 0;
            if (ordenCompra.Estado == (int)ConstantesBE.EstadoOrden.Aprobada
                || ordenCompra.Estado == (int)ConstantesBE.EstadoOrden.Atendida)
            {
                var guiaremisionWS = new GuiaRemisionWS();
                var guiabe = guiaremisionWS.ObtenerporOrden(id);
                ViewBag.IdGuia = guiabe.IdGuiaRemision;
            }


            return View(ordenCompra);
        }

        //
        // POST: /GuiaRemision/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GuiaRemision/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GuiaRemision/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
