using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutedParam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            ViewBag.contador = id;
            return View();
        }

        /// <summary>
        /// Redireccionamos a Index con un routedData contador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost (int? id)
        {
            int contador = 1;

            if (id!=null)
            {
                contador = (int)id + 1;
            }
            return RedirectToAction("Index", new { id = contador }); //{ id = contador } es un parámetro de ruta
        }
    }
}