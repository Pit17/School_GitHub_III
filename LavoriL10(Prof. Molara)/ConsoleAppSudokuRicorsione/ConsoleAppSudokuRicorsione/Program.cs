using System.Diagnostics;
namespace ConsoleAppSudokuRicorsione
{
    internal class Program
    {
        static int[,] schema =
        {
            {0,2,0,0,7,8,5,0,0 },
            {4,0,0,0,5,2,0,0,0 },
            {0,0,1,0,0,3,0,2,0 },

            {0,0,0,0,0,1,0,0,0 },
            {7,3,4,8,0,5,2,6,0 },
            {2,0,9,0,6,7,0,0,5 },

            {0,6,8,7,0,0,3,0,9 },
            {3,4,2,0,1,0,7,0,0 },
            {1,9,0,0,8,6,0,0,2 },
        };
        static bool CheckValid(int ir, int ic, int n)
        {
            //Debug.Assert(schema[ir, ic] == 0, "Casella non vuota");
            //Debug.Assert(1 >= n && n >= 9, "Cifra non valida");
            //verifica se n puo andare in board[ir,ic]
            for (int k = 0; k < 9; k++)
            {
                if (n == schema[ir, k])
                    return false;
            }
            for (int k = 0; k < 9; k++)
            {
                if (n == schema[k, ic])
                    return false;
            }
            int ir_ = ir - ir % 3;
            int ic_ = ic - ic % 3;
            for (int r = 0; r < 3; r++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (n == schema[ir_ + r, ic_ + k])
                        return false;
                }
            }
            return true;
        }

        static HashSet<int>[,] GetChoices()
        {
            HashSet<int>[,] valids = new HashSet<int>[9, 9];

            for (int ir = 0; ir < 9; ir++)
            {
                for (int ic = 0; ic < 9; ic++)
                {
                    if (schema[ir, ic] != 0)
                    {
                        continue;

                    }
                    valids[ir, ic] = new HashSet<int>();
                    for (int n = 0; n <= 9; n++)
                    {
                        if (CheckValid(ir, ic, n))
                            valids[ir, ic].Add(n);
                    }
                }
            }
            return valids;
        }
        static void Resolve()
        {
            int moves_count = 0;
            HashSet<int>[,] choices = GetChoices();
            for (int ir = 0; ir < 9; ir++)
            {
                for (int ic = 0; ic < 9; ic++)
                {
                    if (choices[ir, ic] == null)
                    {
                       //Debug.Assert(schema[ir, ic] != 0, "GUAI");
                        continue;
                    }

                    // controllo 1 passo base
                    if (choices[ir, ic].Count == 0)
                    {
                        // succede se con mossse precendenti è diventato uno schema impossibile

                        return;

                    }
                    //passi ricorsivi
                    foreach(int n in choices[ir, ic])
                    {
                        schema[ir, ic] = n;//mossa
                        Resolve();
                        schema[ir, ic] = 0;//anulla mossa
                        moves_count++;
                    }
                        
                }
               
            }
            if (moves_count == 0) PrintBoard();
        }
        static void PrintBoard()
        {
            for (int ir = 0; ir < 9; ir++)
            {
                for (int ic = 0; ic < 9; ic++)
                {
                    Console.Write(schema[ir, ic] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Resolve();
        }
    }
}