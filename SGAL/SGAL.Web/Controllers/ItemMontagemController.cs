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
    public class ItemMontagemController : Controller
    {
        private SGALContext sgalContext;
        private RepositorioMontagem repositorioMontagem;
        private RepositorioPeca repositorioPeca;

        public ItemMontagemController()
        {
            sgalContext = new SGALContext();
            repositorioMontagem = new RepositorioMontagem(sgalContext);
            repositorioPeca = new RepositorioPeca(sgalContext);
        }

        protected override void Dispose(bool disposing)
        {
            repositorioMontagem.Dispose();
            repositorioPeca.Dispose();
            sgalContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index(int idMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            return View(montagem.Itens);
        }

        [HttpGet]
        public ActionResult Edit(int idMontagem, int idItemMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            var itemMontagem = montagem.Itens.SingleOrDefault(i => i.ItemMontagemID == idItemMontagem);
            ViewBag.Montagem = montagem;
            return View(new ItemMontagemView(itemMontagem.ItemMontagemID) { PecaID = itemMontagem.Peca.PecaID, Quantidade = itemMontagem.Quantidade });
        }

        [HttpPost]
        public ActionResult Edit(int idMontagem, int idItemMontagem, ItemMontagemView itemMontagemView)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            var item = montagem.Itens.SingleOrDefault(i => i.ItemMontagemID == idItemMontagem);
            item.Quantidade = itemMontagemView.Quantidade;
            ViewBag.Montagem = montagem;
            if (TryUpdateModel(item))
            {
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                return RedirectToAction("Index", new { idMontagem = idMontagem });
            }
            return View(itemMontagemView);
        }

        [HttpGet]
        public ActionResult Create(int idMontagem)
        {
            var montagem = repositorioMontagem.Recuperar(idMontagem);
            ViewBag.Montagem = montagem;
            var itemMontagemView = new ItemMontagemView();
            return View(itemMontagemView);
        }

        [HttpPost]
        public ActionResult Create(int idMontagem, ItemMontagemView itemMontagemView)
        {
            ItemMontagem item = new ItemMontagem();
            if (ModelState.IsValid)
            {
                var peca = repositorioPeca.Recuperar(itemMontagemView.PecaID);

                var montagem = repositorioMontagem.Recuperar(idMontagem);

                if (peca == null)
                {
                    ModelState.AddModelError(string.Empty, string.Format("A peça {0} não existe", itemMontagemView.PecaID));
                    ViewBag.Montagem = montagem;
                    return View(itemMontagemView);
                }

                item.Peca = peca;
                item.Quantidade = itemMontagemView.Quantidade;

                montagem.Itens.Add(item);
                repositorioMontagem.Atualizar(montagem);
                repositorioMontagem.Salvar();
                return RedirectToAction("Index", new { idMontagem = idMontagem });
            }
            return View(itemMontagemView);
        }
    }
}