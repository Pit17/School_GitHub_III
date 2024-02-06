using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
            bool program;
            int numero;
            bool[] vector = new bool[90];

            for (int i = 0; i < vector.Length; i++)//riempe la tabella iniziale
            {
                vector[i] = false;
               
                    Console.Write("XX");
                    Console.Write(" ");

                if ((i + 1) % 10 == 0) Console.WriteLine();
                
            }
                while (true)
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
                            int numeroEstratto = Estrazione();
                            Console.WriteLine($"E' uscito il numero {numeroEstratto}");
                            AggiornaTabellone(numeroEstratto);
                            break;
                        case 2: Console.WriteLine(); break;
                        case 3: Console.WriteLine(); break;
                        case 4: Console.WriteLine(); break;

                    }
                }

            
        }

        static int Estrazione()//estrae numero casuale tra 1 e 90
        {
            Random rnd = new Random();
            int numero_estratto = rnd.Next(1, 91);

            return numero_estratto;
        }
        static int AggiornaTabellone(int numero_estratto)//prova per aggiornare il tabellone all'estrazione
        {
            bool[] vector = new bool[90];

            for (int i = 0; i < vector.Length; i++)
            {

                if (i != numero_estratto - 1) vector[i] = false;
                else vector[i] = true;


                if (vector[i] == false)
                {
                    Console.Write("XX");
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(numero_estratto.ToString());
                    Console.Write(" ");
                }


                if ((i + 1) % 10 == 0) Console.WriteLine();


            }
            return 1;
        }
    }
}

