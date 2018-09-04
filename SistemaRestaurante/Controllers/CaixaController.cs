using SistemaRestaurante.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    [AutorizacacoFilter]
    public class CaixaController : Controller
    {
        [Route("Caixa", Name ="ViewCaixa")]
        public ActionResult Index()
        {
            return View();
        }
    }
}