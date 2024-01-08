namespace ConsoleAppEs6
{
    partial class Program
    {
        static void Eratostene(int n)
        {
            bool[] primi = new bool[n];

            for (int i = 2; i < n; i++) primi[i] = true;

            for (int i = 2; i < n; i++)
            {
                if (primi[i]) 
                {
                    for (int j = 2; ; j++)
                    {
                        if (i * j < n) primi[i * j] = false;
                        else break;
                    }
                        
                }
                    
            }

            for (int i = 0; i < n; i++) if (primi[i]) Console.Write(i + " ");
        }
        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero fino a cui stampare numeri primi: ");
            int n = int.Parse(Console.ReadLine());
            Eratostene(n);
        }
    }
}