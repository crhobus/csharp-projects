using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.AcessoDados
{
    public interface IRepositorioComentario : IDisposable
    {
        List<Comentario> Recuperar();
        Comentario Recuperar(int comentarioID);
        void Inserir(Comentario comentario);
        void Atualizar(Comentario comentario);
        void Excluir(Comentario comentario);
        void Salvar();
    }

    public class RepositorioComentario : IRepositorioComentario
    {
        private SGALContext context;
        private bool disposed = false;

        public RepositorioComentario(SGALContext context)
        {
            this.context = context;
        }

        public Comentario Recuperar(int comentarioID)
        {
            return context.Comentarios.Find(comentarioID);
        }

        public List<Comentario> Recuperar()
        {
            return context.Comentarios.ToList();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Inserir(Comentario comentario)
        {
            context.Comentarios.Add(comentario);
        }

        public void Atualizar(Comentario comentario)
        {
            context.Entry(comentario).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(Comentario comentario)
        {
            context.Entry(comentario).State = System.Data.Entity.EntityState.Deleted;
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
