//Autore Malzone Pietro 3H 11/10/2023 Compiti  per prof Molara11/10/2023 Es2
namespace ConsoleAppCompiti_Es2_11_10_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double soglia1 = 0.15;
            double soglia2 = 0.2;
            double soglia3 = 0.23;
            double redditoLordo, redditoNetto = 0, imposta = 0;

            Console.Write("\nPerfavore inserisca il proprio reddito lordo --> ");
            redditoLordo = Double.Parse(Console.ReadLine());

            if (redditoLordo > 10000 && redditoLordo < 15000)
            {
                imposta = ((redditoLordo - 10000) * soglia2) + (10000 * soglia1);
                redditoNetto = redditoLordo - imposta;
            }
            else if (redditoLordo < 10000)
            {
                imposta = (redditoLordo * soglia1);
                redditoNetto = redditoLordo - imposta;
            }
            else if (redditoLordo > 15000)
            {
                imposta = ((redditoLordo - 10000) * soglia2) + (10000 * soglia1) + (redditoLordo - 15000) * soglia3;
                redditoNetto = redditoLordo - imposta;
            }

            Console.WriteLine($"\n Le sono stai sottratti dallo Stato {imposta} euro perciò il suo reddito netto è {redditoNetto} euro");


            Console.WriteLine("\n Premere un tasto per terminare il programma");
            Console.ReadLine();
        }
    }
}