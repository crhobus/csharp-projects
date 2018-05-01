using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantesEnumeracao
{
    class Program
    {

        enum EstadosBrasileiros
        {
            PR,
            SC,
            RS,
            SP
        }

        static void Main(string[] args)
        {
            var possiveis = (EstadosBrasileiros[])Enum.GetValues(typeof(EstadosBrasileiros));

            Console.WriteLine("Qual a sigla do seu estado ({0}):", string.Join(",", possiveis));
            var siglaString = Console.ReadLine();

            EstadosBrasileiros estado;

            bool converteu = Enum.TryParse<EstadosBrasileiros>(siglaString, out estado);

            if (converteu)
            {
                switch (estado)
                {
                    case EstadosBrasileiros.PR:
                        Console.WriteLine("\nNasceu no Paraná");
                        break;
                    case EstadosBrasileiros.SC:
                        Console.WriteLine("\nNasceu em Santa Catarina");
                        break;
                    case EstadosBrasileiros.RS:
                        Console.WriteLine("\nNasceu no Rio Grande do Sul");
                        break;
                    case EstadosBrasileiros.SP:
                        Console.WriteLine("\nNasceu em São Paulo");
                        break;
                }
            }
        }
    }
}
