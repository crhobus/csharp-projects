using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    public class DividendoZeroException : Exception
    {
        public DividendoZeroException() : base("Dividendo não pode ser zero")
        {

        }
    }

    public class Operacoes
    {
        public int Dividir(int dividendo, int divisor)
        {
            if (dividendo == 0)
                throw new DividendoZeroException();
            return dividendo / divisor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Operacoes operacoes = new Operacoes();
                Console.Write("Dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.Write("\nDivisor: ");
                int divisor = int.Parse(Console.ReadLine());

                Console.WriteLine("Divisão ({0} / {1}): {2}",
                                dividendo,
                                divisor,
                                operacoes.Dividir(dividendo, divisor));
            }
            catch (DividendoZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Valor entrado não é um número!");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Informe um valor entre {0} e {1}", int.MinValue, int.MaxValue);
            }
        }
    }
}
