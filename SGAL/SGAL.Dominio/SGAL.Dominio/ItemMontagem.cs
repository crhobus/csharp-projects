using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.Dominio
{
    public class ItemMontagem : Entidade
    {
        public ItemMontagem() : this(0)
        { }

        public ItemMontagem(int itemMontagemID)
        {
            this.ItemMontagemID = itemMontagemID;
        }

        public int ItemMontagemID { get; private set; }
        public Peca Peca { get; set; }
        public int Quantidade { get; set; }

        protected override bool Validar()
        {
            return Peca != null
                && Peca.Valido
                && Quantidade > 0;
        }
    }
}
