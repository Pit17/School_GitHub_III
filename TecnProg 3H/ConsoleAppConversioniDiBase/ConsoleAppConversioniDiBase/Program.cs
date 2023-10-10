using System;

namespace ConsoleAppConversioneDiBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region nome
            Console.Title = ("InputDatiAutorePietroMalzone3H");
            Console.WriteLine("Autore Progetto Pietro Malzone 3H 04/10/2023\n");
            #endregion
            #region Dichiarazioni
            int varInt;
            string stInput;
            #endregion

           /* #region Lettura Intero
            bool inputOk;
            do
            {//leggere valore
                Console.Write("Input valore intero --> ");
                stInput = Console.ReadLine();
                //conversione in intero
                inputOk = int.TryParse(stInput, out varInt);
                if (!inputOk) Console.WriteLine("Input non valido");

            }while (!inputOk);//ricicla se non valido
            #endregion


            
            Console.WriteLine("\nValore inserito = " + varInt);
           
            
            #region conversioni
            Console.WriteLine("Valore in base 10 = " + Convert.ToString(varInt,10));
            Console.WriteLine("Valore in base 16 = " + Convert.ToString(varInt, 16));
            Console.WriteLine("Valore in base 2 = " + Convert.ToString(varInt, 2));
            #endregion
         */




            #region Programma 2
            bool inputOK;
            do
            {//leggere valore
                Console.Write("Input valore intero --> ");
                stInput = Console.ReadLine();
                //conversione in intero
                inputOK = int.TryParse(stInput, out varInt);
                if (!inputOK) Console.WriteLine("Input non valido");

            } while (!inputOK);//ricicla se non valido

            do
            {//leggere valore
                Console.Write("Inserire la base che desidera ricevere (2, 8, 10, 16) --> ");
                stInput = Console.ReadLine();
                //conversione in intero
                inputOK = int.TryParse(stInput, out varInt);
                if (!inputOK) Console.WriteLine("Input non valido");
                if (varInt == 2)//Converto nella base che sceglie l'utente
                {
                    Console.WriteLine("\nValore in base 2 = " + Convert.ToString(varInt, 2));
                }
                else if (varInt == 10)
                {
                    Console.WriteLine("\nValore in base 10 = " + Convert.ToString(varInt, 10));
                }
                else if (varInt == 16)
                {
                    Console.WriteLine("\nValore in base 16 = " + Convert.ToString(varInt, 16));
                }
                else if(varInt == 8){

                    Console.WriteLine("\nValore in base 8 = " + Convert.ToString(varInt, 8));

                }else
                {
                    Console.WriteLine("\nNon ha inserito una base disponibile riprovi");
                    inputOK = false;

                }
            } while (!inputOK);//ricicla se non valido
            #endregion

            #region termine del programma
            Console.WriteLine("\nPremi enter per terminare il programma");
            Console.ReadLine();
            #endregion

        }
    }
}