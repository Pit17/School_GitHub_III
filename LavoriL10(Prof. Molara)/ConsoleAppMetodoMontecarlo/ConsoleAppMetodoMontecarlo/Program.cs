using System.Drawing;
using System.Security.Cryptography;

namespace ConsoleAppMetodoMontecarlo
{//Pietro Malzone 3H Programma metodo Montecarlo
    internal class Program
    {
        const double LATO = 1.0;

        static void Main(string[] args)
        {
            Random rnd = new Random();
           
            long NTOT = 1;
            for (long j = 10; j < 100000000000; j*=10) {

                long NInterni = 0;
                NTOT = j;
         
            
                for (long i = 0; i < NTOT; i++)
                {
                    double y = rnd.NextDouble() * LATO;
                    double x = rnd.NextDouble() * LATO;
                    if ((x*x) + (y*y) <= (LATO*LATO)) NInterni++;

                }
                double stima_PI = 4.0 *((double)NInterni / (double)NTOT);
            
                Console.WriteLine($"N totale = {NTOT} || Pi_greco = {stima_PI} || punti dentro = {NInterni} || esterni ={NTOT - NInterni}");
            
            }
            Console.ReadKey();
        }
    }
}