using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Pietro Malzone 3H gioco indovina il codice in un numero definito di tentativi.
namespace ConsoleAppMasterMindBase
{
    internal class Program
    {
        static void Estrazione(int[] vector)//estrae numero casuale tra 1 e 9 e riempe l'array
        {
            int i = 1;
            Random rnd = new Random();
            int numero_estratto = rnd.Next(0, 10);
            vector[0] = numero_estratto;
            while (true)
            {
                numero_estratto = rnd.Next(0, 10);
                if (numero_estratto != vector[0] && numero_estratto != vector[1] && numero_estratto != vector[2] && numero_estratto != vector[3])//verifico non sia un numero già uscito
                {
                    vector[i] = numero_estratto;
                    i++;
                    if (i == 4) break;
                }


            }

        }

        static int LetturaIntero(int n)
        {
            int numero;

            Console.WriteLine($"Inserire la {n}° cifra da verificare");//leggo l'intero e vedo sia valido
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    if (numero >= 0 && numero <= 9) break;
                    else Console.WriteLine("Numero non valido!");
                }
                else Console.WriteLine("Valore non valido! deve essere compreso tra 0 e 9");//se non valido spiego perchè

            }
            return numero;


        }
        static void LetturaNumero(int[] intArray)
        {

            for (int i = 1; i < 5; i++)//mi segno la lettura in un array
            {
                intArray[i - 1] = LetturaIntero(i); ;
            }
        }

        static int VerificaNumero(int[] intArray, int[] vector)
        {
            int[] state = new int[4];
            
            int esatte = 0;
            int posizione = 0;
            int errate = 0;

            for (int i = 0; i < intArray.Length; i++)//assegno uno stato per ogni cifra 2= giusto 1= pos sbagliata e 3 = errato
            {
                
                if (intArray[i] == vector[i])
                {
                    state[i] = 2;
                    esatte++;
                    

                }
                else if (intArray[i] == vector[0] || intArray[i] == vector[1] || intArray[i] == vector[2] || intArray[i] == vector[3])
                {
                    state[i] = 1;
                    posizione++;

                }
                else
                {
                    state[i] = 0;
                    errate++;
                }
                

            }
            
            Console.WriteLine($"Numeri esatti = {esatte}");//ritorno i risultati
            Console.WriteLine($"Numeri con posizione sbagliata = {posizione}");
            Console.WriteLine($"Numeri sbagliati = {errate}");
            return esatte;
        }


        static void Main(string[] args)
        {
            Console.WindowHeight = 1;
            Console.WindowWidth = 1;
            for (int i = 0;i < 30; i++)
            {
                Console.WindowHeight++;
                Console.WindowWidth+=3;
                Thread.Sleep(10);
                
            }
            int[] vector = new int[4];
            int[] intArray = new int[4];
            int tentativi = 0;
            
            string scelta = "";



            for (int i = 0; i < 4; i++) vector[i] = -1;

            Estrazione(vector);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "PietroMalzone3H";//nome e testo iniziale
            Console.WriteLine(" __  __   ____    ____  _____  ____ _____  __  __  _  __  _  ____ \r\n|  \\/  | / () \\  (_ (_`|_   _|| ===|| () )|  \\/  || ||  \\| || _) \\\r\n|_|\\/|_|/__/\\__\\.__)__)  |_|  |____||_|\\_\\|_|\\/|_||_||_|\\__||____/");
            Console.WriteLine();
            
            Console.WriteLine("         ? ? ? ?");
            Console.WriteLine();
            Console.WriteLine("Scegliere la difficoltà");
            Console.WriteLine("[1] - Facile");
            Console.WriteLine("[2] - Media");
            Console.WriteLine("[3] - Difficile");
            Console.WriteLine("[4] - IMPOSSIBILE!");//scelta difficolta con switch case
            while (true)
            {
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        tentativi = 9;
                        break;
                    case "2":
                        tentativi = 6;
                        break;
                    case "3":
                        tentativi = 3;
                        break;
                    case "4":
                        tentativi = 1;
                        break;
                    default:
                        Console.WriteLine("Non valido!");
                        continue;
                }
                break;
            }


            for (int i = 0; i < tentativi; i++)//avvio il gioco per il numero di tentativi
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"Tentativo n: {i + 1}");
                LetturaNumero(intArray);//leggo numeri
                int esatte = VerificaNumero(intArray, vector);//vedo i risultati
                Console.WriteLine();
                if (esatte == 4)//se ha vinto interrompo il gioco e riferisco
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Hai Vinto! Ci hai messo {i+1} tentativi");
                    break;
                }
            }
            Console.WriteLine("Il numero corretto era:");//riferisco il risultato giusto
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 4; i++) Console.Write(vector[i] + " ");

            Console.ReadKey();
        }
    }
}


