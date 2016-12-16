using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sessions.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string boton, string txtNombre)
        {
            switch (boton)
            {
                case ("+1"):
                    Session["contador"] = Convert.ToInt32(Session["contador"]) + 1;
                    break;
                case ("Entrar"):
                    Session["usuario"] = txtNombre;
                    break;
                case ("Cerrar Sesión"):
                    Session.Clear();
                    Session.Abandon();
                    break;
            }

            return View();
        }

    } //Fin HomeController:Controller
}