using SistemaRestaurante.DAO;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            MesasDAO dao = new MesasDAO();
            IList<Mesa> mesas = dao.Listar();
            ViewBag.Mesas = mesas;
            return View(ViewBag);
        }
    }
}