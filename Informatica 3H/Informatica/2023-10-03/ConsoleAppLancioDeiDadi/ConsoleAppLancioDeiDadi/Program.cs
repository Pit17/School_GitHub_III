using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLancioDeiDadi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Nome
            Console.Title = ("AleaIactaEstAutorePietroMalzone3H");
            Console.WriteLine("Autore Progetto Pietro Malzone 3H 03/10/2023\n");

            #endregion

            #region Dichiarazioni
            const int WINMULTIPLIER = 10;
            int puntata = 0;
            int initialMoney = 50;
            int wallet;
            string stInput;
            bool inputOK;
            int varInt;
            bool credit = true;
            int winNumber1;
            int winNumber2;
            int winNumberTot;
            char rematchInput;
            int rematch;
            Random rnd = new Random();

            #endregion
            wallet = initialMoney;
            while (credit == true && wallet > 0)
            {
                do
                {
                    Console.Write("\nHai " + wallet + " sesterzi");
                    Console.Write("\nQuanti sesterzi vuoi puntare? -->");

                    stInput = Console.ReadLine();

                    inputOK = int.TryParse(stInput, out varInt);
                    if (!inputOK) Console.WriteLine("\nInput non valido :( \nRiprovi");
                    else if (varInt < 0 || varInt > wallet)//verifico sia compresa nel range
                    {
                        Console.WriteLine("\nNon dispone di questa cifra.");
                        inputOK = false;
                    }

                } while (!inputOK);//ricicla se non valido

                puntata = varInt;
                do
                {
                    Console.Write("\nSu quale numero vuoi puntare da 1 a 12? -->");
                    stInput = Console.ReadLine();
                    // conversione stringa in int
                    inputOK = int.TryParse(stInput, out varInt);
                    if (!inputOK) Console.WriteLine("\nInput non valido! Riprova");
                    else if (varInt < 1 || varInt > 12)//verifico il numero sia nel range
                    {

                        Console.WriteLine("\nIl numero da lei inserito non può uscire");
                        Console.WriteLine("Il numero deve essere compreso tra 1 e 12");
                        inputOK = false;

                    }
                } while (!inputOK);//ricicla se non valido

                winNumber1 = rnd.Next(1, 7);
                winNumber2 = rnd.Next(1, 7);
                winNumberTot = winNumber1 + winNumber2;

                Console.WriteLine("E' uscito il numero " + winNumberTot);
                if (winNumberTot == puntata)
                {
                    wallet += puntata * WINMULTIPLIER;
                    Console.WriteLine("Complimenti hai vinto ora hai " + wallet + "sesterzi");
                }
                else
                {
                    Console.WriteLine("Hai perso");
                    wallet = wallet - puntata;  
                }
                Console.WriteLine("Se vuoi rigiocare scrivere S oppure N per abbandonare");
                rematchInput = Console.ReadKey().KeyChar;
                
                if(rematchInput != 's')
                {
                    credit = false;
                }else credit = true;
            }
            Console.WriteLine("Hai " + wallet + "sestenti");
            Console.WriteLine("Arrivederci e grazie per aver giocato!");
            Console.WriteLine("Premere un tasto per terminare il programma");
            Console.ReadKey();  
           
        }
        

        
        
    }
}

