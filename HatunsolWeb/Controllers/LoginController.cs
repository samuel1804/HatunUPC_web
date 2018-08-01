using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HatunsolBE;
using HatunsolWS;
using System.Web.Security;
namespace HatunsolWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
         [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Login/Details/5
        public ActionResult Details(int id)
        {
            return View();

        }

       
     


        [HttpPost]
        public ActionResult Index(UserBE UserBE)
        {
            var db = new UserWS();
            var UsuarioBe = db.ObtenerUsuario(UserBE.UserLogin);

            if (UsuarioBe == null)
            {
                ModelState.AddModelError("", "El Usuario no Existe");
                return View(UserBE);
            }
            else if (UsuarioBe.UserPassword.Equals(UserBE.UserPassword))
            {

                FormsAuthentication.SetAuthCookie(UserBE.UserLogin, true);
                Session["Usuario"] = UsuarioBe; 
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Usuario o Contraseña Incorrectos");
                return View(UserBE);
            }
        }
     
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        //
        // GET: /Login/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create
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
        // GET: /Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Login/Edit/5
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
        // GET: /Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Login/Delete/5
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
