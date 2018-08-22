using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class CozinhaController : Controller
    {
        // GET: Cozinha
        public ActionResult Index()
        {
            return View();
        }
    }
}