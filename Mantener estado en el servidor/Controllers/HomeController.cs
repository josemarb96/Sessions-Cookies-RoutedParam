using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Request siempre son peticiones

            //Si no existe, la creamos y la mandamos al navegador del cliente
            if (!Request.Cookies.AllKeys.Contains("contador"))
            {
                HttpCookie miCookie = new HttpCookie("contador", "0");
                miCookie.Expires = DateTime.Now.AddDays(7);

                //Se puede añadir la fecha de expiración
                Response.Cookies.Add(miCookie);

                //Mandamos un 0 por el viewBag
                ViewBag.contador = 0;
            }
            else
            {
                HttpCookie miCookie = Request.Cookies["contador"];
                int contador = Convert.ToInt32(miCookie.Value);

                //Aquí no sumamos porque no se aumenta
                ViewBag.contador = contador;
            }

            return View();
        }

        [HttpPost, ActionName("Index")]
        public ViewResult IndexPost()
        {
            HttpCookie miCookie = Request.Cookies["contador"];
            int contador = Convert.ToInt32(miCookie.Value);

            //Aumentamos el valor para pasarlo a la vista y meterlo en la cookie
            contador++;
            ViewBag.contador = contador;

            //Incrementar valor de la cookie en el navegador del usuario
            miCookie.Value = Convert.ToString(contador);

            //La cookie expira a los 7 días. Se puede añadir la fecha de expiración también
            miCookie.Expires = DateTime.Now.AddDays(7);

            //Esto quiere decir: añade una cookie al navegador del cliente
            Response.SetCookie(miCookie);

            return View();
        }

    } //Fin HomeController:Controller
}