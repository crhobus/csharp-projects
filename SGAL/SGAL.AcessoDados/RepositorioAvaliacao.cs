using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.AcessoDados
{
    public interface IRepositorioAvaliacao : IDisposable
    {
        List<Avaliacao> Recuperar();
        Avaliacao Recuperar(int avaliacaoID);
        void Inserir(Avaliacao avaliacao);
        void Atualizar(Avaliacao avaliacao);
        void Excluir(Avaliacao avaliacao);
        void Salvar();
    }

    public class RepositorioAvaliacao : IRepositorioAvaliacao
    {
        private SGALContext context;
        private bool disposed = false;

        public RepositorioAvaliacao(SGALContext context)
        {
            this.context = context;
        }

        public Avaliacao Recuperar(int avaliacaoID)
        {
            return context.Avaliacoes.Find(avaliacaoID);
        }

        public List<Avaliacao> Recuperar()
        {
            return context.Avaliacoes.ToList();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Inserir(Avaliacao avaliacao)
        {
            context.Avaliacoes.Add(avaliacao);
        }

        public void Atualizar(Avaliacao avaliacao)
        {
            context.Entry(avaliacao).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(Avaliacao avaliacao)
        {
            context.Entry(avaliacao).State = System.Data.Entity.EntityState.Deleted;
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
