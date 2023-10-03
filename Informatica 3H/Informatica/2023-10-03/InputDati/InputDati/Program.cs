using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputDati
{
    internal class Program
    {
        static void Main(string[] args)

          
        {
            #region Nome
            Console.Title = ("InputDatiAutorePietroMalzone3H");
            Console.WriteLine("Autore Progetto Pietro Malzone 3H 27/09/2023\n");

            #endregion



            #region Dichiarazioni
            const double MINALTEZZA = 0.24;//Dichiarazione costanti per range altezza 
            const double MAXALTEZZA = 2.72;
            const int MINALUNNI = 10; //Dichiarazione costanti per range numero alunni di una classe
            const int MAXALUNNI = 35;
            string stInput;
            bool inputOK;
            int varInt;
            double varDouble;
            #endregion



            #region Lettura e stampa di una scritta
            /* 
                Console.Write("Input Stringa -> ");
                stInput = Console.ReadLine();
                //Visualizza stringa letta
                Console.WriteLine("\nStringa letta = " +  stInput);
            */
            #endregion




            #region Lettura e stampa di un Intero
            /*
             do
             {
                 Console.Write("\nInput valore intero -> ");
                 stInput = Console.ReadLine();
                 // conversione stringa in int
                 inputOK = int.TryParse(stInput, out varInt);
                 if (!inputOK) Console.WriteLine("\nInput non valido! Riprova");

             } while (!inputOK);//ricicla se non valido
             Console.WriteLine("\nIntero letto = " + varInt);
            */
            #endregion




            #region Lettura e stampa di un Double
            /*
             do
             {
                 Console.Write("\nInput valore con decimali -> ");
                 stInput = Console.ReadLine();
                 // conversione stringa in double
                 inputOK = double.TryParse(stInput, out varDouble);
                 if (!inputOK) Console.WriteLine("\nInput non valido! Riprova");

             } while (!inputOK);//ricicla se non valido

             Console.WriteLine("\nNumero = " + varDouble);
            */
            #endregion




            #region Lettura e stampa Numero alunni di una classe
            /*
            do
            {
                Console.Write("\nNumero Alunni -> ");
                stInput = Console.ReadLine();
                // conversione stringa in int
                inputOK = int.TryParse(stInput, out varInt);
                if (!inputOK) Console.WriteLine("\nInput non valido! Riprova");
                else if (varInt < MINALUNNI || varInt > MAXALUNNI)//verifico il numero sia nel range
                     {

                    Console.WriteLine("\nIl numero da lei inserito non può essere una classe");
                    Console.WriteLine("Il numero deve essere compreso tra 10 e 35 alunni");
                    inputOK = false;

                     }

            } while (!inputOK);//ricicla se non valido
            Console.WriteLine("\nNUmero di alunni = " + varInt);
            */
            #endregion



            #region Lettura e stampa di un'altezza di un essere umano
            do
            {
                Console.Write("\nAltezza in metri -> ");
                stInput = Console.ReadLine();
                // conversione stringa in double
                inputOK = double.TryParse(stInput, out varDouble);
                if (!inputOK) Console.WriteLine("\nInput non valido :( \nRiprovi");
                else if (varDouble < MINALTEZZA || varDouble > MAXALTEZZA)//verifico altezza sia compresa nel range
                {
                    Console.WriteLine("\nIl numero da lei inserito non può essere una altezza");
                    Console.WriteLine("L'altezza deve essere compreso tra 0.24 metri e 2.72 metri");
                    inputOK = false;
                }

            } while (!inputOK);//ricicla se non valido

            Console.WriteLine("\nAltezza = " + varDouble + "m");

            #endregion



            #region Termine del programma
            Console.WriteLine("\nPremi un tasto per terminare il programma");
            Console.ReadKey();
            #endregion
        }
    }
}
