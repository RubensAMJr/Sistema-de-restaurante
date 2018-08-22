using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {

            return View();
        }

        public ActionResult Autentica(String login,String senha)
        {
            return RedirectToAction("Index","Home");
        }
    }
}