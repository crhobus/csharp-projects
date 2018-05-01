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
    public interface IRepositorioItemMontagem : IDisposable
    {
        List<ItemMontagem> Recuperar();
        ItemMontagem Recuperar(int itemMontagemID);
        void Inserir(ItemMontagem itemMontagem);
        void Atualizar(ItemMontagem itemMontagem);
        void Excluir(ItemMontagem itemMontagem);
        void Salvar();
    }

    public class RepositorioItemMontagem : IRepositorioItemMontagem
    {
        private SGALContext context;
        private bool disposed = false;

        public RepositorioItemMontagem(SGALContext context)
        {
            this.context = context;
        }

        public ItemMontagem Recuperar(int itemMontagemID)
        {
            var itemMontagem = context.ItensMontagem.Find(itemMontagemID);

            if (itemMontagem != null)
                context.Entry(itemMontagem).Reference(l => l.Peca).Load();

            return itemMontagem;
        }

        public List<ItemMontagem> Recuperar()
        {
            return context.ItensMontagem.Include(e => e.Peca).ToList();
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        public void Inserir(ItemMontagem itemMontagem)
        {
            context.ItensMontagem.Add(itemMontagem);
        }

        public void Atualizar(ItemMontagem itemMontagem)
        {
            context.Entry(itemMontagem).State = System.Data.Entity.EntityState.Modified;
        }

        public void Excluir(ItemMontagem itemMontagem)
        {
            context.Entry(itemMontagem).State = System.Data.Entity.EntityState.Deleted;
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
