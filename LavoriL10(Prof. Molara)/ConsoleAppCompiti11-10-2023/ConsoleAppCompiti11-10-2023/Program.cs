using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Autore Malzone Pietro 3H 11/10/2023 Compiti  per prof Molara11/10/2023 Es1
namespace ConsoleAppCompiti11_10_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region esercizio 1
            
            double soglia1 = 0.15;
            double soglia2 = 0.2;
            double redditoLordo, redditoNetto, imposta;

            Console.Write("\nPerfavore inserisca il proprio reddito lordo --> ");
            redditoLordo = Double.Parse(Console.ReadLine());

            if (redditoLordo > 10000)
            {
                imposta = ((redditoLordo - 10000) * soglia2) + (10000 * soglia1);
                redditoNetto = redditoLordo - imposta;
            }
            else
            {
                imposta = (redditoLordo * soglia1);
                redditoNetto = redditoLordo - imposta;
            }

            Console.WriteLine($"\n Le sono stai sottratti dallo Stato {imposta} euro perciò il suo reddito netto è {redditoNetto} euro");
            #endregion


            Console.WriteLine("\n Premere un tasto per terminare il programma");
            Console.ReadLine();
        }
    }
}
