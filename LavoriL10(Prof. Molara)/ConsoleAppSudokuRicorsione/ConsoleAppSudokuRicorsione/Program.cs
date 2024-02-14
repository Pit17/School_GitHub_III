namespace ConsoleAppSudokuRicorsione
{
    internal class Program
    {
        static int[,] schema =
        {
            {0,5,0,0,7,9,0,0,0 },
            {0,0,0,0,0,0,5,0,0 },
            {0,9,2,0,0,0,0,6,0 },

            {0,0,0,0,0,0,0,0,7 },
            {0,2,0,6,0,0,0,1,0 },
            {0,7,0,2,5,0,0,8,0 },

            {0,0,0,0,4,0,0,0,0 },
            {0,0,8,0,2,0,0,0,0 },
            {7,3,0,0,0,1,0,0,0 },
        };
        static bool CheckValid(int ir,int ic, int n)
        {
            //verifica se n puo andare in board[ir,ic]
            for(int k = 0; k < 9; k++)
            {
                if (n == schema[ir, k])
                    return false;
            }
            for(int k = 0; k < 9; k++)
            {
                if (n == schema[k, ic])
                    return false;
            }
            int ir_ = ir / 3 * 3;
            int ic_ = ic / 3 * 3;
            for (int r = 0; r < 3; r++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (n == schema[ir_+r, ic_+k]) 
                        return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            HashSet<int>[,] valids = new HashSet<int>[9, 9];

            for (int ir = 0; ir < 9; ir++)
            {
                for (int ic = 0; ic < 9; ic++)
                {
                    if (schema[ir,ic] != 0)
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
        }
    }
}