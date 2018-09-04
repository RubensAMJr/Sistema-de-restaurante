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

        [Route("AdicionaMesa")]
        public ActionResult AdicionaMesa(int numeroMesa)
        {
            MesasDAO dao = new MesasDAO();
            if (dao.BuscaPorNumero(numeroMesa) != null)
            {
                ModelState.AddModelError("mesaJaExiste","Mesa com esse numero já existe");
            }
            if (ModelState.IsValid)
            {
                dao.Adiciona(new Mesa(numeroMesa));
                return RedirectToRoute("ViewMesa");
            }
            else
            {
                return RedirectToRoute("ViewMesa");
            }
        }

        [Route("RemoveMesa")]
        public ActionResult RemoverMesa(int numeroMesa)
        {
            MesasDAO dao = new MesasDAO();
            if (dao.BuscaPorNumero(numeroMesa) == null)
            {
                ModelState.AddModelError("mesaNaoExiste", "Mesa com esse numero não existe");
            }
            if (ModelState.IsValid)
            {
                dao.Excluir(numeroMesa);
                return RedirectToRoute("ViewMesa");
            }
            else
            {
                return RedirectToRoute("ViewMesa");
            }
        }



    }
}