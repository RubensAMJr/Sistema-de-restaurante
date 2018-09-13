using SistemaRestaurante.DAO;
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
    public class HomeController : Controller
    {
        
        [Route("Mesas",Name ="ViewMesa")]
        public ActionResult Index()
        {
            MesasDAO dao = new MesasDAO();
            IList<Mesa> mesas = dao.Listar().OrderBy(m => m.Numero).ToList();
            ViewBag.Mesas = mesas;
            return View(ViewBag);
        }

        
    }
}