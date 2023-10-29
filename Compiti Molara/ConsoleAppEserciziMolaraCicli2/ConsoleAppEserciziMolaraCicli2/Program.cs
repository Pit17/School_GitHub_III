using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEserciziMolaraCicli2
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

        static bool IsPositive(int numero_1, int numero_2)
        {
            bool positivo = false;

            if ((numero_1 > 0 && numero_2 > 0) || (numero_1 < 0 && numero_2 < 0)) positivo = true;

            else positivo = false;
            

            return positivo;
        }


        static void Main(string[] args)
        {
            int numero_1 = LetturaIntero("Inserire il primo fattore: ");
            int numero_2 = LetturaIntero("Inserire il secondo fattore: ");
            int risultato = 0;

            bool positivo = IsPositive(numero_1, numero_2);

            numero_1 = Math.Abs(numero_1);
            numero_2 = Math.Abs(numero_2);

            for (int i = 0; i < numero_2; i++)
            {
                risultato += numero_1;
            }

            if (!positivo) risultato = -risultato;

            Console.WriteLine($"Il prodotto è: {risultato}");
            Console.ReadKey();

        }
    }
}
