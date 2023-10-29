using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleAppValidazioneDiUnaData
{
    internal class Program

    {

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
            bool InputOk;

            do
            {
                Console.Write(messaggio);
                InputOk = int.TryParse(Console.ReadLine(), out valore);
                if (!InputOk || valore < valoreMin || valore > valoreMax)
                {
                    Console.WriteLine("Errore! Inserimento non valido");
                    InputOk = false;
                }
            } while (!InputOk);

            return valore;
         }

        static bool ValidazioneData()
        {
            bool validazione = false;
            int anno = InputDati("Inserisca l'anno ---> ", 0, int.MaxValue);
            bool bisestile = Bisestile(anno);
            int mese = InputDati("Inserisca il mese -->", 0, 13);
            int giorno = InputDati("Inserisca il giorno --> ", 0, 32);
            switch (mese)
            {
                case 1 or 3 or 5 or 7 or 8 or 10 or 12:
                    if (giorno <= 31) validazione = true;
                    else validazione = false;
                    break;
                    

                case 4 or 6 or 9 or 11:
                    if (giorno <= 30) validazione = true;
                    else validazione = false;
                    break;

                case 2:
                    if (bisestile)
                    {
                        if (giorno <= 29) validazione = true;
                        else validazione = false;
                    }
                    else
                    {
                        if (giorno <= 28) validazione = true;
                        else validazione = false;
                    }
                    break;
                
            }
           return validazione;
        }

        static void Main(string[] args)
        {
          bool validazione = ValidazioneData();
          if (validazione) Console.WriteLine("Data valida");
          else Console.WriteLine("Data non valida");
          Console.ReadKey();
        }
    }
}