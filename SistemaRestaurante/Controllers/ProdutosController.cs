using SistemaRestaurante.DAO;
using SistemaRestaurante.Filters;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;

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
            Usuario user = (Usuario)Session["Admin"];
            if (user.Cargo.Equals("COZINHEIRO") || user.Cargo.Equals("GERENTE"))
            {
                return View();
            }
            else
            {
                return RedirectToRoute("Sair");
            }
        }

        [Route("AdicionaProduto")]
        public ActionResult Adiciona(string nomeProduto,string precoProduto,string descricao)
        {
            ProdutoDAO dao = new ProdutoDAO();
            var preco = Convert.ToDouble(precoProduto.Replace('.', ','));
            if (dao.BuscaPorNome(nomeProduto) != null)
            {
                return Json(new { success = false, resposta = "Produto com esse nome ja existe" }, JsonRequestBehavior.AllowGet);
            }
            if (preco <= 0)
            {
                return Json(new { success = false, resposta = "Preço não pode ser menor do que 0" }, JsonRequestBehavior.AllowGet);
            }
            if (!Regex.IsMatch(precoProduto, @"^[0-9]{1,3}([.,][0-9]{2})$"))
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

        [Route("AlteraProduto")]
        public ActionResult Altera(string nomeProduto)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorNome(nomeProduto);
            if (produto.EstaEmFalta == true)
            {
                produto.EstaEmFalta = false;
                dao.Atualizar(produto);
                return Json(new { success = true, resposta = "NAO" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                produto.EstaEmFalta = true;
                dao.Atualizar(produto);
                return Json(new { success = true, resposta = "SIM" }, JsonRequestBehavior.AllowGet);
            }
            
        }

        [Route("EditaProduto")]
        public ActionResult Edita(string nomeOriginal,string nomeEditado,string precoEditado,string descricaoEditada)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Debug.WriteLine(precoEditado);
            Produto produto = dao.BuscaPorNome(nomeOriginal);
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
            //var preco = Convert.ToDouble(precoEditado.Replace('.',','),);
            var preco = Convert.ToDouble(precoEditado, CultureInfo.InvariantCulture);
            Debug.WriteLine(preco);
            if (preco <= 0)
            {
                return Json(new { success = false, resposta = "Preço não pode ser menor do que 0" }, JsonRequestBehavior.AllowGet);
            }
            if (!Regex.IsMatch(precoEditado, @"^[0-9]{1,3}([.,][0-9]{2})$"))
            {
                return Json(new { success = false, resposta = "Preço invalido" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                produto.Nome = nomeEditado;
                produto.Preco = preco;
                produto.Descricao = descricaoEditada;
                dao.Atualizar(produto);
                return Json(new { success = true, Produto = produto , format = String.Format("{0:N}", produto.Preco) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("BuscaProdutos")]
        public ActionResult BuscaProdutos()
        {
            ProdutoDAO dao = new ProdutoDAO();
            return Json(new { data = dao.Listar() },JsonRequestBehavior.AllowGet);
        }
        
    }

    
}