using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o texto:");
            string str = Console.ReadLine();
            string s = "";
            int soma = 0;

            for (int i = 0; i < str.Length; i++)
            {
                while (i < str.Length && char.IsDigit(str[i]))
                {
                    s += str.Substring(i, 1);
                    i++;
                }
                if (!"".Equals(s))
                {
                    soma += int.Parse(s);
                }
                s = "";
            }

            Console.WriteLine("A soma dos números do texto é: {0}", soma);
        }
    }
}
