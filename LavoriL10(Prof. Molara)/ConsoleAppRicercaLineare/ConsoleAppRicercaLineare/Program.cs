namespace ConsoleAppRicercaLineare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] elenco = { "Marco", "Lucia", "Giorgio", "Pamela", "Antonio", "Carla", "Fabio" };
            Console.Write("\nInserisca il nome che desidera verificare -->");
            string nome = Console.ReadLine();
            bool flag = false;
            int i;

            for (i = 0; i < elenco.Length; i++)
            {
                if (elenco[i].ToUpper() == nome.ToUpper())
                {
                    flag = true;
                    break;
                }
                
            }
            if (flag == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Il nome {nome} è alla posizione: {i + 1}");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Il nome {nome} non è in elenco.");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}