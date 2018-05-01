using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemDoDeposito notebook = new Computador()
            {
                ID = 102,
                SerialNumber = "opa989",
                TipoCPU = "i7",
                Nome = "Computador",
            };

            ItemDoDeposito impressora = new Hardware()
            {
                ID = 103,
                SerialNumber = "abcxyz",
                Nome = "Impressora",
            };

            ItemDoDeposito office = new Software()
            {
                ID = 104,
                ISBN = "2323-2323-2323",
                Nome = "MS Office",
            };

            impressora.Compra();
            Console.WriteLine("\n");
            Console.Beep();
            notebook.Compra();
            Console.WriteLine("\n");
            Console.Beep();
            office.Compra();

        }
    }
}
