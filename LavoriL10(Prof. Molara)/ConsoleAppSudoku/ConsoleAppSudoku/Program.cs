using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleAppSudoku
{
    internal class Program
    {
        static bool CheckValid(int[,] board, int ir, int ic, int n)
        {
            

            Debug.Assert(board[ir, ic] == 0, "Casella non vuota");
            Debug.Assert(1 <= n && n <= 9, "Cifra non valida");

            // Verifico la riga
            for (int k = 0; k < 9; ++k)
            {
                if (n == board[ir, k])  
                    return false;
            }

            // Verifico la colonna
            for (int k = 0; k < 9; ++k)
            {
                if (n == board[k, ic]) 
                    return false;
            }

            // Verifico l'intorno
            int base_ir = ir - ir % 3;  
            int base_ic = ic - ic % 3;  
            for (int r = 0; r < 3; ++r)
            {
                for (int c = 0; c < 3; ++c)
                {
                    if (n == board[base_ir + r, base_ic + c])
                        return false;
                }
            }

            return true;  // superati tutti i controlli, la mossa è valida
        }
        static HashSet<int>[,] GetChoices(int[,] board)
        {
            HashSet<int>[,] choices = new HashSet<int>[9, 9];

            
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic)
                {
                    if (board[ir, ic] != 0)
                        continue;  

                    choices[ir, ic] = new HashSet<int>();  
                    for (int n = 1; n <= 9; ++n)
                    {
                        if (CheckValid(board, ir, ic, n))  
                            choices[ir, ic].Add(n);
                    }
                }
            }

            return choices;
        }

        static void Resolve(int[,] board)
        {
            HashSet<int>[,] coiches = GetChoices(board);

         
            int best_ir = -1, best_ic = -1;
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic)
                {
                    
                    if (coiches[ir, ic] == null)
                        continue;
                    Debug.Assert(board[ir, ic] == 0, "Grosso guaio! la GetChoices() non funziona bene");

                    if (best_ir < 0 || coiches[best_ir, best_ic].Count > coiches[ir, ic].Count)
                    {
                        best_ir = ir;
                        best_ic = ic;
                    }
                }
            }

            // Passo base 
            if (best_ir < 0)
            {
                PrintBoard(board);  // Winning schema!
                return;
            }

            // Passo base (B) 
            if (coiches[best_ir, best_ic].Count == 0)
                return;  

            // Passi ricorsivi
            foreach (int n in coiches[best_ir, best_ic])  // tento i valori possibili uno alla volta
            {
                board[best_ir, best_ic] = n;  // fa la mossa
                Resolve(board);
                board[best_ir, best_ic] = 0; // annulla ma mossa fatta
            }
        }
        static void PrintBoard(int[,] board)
        {
            Console.Write("\r\n _____           _       _           ______                _                \r\n/  ___|         | |     | |          | ___ \\              | |               \r\n\\ `--. _   _  __| | ___ | | ___   _  | |_/ /___  ___  ___ | |_   _____ _ __ \r\n `--. \\ | | |/ _` |/ _ \\| |/ / | | | |    // _ \\/ __|/ _ \\| \\ \\ / / _ \\ '__|\r\n/\\__/ / |_| | (_| | (_) |   <| |_| | | |\\ \\  __/\\__ \\ (_) | |\\ V /  __/ |   \r\n\\____/ \\__,_|\\__,_|\\___/|_|\\_\\\\__,_| \\_| \\_\\___||___/\\___/|_| \\_/ \\___|_|   \r\n                                                                            \r\n                                                                            \r\n");
            Console.WriteLine("     ╔═════╦═════╦═════╗  ╔═════╦═════╦═════╗  ╔═════╦═════╦═════╗");
            for (int ir = 0; ir < 9; ++ir)
            {
                if (ir % 3 != 0)
                    Console.WriteLine("     ╠═════╬═════╬═════╣  ╠═════╬═════╬═════╣  ╠═════╬═════╬═════╣");
                if (ir > 0 && ir % 3 == 0)
                    Console.WriteLine("     ╚═════╩═════╩═════╝  ╚═════╩═════╩═════╝  ╚═════╩═════╩═════╝\n     ╔═════╦═════╦═════╗  ╔═════╦═════╦═════╗  ╔═════╦═════╦═════╗");
                Console.Write("     ");
                for (int m = 0; m < 3; ++m)
                {
                    Console.Write("║  ");
                    for (int ic = 0; ic < 3; ++ic)
                    {

                        Console.Write(board[ir, 3*m+ic] + "  ║  ");

                    }
                }
               
                Console.WriteLine();
            }
            Console.WriteLine("     ╚═════╩═════╩═════╝  ╚═════╩═════╩═════╝  ╚═════╩═════╩═════╝");
        }
        static int[,] BoardFromString(string str_board)
        {
            

            int[,] board = new int[9, 9];

            int i = 0;
            for (int ir = 0; ir < 9; ++ir)
            {
                for (int ic = 0; ic < 9; ++ic, ++i)
                {
                    if (i < str_board.Length && '1' <= str_board[i] && str_board[i] <= '9')
                        board[ir, ic] = str_board[i] - '0';
                    else
                        board[ir, ic] = 0;
                }
            }

            return board;
        }

        static void Main(string[] args)
        {
            int[,] board = BoardFromString("006000900200100050004052006401009000005070600000600203700280500010004009002000300");

            Resolve(board);
        }
    }
}