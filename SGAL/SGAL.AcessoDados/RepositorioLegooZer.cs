using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SGAL.AcessoDados
{
    public interface IRepositorioLegooZer : IDisposable
    {
        List<LegooZer> Recuperar();
        LegooZer Recuperar(int legooZerID);
        void Inserir(LegooZer legoozer);
        void Atualizar(LegooZer legoozer);
        void Excluir(LegooZer legoozer);
        void Salvar();
    }

    public class RepositorioLegooZer : IRepositorioLegooZer
    {
        private SGALContext context;
        private bool disposed = false;

        public RepositorioLegooZer(SGALContext context)
        {
            this.context = context;
        }

        public LegooZer Recuperar(int legooZerID)
        {
            var legoozer = context.LegooZers.Find(legooZerID);

            if (legoozer != null)
                context.Entry(legoozer).Collection(l => l.Enderecos).Load();

            return legoozer;
        }

        public List<LegooZer> Recuperar()
        {
            return context.LegooZers.Include(e => e.Enderecos).ToList();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Inserir(LegooZer legoozer)
        {
            context.LegooZers.Add(legoozer);
        }

        public void Atualizar(LegooZer legoozer)
        {
            context.Entry(legoozer).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(LegooZer legoozer)
        {
            context.Entry(legoozer).State = System.Data.Entity.EntityState.Deleted;
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
