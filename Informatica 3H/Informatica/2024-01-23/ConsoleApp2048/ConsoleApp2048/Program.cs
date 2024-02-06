using System.Text.Json.Nodes;

namespace ConsoleApp2048
{
    internal class Program
    {
        static Random rnd = new Random();
        static int[,] matrix =
        {
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 }
        };
        static void CopiaMatrix()
        {
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 0)   
                        Console.Write($"      ");
                    else
                        Console.Write($"{1 << matrix[i, j],6}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }
        static void MuoviSinistra()
        {
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for(int j = 0  ; j < matrix.GetLength(1);j++)
                {

                }
                int ic_dest = 0;
                int ic_sorg = 0;
                for (; ic_sorg < matrix.GetLength(1); ic_sorg++)
                {
                    if (matrix[i,ic_sorg] != 0)
                    {
                        matrix[i,ic_dest++]= matrix[i,ic_sorg];
                        matrix[i, ic_sorg] = 0;
                    }
                }
            }
        }
        static void MuoviDestra()
        {

        }
        static void MuoviBasso()
        {

        }
        static void MuoviAlto()
        {

        }
        static void Main(string[] args)
        {
            generatore(rnd.Next(1, 3));
            generatore(rnd.Next(1, 3));
            while(true)
            {
                CopiaMatrix();
                ConsoleKey key = LeggiTasto();
                switch (key)
                {
                    case ConsoleKey.LeftArrow: MuoviSinistra(); break;
                    case ConsoleKey.RightArrow: MuoviDestra(); break;
                    case ConsoleKey.UpArrow: MuoviAlto(); break;
                    case ConsoleKey.DownArrow: MuoviBasso(); break;
                }
                if (!generatore(rnd.Next(1, 3)))
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("GAME OVER");
        }
        
        static bool generatore(int esponente)
        {
            int count_vuoti =0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0) count_vuoti++;
                }
            }
            if (count_vuoti == 0) return false;
            int count = rnd.Next(count_vuoti);
            for (int i = 0; i < matrix.GetLength(0) ; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) ; j++)
                {
                    if (matrix[i,j] != 0)
                    {
                        continue;
                    }
                    if (count--  == 0)
                    {
                        matrix[i,j] = esponente;
                        return true;
                    }
                }
            }
            return false;
           
        }
        static ConsoleKey LeggiTasto()
        {
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    return key.Key;
                }
            }
            
        }

    }
}