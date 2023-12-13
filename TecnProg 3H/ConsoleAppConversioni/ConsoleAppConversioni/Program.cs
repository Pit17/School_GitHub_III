using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Autore_Pietro_Malzone_3H_Conversione_Da_Esadecimale_A_Decimale
namespace ConsoleAppConversioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Autore_Pietro_Malzone_3H_Conversione_Da_Esadecimale_A_Decimale";

            Console.Write("Scrivi il numero esadecimale -->");
            string hex = Console.ReadLine().ToUpper();//Leggo il numero in input e lo metto tutto maiuscolo

            int pos = 0;
            int dec = 0;

            foreach (char c in hex)
            {
                int n = 0;
                if (c >= '0' && c <= '9') //se minore di 10 lo lascio come è
                {
                    n = c - '0';
                }
                else if (c >= 'A' && c <= 'F')//altrimenti converto la lettera nel numero equivalente
                {
                    n = c - 55;
                }
                else
                {
                    Console.WriteLine("Il numero esadecimale non è valido");
                    Console.ReadKey();
                    return;
                }
                dec = dec + n * (int)Math.Pow(16, hex.Length - pos - 1);//calcolo il valore decimale
                pos++;
            }

            Console.WriteLine($"Il numero in base 10 è {dec}");//ritorno il risultato
            Console.ReadKey();
        }
    }
}
