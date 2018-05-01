using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valores
{
    class Program
    {
        static void Main(string[] args)
        {
            var itens = new Item[5];

            Random r = new Random();

            for (int i = 0; i < itens.Length; i++)
            {
                itens[i] = new Item(r.Next());
            }

            Console.WriteLine("Itens: \n");

            foreach (var item in itens)
            {
                Console.WriteLine("ItemID = {0}", item.Id);
            }

            Item algumItem = itens[1];

            Console.WriteLine("Segundo item = {0}", algumItem.Id);

            var jogadores = new String[5];

            jogadores[0] = "Romário";
            jogadores[1] = "Ronaldinho";
            jogadores[2] = "Ronaldinho Gaúcho";
            jogadores[3] = "Marcos";
            jogadores[4] = "Rivaldo";

            var novoArrayJogadores = new String[] { "Romário", "Ronaldinho", "Ronaldinho Gaúcho", "Marcos", "Rivaldo" };

            Console.WriteLine("\nJogadores...");
            foreach (var s in jogadores)
            {
                Console.WriteLine(s);
            }

            Array.Sort(jogadores);

            Console.WriteLine("\nJogadores");
            foreach (var s in jogadores)
            {
                Console.WriteLine(s);
            }

            var posicao = Array.BinarySearch(jogadores, "Ronaldinho");
            if (posicao > 0)
            {
                Console.WriteLine("Na posição {0}", posicao);
            }
        }
    }
}
