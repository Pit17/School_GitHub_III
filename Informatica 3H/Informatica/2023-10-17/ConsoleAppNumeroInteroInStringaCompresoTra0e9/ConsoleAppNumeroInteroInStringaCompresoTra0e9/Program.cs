using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Autore Pietro Malzone 3H 17/10/2023 Console App conversione da numero intero a numero scritto in una stringa
namespace ConsoleAppNumeroInteroInStringaCompresoTra0e9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Nome
            Console.Title = ("AutorePietroMalzone3H17-10-2023");
            Console.WriteLine("AutorePietroMalzone3H17-10-2023");
            #endregion

            string numeroInLettere = "Non valido",numeroInLettereIf = "non valido";
            int numero;
            bool inputOK;
            string varRead;


            #region input
            do
            {
                Console.WriteLine("\nNOTA BENE: Il valore deve essere compreso tra 0 e 9");
                Console.Write("\nInserisca il valore intero -->");

                varRead = Console.ReadLine();
                inputOK = int.TryParse(varRead, out numero);
                if (!inputOK) Console.WriteLine("\nInput non valido :( \nRiprovi");
                else if (numero < 0 || numero > 9)//verifico sia compresa nel range
                {
                    Console.WriteLine("\nNumeri inferiori  a 0 o superiori a 9 non sono accettati.");
                    inputOK = false;
                }

            } while (!inputOK);
            #endregion

            #region metodo switch
            switch (numero)
            {
                case 0:
                    numeroInLettere = "zero";
                    break;
                case 1:
                    numeroInLettere = "uno";
                    break;
                case 2:
                    numeroInLettere = "due";
                    break;
                case 3:
                    numeroInLettere = "tre";
                    break;
                case 4:
                    numeroInLettere = "quattro";
                    break;
                case 5:
                    numeroInLettere = "cinque";
                    break;
                case 6:
                    numeroInLettere = "sei";
                    break;
                case 7:
                    numeroInLettere = "sette";
                    break;
                case 8:
                    numeroInLettere = "otto";
                    break;
                case 9:
                    numeroInLettere = "nove";
                    break;
            }
            #endregion

            #region metdo if
            if (numero == 0)
            {
                numeroInLettereIf = "zero";
            }
            else if(numero == 1)
            {
                numeroInLettereIf = "uno";
            }
            else if (numero == 2)
            {
                numeroInLettereIf = "due";
            }
            else if (numero == 3)
            {
                numeroInLettereIf = "tre";
            }
            else if (numero == 4)
            {
                numeroInLettereIf = "quattro";
            }
            else if (numero == 5) 
            {
                numeroInLettereIf = "cinque";
            }
            else if (numero == 6)
            {
                numeroInLettereIf = "sei";
            }
            else if (numero == 7) 
            {
                numeroInLettereIf = "sette";
            }
            else if (numero == 8) 
            {
                numeroInLettereIf = "otto";
            }
            else if (numero == 9) 
            {
                numeroInLettereIf = "nove";
            }
            #endregion

            #region output
            Console.WriteLine("\nIl numero in lettere con lo switch è --> " + numeroInLettere);
            Console.WriteLine("\nIl numero in lettere con if è --> " + numeroInLettereIf);
            #endregion

            #region termine del programma
            Console.WriteLine("\n premere un tasto per terminare il programma");
            Console.ReadKey();
            #endregion

        }

    }
}

