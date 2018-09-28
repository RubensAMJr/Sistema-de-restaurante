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
    public class CaixaController : Controller
    {
        [Route("Caixa", Name = "ViewCaixa")]
        public ActionResult Index()
        {
            Usuario user = (Usuario)Session["Admin"];
            if (user.Cargo.Equals("CAIXA") || user.Cargo.Equals("GERENTE"))
            {
                return View();
            }
            else
            {
                return RedirectToRoute("Sair");
            }
        }

        [Route("BuscaPedido")]
        public ActionResult BuscaPedido(int numeroComanda)
        {
            ComandaDAO comandaDAO = new ComandaDAO();
            PedidoDAO pedidoDao = new PedidoDAO();
            ItemPedidoDAO itemDao = new ItemPedidoDAO();
            Comanda comanda = comandaDAO.BuscaPorNumero(numeroComanda);
            Pedido pedido = pedidoDao.BuscaPorComanda(comanda.Id);
            IList<ItemPedido> itens = itemDao.ListarPorPedido(pedido.Id);
            return Json(new { success = true, ItemPedido = itens, Total = pedido.ValorTotal }, JsonRequestBehavior.AllowGet);
        }

        [Route("BuscaCartao")]
        public ActionResult BuscaCartao(int numeroCartao)
        {

        }
    }



}