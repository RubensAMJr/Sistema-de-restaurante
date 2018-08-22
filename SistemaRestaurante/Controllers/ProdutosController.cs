using SistemaRestaurante.DAO;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> lista = dao.Listar();
            ViewBag.Produtos = lista;
            return View(ViewBag);
        }
    }
}