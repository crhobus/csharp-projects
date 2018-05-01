using SGAL.AcessoDados;
using SGAL.Dominio;
using SGAL.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGAL.Web.Controllers
{
    public class MontagemController : Controller
    {
        private SGALContext sgalContext;
        private RepositorioMontagem repositorioMontagem;
        private RepositorioLegooZer repositorioLegooZer;

        public MontagemController()
        {
            sgalContext = new SGALContext();
            repositorioMontagem = new RepositorioMontagem(sgalContext);
            repositorioLegooZer = new RepositorioLegooZer(sgalContext);
        }

        protected override void Dispose(bool disposing)
        {
            repositorioMontagem.Dispose();
            repositorioLegooZer.Dispose();
            sgalContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var montagens = from l in repositorioMontagem.Recuperar()
                            orderby l.DescricaoPassoAPasso
                            select l;

            return View(montagens);
        }

        [HttpGet]
        public ActionResult Edit(int idMontagem)
        {
            var montagemParaEditar = repositorioMontagem.Recuperar(idMontagem);
            return View(new MontagemView(montagemParaEditar.MontagemID) { DescricaoPassoAPasso = montagemParaEditar.DescricaoPassoAPasso });
        }

        [HttpPost]
        public ActionResult Edit(int idMontagem, MontagemView montagemView)
        {
            var montagemParaEditar = repositorioMontagem.Recuperar(idMontagem);
            montagemParaEditar.DescricaoPassoAPasso = montagemView.DescricaoPassoAPasso;
            if (montagemView.ImagemFinal != null)
            {
                var binaryReader = new BinaryReader(montagemView.ImagemFinal.InputStream);
                montagemParaEditar.ByteArrayImage = binaryReader.ReadBytes(montagemView.ImagemFinal.ContentLength);
            }

            repositorioMontagem.Atualizar(montagemParaEditar);
            repositorioMontagem.Salvar();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var montagem = new MontagemView();
            return View(montagem);
        }

        [HttpPost]
        public ActionResult Create(MontagemView montagemView)
        {
            if (ModelState.IsValid)
            {
                var legoozer = repositorioLegooZer.Recuperar(montagemView.LegooZerID);
                var binaryReader = new BinaryReader(montagemView.ImagemFinal.InputStream);

                var montagem = new Montagem();
                montagem.LegooZer = legoozer;
                montagem.DataCriacao = DateTime.Now;
                montagem.DescricaoPassoAPasso = montagemView.DescricaoPassoAPasso;
                montagem.ByteArrayImage = binaryReader.ReadBytes(montagemView.ImagemFinal.ContentLength);

                repositorioMontagem.Inserir(montagem);
                repositorioMontagem.Salvar();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}