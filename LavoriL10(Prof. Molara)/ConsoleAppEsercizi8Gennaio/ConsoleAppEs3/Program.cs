namespace ConsoleAppEs3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vett = new int[10];
            for (int i = 0; i < 10;i++)
            {
                vett[i] = i;
            }
            
            if (Ordinato(vett) == true)
            {
                Console.WriteLine("OK");
            }else Console.WriteLine("NO");

        }
        static bool Ordinato(int[] vett)
        {
            for (int k = 0; k < vett.Length - 1; ++k)
            {
                if (vett[k] > vett[k + 1]) return false;
            }
            return true;
        }
    }
}