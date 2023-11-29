namespace ConsoleAppEsercizioInClasse
{
    internal class Program
    {
        static int ValidazioneInput()
        {
            
            while (true)
            {
                Console.WriteLine("Inserisca N:");
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
            //        Dato n > 0 intero produrre a console il seguente 
            //        "albero binario natalizio"
            //            n = 4 (numero di livelli) 
            //            0
            //       1          2
            //     3   4     5     6      n * 2 +1 sx  / n * 2 +2 dx
            //    7 8 9 10 11 12 13 14

            int n = ValidazioneInput();

        }
    }
}