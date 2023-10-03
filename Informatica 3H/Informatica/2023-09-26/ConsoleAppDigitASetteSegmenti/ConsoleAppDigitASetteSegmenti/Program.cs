using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// Pietro Malzone 3H 26/09/2023
namespace ConsoleAppDigitASetteSegmenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = ("ConsoleAppDigitASetteSegmentiAutorePietroMAlzone3H");
            Console.WriteLine("Malzone Pietro 3H 26/09/2023");
            Console.WriteLine("Digit display a 7 segmenti\n");

            Console.Write("          ▒▒▒▒▒▒▒▒▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("          ▒▒▒▒▒▒▒▒▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("          ▒▒▒▒▒▒▒▒▒▒\n");

            Console.WriteLine("Aspetta 5 secondi poi dopo il beep a 4000 Hz e avrai 9");

            Thread.Sleep(5000);
            Console.Beep(4000, 500);

            Console.SetCursorPosition(8, 9);
            Console.WriteLine("            ▒▒");
            Console.SetCursorPosition(8, 10);
            Console.WriteLine("            ▒▒");
            Console.SetCursorPosition(8, 11);
            Console.WriteLine("            ▒▒");
            Console.SetCursorPosition(8, 12);
            Console.WriteLine("            ▒▒");
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("   ▒▒▒▒▒▒▒▒▒▒");

            Console.WriteLine("\nPremi un tasto per continuare");


            Console.ReadKey(); 
        }
    }
}
