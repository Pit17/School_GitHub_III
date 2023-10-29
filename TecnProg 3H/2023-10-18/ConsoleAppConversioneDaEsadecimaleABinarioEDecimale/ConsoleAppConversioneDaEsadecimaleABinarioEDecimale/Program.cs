using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
//Malzone Pietro 3H 25/10/2023 ConsoleApp per convertire un valore esadecimale con massimo due cifre in binario e decimale utilizzando il metodo illustrato in teoria
namespace ConsoleAppConversioneDaEsadecimaleABinarioEDecimale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region nome
            Console.Title = ("InputDatiAutoreMalzonePietro3H18/10/2023");
            Console.WriteLine("Autore Progetto Malzone Pietro 3H 18/10/2023\n");
            #endregion

            #region dichiarazioni
            int varInt,numero, numeroH;
            string stInput, risultatoBase2 = "", risultatoBase10 = "";
            bool inputOk = false;
            #endregion



            for (int i = 0; i < 3; i++)
            {
                #region Lettura Intero
                do
                {//leggere valore
                    Console.Write("Inserire valore esadecimale una cifra alla volta e con un massimo di due cifre --> ");
                    stInput = Console.ReadLine();
                    if (stInput != "0")
                    {
                        if (stInput != "1")
                        {
                            if (stInput != "2")
                            {
                                if (stInput != "3")
                                {
                                    if (stInput != "4")
                                    {
                                        if (stInput != "5")
                                        {
                                            if (stInput != "6")
                                            {
                                                if (stInput != "7")
                                                {
                                                    if (stInput != "8")
                                                    {
                                                        if (stInput != "9")
                                                        {
                                                            stInput = stInput.ToUpper();
                                                            if (stInput == "A")
                                                            {
                                                                numero = 10;
                                                                inputOk = true;
                                                            }
                                                            else if (stInput == "B")
                                                            {
                                                                numero = 11;
                                                                inputOk = true;
                                                            }
                                                            else if (stInput == "C")
                                                            {
                                                                numero = 12;
                                                                inputOk = true;
                                                            }
                                                            else if (stInput == "D")
                                                            {
                                                                numero = 13;
                                                                inputOk = true;
                                                            }
                                                            else if (stInput == "E")
                                                            {
                                                                numero = 14;
                                                                inputOk = true;
                                                            }
                                                            else if (stInput == "F")
                                                            {
                                                                numero = 15;
                                                                inputOk = true;
                                                            }
                                                            else Console.WriteLine("Deve inserire una lettera compresa tra A ed F incluse"); inputOk = false;

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //conversione in intero
                        inputOk = int.TryParse(stInput, out varInt);
                        if (varInt < 0 || varInt > 9)
                        {
                            Console.WriteLine("Numeri negativi o maggiori di 9 non validi. Riprovi");
                            inputOk = false;
                        }
                        if (!inputOk) Console.WriteLine("Input non valido");
                    }
                
                }

            } while (!inputOk);//ricicla se non valido
            #endregion
        }
    }
}
