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
            Alunno();
        }


        static void Alunno()
        {
            GestoreAlunno alunno = new GestoreAlunno();
            alunno.AddMarks(GestoreAlunno.Materie.Italiano, 6);
            alunno.AddMarks(GestoreAlunno.Materie.Italiano, 7);
            alunno.AddMarks(GestoreAlunno.Materie.Italiano, 8);
            alunno.AddMarks(GestoreAlunno.Materie.Matematica, 6);
            alunno.AddMarks(GestoreAlunno.Materie.Matematica, 7);
            alunno.AddMarks(GestoreAlunno.Materie.Matematica, 8);
            alunno.GetMarks(GestoreAlunno.Materie.Italiano).ForEach(Console.WriteLine);
            Console.WriteLine(alunno.GetMedia(GestoreAlunno.Materie.Italiano));

        }  
    }
}
