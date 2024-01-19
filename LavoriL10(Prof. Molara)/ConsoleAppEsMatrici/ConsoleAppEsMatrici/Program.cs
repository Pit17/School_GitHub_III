using System.Globalization;

namespace ConsoleAppEsMatrici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quanti alunni sono presenti in classe?");
            int N = leggiNum();
            Console.WriteLine("Quante materie ci sono?");
            int M = leggiNum();
            string[] vettN = new string[N];
            string[] vettM = new string[M];
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Inserisca il nome dell'alunno presente alla posizione n {i + 1}:");
                vettN[i] = Console.ReadLine();
            }
            for (int i = 0; i < M; i++)
            {
                Console.Write($"Inserisca la materia numero {i + 1}:");
                vettM[i] = Console.ReadLine();
            }
            int[,] T1 = new int[N, M];
            int[,] T2 = new int[N, M];
            Console.WriteLine("Inserisca i Voti del 1° quadrimestre");
            T1 = Pagelle(vettN, vettM, N, M);
            Console.WriteLine("Inserisca i Voti del 2° quadrimestre");
            T2 = Pagelle(vettN, vettM, N, M);
            Console.WriteLine("Questa è la media generale del 1° quadrimestre");
            int m1 = mediaTot(T1,N, M);
            Console.WriteLine(m1);
            Console.WriteLine("Questa è la media generale del 2° quadrimestre");
            int m2 = mediaTot(T2, N, M);
            Console.WriteLine(m2);
        }
        static int[,] Pagelle(string[] vettN, string[] vettM, int N, int M)
        {
            int[,] matrix = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.WriteLine($"Inserisca il voto di {vettN[i]} nella seguente materia {vettM[j]}:");
                    matrix[i, j] = leggiVoti();
                }
            }
            return matrix;
        }
        static int leggiNum()
        {
            int n;
            while (true)
            {
               if( int.TryParse(Console.ReadLine(), out n))
                {
                    if (n > 0) break;
                    else Console.WriteLine("Il numero deve essere maggiore di 0");
                }
                else  Console.WriteLine("Numero non valido");
            }
            return n;

        }
        static int leggiVoti()
        {
            int n;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out n);
                if (n > 0 && n < 11) break;
                else Console.WriteLine("Il vot deve essere in numero compreso tra 1 e 10");
            }
            return n;
                
        }
        static int mediaTot(int[,] matrice, int N, int M) 
        {
            int somma = 0;
            int media;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    somma += matrice[i, j];
                }
            }
            media = somma / (N*M);
            return media;

        }

        //static string migliorMedia() { }

        //static int insufficienze() { }

        //static int votoMedio() { }
    }
}