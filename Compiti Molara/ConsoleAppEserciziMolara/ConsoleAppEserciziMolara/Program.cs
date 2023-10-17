using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleAppEserciziMolara
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            char Operatore = ' ';
            

            #region Countdown
            for (int i = 10;i > 0; i--)
            {
                Console.WriteLine("Hai 10 secondi per pensare un numero da 1 a 100");
                Console.WriteLine("\n" + i);
                Thread.Sleep(1000);
                Console.Clear();
                
            }
            #endregion



            Console.WriteLine("\nOra indovinerò il numero che hai pensato");

            numero = 50;

            
            
            while( Operatore != '=' ) 
            {
                Console.Clear();
                Console.WriteLine($"\nIl tuo numero è {numero}");
                Console.WriteLine("\nSe il numero pensato è maggiore inserire il simbolo >, se il numero pensato è minore inserire < se ho indovinato inserisci =");
                Console.Write("Inserisci il simbolo --> ");
                Operatore = Console.ReadKey().KeyChar;
                if( Operatore == '<' && numero > 1 ) 
                {
                    numero--;

                }else if( Operatore == '>' && numero < 100)
                {
                    numero++;
                }

            }
            Console.WriteLine($"\nEvvai ho indovinato stavi pensando al numero:  {numero}");

            Console.WriteLine("\n\nPremere un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
