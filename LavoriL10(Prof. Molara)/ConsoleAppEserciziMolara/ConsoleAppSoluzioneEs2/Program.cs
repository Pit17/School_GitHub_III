using System.ComponentModel.Design;

namespace ConsoleAppSoluzioneEs2
{
    internal class Program
    {
        const int RANGE_MIN = 1;
        const int RANGE_MAX = 100;
        static void Main(string[] args)
        {
            Console.WriteLine("\nOra indovinerò il numero che hai pensato");
            int sx = RANGE_MIN;
            int dx = RANGE_MAX;
            string risposta;
            while (true)
            { 
                int m = (sx + dx) / 2;
                
                while (true)
                {
                    Console.WriteLine("Hai pensato " + m);
                    risposta = Console.ReadLine();
                    if (risposta == "=" || risposta == "<" || risposta == ">") 
                    {
                        break;               
                    }
                  
                }

                if (risposta == ">")
                {
                    sx = m + 1;
                }else if(risposta == "<")
                {
                    dx = m-1;

                }else
                    break;
            }
        }
    }
}