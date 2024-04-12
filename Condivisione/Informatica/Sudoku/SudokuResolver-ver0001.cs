using System.Collections.Generic;
using System.Diagnostics;

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

            Debug.Assert(board[ir, ic] == 0, "Casella non vuota");
            Debug.Assert(1 <= n  &&  n <= 9, "Cifra non valida");

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
            int base_ir = ir - ir%3;  // diventa 0, 3 oppure 6
            int base_ic = ic - ic%3;  // diventa 0, 3 oppure 6
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
        static HashSet<int>[,] GetChoices()
        {
            HashSet<int>[,] choices = new HashSet<int>[9, 9];

            // Costruisce le scelte per il board[,] corrente
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic)
                {
                    if (board[ir, ic] != 0) // se la cella è già piena...
                        continue;  // ... salto la cella

                    choices[ir, ic] = new HashSet<int>();  // crea l'insieme vuoto
                    for (int n = 1; n <= 9; ++n)
                    {
                        if (CheckValid(ir, ic, n))  // se il numero può entrare nella cella ...
                            choices[ir, ic].Add(n);
                    }
                }
            }

            return choices;
        }

        static void Resolve()
        {
            int moves_count = 0;

            HashSet<int>[,] coiches = GetChoices();
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic)
                {
                    // (coiches[ir, ic] == null) se e solo se (board[ir, ic] != 0)
                    if (coiches[ir, ic] == null)
                    {
                        Debug.Assert(board[ir, ic] != 0, "Grosso guaio! la GetChoices() non funziona bene");
                        continue;
                    }
                    Debug.Assert(board[ir, ic] == 0, "Grosso guaio! la GetChoices() non funziona bene");

                    // Controllo uno dei passi base
                    if (coiches[ir, ic].Count == 0)  // Succede se, con mosse precedenti, abbiamo reso lo schema impossibile
                        return;  // occorre "tornare indetro" annullando una più mosse fatte

                    // Passi ricorsivi
                    foreach (int n in coiches[ir, ic])  // tento i valori possibili uno alla volta
                    {
                        board[ir, ic] = n;  // fa la mossa
                        Resolve();
                        board[ir, ic] = 0; // annulla ma mossa fatta

                        ++moves_count;
                    }
                }
            }

            if (moves_count == 0)
                PrintBoard();
        }
        static void PrintBoard()
        {
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic)
                {
                    Console.Write(board[ir, ic]);
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
