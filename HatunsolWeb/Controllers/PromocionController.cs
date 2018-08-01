using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatunsolWS;
using HatunsolBE;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
namespace HatunsolWeb.Controllers
{
    public class PromocionController : Controller
    {
        //
        // GET: /Prmocion/
        public ActionResult Index()
        {

            ViewBag.ListaEstado = new ParametroWS().Listar((int)ConstantesBE.Dominio.EstadoPromocion);
            var Lista = new PromocionWS().Listar("");
            return View(Lista);
        }

        //
        // GET: /Prmocion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Prmocion/Create
        public ActionResult Create()
        {
            string FechaInicio = "01/11/2016";
            string FechaFin = "14/11/2016";
            int IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
            CargarArticulosBajaRotacion(FechaInicio,FechaFin,IdEstablecimiento);
            ViewBag.Estados = new ParametroWS().Listar((int)ConstantesBE.Dominio.EstadoPromocion);
            return View();
        }


        public void CargarArticulosBajaRotacion(string FechaInicio,string FechaFin,int IdEstablecimiento)
        {
            ViewBag.Articulos = JsonConvert.SerializeObject(new ArticuloWS().ArticulosBajaRotacion(FechaInicio, FechaFin, IdEstablecimiento)); ;
        }

        [HttpPost]
        public ActionResult GuardarPromocion(string Nombre, string Descripcion,string FechaInicio,string FechaFin,string Articulos)
        {
            try
            {
                //var order = orden.ToObject<OrdenCompraBE>();
                var promocionws = new PromocionWS();
                List<ArticuloBE> articulos = new JavaScriptSerializer().Deserialize<List<ArticuloBE>>(Articulos);
                var promocion = new PromocionBE();
                promocion.IdEstablecimiento = ((UserBE)Session["Usuario"]).EmpleadoId;
                promocion.Articulos = articulos;
                promocion.Nombre = Nombre;
                promocion.Descripcion = Descripcion;
                promocion.FechaInicio = DateTime.Parse(FechaInicio);
                promocion.FechaFin = DateTime.Parse(FechaFin);
                promocionws.Insertar(promocion);

                // TODO: Add insert logic here

                return Json(new { success = true });
            }
            catch
            {
                return View();
            }
        }
    

    

        //
        // POST: /Prmocion/Create
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
        // GET: /Prmocion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Prmocion/Edit/5
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
        // GET: /Prmocion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Prmocion/Delete/5
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
