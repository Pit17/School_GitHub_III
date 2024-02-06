using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCompiti11_10_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region esercizio 1
            /*
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
            */
            #endregion

            #region esercizio 2
            /*
            double soglia1 = 0.15;
            double soglia2 = 0.2;
            double soglia3 = 0.23;
            double redditoLordo, redditoNetto = 0, imposta = 0;

            Console.Write("\nPerfavore inserisca il proprio reddito lordo --> ");
            redditoLordo = Double.Parse(Console.ReadLine());

            if (redditoLordo > 10000 && redditoLordo < 15000)
            {
                imposta = ((redditoLordo - 10000) * soglia2) + (10000 * soglia1);
                redditoNetto = redditoLordo - imposta;
            }
            else if (redditoLordo < 10000)
            {
                imposta = (redditoLordo * soglia1);
                redditoNetto = redditoLordo - imposta;
            } else if (redditoLordo > 15000){
                imposta = ((redditoLordo - 10000) * soglia2) + (10000 * soglia1) + (redditoLordo-15000) * soglia3;
                redditoNetto = redditoLordo - imposta;
            }

            Console.WriteLine($"\n Le sono stai sottratti dallo Stato {imposta} euro perciò il suo reddito netto è {redditoNetto} euro");
            
            */
            #endregion

            #region esercizio 3

            int ore1, minuti1, secondi1, ore2, minuti2, secondi2, secondidifferenza,ora,minuti,secondi , tempoinsec1 , tempoinsec2;

            Console.WriteLine("Inserisca i dati del primo orario");
            Console.WriteLine("Ore -->");
            ore1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Minuti -->");

            minuti1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Secondi -->");
            secondi1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisca i dati del  orario");
            Console.WriteLine("Ore -->");
            ore2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Minuti -->");
            minuti2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Secondi -->");
            secondi2 = int.Parse(Console.ReadLine());

            tempoinsec1 = ((ore1 * 3600) + secondi1 + (minuti1 * 60));
            tempoinsec2 = (ore2 * 3600) + secondi2 + (minuti2 * 60);

            if (tempoinsec1 > tempoinsec2)
            {
                secondidifferenza = tempoinsec1 - tempoinsec2;

            }else secondidifferenza = tempoinsec2 - tempoinsec1;

            secondi = secondidifferenza % 60;

            minuti = (secondidifferenza-secondi) / 60;

            ora = (secondidifferenza - secondi)/3600;

            Console.WriteLine($"La differenza è di {ora} ore {minuti} minuti e {secondi} secondi");



            #endregion

            Console.WriteLine("\n Premere un tasto per terminare il programma");
            Console.ReadLine();
        }
    }
}
