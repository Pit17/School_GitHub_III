using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEserciziMolaraCicli2Es5
{
    internal class Program
    {
        static int LetturaIntero(string messaggio)
        {

            int valore;

            while (true)
            {
                Console.Write(messaggio);

                if (int.TryParse(Console.ReadLine(), out valore))

                    break;

                else
                {
                    Console.WriteLine("Errore! Inserire un numero intero");


                }

            }
            return valore;
        }
        static void Main(string[] args)
        {
            int numero = LetturaIntero("Inserire un numero: ");
            int quadrato = 0,j = 1;

            for (int i = 1; i <= numero; i ++)
            {

                quadrato += j;
                j += 2;
  
            }

            Console.WriteLine($"Il quadrato di {numero} è {quadrato}");
            Console.ReadKey();
        }
    }
}
