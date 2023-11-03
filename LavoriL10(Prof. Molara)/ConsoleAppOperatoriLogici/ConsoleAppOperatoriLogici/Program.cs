namespace ConsoleAppOperatoriLogici
{
    internal class Program
    {


        static bool AND()
        {
            bool A = true, B = true, C = true;
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        A = false;
                        B = false;
                        Console.WriteLine($"{A}  | {B}    | {A && B}");
                        break;

                    case 2:
                        A = false;
                        B = true;
                        Console.WriteLine($"{A}  | {B}   | {A && B}");
                        break;

                    case 3:
                        A = true;
                        B = false;
                        Console.WriteLine($"{A}  | {B}   | {A && B}");
                        break;

                    case 4:
                        A = true;
                        B = true;
                        Console.WriteLine($"{A}  | {B}   | {A && B}");
                        break;
                }

            }
            return C;
        }

        static bool OR()
        {

            bool A = true, B = true, C = true;
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        A = false;
                        B = false;
                        Console.WriteLine($"{A}  | {B}  | {A || B}");
                        break;

                    case 2:
                        A = false;
                        B = true;
                        Console.WriteLine($"{A}  | {B}   | {A || B}");
                        break;

                    case 3:
                        A = true;
                        B = false;
                        Console.WriteLine($"{A}  | {B}  | {A || B}");
                        break;

                    case 4:
                        A = true;
                        B = true;
                        Console.WriteLine($"{A}  | {B}   | {A || B}");
                        break;
                }

            }
            return C;
        }

        static bool XOR()
        {

            bool A = true, B = true, C = true;
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        A = false;
                        B = false;
                        Console.WriteLine($"{A}  | {B}  | {A != B}");
                        break;

                    case 2:
                        A = false;
                        B = true;
                        Console.WriteLine($"{A}  | {B}  | {A != B}");
                        break;

                    case 3:
                        A = true;
                        B = false;
                        Console.WriteLine($"{A}  | {B}   | {A != B}");
                        break;

                    case 4:
                        A = true;
                        B = true;
                        Console.WriteLine($"{A}  | {B}   | {A != B}");
                        break;
                }

            }
            return C;
        }


        static bool NOT()
        {
            bool A = true, C = true;
            for (int i = 1; i < 3; i++)
            {
                switch (i)
                {
                    case 1:
                        A = false;
                        Console.WriteLine($"{A}  | {!A}");
                        break;

                    case 2:
                        A = true;
                        Console.WriteLine($"{A} | {!A}");
                        break;

                }
            }
            return C;
        }
        static void Main(string[] args)
        {
            AND();
            OR();
            XOR();
            NOT();
        }
    }
}