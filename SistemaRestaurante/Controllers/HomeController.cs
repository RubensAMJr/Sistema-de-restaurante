using SistemaRestaurante.DAO;
using SistemaRestaurante.Filters;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    [AutorizacacoFilter]
    public class HomeController : Controller
    {
        [Route("Mesas", Name = "ViewMesa")]
        public ActionResult Index()
        {
            MesasDAO dao = new MesasDAO();
            IList<Mesa> mesas = dao.Listar().OrderBy(m => m.Numero).ToList();
            ViewBag.Mesas = mesas;
            Usuario user = (Usuario)Session["Admin"];
            if (user.Cargo.Equals("GARCOM") || user.Cargo.Equals("GERENTE"))
            {
                return View();
            }
            else
            {
                return RedirectToRoute("Sair");
            }
        }
            
        

        [Route("BuscaComandas")]
        public ActionResult Busca(int mesaId)
        {
            ItemPedidoDAO itemDao = new ItemPedidoDAO();
            ComandaDAO dao = new ComandaDAO();
            IList<Comanda> comandas = dao.ListarPorMesa(mesaId);
            IList<Comanda> comandasTotal = dao.ListarSemMesa();
            if (comandas.Count == 0)
            {
                return Json(new { success = false, resposta = "Mesa não possui comandas" , ComandasTotal = comandasTotal }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, Comandas = comandas , ComandasTotal = comandasTotal }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("AddComanda")]
        public ActionResult Adiciona(int mesaId,int comandaId,int userId)
        {
            PedidoDAO daoPedido = new PedidoDAO();
            ComandaDAO daoComanda = new ComandaDAO();
            Comanda comanda = daoComanda.BuscaPorId(comandaId);
            if (comanda == null)
            {
                return Json(new { success = false, resposta = "Comanda não existe"},JsonRequestBehavior.AllowGet);
            }
            else
            {
                MesasDAO dao = new MesasDAO();
                Mesa mesa = dao.BuscaPorId(mesaId);
                mesa.Ocupada = true;
                dao.Atualizar(mesa);
                Pedido pedido = new Pedido();
                comanda.MesaId = mesaId;
                comanda.Pedido = pedido;
                daoComanda.Atualizar(comanda);
                return Json(new { success = true, resposta = "Comanda Acidionada com sucesso" }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("BuscaProduto")]
        public ActionResult BuscaProduto()
        {
            ProdutoDAO dao = new ProdutoDAO();
            return Json(new { success = true, Produtos = dao.Listar()});
        }

        [Route("ExcluiComanda")]
        public ActionResult ExcluiComanda(int comandaId,int mesaId)
        {
            ComandaDAO dao = new ComandaDAO();
            PedidoDAO pedidoDao = new PedidoDAO();
            Pedido pedido = pedidoDao.BuscaPorComanda(comandaId);
            pedidoDao.Excluir(pedido);
            Comanda comanda = dao.BuscaPorId(comandaId);
            comanda.MesaId = null;
            dao.Atualizar(comanda);
            if (dao.ListarPorMesa(mesaId).Count == 0)
            {
                MesasDAO mesaDao = new MesasDAO();
                Mesa mesa = mesaDao.BuscaPorId(mesaId);
                mesa.Ocupada = false;
                mesaDao.Atualizar(mesa);
            }

            return Json(new { success = true, resposta = "comanda removida com sucesso" });

        }

        [Route("FinalizaPedido")]
        public ActionResult Finaliza(int comandaId,string observacao,int quantidade,int produtoId,int usuarioId)
        {
            UsuarioDAO userDao = new UsuarioDAO();
           ItemPedidoDAO itemDao = new ItemPedidoDAO();
           PedidoDAO pedidoDao = new PedidoDAO();
           ProdutoDAO produtoDao = new ProdutoDAO();
           Pedido pedido = pedidoDao.BuscaPorComanda(comandaId);
           Produto produto = produtoDao.BuscaPorId(produtoId);
            Usuario user = userDao.BuscaPorId(usuarioId);
           for (int i = 0; i <= quantidade -1; i++)
           {
                ItemPedido item = new ItemPedido();
                item.Entregue = false;
                item.Observacao = observacao;
                item.Produto = produto;
                pedido.Itens.Add(item);
                produto.numeroVendas++;
                user.NumeroPedidos++;

           }
            userDao.Atualizar(user);
            produtoDao.Atualizar(produto);
            pedidoDao.Atualizar(pedido);
            ItemPedido ultimo = itemDao.BuscaUltimo();
            return Json(new { success = true, Nome = produto.Nome, observacao, Entregue = false, ItemId = ultimo.Id, JsonRequestBehavior.AllowGet });
        }

        [Route("CarregaDados")]
        public ActionResult Carrega(int comandaId)
        {
            PedidoDAO dao = new PedidoDAO();
            ItemPedidoDAO itemDao = new ItemPedidoDAO();
            Pedido pedido = dao.BuscaPorComanda(comandaId);
            IList<ItemPedido> itens = itemDao.ListarPorPedido(pedido.Id);
            return Json(new { success = true, ItemPedido = itens }, JsonRequestBehavior.AllowGet);
        }

        [Route("ExcluiItem")]
        public ActionResult ExcluirPedido(int itemId,int comandaId)
        {
            ProdutoDAO prodDao = new ProdutoDAO();
            PedidoDAO pedDao = new PedidoDAO();
            Pedido pedido = pedDao.BuscaPorComanda(comandaId);
            ItemPedidoDAO dao = new ItemPedidoDAO();
            ItemPedido item = dao.BuscaPorIdComProduto(itemId);
            Produto produto = prodDao.BuscaPorId(item.Produto.Id);
            if (item == null)
            {
                return Json(new { success = false, resposta = "Item não existe" }, JsonRequestBehavior.AllowGet);
            }else if (item.Entregue == true)
            {
                return Json(new { success = false, resposta = "Item já foi entregue" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                produto.numeroVendas--;
                pedido.ValorTotal -= item.Produto.Preco;
                pedDao.Atualizar(pedido);
                dao.Excluir(item);
                prodDao.Atualizar(produto);
                return Json(new { success = true, resposta = "Item foi removido" }, JsonRequestBehavior.AllowGet);
            }
        }
    }


}