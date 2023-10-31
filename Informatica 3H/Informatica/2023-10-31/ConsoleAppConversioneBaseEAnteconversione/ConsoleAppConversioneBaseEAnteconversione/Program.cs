using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
//Autore Pietro Malzone 3H 31/10/2023 Conversioni e Anticonversioni
namespace ConsoleAppConversioneBaseEAnteconversione
{
    
    internal class Program
    {
        static bool Name()// inserisce nome e title
        {
            Console.Title = "AutorePietroMalzone3H31/10/2023";
            Console.WriteLine("Autore Pietro Malzone 3H 31/10/2023");
            return true;
        }

        static int ToInt(char valore)// converte char a intero.
        {
            {
                if (valore < 58)
                {
                    return valore - 48;
                }
                else
                {
                    return valore - 55;
                }

            }

        }

        static char CharValue(int valore)// converte int to char
        {
            char risultato;
            int digit = valore;
            {
                if (digit < 10)
                {
                    string result = digit.ToString();
                    risultato = result[0];
                }
                else
                {
                    risultato = (char)(digit - 55);
                }
                return risultato;

            }

        }

        static int BaseToInt(string str, int base1)
        {
            if (base1 > 36 || base1 < 2)//identifico errore
            {
                return -90;
            }
            else//oppure converto la stringa
            {
                int valore = 0, exp = 1;
                str = str.ToUpper();
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    valore += exp * ToInt(str[i]);
                    exp *= base1;
                }
                return valore;
            }
        }

        static string IntToBase(int value, int base1) 
        {

            char a;
            string risultato1;
            int resto,differenza;
            if (base1 > 36 || base1 < 2)//identifico errore
            {
                return "ERRORE";
            }
            else//decodifico l'intero in stringa
            {
                do
                {
                    resto = value % base1;
                    a = CharValue(resto);
                    risultato1 = a.ToString();
                    differenza = value / base1;
                    a = CharValue(differenza);
                    risultato1 = a + risultato1;
                } while (value / base1 != 1);


                return risultato1;
            }
            
        }
        static int LetturaIntero(string messaggio)
        {

            int valore;//leggo interi

            while (true)
            {
                Console.Write(messaggio);

                if (int.TryParse(Console.ReadLine(), out valore))

                    break;

                else
                {
                    Console.WriteLine("Errore! Inserire un numero intero");


                }

            }
            return valore;
        }

        static void Main(string[] args)
        {
            Name();
            string lab;
            bool input = false;

            
            while (input == false) {
                Console.Write("Cosa desidera fare?" +
                "\n1) Convertire una stringa in una base da lei desiderata." +
                "\n2) Fornire un valore e convertirlo in intero" +
                "\n --> ");
                lab = Console.ReadLine();
                if (lab == "1")//caso 1
                {
                    string str;
                    int base1,result;
                    
                    Console.WriteLine("Inserisci la stringa:");
                    str = Console.ReadLine();
                    base1 = LetturaIntero("Inserisca la base:");
                    result = BaseToInt(str, base1);
                    if (result == -90)
                    {
                        Console.WriteLine("La base da lei inserita è minore di 2 o maggiore di 36");
                    }
                    else Console.WriteLine($"La stringa {str} in base {base1} è {result}");

                    break;

                } else if (lab == "2")//caso2
                {
                    int base2, value;
                    string result;
                    value = LetturaIntero("Inserisca il valore:");
                    base2 = LetturaIntero("Inserisca la base:");
                    result = IntToBase(value, base2);
                    if (result == "ERRORE")
                    {
                        Console.WriteLine("La base da lei inserita è minore di 2 o maggiore di 36");
                    }
                    else Console.WriteLine($"Il valore {value} in base {base2} è {result}");


                    break;

                } else Console.WriteLine("Inserisca o 1 o 2"); input = false;
            }
            Console.WriteLine("Premere per terminare il programma");//terminare programma
            Console.ReadKey();
        }
    }
}
