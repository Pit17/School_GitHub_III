using System;
using System.Diagnostics;

namespace Cache_Tester
{
    class Program
    {
        const long DEFAULT_N_LOOPS = 100;
        static void MatrixReader(byte[,] matrix, bool scan_by_rows)
        {
            int max_rows = matrix.GetLength(0);
            int max_cols = matrix.GetLength(1);

            byte unused = 0;

            if (scan_by_rows)
            {
                for (int row = 0; row < max_rows; ++row)
                    for (int col = 0; col < max_cols; ++col)
                        unused = matrix[row, col];
            }
            else
            {
                for (int col = 0; col < max_cols; ++col)
                    for (int row = 0; row < max_rows; ++row)
                        unused = matrix[row, col];
            }
        }

        static void MatrixWriter(byte[,] matrix, byte value, bool scan_by_rows)
        {
            int max_rows = matrix.GetLength(0);
            int max_cols = matrix.GetLength(1);

            if (scan_by_rows)
            {
                for (int row = 0; row < max_rows; ++row)
                    for (int col = 0; col < max_cols; ++col)
                        matrix[row, col] = value;
            }
            else
            {
                for (int col = 0; col < max_cols; ++col)
                    for (int row = 0; row < max_rows; ++row)
                        matrix[row, col] = value;
            }
        }

        static void SetupScheduler(int n_core)
        {
            Process Proc = Process.GetCurrentProcess();
            ProcessThread thread = Proc.Threads[0];
            thread.IdealProcessor = n_core;
            thread.ProcessorAffinity = (IntPtr)(n_core + 1);
        }

        static string FormatSize(long size)
        {
            if (size >= 1024L * 1024L * 1024L * 1024L)
                return $"{(double)size / (double)(1024L * 1024L * 1024L * 1024L):0.#} TB";
            if (size >= 1024L * 1024L * 1024L)
                return $"{(double)size / (double)(1024L * 1024L * 1024L):0.#} GB";
            if (size >= 1024L * 1024L)
                return $"{(double)size / (double)(1024L * 1024L):0.#} MB";
            if (size >= 1024L)
                return $"{(double)size / (double)(1024L):0.#} KB";
            return $"{size} B";
        }

        static string FormatTime(double seconds)
        {
            if (seconds < 1E-9)
                return $"{seconds * 1e12:0.#} picosec";
            if (seconds < 1E-6)
                return $"{seconds * 1e9:0.#} nanosec";
            if (seconds < 1E-3)
                return $"{seconds * 1e6:0.#} microsec";
            if (seconds < 1E-0)
                return $"{seconds * 1e3:0.#} ms";
            return $"{seconds:0.#} s";
        }
        static void PrintResult(string title, double milliseconds, long matrix_len)
        {
            double seconds = milliseconds / 1000;
            Console.WriteLine("{0} : mean total time = {1} | mean byte time = {2}"
                             , title
                             , FormatTime(milliseconds)
                             , FormatTime(milliseconds / (double)matrix_len));
        }

        static void PrintUsage()
        {
            Console.WriteLine("Cache-Tester <number of rows> <number of cols> [<number of loops>]");
            Console.WriteLine();
            Console.WriteLine("             <number of rows> = number of rows in the int[,] matrix");
            Console.WriteLine("             <number of cols> = number of columns in the int[,] matrix");
            Console.WriteLine("             <number of loops> = (opzional) how many times to execute each test. Defaults to {}", DEFAULT_N_LOOPS);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintUsage();
                return;
            }

            long n_rows;
            if (!long.TryParse(args[0], out n_rows))
            {
                Console.WriteLine("Parameter <number of rows> : not a valid integer number");
                return;
            }

            long n_cols;
            if (!long.TryParse(args[1], out n_cols))
            {
                Console.WriteLine("Parameter <number of cols> : not a valid integer number");
                return;
            }

            long n_loops = DEFAULT_N_LOOPS;
            if (args.Length > 2  &&  !long.TryParse(args[2], out n_loops))
            {
                Console.WriteLine("Parameter <number of n_loops> : not a valid integer number");
                return;
            }

            byte[,] matrix = new byte[n_rows, n_cols];
            var watch = new System.Diagnostics.Stopwatch();

            Console.WriteLine($"Matrix : {n_rows} rows x {n_cols} cols = {FormatSize(matrix.LongLength)}");

            SetupScheduler(0);

            watch.Restart();
            for (int i = 0; i < n_loops; ++i)
                MatrixReader(matrix, true);
            watch.Stop();
            PrintResult("Read access by-rows", (double)watch.ElapsedMilliseconds / (double)n_loops, matrix.LongLength);

            watch.Restart();
            for (int i = 0; i < n_loops; ++i)
                MatrixReader(matrix, false);
            watch.Stop();
            PrintResult("Read access by-cols", (double)watch.ElapsedMilliseconds / (double)n_loops, matrix.LongLength);

            watch.Restart();
            for (int i = 0; i < n_loops; ++i)
                MatrixWriter(matrix, (byte)i, true);
            watch.Stop();
            PrintResult("Write access by-rows", (double)watch.ElapsedMilliseconds / (double)n_loops, matrix.LongLength);

            watch.Restart();
            for (int i = 0; i < n_loops; ++i)
                MatrixWriter(matrix, (byte)i, false);
            watch.Stop();
            PrintResult("Write access by-cols", (double)watch.ElapsedMilliseconds / (double)n_loops, matrix.LongLength);
        }
    }
}
