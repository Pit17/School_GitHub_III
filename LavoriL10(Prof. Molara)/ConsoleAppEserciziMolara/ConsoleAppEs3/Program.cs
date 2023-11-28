using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEs3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number, guess;
            bool inputOk, guessed = false;
            string strInput;
            Random rnd = new Random();

            number = rnd.Next(0, 101);

            Console.WriteLine("Dovrai indovinare il numero che il programma ha generato, è da 0 a 100");

            do
            {
                do
                {
                    Console.WriteLine("Inserisci il numero che pensi sia corretto: ");
                    strInput = Console.ReadLine();
                    inputOk = int.TryParse(strInput, out guess);

                    if (!inputOk) Console.WriteLine("valore inserito non valido, riprova");
                    if (guess < 0 || guess > 100)
                    {
                        inputOk = false;
                        Console.WriteLine("il valore inserito deve essere compreso tra 0 e 100");
                    }
                } while (!inputOk);

                if (guess < number) Console.WriteLine('>');
                else if (guess > number) Console.WriteLine('<');
                else guessed = true;

            } while (!guessed);

            Console.WriteLine("Complimenti, hai indovinato!");

            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
