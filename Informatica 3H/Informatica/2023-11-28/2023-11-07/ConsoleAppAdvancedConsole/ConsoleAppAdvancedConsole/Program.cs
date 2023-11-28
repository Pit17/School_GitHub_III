using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Autore Pietro Malzone 3H 07/11/2023 
namespace ConsoleAppAdvancedConsole
{
    internal class Program
    {
      
        const string nome_file = @"..\..\Frasi.txt";
        static char LeggiTasto()//lettura char
        {
            if (!Console.KeyAvailable) return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true);

            return key.KeyChar;
        }

        static void TypeCheck(string frase,out int errori,out double tempo)
        {
            Console.Clear();
            Console.WriteLine(frase);
            System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch();
            int i = 0, position = 0, errors = 0;
            double time;

            while (true) 
            {
                cronometro.Start();
                Console.CursorVisible = false;
                Console.SetCursorPosition(position, 1);
                Console.Write("^");
                Console.SetCursorPosition(position, 0);
                char type = LeggiTasto();
                
                if (type != '\0')//se corretto
                {

                    if (type == frase[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(frase[i]);
                        i++;
                        position++;

                    }
                    else//Se errato
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(frase[i]);
                        i++;
                        position++;
                        errors++;
                    }

                    Console.SetCursorPosition(position, 1);//cursore 
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("^");
                    Console.SetCursorPosition(position - 1, 1);
                    Console.Write(" ");
                    
                }
                if (i == frase.Length) break;
            }
            cronometro.Stop();
            time = (double)cronometro.ElapsedMilliseconds / 1000.0;
            errori = errors;
            tempo = time;

        }

        static void Main(string[] args)//main
        {
            Console.Title = "AutorePietroMalzone3H"
            string riga;
            int errori,erroriTot = 0,lenght = 0;
            double tempo = 0, tempoTot = 0.0;
            using (StreamReader sr = new StreamReader(nome_file))
            {
                while (!sr.EndOfStream)
                {
                    riga = sr.ReadLine();

                    TypeCheck(riga,out errori,out tempo);
                    erroriTot += errori;
                    tempoTot += tempo;
                    lenght += riga.Length;
                }

                sr.Close();
            }
            Console.WriteLine($"\nComplimenti hai terminato con {erroriTot} errori su {lenght} caratteri totali.\nIl tuo tasso di errore è del {((double)erroriTot/ (double)lenght * 100.0):0.##}%\nHai terminato in {tempoTot} secondi \nLa tua velocità media è {(int)(lenght /tempoTot * 60)} caratteri al minuto");
            //risultato
            Console.ReadKey();
        }
    }
}


