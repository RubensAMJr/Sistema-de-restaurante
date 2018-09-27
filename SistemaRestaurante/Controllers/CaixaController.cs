using SistemaRestaurante.Filters;
using SistemaRestaurante.Models;
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
            Usuario user = (Usuario)Session["Admin"];
            if (user.Cargo.Equals("CAIXA") || user.Cargo.Equals("GERENTE"))
            {
                return View();
            }
            else
            {
                return RedirectToRoute("Sair");
            }
        }
    }
}