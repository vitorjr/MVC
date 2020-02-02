using FinanceiroWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> todasAsNoticias;

        public HomeController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }

        public ActionResult Index()
        {
            var ultimasNoticias = todasAsNoticias.Take(3);
            var todasAscategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();
            ViewBag.Categorias = todasAscategorias;
            return View(ultimasNoticias);
        }

        public ActionResult MostrarNoticia(int noticiaId, string titulo, string categoria)
        {
            return View(todasAsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaId));
        }

        public ActionResult TodasAsNoticias()
        {
            return View(todasAsNoticias); 
        }

        public ActionResult MostrarCategoria(string categoria)
        {
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categoria = categoria;
            return View(categoriaEspecifica);
        }
       
        /*
        [HttpPost]
        public ActionResult AdicionarDespesa()
        {
            var despesa = new Despesas {

            };

            ViewData["nome_depesa"] = 
            return View();
        }
        */
    }
}