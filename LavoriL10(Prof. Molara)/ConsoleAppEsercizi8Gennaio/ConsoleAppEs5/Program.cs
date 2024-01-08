namespace ConsoleAppEs5
{
    partial class Program
    {
        static int[] generaP(int n)
        {
            int pointer = 0;
            int[] primi = new int[n];
            for (int j = 2; pointer < n; j++)
            {
                bool primo = true;
                for (int i = 2; i < j; i++)
                    if (j % i == 0)
                    {
                        primo = false;
                        break;
                    }
                if (primo) primi[pointer++] = j;
            }

            return primi;

        }
        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero di numeri primi che desidera: ");
            int n = int.Parse(Console.ReadLine());
            int[] numeri = generaP(n);
            for (int i = 0; i < numeri.Length; i++)
                Console.Write(numeri[i] + ", ");
        }
    }

}