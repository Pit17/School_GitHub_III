namespace ConsoleAppEs2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static void ShiftRight(string[] vett, ref int vett_count, int idx)
        {
            if (idx < 0 || vett_count <= idx)
                throw new IndexOutOfRangeException();

            int move_count = vett_count - idx - 1;  // numero di elementi da spostare
            for (int k = 0; k < move_count; ++k)
                vett[idx + k] = vett[idx + k + 1];
            --vett_count;
        }
    }
}