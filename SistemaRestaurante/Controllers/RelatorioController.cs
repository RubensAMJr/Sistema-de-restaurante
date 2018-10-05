using SistemaRestaurante.DAO;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class RelatorioController : Controller
    {
        [Route("Relatorio", Name = "ViewRelatorio")]
        public ActionResult Relatorio()
        {
            return View();
        }

    }
}