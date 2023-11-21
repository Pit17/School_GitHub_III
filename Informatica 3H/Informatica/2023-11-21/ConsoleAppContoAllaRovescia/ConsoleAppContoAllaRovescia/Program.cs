using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Autore Pietro Malzone 3H Numeri 7 digit
namespace ConteggioAllaRovescia
{
    internal class Program
    {
        static string[] cifra_0 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_1 = {
            "       ▓",
            "       ▓",
            "       ▓",
            "        ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_2 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
            "▓       ",
            "▓       ",
            " ▓▓▓▓▓▓ ",
        };
        static string[] cifra_3 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "   ▓▓▓▓▓",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };
        static string[] cifra_4 = {
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "       ▓ ",
        };
        static string[] cifra_5 = {
            " ▓▓▓▓▓▓ ",
            "▓      ",
            "▓      ",
            " ▓▓▓▓▓▓",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };
        static string[] cifra_6 = {
            " ▓▓▓▓▓▓ ",
            "▓       ",
            "▓       ",
            " ▓▓▓▓▓▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };
        static string[] cifra_7 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "       ▓",
            "       ▓",
            "       ▓",
            "       ▓ ",
        };
        static string[] cifra_8 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",

        };
        static string[] cifra_9 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓▓",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };





        static void StampaCifra(string[] cifra,int riga ,int colonna)
        {
                Console.SetCursorPosition(colonna, riga);
            foreach (string s in cifra)
            {
                Console.Write(s);
            }
                
            
        }

        static void Main(string[] args)
        {
            Console.Title = "PietroMalzone3H";
            bool inputOK = true;
            int number;
            string numero;
            string[][] nums = { cifra_0, cifra_1, cifra_2, cifra_3, cifra_4, cifra_5, cifra_6, cifra_7, cifra_8, cifra_9 };
            Console.Write("Scrivere il numero che si desidera stampare: ");
            while (true) 
            { 
                numero = Console.ReadLine();
                inputOK = int.TryParse(numero, out number);
                if (inputOK == true) break;
                else Console.WriteLine("Numero non valido.");
            
            }
            
            for (int j = 0; j < 7; j++)//stampa riga per riga di tutti i  numeri contemporaneamente.
            {
                for (int i = 0; i < numero.Length; i++)
                {
                    Console.Write(nums[numero[i] - 48][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            


            Console.ReadKey();
        }
    }
}
