using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
//Autore Pietro Malzone 3H 24/10/2023 Console App conversione da numero intero a numero scritto in una stringa
namespace ConsoleAppNumeriInParole
{
    internal class Program
    {
        static void Main(string[] args)
        {
           


            #region Nome
            Console.Title = ("AutorePietroMalzone3H17-10-2023");
            Console.WriteLine("AutorePietroMalzone3H17-10-2023");
            #endregion

            string numeroInLettere = "";
            int numero;
            bool inputOK;
            string varRead;

            #region input
            do
            {
                Console.WriteLine("\nNOTA BENE: Il valore deve essere compreso tra 0 e 9999");
                Console.Write("\nInserisca il valore intero -->");

                varRead = Console.ReadLine();
                inputOK = int.TryParse(varRead, out numero);
                if (!inputOK) Console.WriteLine("\nInput non valido :( \nRiprovi");
                else if (numero < 0 || numero > 9999)//verifico sia compresa nel range
                {
                    Console.WriteLine("\nNumeri inferiori  a 0 o superiori a 9999 non sono accettati.");
                    inputOK = false;
                }

            } while (!inputOK);
            #endregion

            
            if (numero == 0)//caso 0
            {

                numeroInLettere = "zero";

            }
            else // numero > di 0
            {

                #region miglialia
                switch (numero / 1000)
                {
                    case 1:
                        numeroInLettere += "mille";
                        break;
                    case 2:
                        numeroInLettere += "duemila";
                        break;
                    case 3:
                        numeroInLettere += "tremila";
                        break;
                    case 4:
                        numeroInLettere += "quattromila";
                        break;
                    case 5:
                        numeroInLettere += "cinquemila";
                        break;
                    case 6:
                        numeroInLettere += "seimila";
                        break;
                    case 7:
                        numeroInLettere += "settemila";
                        break;
                    case 8:
                        numeroInLettere += "ottomila";
                        break;
                    case 9:
                        numeroInLettere += "novemila";
                        break;
                    default:
                        break;

                }
                #endregion

                #region centinaia
                switch (numero / 100 % 10)
                {
                    case 1:
                        numeroInLettere += "cento";
                        break;
                    case 2:
                        numeroInLettere += "duecento";
                        break;
                    case 3:
                        numeroInLettere += "trecento";
                        break;
                    case 4:
                        numeroInLettere += "quattrocento";
                        break;
                    case 5:
                        numeroInLettere += "cinquecento";
                        break;
                    case 6:
                        numeroInLettere += "seicento";
                        break;
                    case 7:
                        numeroInLettere += "settecento";
                        break;
                    case 8:
                        numeroInLettere += "ottocento";
                        break;
                    case 9:
                        numeroInLettere += "novecento";
                        break;
                    default:
                        break;
                }
                #endregion

                #region decine
                switch (numero / 10 % 10)
                {
                    case 1:

                        switch (numero % 100)//casi speciali
                        {
                            case 10:
                                numeroInLettere += "dieci";
                                break;
                            case 11:
                                numeroInLettere += "undici";
                                break;
                            case 12:
                                numeroInLettere += "dodici";
                                break;
                            case 13:
                                numeroInLettere += "tredici";
                                break;
                            case 14:
                                numeroInLettere += "quattordici";
                                break;
                            case 15:
                                numeroInLettere += "quindici";
                                break;
                            case 16:
                                numeroInLettere += "sedici";
                                break;
                            case 17:
                                numeroInLettere += "diciasette";
                                break;
                            case 18:
                                numeroInLettere += "diciotto";
                                break;
                            case 19:
                                numeroInLettere += "diciannove";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        numeroInLettere += "venti";
                        break;
                    case 3:
                        numeroInLettere += "trenta";
                        break;
                    case 4:
                        numeroInLettere += "quaranta";
                        break;
                    case 5:
                        numeroInLettere += "cinquanta";
                        break;
                    case 6:
                        numeroInLettere += "sessanta";
                        break;
                    case 7:
                        numeroInLettere += "settanta";
                        break;
                    case 8:
                        if(numero /100 %10 != 0)
                        {
                            numeroInLettere = numeroInLettere.Substring(0, numeroInLettere.Length - 1);
                        }
                        
                        numeroInLettere += "ottanta";
                        break;
                    case 9:
                        numeroInLettere += "novanta";
                        break;
                    default:
                        break;
                }
                #endregion

                #region unità
                if (numero / 10 % 10 != 1)
                {
                    switch (numero % 10)
                    {
                        case 1:
                            if (numero / 10 % 10 != 0)
                            {
                                numeroInLettere = numeroInLettere.Substring(0, numeroInLettere.Length - 1);
                                
                            }
                            numeroInLettere += "uno";
                            break;

                        case 2:
                            numeroInLettere += "due";
                            break;
                        case 3:
                            numeroInLettere += "tre";
                            break;
                        case 4:
                            numeroInLettere += "quattro";
                            break;
                        case 5:
                            numeroInLettere += "cinque";
                            break;
                        case 6:
                            numeroInLettere += "sei";
                            break;
                        case 7:
                            numeroInLettere += "sette";
                            break;
                        case 8:
                            if (numero / 10 % 10 != 0)
                            {
                                numeroInLettere = numeroInLettere.Substring(0, numeroInLettere.Length - 1);
                                
                            }
                            numeroInLettere += "otto";
                            break;

                        case 9:
                            numeroInLettere += "nove";
                            break;
                        default
                            :
                            break;
                    }
                }
                #endregion

            }


            #region output
            Console.WriteLine("Il numero in lettere è --> " + (numeroInLettere));
            #endregion


            #region termine del programma
            Console.WriteLine("\n premere un tasto per terminare il programma");
            Console.ReadKey();
            #endregion


        }
    }
}
