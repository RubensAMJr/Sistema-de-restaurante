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
                Session["Admin"] = usuario;
                return RedirectToAction("Index", "Home");
            }
           else
           {
                return RedirectToAction("Index");
           }
        }

        [Route("LogOut", Name = "Sair")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction("Index");
        }

        //[Route("Cadastra", Name = "Cadastra")]
        //public ActionResult Cadastra(String Cargo,String Usuario,String Senha)
        //{
        //    UsuarioDAO dao = new UsuarioDAO();
            

        //}

    }

}
