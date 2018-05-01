using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte maiorIdadePenal = 18;
            const byte melhorIdade = 65;

            Console.Write("Qual é sua idade? ");
            string idadeComoString = Console.ReadLine();

            byte idade = byte.Parse(idadeComoString);

            if (idade >= melhorIdade)
                Console.WriteLine("Você está na melhor idade");
            else if (idade >= maiorIdadePenal)
                Console.WriteLine("Te cuida mano!");
            else
                Console.WriteLine("Você é um jovem!");
        }
    }
}
