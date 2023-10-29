using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEserciziMolaraCicli2Es2
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
            
            int numero1 = LetturaIntero("Inserire il dividendo: ");
            int numero2 = LetturaIntero("Inserire il divisore: ");
            bool positivo = IsPositive(numero1, numero2);
            int quoziente = 0, resto = 0;
            numero1 = Math.Abs(numero1);
            numero2 = Math.Abs(numero2);
            int num = numero1;
            

            while (num >= numero2)
            {
                num -= numero2;
                quoziente++;
            }

            resto = numero1 - (numero2 * quoziente);

            if (!positivo) quoziente = -quoziente;

            Console.WriteLine($"Il quoziente e' {quoziente} con resto {resto}");
            Console.ReadKey();
        }
    }
}
