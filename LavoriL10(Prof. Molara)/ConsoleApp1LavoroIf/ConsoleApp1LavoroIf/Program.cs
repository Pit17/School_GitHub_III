namespace ConsoleApp1LavoroIf
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            double soglia1 = 0.15;
            double soglia2 = 0.2;
            double redditoLordo, redditoNetto,imposta;

            Console.Write("\nPerfavore inserisca il proprio reddito lordo --> ");
            redditoLordo = Double.Parse(Console.ReadLine());

            if (redditoLordo > 10000)
            {
                imposta = ((redditoLordo - 10000) * soglia2) + (10000 * soglia1);
                redditoNetto = redditoLordo - imposta;
            }
            else
            {
                imposta = (redditoLordo * soglia1);
                redditoNetto = redditoLordo - imposta;
            }

            Console.WriteLine($"\n Le sono stai sottratti dallo Stato {imposta} euro perciò il suo reddito netto è {redditoNetto} euro");

        }


    }
}