using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte valor;

            for (valor = 0; valor < 1 || valor > 15;)
            {
                Console.Write("Digite nro para processar (1-15): ");
                valor = byte.Parse(Console.ReadLine());
            }

            Console.WriteLine("Processando para o valor '{0}'...'", valor);

            var menorNumero = 0;
            bool encontrado = false;

            for (; !encontrado;)
            {
                menorNumero++;
                encontrado = true;

                for (var i = 2; i <= valor; i++)
                {
                    if (menorNumero % i != 0)
                    {
                        encontrado = false;
                        break;
                    }
                }
            }

            Console.WriteLine("Menor Número é: {0}", menorNumero);

        }
    }
}
