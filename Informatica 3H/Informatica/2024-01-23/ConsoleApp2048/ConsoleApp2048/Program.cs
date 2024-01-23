

using System.Net.NetworkInformation;

namespace ConsoleApp2048
{
    internal class Program
    {
        
        static int points = 0;
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
            Console.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 0)   
                        Console.Write($"      ");
                    else {
                        switch (matrix[i, j])
                        {
                            case 1: Console.ForegroundColor = ConsoleColor.White; break;
                            case 2: Console.ForegroundColor = ConsoleColor.Yellow; break;
                            case 3: Console.ForegroundColor = ConsoleColor.Magenta; break;
                            case 4: Console.ForegroundColor = ConsoleColor.Red; break;
                            case 5: Console.ForegroundColor = ConsoleColor.Cyan; break;
                            case 6: Console.ForegroundColor = ConsoleColor.Green; break;
                            case 7: Console.ForegroundColor = ConsoleColor.Blue; break;
                            case 8: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                            case 9: Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                            case 10: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                            case 11: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                        }
                        Console.Write($"{1 << matrix[i, j],6}");
                    }
                        
                }
                Console.WriteLine();
                Console.WriteLine();
               
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Punti: {points}");
        }
        static void MuoviSinistra()
        {
            for (int i = 0; i < 4; i++)
            {
                int free = 0, last = 0, lastSum = -1;

                for (int j = 0; j < 4; j++)
                    if (matrix[i, j] != 0)
                    {
                        if (j != 0)
                        {
                            if (matrix[i, j] == matrix[i, last])
                            {
                                if (last != lastSum)
                                {
                                    matrix[i, last] ++;
                                    points += 1 << matrix[i, last];
                                    matrix[i, j] = 0;
                                    lastSum = last;
                                }
                                else
                                    if (free != j)
                                {
                                    matrix[i, free] = matrix[i, j];
                                    matrix[i, j] = 0;
                                    last = free++;
                                }


                            }
                            else
                            {
                                if (free != j)
                                {
                                    matrix[i, free] = matrix[i, j];
                                    matrix[i, j] = 0;
                                }
                                last = free++;
                            }
                        }
                        else free++;

                    }
            }
        }
        static void MuoviDestra()
        {
            for (int i = 0; i < 4; i++)
            {
                int free = 3, last = 3, lastSum = -1;

                for (int j = 3; j >= 0; j--)
                    if (matrix[i, j] != 0)
                    {
                        if (j != 3)
                        {
                            if (matrix[i, j] == matrix[i, last])
                            {
                                if (last != lastSum)
                                {
                                    matrix[i, last] ++;
                                    points += 1 << matrix[i, last];
                                    matrix[i, j] = 0;
                                    lastSum = last;
                                }
                                else
                                    if (free != j)
                                {
                                    matrix[i, free] = matrix[i, j];
                                    matrix[i, j] = 0;
                                    last = free--;
                                }
                            }
                            else
                            {
                                if (free != j)
                                {
                                    matrix[i, free] = matrix[i, j];
                                    matrix[i, j] = 0;
                                }
                                last = free--;
                            }
                        }
                        else free--;
                    }
            }
        }
    
        static void MuoviBasso()
        {
            for (int i = 0; i < 4; i++)
            {
                int free = 3, last = 3, lastSum = -1;

                for (int j = 3; j >= 0; j--)
                    if (matrix[j, i] != 0)
                    {
                        if (j != 3)
                        {
                            if (matrix[j, i] == matrix[last, i])
                            {
                                if (last != lastSum)
                                {
                                    matrix[last, i] ++;
                                    points += 1 << matrix[i, last];
                                    matrix[j, i] = 0;
                                    lastSum = last;
                                }
                                else
                                    if (free != j)
                                {
                                    matrix[free, i] = matrix[j, i];
                                    matrix[j, i] = 0;
                                    last = free--;
                                }

                            }
                            else
                            {
                                if (free != j)
                                {
                                    matrix[free, i] = matrix[j, i];
                                    matrix[j, i] = 0;
                                }
                                last = free--;
                            }
                        }
                        else free--;


                    }
            }
        }
        static void MuoviAlto()
        {
            
                for (int i = 0; i < 4; i++)
                {
                    int free = 0, last = 0, lastSum = -1;

                    for (int j = 0; j < 4; j++)
                        if (matrix[j, i] != 0)
                        {
                            if (j != 0)
                            {
                                if (matrix[j, i] == matrix[last, i])
                                {
                                    if (last != lastSum)
                                    {
                                        matrix[last, i] ++;
                                        points += 1 << matrix[i, last];
                                        matrix[j, i] = 0;
                                        lastSum = last;
                                    }
                                    else
                                        if (free != j)
                                    {
                                        matrix[free, i] = matrix[j, i];
                                        matrix[j, i] = 0;
                                        last = free++;
                                    }
                                }
                                else
                                {
                                    if (free != j)
                                    {
                                        matrix[free, i] = matrix[j, i];
                                        matrix[j, i] = 0;
                                    }
                                    last = free++;
                                }
                            }
                            else free++;

                        }
                }
            
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
            int count_vuoti = 0;
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