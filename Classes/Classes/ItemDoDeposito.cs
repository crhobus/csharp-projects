using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ItemDoDeposito
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual void Compra()
        {
            Console.WriteLine("Comprando... {0}", Nome);
        }
    }

    public class Software : ItemDoDeposito
    {
        public string ISBN { get; set; }

        public override void Compra()
        {
            base.Compra();
            Console.WriteLine("\tISBN: {0}", ISBN);
        }

    }

    public class Hardware : ItemDoDeposito
    {
        public string SerialNumber { get; set; }
        public override void Compra()
        {
            base.Compra();
            Console.WriteLine("Serial Number: {0}", SerialNumber);
        }
    }

    public class Computador : Hardware
    {
        public string TipoCPU { get; set; }
        public string Discos { get; set; }

        public override void Compra()
        {
            base.Compra();
            Console.WriteLine("\tTipo da CPU: {0}", TipoCPU);
        }
    }

    public class Periferico : ItemDoDeposito
    {
        public string Descricao { get; set; }
    }
}
