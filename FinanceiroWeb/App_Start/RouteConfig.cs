using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinanceiroWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Todas as Noticias",
                url:"noticias/",
                defaults: new { controller = "Home", action = "TodasAsNoticias"}

                );

            routes.MapRoute(
               name: "Categoria Especificas",
               url: "noticias/{categoria}/",
               defaults: new { controller = "Home", action = "MostrarCategoria", }

               );

            routes.MapRoute(
               name: "Mostra Noticia",
               url: "noticias/{categoria}/{titulo}-{noticiaId}",
               defaults: new { controller = "Home", action = "MostrarNoticia", }

               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate"},
                new { year = @"\d{4}", moth= @"\d{2}"}
                );
        }
    }
}
