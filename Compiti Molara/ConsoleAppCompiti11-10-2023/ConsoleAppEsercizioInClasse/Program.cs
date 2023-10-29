
//programma di Daniele Broccoli

using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        #region Variable and Constant Declaration
        double notTaxedIncome;
        double taxedIncome;
        double taxToPay = 0;
        string stInput;
        string stInput2;
        string stInput3;
        bool inputOk;
        const int LIMITTEN = 10000;
        const int LIMITUNTILFIFTEEN = 5000;
        const int LIMITOVERFIFTEEN = 15000;
        const int ALIUNTILTEN = 15;
        const int ALIOVERTENUNTILFIFTEEN = 20;
        const int ALIOVERFIFTEEN = 23;
        int hours, minutes, seconds;
        int hours2, minutes2, seconds2;
        #endregion

        /*#region Reading and Checking Input
        do
        {
            Console.Write("Inserisci il tuo reddito lordo annuo --> ");
            stInput = Console.ReadLine();

            inputOk = double.TryParse(stInput, out notTaxedIncome);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (notTaxedIncome < 0.00001)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un reddito valido!");
                inputOk = false;
            }
        } while (!inputOk);

        #endregion

        #region Tax Calculation
        if (notTaxedIncome <= LIMITTEN)
        {
            taxToPay = notTaxedIncome / 100 * ALIUNTILTEN;
        }
        else if (notTaxedIncome > LIMITTEN && notTaxedIncome <= LIMITOVERFIFTEEN)
        {
            taxToPay += LIMITTEN / 100 * ALIUNTILTEN;
            taxToPay += (notTaxedIncome - LIMITTEN) / 100 * ALIOVERTENUNTILFIFTEEN;
        }
        else
        {
            taxToPay += LIMITTEN / 100 * ALIUNTILTEN;
            taxToPay += LIMITUNTILFIFTEEN / 100 * ALIOVERTENUNTILFIFTEEN;
            taxToPay += (notTaxedIncome - LIMITOVERFIFTEEN) / 100 * ALIOVERFIFTEEN;
        }

        taxedIncome = notTaxedIncome - taxToPay;

        Console.Clear();
        Console.WriteLine($"Il tuo reddito annuale pulito è {taxedIncome}€, le tasse pagate sono {taxToPay}€");
        #endregion

        Console.WriteLine("\n\nPremi Enter per continuare con il programma...");
        Console.ReadLine();
        Console.Clear();
        */
        #region Times Input
        do
        {
            Console.Write("Inserisci il primo valore per le ore --> ");
            stInput = Console.ReadLine();

            inputOk = int.TryParse(stInput, out hours);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (hours <= 0 || hours > 24)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un'ora valida!");
                inputOk = false;
            }
        } while (!inputOk);

        do
        {
            Console.Write("Inserisci il primo valore per i minuti --> ");
            stInput2 = Console.ReadLine();

            inputOk = int.TryParse(stInput2, out minutes);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (minutes < 0 || minutes >= 60)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un minutaggio valido!");
                inputOk = false;
            }
        } while (!inputOk);

        do
        {
            Console.Write("Inserisci il primo valore per i secondi --> ");
            stInput3 = Console.ReadLine();

            inputOk = int.TryParse(stInput3, out seconds);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (seconds < 0 || seconds >= 60)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un numero di secondi valido!");
                inputOk = false;
            }
        } while (!inputOk);

        Console.Clear();

        do
        {
            Console.Write("Inserisci il secondo valore per le ore --> ");
            stInput = Console.ReadLine();

            inputOk = int.TryParse(stInput, out hours2);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (hours2 <= 0 || hours2 > 24)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un'ora valida!");
                inputOk = false;
            }
        } while (!inputOk);

        do
        {
            Console.Write("Inserisci il secondo valore per i minuti --> ");
            stInput2 = Console.ReadLine();

            inputOk = int.TryParse(stInput2, out minutes2);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (minutes2 < 0 || minutes2 >= 60)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un minutaggio valido!");
                inputOk = false;
            }
        } while (!inputOk);

        do
        {
            Console.Write("Inserisci il secondo valore per i secondi --> ");
            stInput3 = Console.ReadLine();

            inputOk = int.TryParse(stInput3, out seconds2);

            if (!inputOk)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserisci un valore numerico valido!");
            }
            else if (seconds2 < 0 || seconds2 >= 60)
            {
                Console.Clear();
                Console.WriteLine("ERRORE! Inserire un numero di secondi valido!");
                inputOk = false;
            }
        } while (!inputOk);

        #endregion

        #region Conversion,Calculus and Output
        int firstTime = hours * 3600 + minutes * 60 + seconds;
        int secondTime = hours2 * 3600 + minutes2 * 60 + seconds2;

        int finalTime;

        if (firstTime > secondTime)
        {
            finalTime = firstTime - secondTime;
        }
        else
        {
            finalTime = secondTime - firstTime;
        }

        int finalHours = (int)(finalTime / 3600);
        int finalMinutes = (int)((finalTime - finalHours * 3600) / 60);
        int finalSeconds = (int)(finalTime - finalHours * 3600 - finalMinutes * 60);

        Console.Clear();
        Console.WriteLine($"La differenza equivale a {finalHours} ore {finalMinutes} minuti e {finalSeconds} secondi!");
        #endregion


        Console.WriteLine("\nPremi Enter per terminare il programma...");
        Console.ReadKey();
    }
}
