namespace Sottoprogrammi
{
    internal class Program
    {
        static int LeggiValoreIntero(string messaggio, int valore_minimo, int valore_massimo)
        {
            int valore;
            while (true)
            {
                Console.Write(messaggio);

                if (!int.TryParse(Console.ReadLine(), out valore))  // errore nella conversione intera?
                    continue;

                if (valore < valore_minimo || valore_massimo < valore)
                {
                    Console.WriteLine($"Valore non valido! (deve essere fra {valore_minimo} e {valore_massimo})");
                    continue;
                }

                break;  // tutto ok!
            }

            return valore;
        }
        static int LeggiValoreIntero_alternativa(string messaggio, int valore_minimo, int valore_massimo)
        {
            while (true)
            {
                Console.Write(messaggio);

                int valore;
                if (!int.TryParse(Console.ReadLine(), out valore))  // errore nella conversione intera?
                    continue;

                if (valore < valore_minimo || valore_massimo < valore)
                {
                    Console.WriteLine($"Valore non valido! (deve essere fra {valore_minimo} e {valore_massimo}");
                    continue;
                }

                return valore;  // la parola chiave 'return' può essere utilizzata in qualunque punto del sottoprogramma
            }
        }

        static void Main(string[] args)
        {
            int ora1 =     LeggiValoreIntero("Inserisci l'orario del primo valore: ", 0, 23);
            int minuti1 =  LeggiValoreIntero("Inserisci i minuti del primo valore: ", 0, 59);
            int secondi1 = LeggiValoreIntero("Inserisci i secondi del primo valore: ", 0, 59);
        }
    }
}