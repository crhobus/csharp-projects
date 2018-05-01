using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeConstrucao
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string minhaString = "Olá Mundo!";
            char meuCaracter = '\n';
            Console.WriteLine(minhaString);

            int valorInteiro = 10;
            Console.WriteLine(valorInteiro);
            Console.WriteLine("{0:D5}", valorInteiro);

            double valorFracionado = 4.20D;
            double soma = valorFracionado + valorInteiro;

            float outroValor = 4.20F;
            decimal outroValorFracionado = 4.20M;

            double x = valorFracionado + outroValor;

            Console.WriteLine("{0} + {1} = {2}", valorFracionado, valorInteiro, soma);
        }
    }
}
