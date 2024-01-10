
namespace ConsoleAppEs7
{
    class Program
    {
        static int[] generaP(int n)
        {
            int pointer = 0;
            int[] primi = new int[n];
            for (int j = 2; pointer < n; j++)
            {
                bool primo = true;
                for (int i = 2; i < j; i++)
                    if (j % i == 0)
                    {
                        primo = false;
                        break;
                    }
                if (primo) primi[pointer++] = j;
            }

            return primi;

        }
        static void Eratostene(int n)
        {
            bool[] primi = new bool[n];

            for (int i = 2; i < n; i++) primi[i] = true;

            for (int i = 2; i < n; i++)
            {
                if (primi[i])
                {
                    for (int j = 2; ; j++)
                    {
                        if (i * j < n) primi[i * j] = false;
                        else break;
                    }

                }

            }

           
        }
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch();
            Console.WriteLine("valori\t\tMetodo 1\tMetodo di Eratostene");

            for (int i = 0; i < 10; i++)
            {
                int valori = 10 * (int)Math.Pow(10,i);
                cronometro.Restart();
                generaP(valori);
                cronometro.Stop();
                double tempo1 = (cronometro.ElapsedMilliseconds)/1000;
                cronometro.Restart();
                Eratostene(valori);
                cronometro.Stop();
                double tempo2 = (cronometro.ElapsedMilliseconds) / 1000;
                Console.WriteLine($"{valori}\t\t{tempo1}\t\t{tempo2}");
                
            }

        }
    }
}