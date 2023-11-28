namespace ConsoleAppCompiti12_11
{
    internal class Program
    {
        static int InputDati(string messaggio)
        {
            int valore;
            bool InputOk;

            do
            {
                Console.Write(messaggio);
                InputOk = int.TryParse(Console.ReadLine(), out valore);
                if (!InputOk || valore < 0)
                {
                    Console.WriteLine("Errore! Inserimento non valido");
                    InputOk = false;
                }
            } while (!InputOk);

            return valore;
        }


        static void Main(string[] args)
        {
          int n = InputDati("Inserisci il numero: ");
          int somma = 0;
          for (int i = 0; i <= n; i+=5)
          {

            somma += i;

          }
          Console.WriteLine($"La somma dei multipli di 5 è {somma}");
        }
    }

    /*
2
* 2.25    risultato
___double____


2
* (int)2.25    risultato
____int_____


(double)2
* (int)2.9    risultato
_____double________


(int)3.1
* (int)2.9    risultato
______int________


(int)(3.1
* 2.9)    risultato
_______int_________



!(x == 7)    equivale
a _____x != 7_____


!(x < 5)    equivale
a __________x > 5_____________


!(x >=
-3)    equivale a
________x < -3________


!(x < 4
||
20 <= x)    equivale
a _______x > 4 || x < 20_________


!(0 <= x &&
x < 8)    equivale a ____x < 0 || x > 8_____
   */
    
}