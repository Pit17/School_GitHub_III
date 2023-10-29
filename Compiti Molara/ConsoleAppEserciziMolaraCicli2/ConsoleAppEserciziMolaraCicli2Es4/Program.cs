using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEserciziMolaraCicli2Es4
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
            int m = LetturaIntero("Inserire il numero di righe: ");
            int n = LetturaIntero("Inserire il numero di caratteri per riga: ");

            for (int i = 0; i < m; i++)
            {
                int j = 0;
                while (j < n)
                {
                    Console.Write("#");
                    j++;
                }
                Console.WriteLine();
                
            }
            Console.ReadKey();
        }
    }
}
