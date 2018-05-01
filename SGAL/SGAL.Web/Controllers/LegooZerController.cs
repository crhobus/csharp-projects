using SGAL.AcessoDados;
using SGAL.Dominio;
using SGAL.Web.Filters;
using SGAL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGAL.Web.Controllers
{
    public class LegooZerController : Controller
    {
        private SGALContext sgalContext;
        private RepositorioLegooZer repositorioLegooZer;

        public LegooZerController()
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

        public ActionResult Index()
        {
            var legoozers = from l in repositorioLegooZer.Recuperar()
                                //where l.LegooZerID > 7
                            orderby l.Nome
                            select l;

            return View(legoozers);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var legoozerParaEditar = repositorioLegooZer.Recuperar(id);
            return View(legoozerParaEditar);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var legoozerParaEditar = repositorioLegooZer.Recuperar(id);
            if (TryUpdateModel(legoozerParaEditar))
            {
                repositorioLegooZer.Atualizar(legoozerParaEditar);
                repositorioLegooZer.Salvar();
                return RedirectToAction("Index");
            }
            return View(legoozerParaEditar);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new LegooZer());
        }

        [HttpPost]
        public ActionResult Create(LegooZer legoozer)
        {
            if (ModelState.IsValid)
            {
                repositorioLegooZer.Inserir(legoozer);
                repositorioLegooZer.Salvar();
                return RedirectToAction("Index");
            }
            return View(legoozer);
        }
        
    }
}