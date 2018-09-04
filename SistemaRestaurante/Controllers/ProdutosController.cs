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
    public class ProdutosController : Controller
    {
        [Route("Produtos",Name ="ViewProdutos")]
        public ActionResult Index()
        {
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> lista = dao.Listar();
            ViewBag.Produtos = lista;
            return View(ViewBag);
        }
    }
}