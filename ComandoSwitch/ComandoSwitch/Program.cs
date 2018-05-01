using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandoSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escola um número entre 1 e 5:");
            int numero = int.Parse(Console.ReadLine());

            switch (numero)
            {
                case 1:
                    Console.WriteLine("Você escolheu o menor número permitido");
                    break;
                case 2:
                    Console.WriteLine("Você escolheu o 2");
                    break;
                case 3:
                    Console.WriteLine("Você escolheu o 3");
                    break;
                case 4:
                    Console.WriteLine("Você escolheu o 4");
                    break;
                case 5:
                    Console.WriteLine("Você escolheu o maior número permitido");
                    break;
                default:
                    Console.WriteLine("Valor inválido");
                    break;
            }
        }
    }
}
