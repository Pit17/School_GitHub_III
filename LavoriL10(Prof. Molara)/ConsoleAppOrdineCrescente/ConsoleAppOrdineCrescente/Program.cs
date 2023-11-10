namespace ConsoleAppOrdineCrescente
{
    internal class Program//Autore Pietro Malzone 10/11/2023
    {
        static void Main(string[] args)
        {

            Console.Title = "AutorePietroMalzone3H";
            int a, b, c;
            Console.ForegroundColor = ConsoleColor.Yellow;
            
                Console.WriteLine("Inserisca il primo dato");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisca il secondo dato");
                b = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisca il terzo dato");
                c = int.Parse(Console.ReadLine());// acquisizione input

#if true
                if (a >= b && b >= c) Console.WriteLine($"{c}, {b}, {a}");//casistiche possibili
                else if (a >= c && c >= b) Console.WriteLine($"{b}, {c}, {a}");
                else if (b >= a && a >= c) Console.WriteLine($"{c}, {a}, {b}");
                else if (b >= c  && c >= a) Console.WriteLine($"{a}, {c}, {b}");
                else if (c >= b && b >= a) Console.WriteLine($"{a}, {b}, {c}");
                else if (c >= a && a >= b) Console.WriteLine($"{b}, {a}, {c}");
#endif
                Console.WriteLine("          __");//disegno simpatico
                Console.WriteLine("         /  |");
                Console.WriteLine("        /   |");
                Console.WriteLine("+-------|   |");
                Console.WriteLine("|___|   |   |");
                Console.WriteLine("|___|       |");
                Console.WriteLine("|___|       |");
                Console.WriteLine("|___|_______+");

                Console.ReadKey();
            
        }
    }
}