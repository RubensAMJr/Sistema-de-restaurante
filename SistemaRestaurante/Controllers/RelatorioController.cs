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

        [Route("ViewItensNumero")]
        public ActionResult RelatorioNumero()
        {
            IList<Produto> produtos = new ProdutoDAO().Listar().OrderByDescending(p => p.numeroVendas).ToList();
            return Json(new {success = true, Produtos = produtos},JsonRequestBehavior.AllowGet);
        }

        [Route("ViewGarcons")]
        public ActionResult RelatorioGarcom()
        {
            IList<Usuario> garcons = new UsuarioDAO().Listar().OrderByDescending(g => g.NumeroPedidos).ToList();
            return Json(new { success = true, Garcom = garcons }, JsonRequestBehavior.AllowGet);
        }
    }
}