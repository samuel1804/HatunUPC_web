using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatunsolBE;
using HatunsolWS;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
namespace HatunsolWeb.Controllers
{
    public class OrdenCompraController : Controller
    {
        //
        // GET: /OrdenCompra/
        public ActionResult Index()
        {
            var daoOrden = new OrdenCompraWS();
            UserBE usuario=((UserBE) Session["Usuario"]);
            int IdEstablecimiento=0;
            if(usuario.Rol.RolId==(int)ConstantesBE.Rol.Establecimiento){
            IdEstablecimiento=usuario.EmpleadoId;
            }
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1);
            var lista = daoOrden.Listar("", 0, firstDayOfMonth, lastDayOfMonth, IdEstablecimiento);

            var daoParametro = new ParametroWS();
            ViewBag.ListaEstado = daoParametro.Listar((int)ConstantesBE.Dominio.EstadoOrdenCompra);



            return View(lista);
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
            var lista = daoOrden.Listar(RazonSocial, Estado, DateTime.Parse(FechaInicio), Fechaf,IdEstablecimiento);
            var daoParametro = new ParametroWS();
            ViewBag.ListaEstado = daoParametro.Listar((int)ConstantesBE.Dominio.EstadoOrdenCompra);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }



        //
        // GET: /OrdenCompra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /OrdenCompra/Create

        public ActionResult Create(int? IdOrden)
        {
            var db = new ProveedorWS();
            ViewBag.Proveedores = db.Listar();
            var articulo = new ArticuloWS();
            ViewBag.Articulos = articulo.Listar();
            int IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
            var OrdenCompra = new OrdenCompraBE();
            var EstablecimientoWS = new EstablecimientoWS();
            OrdenCompra.Establecimiento = EstablecimientoWS.Obtener(IdEstablecimiento);
            Session["detalle"] = null;

            if (IdOrden != null)
            {
                OrdenCompra = new OrdenCompraWS().Obtener((int)IdOrden);
            }
            else
            {
                OrdenCompra.Proveedor = new ProveedorBE()
                {
                    IdProveedor = 0,
                    RUC = "",
                    RazonSocial = ""
                };
            }
            //var detalle = (List<ArticuloBE>)Session["detalle"];
            //OrdenCompraBE orden = new OrdenCompraBE();
            return View(OrdenCompra);
        }

        [HttpPost]
        public ActionResult Guardar(OrdenCompraBE ordenCompraBE)
        {
            return null;
        }

        [HttpGet]
        public ActionResult CargarProducto(int IdProveedor, int IdArticulo)
        {
            var ArticuloWS = new ArticuloWS();
            var articulo = ArticuloWS.ObtenerporProveedor(IdProveedor, IdArticulo);

            return Json(articulo, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult EditarItem(ArticuloBE articulo)
        {
            var detalle = (List<ArticuloBE>)Session["detalle"];
            if (detalle == null)
            {
                detalle = new List<ArticuloBE>();
            }
            var art = detalle.Where(t => t.IdArticulo == articulo.IdArticulo).FirstOrDefault();
            art.Cantidad = articulo.Cantidad;
            art.Costo = articulo.Costo;
            art.SubTotal = articulo.SubTotal;
            Session["detalle"] = detalle;

            return Json(articulo);
        }


        [HttpPost]
        public JsonResult Agregar(ArticuloBE articulo)
        {
            var detalle = (List<ArticuloBE>)Session["detalle"];
            if (detalle == null)
            {
                detalle = new List<ArticuloBE>();
            }
            detalle.Add(articulo);
            Session["detalle"] = detalle;

            return Json(articulo);
        }
        public ActionResult _GridArticulos()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CargarProveedor(int IdProveedor)
        {
            var ProveedorWS = new ProveedorWS();
            var Proveedor = ProveedorWS.Obtener(IdProveedor);
            return Json(Proveedor, JsonRequestBehavior.AllowGet);
        }



        //
        // POST: /OrdenCompra/Create

        public CrystalReportPdfResult Imprimir(int IdOrden)
        {
            ReportDocument rd = new ReportDocument();
            var ordencompraWS = new OrdenCompraWS();
            var guias = ordencompraWS.Imprimir(7);
            string reportPath = Path.Combine(Server.MapPath("~/Reports/ReportOrdenCompra.rpt"));
            return new CrystalReportPdfResult(reportPath, guias);
        }


        [HttpPost]
        public ActionResult GuardarOrden(OrdenCompraBE orden, string Direccion, string Articulos)
        {
            try
            {
                //var order = orden.ToObject<OrdenCompraBE>();
                var ordenws = new OrdenCompraWS();
                List<ArticuloBE> articulos = new JavaScriptSerializer().Deserialize<List<ArticuloBE>>(Articulos);
                orden.IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
                orden.Articulos = articulos;
                orden.SubTotal = articulos.Sum(t => t.SubTotal);
                orden.IGV = 0;
                orden.Total = orden.SubTotal;
                ordenws.Insertar(orden);
            
                // TODO: Add insert logic here

                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrdenCompra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /OrdenCompra/Edit/5
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
        // GET: /OrdenCompra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OrdenCompra/Delete/5
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
