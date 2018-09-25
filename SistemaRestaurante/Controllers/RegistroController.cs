using SistemaRestaurante.DAO;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class RegistroController : Controller
    {
        [Route("Registro", Name = "ViewRegistros")]
        public ActionResult Index()
        {
            MesasDAO dao = new MesasDAO();
            UsuarioDAO userDao = new UsuarioDAO();
            ComandaDAO comandaDao = new ComandaDAO();
            ProdutoDAO prodDao = new ProdutoDAO();
            CartaoDAO cartDAO = new CartaoDAO();
            IList<Mesa> mesas = dao.Listar().OrderBy(m => m.Numero).ToList();
            ViewBag.Mesas = mesas;
            ViewBag.Usuarios = userDao.Listar();
            ViewBag.Comandas = comandaDao.Listar().OrderBy(c => c.Numero).ToList();
            ViewBag.Cartoes = cartDAO.Listar().OrderBy(ca => ca.NumeroCartao).ToList();
            return View();
        }

        [Route("AdicionaMesa")]
        public ActionResult AdicionaMesa(int numeroMesa)
        {
            MesasDAO dao = new MesasDAO();
            if(dao.BuscaPorNumero(numeroMesa) != null)
            {
                return Json(new { success = false, resposta = "Mesa Já existe" }, JsonRequestBehavior.AllowGet);
            }
            if (numeroMesa <= 0)
            {
                return Json(new { success = false, resposta = "Mesa não pode ser negativa" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
            dao.Adiciona(new Mesa(numeroMesa));
            return Json(new { success = true , Mesa = dao.BuscaPorNumero(numeroMesa) }, JsonRequestBehavior.AllowGet);
            }

        }

        [Route("RemoveMesa")]
        public ActionResult RemoverMesa(int numeroMesa)
        {
            MesasDAO dao = new MesasDAO();
            dao.Excluir(numeroMesa);
            return Json(numeroMesa);
        }

        [Route("AdicionaComanda")]
        public ActionResult AdicionaComanda(int numeroComanda)
        {
            ComandaDAO dao = new ComandaDAO();
            if (dao.BuscaPorNumero(numeroComanda) != null)
            {
                return Json(new { success = false, resposta = "Comanda Já existe" }, JsonRequestBehavior.AllowGet);
            }
            if (numeroComanda <= 0)
            {
                return Json(new { success = false, resposta = "Comanda não pode ser negativa" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dao.Adiciona(new Comanda(numeroComanda));
                return Json(new { success = true, Comanda = dao.BuscaPorNumero(numeroComanda) }, JsonRequestBehavior.AllowGet);
            }

        }

        [Route("RemoveComanda")]
        public ActionResult RemoverComanda(int numeroComanda)
        {
            ComandaDAO dao = new ComandaDAO();
            dao.Excluir(numeroComanda);
            return Json(numeroComanda);
        }

        [Route("AdicionaCartao")]
        public ActionResult AdicionaCartao(string nomeCliente,int numeroCartao)
        {
            
            CartaoDAO dao = new CartaoDAO();
            if (dao.BuscaPorNumero(numeroCartao) != null)
            {
                return Json(new { success = false, resposta = "Numero do cartão já existe" }, JsonRequestBehavior.AllowGet);
            }
            if (numeroCartao <= 0)
            {
                return Json(new { success = false, resposta = "Numero do cartão não pode ser negativo" }, JsonRequestBehavior.AllowGet);
            }
            if (dao.BuscaPorNome(nomeCliente) != null)
            {
                return Json(new { success = false, resposta = "Cliente já possui cadastro" }, JsonRequestBehavior.AllowGet);
            }
            if (!Regex.IsMatch(nomeCliente , @"^[a-zA-Z\s]+$"))
            {
                return Json(new { success = false, resposta = "Nome Invalido" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dao.Adiciona(new Cartao(numeroCartao,nomeCliente));
                return Json(new { success = true, Cartao = dao.BuscaPorNumero(numeroCartao) }, JsonRequestBehavior.AllowGet);
            }

        }

        [Route("RemoveCartao")]
        public ActionResult RemoverCartao(int numeroCartao)
        {
            CartaoDAO dao = new CartaoDAO();
            dao.Excluir(numeroCartao);
            return Json(numeroCartao);
        }



    }
}