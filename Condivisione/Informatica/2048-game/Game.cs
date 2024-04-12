namespace _2048
{
    internal class Game
    {
        static int[,] board = {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
        };

        static Random rnd = new Random();
        static bool PiazzaCellaCasuale(int esponente)
        {
            // Fase 1: conta il numero di posti liberi
            int conta_liberi = 0;
            for (int ir = 0; ir < board.GetLength(0); ++ir)
            {
                for (int ic = 0; ic < board.GetLength(1); ++ic)
                {
                    if (board[ir, ic] == 0)
                        ++conta_liberi;
                }
            }

            if (conta_liberi == 0)
                return false;

            // Fase 2: piazza il valore voluto
            int count = rnd.Next(conta_liberi);
            for (int ir = 0; ir < board.GetLength(0); ++ir)
            {
                for (int ic = 0; ic < board.GetLength(1); ++ic)
                {
                    if (board[ir, ic] != 0)  // ignora le celle piene
                        continue;

                    if (count-- == 0)  // se count è azzerato, quella è la cella individuata
                    {
                        board[ir, ic] = esponente;
                        return true;  // è stato possibile piazzare l'esponente voluto
                    }
                }
            }

            return false;  // board[] è pieno!
        }
        static ConsoleKey LeggiTasto()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow
                    || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    return key.Key;
                }
            }
        }
        static void CopiaBoardSuConsole()
        {
            Console.WriteLine("-------------");
            for (int ir = 0; ir < board.GetLength(0); ++ir)
            {
                Console.WriteLine();
                for (int ic = 0; ic < board.GetLength(1); ++ic)
                {
                    if (board[ir, ic] == 0)
                        Console.Write("    ");
                    else 
                        Console.Write($"{(int)Math.Pow(2, board[ir, ic]),4}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static void MuoviSinistra() { /* TODO */ }
        static void MuoviDestra() { /* TODO */ }
        static void MuoviAlto() { /* TODO */ }
        static void MuoviBasso() { /* TODO */ }

        static void Main(string[] args)
        {
            PiazzaCellaCasuale(rnd.Next(1, 3));
            PiazzaCellaCasuale(rnd.Next(1, 3));
            while (true)
            {
                CopiaBoardSuConsole();

                ConsoleKey key = LeggiTasto();
                switch (key)
                {
                    case ConsoleKey.LeftArrow: MuoviSinistra(); break;
                    case ConsoleKey.RightArrow: MuoviDestra(); break;
                    case ConsoleKey.UpArrow: MuoviAlto(); break;
                    case ConsoleKey.DownArrow: MuoviBasso(); break;
                }

                if (!PiazzaCellaCasuale(rnd.Next(1, 3)))  // se non può entrare una nuova cella, allora è game-over
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Game Over!");
        }
    }
}
