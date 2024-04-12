using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClassiAlunni
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<GestoreAlunno> classe3h = new List<GestoreAlunno>();
            classe3h.Add(new GestoreAlunno("Alan", "Agostini", 2007));
            classe3h.Add(new GestoreAlunno("Matteo", "Angiolillo", 2007));
            classe3h.Add(new GestoreAlunno("Marco", "Balducci", 2007));
            classe3h.Add(new GestoreAlunno("Alan", "Bovo", 2007));
            classe3h.Add(new GestoreAlunno("Daniele", "Broccoli", 2007));
            classe3h.Add(new GestoreAlunno("Simone", "Ceccarelli", 2007));
            classe3h.Add(new GestoreAlunno("Mattia", "Cincotta", 2007));
            classe3h.Add(new GestoreAlunno("Giulia", "Cocka", 2007));
            classe3h.Add(new GestoreAlunno("Antonio", "De Rosa", 2006));
            classe3h.Add(new GestoreAlunno("Fabio", "Fantini", 2007));
            classe3h.Add(new GestoreAlunno("Giacomo", "Ferrari", 2007));
            classe3h.Add(new GestoreAlunno("Nicolò", "Landini", 2007));
            classe3h.Add(new GestoreAlunno("Elia", "Lanzoni", 2007));
            classe3h.Add(new GestoreAlunno("Pietro", "Malzone", 2007));
            classe3h.Add(new GestoreAlunno("Mirko", "Paganelli", 2007));
            classe3h.Add(new GestoreAlunno("Federico", "Palmiotto", 2007));
            classe3h.Add(new GestoreAlunno("Paolo", "Preti", 2007));
            classe3h.Add(new GestoreAlunno("Maria", "Rossi", 2007));
            classe3h.Add(new GestoreAlunno("Pietro", "Rodaro", 2007));
            classe3h.Add(new GestoreAlunno("Nicholas", "Sassano", 2007));
            classe3h.Add(new GestoreAlunno("Lorenzo", "Shani", 2007));
            classe3h.Add(new GestoreAlunno("Gabriele", "Ventura", 2007));


            for(int i = 0; i < classe3h.Count; i++)
            {
                Console.WriteLine($" Nome : {classe3h[i].GetName} - Cognome : {classe3h[i].GetSurname} - Anno di nascita : {classe3h[i].GetBirthYear}" );
            }
        }


     
    }
}
