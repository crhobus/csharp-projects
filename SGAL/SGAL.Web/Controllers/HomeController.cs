using SGAL.Dominio;
using SGAL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGAL.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var condicaoTempo = new CondicaoTempo();
            condicaoTempo.Situacao = "Nublado";
            condicaoTempo.Data = DateTime.Now;
            condicaoTempo.Codigo = 1000;

            return View(condicaoTempo);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LegooZer()
        {
            var legoozer = new LegooZer()
            {
                Nome = "Mad",
                SobreNome = "Max",
                EnderecoEmail = "mad@max.com"
            };

            return View(legoozer);
        }
    }
}