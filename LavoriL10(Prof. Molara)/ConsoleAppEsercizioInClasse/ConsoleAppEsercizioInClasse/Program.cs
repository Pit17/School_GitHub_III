namespace ConsoleAppEsercizioInClasse
{
    internal class Program
    {
        static int ValidazioneInput()
        {
            
            while (true)
            {
                Console.Write("Inserisca N:");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    if (n > 0) return n;
                    else Console.WriteLine("Il valore deve essre maggiore di 0");
                }
                else Console.WriteLine("Il valore deve essere intero");
            }
        }
        static void Main(string[] args)
        {

            int n = ValidazioneInput();
            int k = 0;
            int giri = 1, contatore = 0;

            for (int i = 1; i < Math.Pow(2,n); i++)
            {
                for (int j = 0; j < Math.Pow(2,n - contatore) -1; j++) Console.Write(" ");

                Console.Write(i-1);

                for (int j = 0; j < Math.Pow(2, n - contatore) - 1; j++) Console.Write(" ");


                if (giri == i)
                {
                    contatore++;
                    Console.WriteLine();
                    giri = giri * 2 + 1;
                }
                

            }

        }
    }
}