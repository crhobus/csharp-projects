using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Deposito
    {
        public int ID { get; private set; }
        public string NomeDeposito { get; private set; }

        public Deposito(string nome, int id)
        {
            NomeDeposito = nome;
            ID = id;
        }

        public ItemDoDeposito EncontrarItem(int id)
        {
            return new ItemDoDeposito
            {
                ID = id,
                Nome = "Microsoft Office"
            };
        }
    }
}
