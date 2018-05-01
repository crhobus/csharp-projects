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
    public class ComentarioController : Controller
    {
        private SGALContext sgalContext;
        private RepositorioMontagem repositorioMontagem;
        private RepositorioComentario repositorioComentario;

        public ComentarioController()
        {
            sgalContext = new SGALContext();
            repositorioMontagem = new RepositorioMontagem(sgalContext);
            repositorioComentario = new RepositorioComentario(sgalContext);
        }

        protected override void Dispose(bool disposing)
        {
            repositorioMontagem.Dispose();
            repositorioComentario.Dispose();
            sgalContext.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult Index(int idMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            return View(montagem.Comentarios);
        }

        [HttpGet]
        public ActionResult Create(int idMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var comentarioView = new ComentarioView();
            return View(comentarioView);
        }

        [HttpPost]
        public ActionResult Create(int idMontagem, ComentarioView comentarioView)
        {
            Comentario comentario = new Comentario();
            if (ModelState.IsValid)
            {

                var montagem = repositorioMontagem.Recuperar(idMontagem);

                comentario.DataComentario = DateTime.Now;
                comentario.TextoComentario = comentarioView.TextoComentario;

                montagem.Comentarios.Add(comentario);
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                ViewBag.Montagem = montagem;
                return RedirectToAction("Index", new { idMontagem = idMontagem });
            }
            return View(comentario);
        }

        [HttpGet]
        public ActionResult Delete(int idMontagem, int idComentario)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var comentarioView = new ComentarioView();

            var comentario = repositorioComentario.Recuperar(idComentario);

            comentarioView.DataComentario = comentario.DataComentario;
            comentarioView.TextoComentario = comentario.TextoComentario;

            return View(comentarioView);
        }

        [HttpPost]
        public ActionResult Delete(int idMontagem, int idComentario, FormCollection collection)
        {
            if (ModelState.IsValid)
            {

                var comentario = repositorioComentario.Recuperar(idComentario);

                var montagem = repositorioMontagem.Recuperar(idMontagem);

                montagem.Comentarios.Remove(comentario);
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                ViewBag.Montagem = montagem;
            }
            return RedirectToAction("Index", new { idMontagem = idMontagem });
        }

        [HttpGet]
        public ActionResult Edit(int idMontagem, int idComentario)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var comentario = repositorioComentario.Recuperar(idComentario);
            return View(new ComentarioView(montagem.MontagemID) { ComentarioID = comentario.ComentarioID, DataComentario = comentario.DataComentario , TextoComentario = comentario.TextoComentario });
        }
        
        [HttpPost]
        public ActionResult Edit(int idMontagem, int idComentario, ComentarioView comentarioView)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            var comentario = repositorioComentario.Recuperar(idComentario);

            comentario.TextoComentario = comentarioView.TextoComentario;

            if (TryUpdateModel(comentario))
            {
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                return RedirectToAction("Index", new { idMontagem = idMontagem });
            }
            return View(comentarioView);
        }
        

    }
}