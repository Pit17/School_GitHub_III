using System.Net.Security;

namespace PrimitivePerVettori
{
    partial class Program
    {
        static void Main(string[] args)
        {
            VettoreDiStringhe nomi = new VettoreDiStringhe(1);
            
            if (nomi.IsEmpty())
                Console.WriteLine("In questo momento non ci sono nomi nella lista");
            nomi.Add("Lucia");
            nomi.Add("Paolo");
            nomi.Add("Marco");
            nomi.Add("Carla");

            nomi.InsertAt( 1, "Luigi");
            nomi.EraseFrom(1);

            nomi.Sort();

            string nome = "Marco";
            int idx = nomi.Find(nome);
            if (idx >= 0)
                Console.WriteLine($"Il nome '{nome}' è in posizione {idx+1}");
            else
                Console.WriteLine($"Il nome '{nome}' non è presente");
        }
    }
}
