using System.Reflection.Metadata.Ecma335;

namespace ConsoleAppValidazioneDiUnaData
{
    internal class Program

    {
        static int ValidazioneData()
        {
            bool validazione = false;
            int anno = InputDati("Inserisca l'anno ---> ",0,int.MaxValue);
            bool bisestile = Bisestile(anno);
            int mese = InputDati("Inserisca il mese -->", 0, 13);
            int giorno = InputDati("Insersica il giorno --> ", 0, 32);
            if (mese == 11 || mese == 9 || mese == 6 || mese = 4)
            {
                if (giorno <= 30) validazione = true;
            }
            if (mese == 2) 
            { 
               if (bisestile == true)
                {
                    if(giorno <= 29) validazione = true;
                }
               else
                {
                    if (giorno <= 28) validazione = true;
                }
            }
        
        }
        static bool Bisestile(int anno) 
        {
            bool bisestile; 
            if (anno % 4 != 0) bisestile = false;

            else if (anno % 1000 == 0) bisestile = true;

            else if (anno % 100 == 0) bisestile = false; 

            else bisestile = true;

            return bisestile;
            
        }
        static int InputDati(string messaggio, int valoreMin, int valoreMax)
        {
            int valore;
            while (true)
            {
                Console.Write(messaggio);
                if (int.TryParse(Console.ReadLine(), out valore))
                    continue;

                if (valore < valoreMin || valore > valoreMax)
                    continue;


                break;
            }
            return valore;

         }
        static void Main(string[] args)
        {
          
        }
    }
}