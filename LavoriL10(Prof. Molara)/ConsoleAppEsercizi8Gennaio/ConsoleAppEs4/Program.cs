namespace ConsoleAppEs4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quanti nomi desidera inserire?");
            int lenght = int.Parse(Console.ReadLine());
            string[] names = new string[lenght];
            int[] ages = new int[lenght];
            for (int i = 0; i < lenght; i++)
            {
                Console.WriteLine("Inserire il nome");
                names[i] = Console.ReadLine();
                Console.WriteLine($"Inserire l'età di {names[i]}");
                ages[i] = int.Parse(Console.ReadLine());
                if (ages[i] < 0)
                {
                    Console.WriteLine("L'età non può essere negativa ricominiciare l'aggiunta dell'ultimo utente");
                    i--;
                }
            }
            int n = ages.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                   
                    if (ages[j] > ages[j + 1])
                    {
                        
                        int tempEta = ages[j];
                        ages[j] = ages[j + 1];
                        ages[j + 1] = tempEta;

                        string tempNome = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tempNome;
                    }
                }
            }

            
            Console.WriteLine("Lista ordinata in base all'età:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{names[i]} - {ages[i]} anni");
            }
        }
    }
}
