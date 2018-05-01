using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.AcessoDados
{
    public interface IRepositorioPeca : IDisposable
    {
        List<Peca> Recuperar();
        Peca Recuperar(int pecaID);
        void Inserir(Peca peca);
        void Atualizar(Peca peca);
        void Excluir(Peca peca);
        void Salvar();
        int nextId();
    }

    public class RepositorioPeca : IRepositorioPeca
    {
        private SGALContext context;
        private bool disposed = false;

        public RepositorioPeca(SGALContext context)
        {
            this.context = context;
        }

        public Peca Recuperar(int pecaID)
        {
            return context.Pecas.Find(pecaID);
        }

        public List<Peca> Recuperar()
        {
            return context.Pecas.ToList();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Inserir(Peca peca)
        {
            context.Pecas.Add(peca);
        }

        public void Atualizar(Peca peca)
        {
            context.Entry(peca).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(Peca peca)
        {
            context.Entry(peca).State = System.Data.Entity.EntityState.Deleted;
        }

        public int nextId()
        {
            return context.Pecas.Max(p => p.PecaID) + 1;
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
