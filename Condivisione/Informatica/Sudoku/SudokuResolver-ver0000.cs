using System.Collections.Generic;

namespace SudokuResolver
{
    internal class Program
    {
        static int[,] board = {
            { 0,5,0, 0,7,9, 0,0,0 },
            { 0,0,0, 0,0,0, 5,0,0 },
            { 0,9,2, 0,0,0, 0,6,0 },

            { 0,8,0, 0,0,0, 4,0,7 },
            { 0,2,0, 6,0,0, 0,1,0 },
            { 0,7,0, 2,5,0, 0,8,0 },

            { 0,0,0, 0,4,0, 0,0,0 },
            { 0,0,8, 0,2,0, 0,0,0 },
            { 7,3,0, 0,0,1, 0,0,0 },
        };
        static bool CheckValid(int ir, int ic, int n)
        {
            // Verifica se 'n' può andare in board[ir, ic] senza violare le regole

            // Esempio : CheckValid(0, 0, 7) --> false (c'è già sia nella riga che nella colonna)
            // Esempio : CheckValid(0, 0, 9) --> false (c'è già nella riga, c'è già nell'intorno)
            // Esempio : CheckValid(0, 0, 2) --> false (c'è già nella riga, c'è già nell'intorno)

            // Verifico la riga
            for (int k = 0; k < 9; ++k)
            {
                if (n == board[ir, k])  // già presente?
                    return false;
            }

            // Verifico la colonna
            for (int k = 0; k < 9; ++k)
            {
                if (n == board[k, ic])  // già presente?
                    return false;
            }

            // Verifico l'intorno
            int base_ir = ir/3*3;  // diventa 0, 3 oppure 6
            int base_ic = ic/3*3;  // diventa 0, 3 oppure 6
            for (int r = 0; r < 3; ++r)
            {
                for (int c = 0; c < 3; ++c)
                {
                    if (n == board[base_ir+r, base_ic+c])
                        return false;
                }
            }

            return true;  // superati tutti i controlli, la mossa è valida
        }
        static void Main(string[] args)
        {
            HashSet<int>[,] valids = new HashSet<int>[9, 9];

            // Costruisce le scelte per il board[,] corrente
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic)
                {
                    if (board[ir, ic] != 0) // se la cella è già piena...
                        continue;  // ... salto la cella

                    valids[ir, ic] = new HashSet<int>();  // crea l'insieme vuoto
                    for (int n = 1; n <= 9; ++n)
                    {
                        if (CheckValid(ir, ic, n))  // se il numero può entrare nella cella ...
                            valids[ir, ic].Add(n);
                    }
                }
            }
        }
    }
}
