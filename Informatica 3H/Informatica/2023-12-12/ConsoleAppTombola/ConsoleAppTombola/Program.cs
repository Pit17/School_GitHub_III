using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
//Autore Pietro Malzone 3H 12/12/2023
namespace ConsoleAppTombola
{
    internal class Program
    {

        static bool stampaScheda = false;//utilizzo due variabili globali
        static string schedina = "";

        #region main
        static void Main(string[] args)
        {
            
            Console.Title = "Autore_Pietro_Malzone_3H";//Autore e inializzazione variabili e titolo
            bool program = true;
            int numero,estrazioni=0;
            bool[] vector = new bool[90];
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("╔══════════════════════════════════════╗\n");
            Console.Write("║                                      ║\n");
            Console.Write("║  T O M B O L A   N A T A L I Z I A   ║\n");
            Console.Write("║                                      ║\n");
            Console.Write("╚══════════════════════════════════════╝\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < vector.Length; i++)
            {


                if (vector[i] == false)//tabellone iniziale a video
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♣♣");
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                }


                if ((i + 1) % 10 == 0) Console.WriteLine();


            }
            while (program == true && estrazioni<90)
            {
                Console.WriteLine();//possibili scelte stampate a video
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Premere '1' per estrarre un numero");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Premere '2' per verificare una cinquina (Non bisogna inserire numeri uguali)");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Premere '3' per verificare una decina (Non bisogna inserire numeri uguali)");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Premere '4' per verificare una Tombola (Non bisogna inserire numeri uguali)");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Premere '5' per generare una schedina");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Premere '6' per uscire dal programma");
                Console.ForegroundColor = ConsoleColor.White;
                #region acquisizione input
                char choice = Console.ReadKey(true).KeyChar;
                #endregion

                switch (choice)//inizo delle funzionalità dove ogni case chiama una funzione che solge quel lavoro
                {
                    case '1'://estrae un numero tramite funzione
                        int numeroEstratto = Estrazione(vector);
                        estrazioni++;
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"E' uscito il numero {numeroEstratto}");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        AggiornaTabellone(numeroEstratto, vector);
                        break;
                    case '2'://verifica cinquina tramite funzione
                        bool verifica5 = VerificaCinquina(vector);
                        if (verifica5 == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("La cinquina e' valida.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La cinquina non e' valida.");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '3'://verifica decina tramite funzione
                        bool verifica10 = VerificaDecina(vector);
                        if (verifica10 == true)
                        {
                            Console.WriteLine("La decina e' valida.");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La decina non e' valida.");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '4'://verifica tombola tramite funzione
                        bool verifica15 = VerificaTombola(vector);
                        if (verifica15 == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("La tombola e' valida.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La tombola non e' valida.");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '5'://genero schedina tramite funzione
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Schedina();
                        Console.WriteLine(schedina);//stampo la schedina a video
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '6'://esco dal programma
                            program = false;
                            break;
                    default: //in caso di valore non valido lo segnalo a video
                        Console.WriteLine("Scelta non valida");
                        break;
                }

            }
            if (estrazioni == 90)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSono usciti tutti i numeri ☻ ");
                Console.ReadKey();
            }


            
        }
        #endregion

        #region Estrazione
        static int Estrazione(bool[] vector)//estrae numero casuale tra 1 e 90
        {

            Random rnd = new Random();
            int numero_estratto = rnd.Next(1, 91);
            while (true)
            {

                if (vector[numero_estratto - 1] == false) break;//se il numero è già uscito ne genero un altro
                else numero_estratto = rnd.Next(1, 91);
            }
            return numero_estratto;
        }
        #endregion

        #region AggiornaTabellone
        static int AggiornaTabellone(int numero_estratto, bool[] vector)//per aggiornare il tabellone all'estrazione
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("╔══════════════════════════════════════╗\n");
            Console.Write("║                                      ║\n");
            Console.Write("║  T O M B O L A   N A T A L I Z I A   ║\n");
            Console.Write("║                                      ║\n");
            Console.Write("╚══════════════════════════════════════╝\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            vector[numero_estratto - 1] = true;

            for (int i = 0; i < vector.Length; i++)
            {


                if (vector[i] == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♣♣");
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (i + 1 < 10) Console.Write(" ");//se nella prima fila aggiungo uno spazio
                    Console.Write(i+1);
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                }


                if ((i + 1) % 10 == 0) Console.WriteLine();


            }
            return 1;
        }
        #endregion

        #region VerificaCinquina
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
        #endregion

        #region VerificaDecina
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
        #endregion

        #region VerificaTombola
        static bool VerificaTombola(bool[] vector)//verifica se è uscita una Tombola
        {
            bool result = false;
            int numero = 0, contatore = 0;
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Inserire il {i + 1} numero da verificare");//vedo i numeri da verificare
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

        #endregion

        #region genera_Schedina
        static void Schedina()
        {

            Console.WriteLine("Segnarsi la cartella su un foglio poichè essa verrà eliminata alla prossima estrazione!");
            Random rnd = new Random();
            int[] scheda = new int[27]; //array schedina

            for (int i = 0; i < scheda.Length; i++)
                scheda[i] = 1; 

            for (int i = 0; i < 3; i++) 
            {
                int[] spazi = new int[4];

                for (int count = 0; count < 4; count++) //posizioni degli spazi
                {
                    int estratto = rnd.Next(0, 9);
                    spazi[count] = estratto;
                    for (int j = 0; j < count; j++) //verifico sia un numero diverso dai precedenti
                        if (estratto == spazi[j])
                        {
                            count--;
                            break;
                        }

                }

                for (int j = 0; j < spazi.Length; j++)
                    scheda[i * 9 + spazi[j]] = 0; 

                for (int j = 0; j < 9; j++) //riempio la scheda con i numeri
                {
                    if (scheda[i * 9 + j] == 0) 
                        continue;
                    else
                    {
                        int estratto;
                        if (j == 0) estratto = rnd.Next(1, 10);
                        else estratto = rnd.Next(j * 10, (j + 1) * 10); 
                        scheda[i * 9 + j] = estratto;
                        for (int k = 0; k < i * 9 + j; k++) 
                        {
                            if (scheda[k] == estratto)
                            {
                                j--;
                                break;
                            }
                        }
                    }
                }
            }

            //crezione schedina

            schedina = "╔════╦════╦════╦════╦════╦════╦════╦════╦════╗"; 
            stampaScheda = true; //valore che verrà usato nel main

            for (int i = 0; i < scheda.Length; i++) 
            {
                if (i % 9 == 0)
                {
                    if (i == 0) schedina += "\n║"; 
                    else
                    {
                        schedina += "\n╠════╬════╬════╬════╬════╬════╬════╬════╬════╣\n║";
                    }
                }

                if (scheda[i] == 0) schedina += "    ║"; 
                else if (scheda[i] < 10) 
                    schedina += " 0" + scheda[i].ToString() + " ║";//stampo i numeri
                else schedina += " " + scheda[i].ToString() + " ║";

            }
            schedina += "\n╚════╩════╩════╩════╩════╩════╩════╩════╩════╝";


        }
        #endregion


    }
}

