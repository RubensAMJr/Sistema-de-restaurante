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

        [Route("AdicionaComanda")]
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
                
                return Json(new { success = false, resposta = "Comanda não existe" }, JsonRequestBehavior.AllowGet);
            }
        }
    }


}