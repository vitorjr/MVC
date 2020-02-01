using FinanceiroWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb.Controllers
{
    public class UsuarioController : Controller
    {
        
        // GET: Usuario
        public ActionResult Usuario()
        {
            var usuario = new Usuario();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Usuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome))
            {
                ModelState.AddModelError("Nome", "O campo nome está faltando");
            }

            if(usuario.Senha != usuario.ConfirmarSenha)
            {
                ModelState.AddModelError("", "O campo senha está diferente");
            }

            if (ModelState.IsValid)
            {
                return View("Resultado", usuario);
            }
            return View(usuario);
        }

        public ActionResult Resultado(Usuario usuario)
        {
            return View(usuario);
        }
    }
}