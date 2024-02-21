namespace ConsoleAppAsciiTable
{
    internal class Program
    {
        //Autore Pietro MAlzone 3H ConsoleApp ASCII non estesa
        static void Main(string[] args)
        {

            string str = "";
            for (int i = 0; i < 33; i++) {
              char c = (char)i;
                if (char.IsWhiteSpace(c))//se null  scrivo null
                {
                    str = "null   ";
                }else if (char.IsControl(c))//se control scrivo control
                {
                    str = "control";
                }
                if (i < 10 )// se minore di 10 lo ident aggiungendo uno spazio
                {
                    str = str + " ";
                }
                if (i == 29 || i == 30 || i == 31 || i == 32)// casi speciali
                {
                    Console.WriteLine($"|  {i}  --> {str} |     |  {i + 33}  --> {c = (char)(i + 33)} |     |  {i + 66} --> {c = (char)(i + 66)} |");

                }
                else //casi normali
                Console.WriteLine($"|  {i}  --> {str} |     |  {i+33}  --> {c=(char)(i+33)} |     |  {i+66} --> {c = (char)(i + 66)} |     |  {i+99}  --> {c = (char)(i + 99)} |");


            }

        }
    }
}