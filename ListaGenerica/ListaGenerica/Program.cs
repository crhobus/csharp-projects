using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ListaGenerica
{
    class Program
    {
        static void Main(string[] args)
        {
            DiversasColecoes();

            var capitais = new Dictionary<string, int>() {
                {"Florianópolis", 100},
                {"Porto Alegre", 101},
                {"Curitiba", 300},
            };

            capitais.Add("Rio de Janeiro", 500);
            capitais.Add("São Paulo", 800);
            capitais.Add("Fortaleza", 700);

            Console.Write("Digite o nome da capital:");
            var capital = Console.ReadLine();

            if (capitais.ContainsKey(capital))
            {
                var habitantes = capitais[capital];
                Console.WriteLine("Total de habitantes de {0} é {1}",
                    capital,
                    habitantes);
            }
            else
                Console.WriteLine("Capital desconhecida");

            foreach (var c in capitais.Keys)
            {
                Console.WriteLine("{0} = \t\t{1} Habitantes", c, capitais[c]);
            }
        }

        private static void DiversasColecoes()
        {
            var arrayNumeros = new int[] { 100, 200, 300, 400 };

            var listaNumeros = CriarLista(10);
            var listaNumeros2 = CriarLista(5);

            var filaNumeros = CriarFila(5);

            var pilhaNumeros = CriarPilha(5);

            Console.WriteLine("Lista 01");
            ExibirLista(listaNumeros);

            Console.WriteLine("\nLista 02");
            ExibirLista(listaNumeros2);

            Console.WriteLine("\nArray");
            ExibirLista(arrayNumeros);

            Console.WriteLine("\nFila");
            ExibirLista(filaNumeros);

            Console.WriteLine("\nPilha");
            ExibirLista(pilhaNumeros);
        }

        private static IEnumerable<int> CriarPilha(int totalItens)
        {
            Stack<int> listaNumeros = new Stack<int>();

            for (int i = 0; i < totalItens; i++)
            {
                listaNumeros.Push(i * 1000);
            }

            return listaNumeros;
        }

        private static IEnumerable<int> CriarFila(int totalItens)
        {
            Queue<int> listaNumeros = new Queue<int>();

            for (int i = 0; i < totalItens; i++)
            {
                listaNumeros.Enqueue(i * 1000);
            }

            return listaNumeros;
        }

        private static IEnumerable<int> CriarLista(int totalItens)
        {
            var r = new Random();

            List<int> listaNumeros = new List<int>();

            for (int i = 0; i < totalItens; i++)
            {
                listaNumeros.Add(r.Next());
            }

            return listaNumeros;
        }

        private static void ExibirLista(IEnumerable<int> listaNumeros)
        {
            foreach (var numero in listaNumeros)
            {
                Console.WriteLine(numero);
            }
        }

    }
}
