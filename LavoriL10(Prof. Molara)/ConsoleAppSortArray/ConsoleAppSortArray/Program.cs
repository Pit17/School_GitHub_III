using System.Security.AccessControl;

namespace ConsoleAppSortArray
{
    internal class Program
    {
        static void Ordinamento1(int[] vett , int n)
        {
            

            for (int i = 0; i <= vett.Length - 1; i++)
            {
                int j_min = i;
                for (int j = i +1; j < vett.Length; j++)
                {
                    if (vett[j_min] > vett[j]) j_min = j;
                }
                 if (i != j_min)
                 {
                    int aus = vett[i];
                    vett[i] = vett[j_min];
                    vett[j_min] = aus;
                 }   
                    
                        

                   
                Console.Write(vett[i] + " ");
            }
        }
        static int ValidazioneInput(string testo)
        {
            while (true)
            {
                Console.Write($"Inserisca {testo}");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    if (n >= 0) return n;
                    else Console.WriteLine("Il valore deve essre maggiore di 0");
                }
                else Console.WriteLine("Il valore deve essere intero");
            }
        }
        static void Main(string[] args)
        {
         
           int n = (ValidazioneInput("grandezza vettore: "));
            int[] vettore = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                vettore[i] = ValidazioneInput("il numero: ");
            }
            Ordinamento1(vettore, n);
        }
    }
}