using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetorAlfabeto
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] alfabeto = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l',
                                      'm','n','o','p','q','r','s','t','u','v','x','y','z'};            

            string texto;

            Console.WriteLine("DIGITE SUA PALAVRA:");
            texto = Console.ReadLine();

            char[] palavra = texto.ToCharArray();

            for (int i = 0; i < palavra.Length; i++)
            {
                int conversaoTexto = 0;
                
                for(int j = 0; i < alfabeto.Length; j++)
                {
                    if (alfabeto[j].Equals(palavra[i]))
                    {
                        conversaoTexto = j + 1;
                        break;
                    }
                }

                Console.Write(" " + conversaoTexto + " ");
            }

            Console.ReadLine();

        }

    }
}
