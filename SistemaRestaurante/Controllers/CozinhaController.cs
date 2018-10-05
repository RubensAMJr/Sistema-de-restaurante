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
    public class CozinhaController : Controller
    {
        [Route("Cozinha", Name ="ViewCozinha")]
        public ActionResult Index()
        {
            ItemPedidoDAO dao = new ItemPedidoDAO();
            IList<ItemPedido> pedidos = dao.ListarNaoEntregues(); 
            ViewBag.Pedidos = pedidos;
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

        [Route("RemoveItem")]
        public ActionResult Deleta(int pedidoId)
        {
            ItemPedidoDAO dao = new ItemPedidoDAO();
            ItemPedido item = dao.BuscaPorId(pedidoId);
            Pedido pedido = new PedidoDAO().BuscaPorId(pedidoId);
            Comanda comanda = new ComandaDAO().BuscaPorId((int)pedido.ComandaId);
            Mesa mesa = new MesasDAO().BuscaPorId((int)comanda.MesaId);
            item.Entregue = true;
            dao.Atualizar(item);
            return Json(new { success = true,resposta = "Pedido finalizado com sucesso",Comanda = comanda.Numero,Mesa = mesa.Numero},JsonRequestBehavior.AllowGet);
        }
    }
}