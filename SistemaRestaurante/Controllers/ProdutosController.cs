using SistemaRestaurante.DAO;
using SistemaRestaurante.Filters;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            
            return View();
        }

        [Route("AdicionaProduto")]
        public ActionResult Adiciona(string nomeProduto,string precoProduto,string descricao)
        {
            ProdutoDAO dao = new ProdutoDAO();
            var preco = Convert.ToDouble(precoProduto);
            if (dao.BuscaPorNome(nomeProduto) != null)
            {
                return Json(new { success = false, resposta = "Produto com esse nome ja existe" }, JsonRequestBehavior.AllowGet);
            }
            if (preco <= 0)
            {
                return Json(new { success = false, resposta = "Preço não pode ser menor do que 0" }, JsonRequestBehavior.AllowGet);
            }
            if (!Regex.IsMatch(precoProduto, @"^[0-9]{1,3}([.,][0-9]{1,2})?$"))
            {
                return Json(new { success = false, resposta = "Preço invalido" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dao.Adiciona(new Produto(nomeProduto, preco, descricao, false));
                return Json(new { success = true, Produto = dao.BuscaPorNome(nomeProduto) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("RemoveProduto")]
        public ActionResult Remove(string nomeProduto)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorNome(nomeProduto);
            dao.Excluir(produto);
            return Json(new { success = true, resposta = "Produto removido com sucesso" }, JsonRequestBehavior.AllowGet);
        }

        
    }

    
}