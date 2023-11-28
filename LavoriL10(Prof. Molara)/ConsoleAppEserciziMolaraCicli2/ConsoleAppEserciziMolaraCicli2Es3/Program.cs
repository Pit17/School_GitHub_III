using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEserciziMolaraCicli2Es3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome_prodotto = "a",nome_prodotto_costoso="a";
            double prezzo = 0.0,prezzo_maggiore = 0.0 ;

            while(nome_prodotto != "")
            {
                Console.Write("Inserire il nome del prodotto: ");
                nome_prodotto = Console.ReadLine();
                if (nome_prodotto == "") break;

                Console.Write("Inserire il prezzo del prodotto: ");
                prezzo = double.Parse(Console.ReadLine());
                if (prezzo > prezzo_maggiore)
                    {
                        prezzo_maggiore = prezzo;
                        nome_prodotto_costoso = nome_prodotto;
                }
                
            }
            if (nome_prodotto_costoso == "a") Console.WriteLine("Non è stato inserito nessun prodotto");
            else
            Console.WriteLine($"Il prodotto più costoso è {nome_prodotto_costoso} e costa {prezzo_maggiore} euro");
            Console.ReadKey();
        }
    }
}
