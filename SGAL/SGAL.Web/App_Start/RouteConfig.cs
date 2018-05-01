using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SGAL.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "LocalizarLegoozer",
                url: "legoozer/{nome}",
                defaults: new { controller = "legoozer", action = "localizar", nome = "" });

            routes.MapRoute(
                name: "Calendario",
                url: "calendario/{ano}/{numSemana}",
                defaults: new { controller = "CalendarioUtils", action = "NumeroDaSemana", ano = "", numSemana = "" });

            routes.MapRoute(
                name: "CalendarioFormato",
                url: "calendarioformato/{ano}/{numSemana}/{formato}",
                defaults: new { controller = "CalendarioUtils", action = "NumeroDaSemanaFormato", ano = "", numSemana = "", formato = "" });*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
