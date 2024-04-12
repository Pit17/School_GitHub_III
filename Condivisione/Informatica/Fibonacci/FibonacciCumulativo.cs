using System;

namespace Fibonacci
{
    class Program
    {
        static long FibonacciRicorsivo(int N)  // produce l'N-esimo numero di fibonacci
        {
            // Passo base (per N == 0 oppure N == 1 il valore di ritorno è 1 per definizione)
            if (N <= 1)
                return 1;

            // Passo ricorsivo (per N >= 2 il valore di ritorno è la somma dei due che precedono)
            long fib_n2 = FibonacciRicorsivo(N - 2);
            long fib_n1 = FibonacciRicorsivo(N - 1);

            return fib_n2 + fib_n1;
        }
        static long FibonacciIterativo(int N)  // produce l'N-esimo numero di fibonacci
        {
            if (N <= 1)  // per N == 0 oppure N == 1 il valore di ritorno è 1 per definizione
                return 1;

            // per N >= 2 il valore di ritorno è la somma dei due che precedono
            long fib = 0;
            long fib0 = 1, fib1 = 1;
            for (int i = 2; i <= N; ++i)
            {
                fib = fib1 + fib0;

                fib0 = fib1;
                fib1 = fib;
            }

            return fib;
        }
        static void Main(string[] args)
        {
            // Calcola e stampa i primi 60 numeri di Fibonacci

            for (int N = 0; N < 60; ++N)
            {
                Console.Write($"N = {N}, ");
                Console.Write($"Fib_ite = {FibonacciIterativo(N)}, ");
                Console.Write($"Fib_ric = {FibonacciRicorsivo(N)}");
                Console.WriteLine();
            }
        }
    }
}