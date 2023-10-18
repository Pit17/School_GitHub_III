using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEs1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stInput;
            int intNumber;
            bool inputOk;
            int intSecNumber;

            do
            {
                Console.Write("Inserire il primo numero che si desidera calcolare --> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intNumber);
                if (!inputOk)
                {
                    Console.WriteLine("Input NON valido");
                }
                else if (intNumber < 0)
                {
                    inputOk = false;
                    Console.WriteLine("Input NON valido: inserire un numero maggiore di 0");
                }

            } while (!inputOk);

            do
            {
                Console.Write("Inserire il secondo numero che si desidera calcolare --> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intSecNumber);
                if (!inputOk)
                {
                    Console.WriteLine("Input NON valido");
                }
                else if (intSecNumber < 0)
                {
                    inputOk = false;
                    Console.WriteLine("Input NON valido: inserire un numero maggiore di 0");
                }

            } while (!inputOk);

            Console.Write($"Il Massimo Comun Divisore tra {intNumber} e {intSecNumber} è ");

            while (intSecNumber != 0)
            {
                int temp = intSecNumber;
                intSecNumber = intNumber % intSecNumber;
                intNumber = temp;
            }

            Console.WriteLine(intNumber);

            Console.WriteLine("\nPremi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}     
        