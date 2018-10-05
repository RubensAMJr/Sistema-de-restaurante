using SistemaRestaurante.DAO;
using SistemaRestaurante.Filters;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaRestaurante.Controllers
{
    public class LoginController : Controller
    {
        [Route("Login", Name ="TelaLogin")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Registra",Name ="TelaRegistro")]
        [AutorizacacoFilter()]
        public ActionResult Registrar()
        {

            return View();
        }

        [Route("Autentica")]
        public ActionResult Autentica(String usuario,String senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario user = dao.Busca(usuario, senha);
            if (user != null)
            {
                Session["Admin"] = user;
                if (user.Cargo.Equals("GARCOM"))
                {
                    return RedirectToAction("Index", "Home");
                }else if (user.Cargo.Equals("COZINHEIRO"))
                {
                    return RedirectToAction("Index", "Cozinha");
                }
                else if(user.Cargo.Equals("CAIXA"))
                {
                    return RedirectToAction("Index", "Caixa");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("LogOut", Name = "Sair")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction("Index");
        }

        [Route("NovoUsuario")]
        public ActionResult NovoUsuario(string cargo,string nome,string usuario,string senha)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario user = dao.Busca(usuario, senha);
            if (user == null)
            {
                user = new Usuario(cargo,nome,usuario,senha);
                dao.Adiciona(user);
                return Json(new { sucess = true, resposta = "Usuario cadastrado com sucesso"},JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { sucess = false, resposta = "Usuario já existe" }, JsonRequestBehavior.AllowGet);
            }

        }

        [Route("RemoveUsuario")]
        public ActionResult Remove(string Nome)
        {

            UsuarioDAO dao = new UsuarioDAO();
            if (dao.BuscaPorNome(Nome) != null)
            {
                dao.ExcluirPorNome(Nome);
                return Json(new { success = true , resposta = "Usuario removido"});
            }
            else
            {
                return Json(new { success = false, resposta = "Erro ao remover usuario" });
            }
        }
    }

}
