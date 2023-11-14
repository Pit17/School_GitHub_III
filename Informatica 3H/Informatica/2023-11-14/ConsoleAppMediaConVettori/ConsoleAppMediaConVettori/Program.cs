
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ConsoleApp che fa la media e stampa i valori maggiore della media tramite l'uso di vettori.Pietro Malzone 3H 2023/11/14
namespace ConsoleAppMediaConVettori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Estetica
            Console.Title = "AutorePietroMalzone3H";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+------------------+-------------+-----+");
            Console.WriteLine("| Pietro Malzone   | 2023/11/14  | 3H  |");
            Console.WriteLine("+------------------+-------------+-----+");
            Console.ForegroundColor = ConsoleColor.Yellow;
            #endregion

            #region variabili
            int n;
            double media =0;
            #endregion

            #region acquisizione input
            while (true)
            {
                Console.WriteLine("Inserisca la grandezza del vettore:");
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    if (n > 0) break;
                }
                else Console.WriteLine("Valore non valido");
            }
            #endregion

            #region Allocazione
            double[] vector = new double[n];
            #endregion

            #region Caricamento vettore
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine($"Inserisca il numero:");
                vector[i] = double.Parse(Console.ReadLine());
            }
            #endregion

            #region Media
            for (int i = 0;i < vector.Length; i++)
            {
                media += vector[i];
            }

            media /= n;
            

            Console.WriteLine($"La media è pari a {media}");
            #endregion

            #region Numeri maggiori della media
            Console.Write($"I numeri maggiori della media pari a {media} sono :  ");
            for (int i = 0; i < n; i++)
            {
                if (vector[i] >= media) 
                {
                    Console.Write(vector[i] + "; ");
                }
            }
            #endregion

            #region Fine del programma
            Console.WriteLine("Premere per terminare...");
            Console.ReadKey();
            #endregion

        }
    }
}
