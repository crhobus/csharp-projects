using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcecaoPrograma
{
    public class ExecucaoTeste
    {
        public void Metodo1()
        {
            Console.WriteLine("Inicio do método 1");
            Metodo2();
            Console.WriteLine("Fim do método 1");
        }

        public void Metodo2()
        {
            Console.WriteLine("Inicio do método 2");
            try
            {
                Metodo3();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exceção capturada: {0}", e.Message);
            }
            Console.WriteLine("Fim do método 2");
        }

        public void Metodo3()
        {
            Console.WriteLine("Exemplificando abertura de um recurso");
            try
            {
                Console.WriteLine("Inicio do método 3");
                var x = 0;
                var y = 12 / x;
                Console.WriteLine("Fim do método 3");
            }
            finally
            {
                Console.WriteLine("Exemplificando fechamento de um recurso");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var execucaoTeste = new ExecucaoTeste();
            execucaoTeste.Metodo1();
        }
    }
}
