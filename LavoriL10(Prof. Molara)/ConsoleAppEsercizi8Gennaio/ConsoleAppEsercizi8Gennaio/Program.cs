using System.Reflection;
using System.Security.Principal;

namespace ConsoleAppEsercizi8Gennaio
{
    internal class Program
    {
        static void Main()
        {
          
            string principale = "Precipitevolissimevolmente";
            string sottostringa = "cione";

            int risultato = Sottostringa(principale, sottostringa);

            if (risultato != -1)
            {
                Console.WriteLine($"La sottostringa \"{sottostringa}\" è presente nella stringa principale a partire dall'indice {risultato}.");
            }
            else
            {
                Console.WriteLine($"La sottostringa \"{sottostringa}\" non è presente nella stringa principale (\"{principale}\").");
            }
        }

        static int Sottostringa(string principale, string sottostringa)
        {
            int indice = principale.IndexOf(sottostringa);
            return indice;
        }
    }

}
