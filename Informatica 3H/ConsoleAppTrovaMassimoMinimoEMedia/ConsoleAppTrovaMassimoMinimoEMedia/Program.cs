using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTrovaMassimoMinimoEMedia
{
    internal class Program
    {
        //Autore Pietro Malzone 3 H 24/10/2023 Trova massimo minimo e media di una serie di numeri senza array
        static void Main(string[] args)
        {

            #region Nome
            Console.Title = ("AutorePietroMalzone3H17-10-2023");
            Console.WriteLine("AutorePietroMalzone3H17-10-2023");
            #endregion

            #region Dichiarazioni
            int max = int.MinValue, min = int.MaxValue,nNumeri = 0,numero=0,somma = 0;
            double media;
            string varRead;
            bool inputOK,end = false;
            #endregion

            #region Istruzioni
            Console.WriteLine("\nInserisca un numero e le restituiremo il maggiore il minore e la media\n\n");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("| NOTA BENE: La quantità di numeri la decide lei semplicemente scrivendo 'fine' |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("+-------------------------------------------------------------------------------+");
            #endregion

            #region Input
            do
            {

                
               
                do
                {
  
                    Console.Write("\nInserisca il valore intero -->");

                    varRead = Console.ReadLine();
                    if (varRead.ToUpper() == "FINE")
                    {
                        inputOK = true;
                        end= true;
                        
                    }
                    else
                    {
                        inputOK = int.TryParse(varRead, out numero);
                        if (!inputOK) Console.WriteLine("\nInput non valido :( \nRiprovi");
                    }
                } while (!inputOK);
                #endregion

            #region Calcolo

                if (end == true) continue;
                else
                {
                    if (numero > max) max = numero;//tengo il numero maggiore

                    if (numero < min) min = numero;//tengo il numero minore

                    somma += numero;//salvo la somma

                    nNumeri++;//incremento il numero di valori inseriti

                }
            } while (end != true);
            #endregion

            #region Output
            if (nNumeri < 2) Console.WriteLine("\nNon possiamo fornirle numero massimo, minimo e media poichè non ha inserito alcun numero");
            else
            {

                Console.WriteLine($"\nIl numero massimo è {max}");
                Console.WriteLine($"Il numero minimo è {min}");
                Console.WriteLine($"La media è {media =somma / nNumeri}");
            }
            Console.WriteLine("\n Premere per terminare");
            Console.ReadKey();
            #endregion
        }
    }
}
