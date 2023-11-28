using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
//Autore Pietro Malzone 3H 28/11/2023
namespace ConsoleAppTombola
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.Title = "Autore_Pietro_Malzone_3H";
            bool program = true;
            int numero,estrazioni=0;
            bool[] vector = new bool[90];
            Console.Write("+--------------------------------------+\n");
            Console.Write("|                                      |\n");
            Console.Write("|    Benvenuto nel programma Tombola   |\n");
            Console.Write("|                                      |\n");
            Console.Write("+--------------------------------------+\n");
            Console.WriteLine();
            for (int i = 0; i < vector.Length; i++)
            {


                if (vector[i] == false)
                {
                    Console.Write("XX");
                    Console.Write(" ");
                }


                if ((i + 1) % 10 == 0) Console.WriteLine();


            }
            while (program == true && estrazioni<=90)
            {
                Console.WriteLine("Premere '1' per estrarre un numero");
                Console.WriteLine("Premere '2' per verificare una cinquina");
                Console.WriteLine("Premere '3' per verificare una decina");
                Console.WriteLine("Premere '4' per verificare una Tombola");
                Console.WriteLine("Premere '5' per uscire dal programma");
                #region acquisizione input
                while (true)
                {

                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        if (numero > 0 && numero < 6) break;
                    }
                    else Console.WriteLine("Valore non valido");
                }
                #endregion

                switch (numero)//inizo delle funzionalità
                {
                    case 1:
                        int numeroEstratto = Estrazione(vector);
                        estrazioni++;
                        Console.Clear();
                        Console.WriteLine($"E' uscito il numero {numeroEstratto}");
                        AggiornaTabellone(numeroEstratto, vector);
                        break;
                    case 2:
                        bool verifica5 = VerificaCinquina(vector);
                        if (verifica5 == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("La cinquina e' valida.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La cinquina non e' valida.");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        bool verifica10 = VerificaDecina(vector);
                        if (verifica10 == true)
                        {
                            Console.WriteLine("La decina e' valida.");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La decina non e' valida.");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        bool verifica15 = VerificaTombola(vector);
                        if (verifica15 == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("La tombola e' valida.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La tombola non e' valida.");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                            program = false;
                            break;
                }
            }

            
        }

        static int Estrazione(bool[] vector)//estrae numero casuale tra 1 e 90
        {
            Random rnd = new Random();
            int numero_estratto = rnd.Next(1, 91);
            while (true)
            {
                if (vector[numero_estratto - 1] == false) break;
                else numero_estratto = rnd.Next(1, 91);
            }
            return numero_estratto;
        }
        static int AggiornaTabellone(int numero_estratto, bool[] vector)//prova per aggiornare il tabellone all'estrazione
        {
            Console.Write("+--------------------------------------+\n");
            Console.Write("|                                      |\n");
            Console.Write("|    Benvenuto nel programma Tombola   |\n");
            Console.Write("|                                      |\n");
            Console.Write("+--------------------------------------+\n");
            Console.WriteLine();
            vector[numero_estratto - 1] = true;

            for (int i = 0; i < vector.Length; i++)
            {


                if (vector[i] == false)
                {
                    Console.Write("XX");
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(i+1);
                    Console.Write(" ");
                }


                if ((i + 1) % 10 == 0) Console.WriteLine();


            }
            return 1;
        }

        static bool VerificaCinquina(bool[] vector)//verifica se è uscita una cinquina
        {
            bool result = false;
            int numero = 0,contatore=0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Inserire il {i + 1} numero da verificare");
                while (true)
                {

                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        if (numero > 0 && numero < 90) break;
                    }
                    else Console.WriteLine("Valore non valido");

                   
                    
                   
                }
                if (vector[numero - 1] == true) contatore++;

        
            }   
            if (contatore == 5) result = true;
            return result;
        }

        static bool VerificaDecina(bool[] vector)//verifica se è uscita una decina
        {
            bool result = false;
            int numero = 0, contatore = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Inserire il {i + 1} numero da verificare");
                while (true)
                {

                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        if (numero > 0 && numero < 90) break;
                    }
                    else Console.WriteLine("Valore non valido");




                }
                if (vector[numero - 1] == true) contatore++;


            }
            if (contatore == 10) result = true;
            return result;
        }
        static bool VerificaTombola(bool[] vector)//verifica se è uscita una Tombola
        {
            bool result = false;
            int numero = 0, contatore = 0;
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Inserire il {i + 1} numero da verificare");
                while (true)
                {

                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        if (numero > 0 && numero < 90) break;
                    }
                    else Console.WriteLine("Valore non valido");




                }
                if (vector[numero - 1] == true) contatore++;


            }
            if (contatore == 15) result = true;
            return result;
        }

        
    }
}

