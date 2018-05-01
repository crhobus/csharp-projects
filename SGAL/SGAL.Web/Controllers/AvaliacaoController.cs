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
    public class AvaliacaoController : Controller
    {
        private SGALContext sgalContext;
        private RepositorioMontagem repositorioMontagem;
        private RepositorioAvaliacao repositorioAvaliacao;

        public AvaliacaoController()
        {
            sgalContext = new SGALContext();
            repositorioMontagem = new RepositorioMontagem(sgalContext);
            repositorioAvaliacao = new RepositorioAvaliacao(sgalContext);
        }

        protected override void Dispose(bool disposing)
        {
            repositorioMontagem.Dispose();
            repositorioAvaliacao.Dispose();
            sgalContext.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult Index(int idMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            return View(montagem.Avaliacoes);
        }
        
        [HttpGet]
        public ActionResult Create(int idMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var avaliacaoView = new AvaliacaoView();
            return View(avaliacaoView);
        }
        
        [HttpPost]
        public ActionResult Create(int idMontagem, AvaliacaoView avaliacaoView)
        {
            Avaliacao avaliacao = new Avaliacao();
            if (ModelState.IsValid)
            {

                var montagem = repositorioMontagem.Recuperar(idMontagem);

                avaliacao.DataComentario = DateTime.Now;
                avaliacao.QuantidadeEstrelas = avaliacaoView.QuantidadeEstrelas;

                montagem.Avaliacoes.Add(avaliacao);
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                ViewBag.Montagem = montagem;
                return RedirectToAction("Index", new { idMontagem = idMontagem });
            }
            return View(avaliacao);
        }
        
        [HttpGet]
        public ActionResult Delete(int idMontagem, int idAvaliacao)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var avaliacaoView = new AvaliacaoView();

            var avaliacao = repositorioAvaliacao.Recuperar(idAvaliacao);

            avaliacaoView.DataComentario = avaliacao.DataComentario;
            avaliacaoView.QuantidadeEstrelas = avaliacao.QuantidadeEstrelas;

            return View(avaliacaoView);
        }

        [HttpPost]
        public ActionResult Delete(int idMontagem, int idAvaliacao, FormCollection collection)
        {
            if (ModelState.IsValid)
            {

                var avaliacao = repositorioAvaliacao.Recuperar(idAvaliacao);

                var montagem = repositorioMontagem.Recuperar(idMontagem);

                montagem.Avaliacoes.Remove(avaliacao);
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                ViewBag.Montagem = montagem;
            }
            return RedirectToAction("Index", new { idMontagem = idMontagem });
        }
        
        [HttpGet]
        public ActionResult Edit(int idMontagem, int idAvaliacao)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var avaliacao = repositorioAvaliacao.Recuperar(idAvaliacao);
            return View(new AvaliacaoView(montagem.MontagemID) { AvaliacaoID = avaliacao.AvaliacaoID, DataComentario = avaliacao.DataComentario, QuantidadeEstrelas = avaliacao.QuantidadeEstrelas });
        }
        
        [HttpPost]
        public ActionResult Edit(int idMontagem, int idAvaliacao, AvaliacaoView avaliacaoView)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            var avaliacao = repositorioAvaliacao.Recuperar(idAvaliacao);

            avaliacao.QuantidadeEstrelas = avaliacaoView.QuantidadeEstrelas;

            if (TryUpdateModel(avaliacao))
            {
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                return RedirectToAction("Index", new { idMontagem = idMontagem });
            }
            return View(avaliacaoView);
        }
        

    }
}