using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            var valor = 10;
            var outroValor = valor++;

            Console.WriteLine("Valor: {0} - outroValor: {1}", valor, outroValor);

            var valor2 = 10;
            var outroValor2 = ++valor2;

            Console.WriteLine("Valor2: {0} - outroValor2: {1}", valor2, outroValor2);

            Console.WriteLine("Quantos anos você tem? ");
            byte idade = byte.Parse(Console.ReadLine());

            //while (idade > 0)
            //{
            //    Console.Write("Feliz Aniversário Envelheço na Cidade");
            //    idade--;
            //}

            /*for (byte i = 0; i < idade; i++)
            {
                Console.Write("\nFeliz Aniversário Envelheço na Cidade");
            }*/

            for (; idade > 0; idade--)
            {
                Console.Write("\nFeliz Aniversário Envelheço na Cidade");
            }

            Console.WriteLine("\n\n\n\tÉ big, é big, é hora...");


            var i = 0;
            for (;;)
            {
                i++;
                if (i == 5)
                    continue;
                Console.WriteLine("Feliz aniversário {0}", i);
                if (i > 10)
                    break;
            }
        }
    }
}
