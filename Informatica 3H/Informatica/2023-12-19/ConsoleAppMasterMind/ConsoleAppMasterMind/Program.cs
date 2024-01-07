using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pietro Malzone 3H gioco indovina il codice in un numero definito di tentativi.
namespace ConsoleAppMasterMind
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
                if (numero_estratto != vector[0] && numero_estratto != vector[1] && numero_estratto != vector[2] && numero_estratto != vector[3])
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

            Console.WriteLine($"Inserire la {n}° cifra da verificare");
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    if (numero >= 0 && numero <= 9) break;
                    else Console.WriteLine("Numero non valido!");
                }
                else Console.WriteLine("Valore non valido! deve essere compreso tra 0 e 9");

            }
            return numero;


        }
        static void LetturaNumero(int[] intArray)
        {
            
            for (int i = 1;i < 5; i++)
            {
                intArray[i-1] = LetturaIntero(i); ;
            }
        }

        static bool VerificaNumero(int[] intArray, int[] vector)
        {
            int[] state = new int[4];
            int contatore = 0;
            int esatte = 0;
            int posizione = 0;
            int errate = 0;

            for (int i = 0; i < intArray.Length; i++)
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

                for (int j = 0; j < 4; j++)
                {

                    if (state[j] == 2) contatore++;
                }
                if (contatore == 4)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(intArray[i] + " ");

                    }
                    return true;
                }
                else
                {
                    Console.WriteLine($"Numeri esatti = {esatte}");
                    Console.WriteLine($"Numeri con posizione sbagliata = {posizione}");
                    Console.WriteLine($"Numeri sbagliati = {errate}");
                    

                }
                
            }
            return false;
        }


        static void Main(string[] args)
        {
            int[] vector = new int[4];
            int[] intArray = new int[4];
            int tentativi = 5;
            bool result = false;
            
            for (int i = 0; i < 4; i++) vector[i] = -1;

            Estrazione(vector);
            Console.Title = "PietroMalzone3H";
            Console.WriteLine(" __  __   ____    ____  _____  ____ _____  __  __  _  __  _  ____ \r\n|  \\/  | / () \\  (_ (_`|_   _|| ===|| () )|  \\/  || ||  \\| || _) \\\r\n|_|\\/|_|/__/\\__\\.__)__)  |_|  |____||_|\\_\\|_|\\/|_||_||_|\\__||____/");
            Console.WriteLine();
            Console.WriteLine("         ? ? ? ?");
            Console.WriteLine();
            
            for (int i = 0; i < tentativi; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.WriteLine($"Tentativo n: {i+1}");
                LetturaNumero(intArray);
                result = VerificaNumero(intArray, vector);
                Console.WriteLine();
                if (result == true)
                {
                    Console.WriteLine("Hai Vinto!") ;
                    break;
                }
            }
            Console.WriteLine("Numero corretto:");
            Console.ForegroundColor= ConsoleColor.Green;
            for (int i = 0; i < 4; i++) Console.Write(vector[i] + " ");

            Console.ReadKey();
        }
    }
}
