using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SGAL.AcessoDados
{
    public interface IRepositorioMontagem : IDisposable
    {
        List<Montagem> Recuperar();
        Montagem Recuperar(int montagemID);
        void Inserir(Montagem montagem);
        void Atualizar(Montagem montagem);
        void Excluir(Montagem montagem);
        void Salvar();
    }

    public class RepositorioMontagem : IRepositorioMontagem
    {
        private SGALContext context;
        private bool disposed = false;

        public RepositorioMontagem(SGALContext context)
        {
            this.context = context;
        }

        public Montagem Recuperar(int montagemID)
        {
            var montagem = context.Montagens.Find(montagemID);

            if (montagem != null)
            {
                context.Entry(montagem).Collection(l => l.Itens).Load();
                foreach (ItemMontagem item in montagem.Itens)
                {
                    context.Entry(item).Reference(l => l.Peca).Load();
                }
                context.Entry(montagem).Collection(l => l.Comentarios).Load();
                context.Entry(montagem).Collection(l => l.Avaliacoes).Load();
                context.Entry(montagem).Reference(l => l.LegooZer).Load();
            }
            return montagem;
        }

        public MontagemExibicao RecuperarParaExibicao(int montagemID)
        {
            var montagem = Recuperar(montagemID);
            var montagemExibicao = new MontagemExibicao();
            montagemExibicao.Nome = montagem.LegooZer.Nome;
            montagemExibicao.SobreNome = montagem.LegooZer.SobreNome;
            montagemExibicao.DataMontagem = montagem.DataCriacao;
            montagemExibicao.MontagemID = montagem.MontagemID;
            List<ItemMontagem> itens = montagem.Itens;
            List<ItemMontagemExibicao> itensMontagemExibicao = new List<ItemMontagemExibicao>();
            foreach (ItemMontagem item in itens)
            {
                itensMontagemExibicao.Add(new ItemMontagemExibicao()
                {
                    ItemMontagemID = item.ItemMontagemID,
                    Quantidade = item.Quantidade,
                    NomePeca = item.Peca.Descricao,
                });
            }
            montagemExibicao.ItensMontagemExibicao = itensMontagemExibicao;

            List<Comentario> comentarios = montagem.Comentarios;
            if (comentarios != null)
            {

                List<ComentarioExibicao> comentariosMontagemExibicao = new List<ComentarioExibicao>();
                foreach (Comentario comentario in comentarios)
                {
                    comentariosMontagemExibicao.Add(new ComentarioExibicao()
                    {
                        ComentarioID = comentario.ComentarioID,
                        DataComentario = comentario.DataComentario,
                        TextoComentario = comentario.TextoComentario,
                    });
                }
                montagemExibicao.ComentariosMontagemExibicao = comentariosMontagemExibicao;

            }

            montagemExibicao.DescricaoPassoAPasso = montagem.DescricaoPassoAPasso;
            return montagemExibicao;
        }

        public List<Montagem> Recuperar()
        {
            return context.Montagens.Include(e => e.LegooZer).Include(e => e.Comentarios).ToList();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Inserir(Montagem montagem)
        {
            context.Montagens.Add(montagem);
        }

        public void Atualizar(Montagem montagem)
        {
            context.Entry(montagem).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(Montagem montagem)
        {
            context.Entry(montagem).State = System.Data.Entity.EntityState.Deleted;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Salvar();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
