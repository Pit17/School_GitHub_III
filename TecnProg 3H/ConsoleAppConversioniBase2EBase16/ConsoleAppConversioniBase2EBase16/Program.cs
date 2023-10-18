using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
//Malzone Pietro 3H 18/10/2023 ConsoleApp per convertire un intero in base 2 e 16 utilizzando il metodo illustrato in teoria
namespace ConsoleAppConversioniBase2EBase16
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
            int varInt ,numero;
            string stInput, risultato = "", risultatoBase16 = "";
            bool inputOk;
            #endregion

            #region Lettura Intero
            do
            {//leggere valore
                Console.Write("Input valore intero --> ");
                stInput = Console.ReadLine();
                //conversione in intero
                inputOk = int.TryParse(stInput, out varInt);
                if (varInt < 0)
                {
                    Console.WriteLine("Numeri negativi non valido. Riprovi");
                    inputOk = false;
                }
                if (!inputOk) Console.WriteLine("Input non valido");

            } while (!inputOk);//ricicla se non valido
            #endregion

            numero = varInt;// conversione base 2
            do
            {
               
                risultato = (numero % 2).ToString() + risultato;
                numero /= 2;
               

            } while (numero > 0);



            numero = varInt;
            do//conversione base 16
            {
                if (numero % 16  == 10)
                {
                    risultatoBase16 = "A" + risultatoBase16;
                }else if (numero % 16 == 11)
                {
                    risultatoBase16 = "B" + risultatoBase16;
                }
                else if(numero % 16 == 12)
                {
                    risultatoBase16 = "C" + risultatoBase16;
                }else if (numero % 16 == 13)
                {
                    risultatoBase16 = "D" + risultatoBase16;
                }
                else if (numero % 16 == 14)
                {
                    risultatoBase16 = "E" + risultatoBase16;
                }
                else if (numero % 16 == 15)
                {
                    risultatoBase16 = "F" + risultatoBase16;
                }
                else
                {
                    risultatoBase16 = (numero % 16).ToString() + risultatoBase16;
                }

                numero /= 16;
            } while (numero > 0);


            Console.WriteLine("\nValore inserito = " + varInt);
            Console.WriteLine("\nValore inserito base 2 = " + risultato);//risultati
            Console.WriteLine("\nValore inserito base 16 = " + risultatoBase16);

            #region termine del programma
            Console.WriteLine("\nPremi enter per terminare il programma");
            Console.ReadLine();
            #endregion
        }
    }
}
