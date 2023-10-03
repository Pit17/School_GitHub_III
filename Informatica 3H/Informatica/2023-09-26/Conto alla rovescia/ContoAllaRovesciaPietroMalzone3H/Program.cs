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
            Console.Title = "Programma Conto Alla Rovescia Autore Pietro Malzone 3H";
            Console.WriteLine("Malzone Pietro 3H");
            Console.WriteLine("Conto alla rovescia");

           #region numero 9
            Console.Write("          ▒▒▒▒▒▒▒▒▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("        ▒▒          ▒▒\n");
            Console.Write("          ▒▒▒▒▒▒▒▒▒▒\n");
            Console.Write("                    ▒▒\n");
            Console.Write("                    ▒▒\n");
            Console.Write("                    ▒▒\n");
            Console.Write("                    ▒▒\n");
            Console.Write("          ▒▒▒▒▒▒▒▒▒▒\n");
#endregion
            Console.CursorVisible = false; // rimuove cursore che lampeggia
            Console.WriteLine("Aspetta 1 secondo poi dopo il Beep a 4000 Hz scenderà");

            Thread.Sleep(500);
            Console.Beep(4000, 500);

           #region numero 8
            Console.SetCursorPosition(8, 8);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 9);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 10);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 11);
            Console.Write("▒▒");
            #endregion


            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 7

            Console.SetCursorPosition(8, 3);
            Console.Write("  ");
            Console.SetCursorPosition(8, 4);
            Console.Write("  ");
            Console.SetCursorPosition(8, 5);
            Console.Write("  ");
            Console.SetCursorPosition(8, 6);
            Console.Write("  ");

            Console.SetCursorPosition(9, 7);
            Console.Write("                   ");

            Console.SetCursorPosition(8, 8);
            Console.Write("  ");
            Console.SetCursorPosition(8, 9);
            Console.Write("  ");
            Console.SetCursorPosition(8, 10);
            Console.Write("  ");
            Console.SetCursorPosition(8, 11);
            Console.Write("  ");

            Console.SetCursorPosition(9, 12);
            Console.Write("                   ");
#endregion

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 6
            Console.SetCursorPosition(8, 3);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 4);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 5);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 6);
            Console.Write("▒▒");

            Console.SetCursorPosition(20, 3);
            Console.Write("  ");
            Console.SetCursorPosition(20, 4);
            Console.Write("  ");
            Console.SetCursorPosition(20, 5);
            Console.Write("  ");
            Console.SetCursorPosition(20, 6);
            Console.Write("  ");

            Console.SetCursorPosition(8, 8);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 9);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 10);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 11);
            Console.Write("▒▒");

            Console.SetCursorPosition(9, 7);
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

            Console.SetCursorPosition(9, 12); 
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

#endregion
            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 5
            Console.SetCursorPosition(8, 8);
            Console.Write("  ");
            Console.SetCursorPosition(8, 9);
            Console.Write("  ");
            Console.SetCursorPosition(8, 10);
            Console.Write("  ");
            Console.SetCursorPosition(8, 11);
            Console.Write("  ");
            Console.SetCursorPosition(9, 12);
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

            #endregion

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 4
            Console.SetCursorPosition(9, 12);
            Console.Write("            ");

            Console.SetCursorPosition(9, 2);
            Console.Write("            ");

            Console.SetCursorPosition(20, 3);
            Console.Write("▒▒");
            Console.SetCursorPosition(20, 4);
            Console.Write("▒▒");
            Console.SetCursorPosition(20, 5);
            Console.Write("▒▒");
            Console.SetCursorPosition(20, 6);
            Console.Write("▒▒");


            #endregion

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 3
            Console.SetCursorPosition(9, 2);
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

            Console.SetCursorPosition(9, 12);
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

            Console.SetCursorPosition(8, 3);
            Console.Write("  ");
            Console.SetCursorPosition(8, 4);
            Console.Write("  ");
            Console.SetCursorPosition(8, 5);
            Console.Write("  ");
            Console.SetCursorPosition(8, 6);
            Console.Write("  ");
            #endregion

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 2
            Console.SetCursorPosition(8, 8);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 9);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 10);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 11);
            Console.Write("▒▒");

            Console.SetCursorPosition(20, 8);
            Console.Write("  ");
            Console.SetCursorPosition(20, 9);
            Console.Write("  ");
            Console.SetCursorPosition(20, 10);
            Console.Write("  ");
            Console.SetCursorPosition(20, 11);
            Console.Write("  ");
            #endregion

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 1
            Console.SetCursorPosition(8, 8);
            Console.Write("  ");
            Console.SetCursorPosition(8, 9);
            Console.Write("  ");
            Console.SetCursorPosition(8, 10);
            Console.Write("  ");
            Console.SetCursorPosition(8, 11);
            Console.Write("  ");

            Console.SetCursorPosition(20, 8);
            Console.Write("▒▒");
            Console.SetCursorPosition(20, 9);
            Console.Write("▒▒");
            Console.SetCursorPosition(20, 10);
            Console.Write("▒▒");
            Console.SetCursorPosition(20, 11);
            Console.Write("▒▒");

            Console.SetCursorPosition(9, 2);
            Console.Write("                   ");

            Console.SetCursorPosition(9, 7);
            Console.Write("                   ");

            Console.SetCursorPosition(9, 12);
            Console.Write("                   ");


            #endregion

            Thread.Sleep(500);
            Console.Beep(4000, 500);

            #region numero 0

            Console.SetCursorPosition(9, 2);
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

            Console.SetCursorPosition(9, 12);
            Console.Write(" ▒▒▒▒▒▒▒▒▒▒");

            Console.SetCursorPosition(8, 3);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 4);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 5);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 6);
            Console.Write("▒▒");

            Console.SetCursorPosition(8, 8);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 9);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 10);
            Console.Write("▒▒");
            Console.SetCursorPosition(8, 11);
            Console.Write("▒▒");

            #endregion

            Console.Beep(4000, 500);
            Console.Beep(4000, 500);
            Console.Beep(4000, 500);
        }
    }
}
