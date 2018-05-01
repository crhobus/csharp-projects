using SGAL.AcessoDados;
using SGAL.Dominio;
using SGAL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGAL.Web.Controllers
{
    public class EnderecosLegooZerController : Controller
    {

        private SGALContext sgalContext;
        private RepositorioLegooZer repositorioLegooZer;

        public EnderecosLegooZerController()
        {
            sgalContext = new SGALContext();
            repositorioLegooZer = new RepositorioLegooZer(sgalContext);
        }

        protected override void Dispose(bool disposing)
        {
            repositorioLegooZer.Dispose();
            sgalContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index(int idLegoozer)
        {
            var legoozer = repositorioLegooZer.Recuperar(idLegoozer);
            ViewBag.LegooZer = legoozer;
            return View(legoozer.Enderecos);
        }

        [HttpGet]
        public ActionResult Edit(int idLegoozer, int idEndereco)
        {
            var legoozer = repositorioLegooZer.Recuperar(idLegoozer);
            var endereco = legoozer.Enderecos.SingleOrDefault(e => e.EnderecoID == idEndereco);
            ViewBag.LegooZer = legoozer;
            return View(endereco);
        }

        [HttpPost]
        public ActionResult Edit(int idLegoozer, int idEndereco, FormCollection collection)
        {
            var legoozer = repositorioLegooZer.Recuperar(idLegoozer);
            var endereco = legoozer.Enderecos.SingleOrDefault(e => e.EnderecoID == idEndereco);
            ViewBag.LegooZer = legoozer;
            if (TryUpdateModel(endereco))
            {
                repositorioLegooZer.Atualizar(legoozer);
                repositorioLegooZer.Salvar();
                return RedirectToAction("Index", new { idLegoozer = idLegoozer });
            }
            return View(endereco);
        }

        [HttpGet]
        public ActionResult Create(int idLegoozer)
        {
            var legoozer = repositorioLegooZer.Recuperar(idLegoozer);
            ViewBag.LegooZer = legoozer;
            var novoEndereco = new Endereco();
            return View(novoEndereco);
        }

        [HttpPost]
        public ActionResult Create(int idLegoozer, Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                var legoozer = repositorioLegooZer.Recuperar(idLegoozer);
                legoozer.Enderecos.Add(endereco);
                repositorioLegooZer.Atualizar(legoozer);
                repositorioLegooZer.Salvar();
                return RedirectToAction("Index", new { idLegoozer = idLegoozer });
            }
            return View(endereco);
        }
    }
}