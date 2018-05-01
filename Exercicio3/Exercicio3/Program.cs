using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Bloco bloco = new Bloco(4, 2, 6);
            Console.WriteLine("Volume do bloco é {0}", bloco.Volume);
            Console.WriteLine("Área do bloco é {0}", bloco.Area);
        }
    }
}
