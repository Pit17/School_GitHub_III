using System;
using System.IO;
//Autore Pietro Malzone 3H Pianoforte
//Nel file .txt si possono inserire le lettere della tastiera corrispondenti alla nota desiderata.
namespace Pianoforte
{
    internal class Program
    {
      
        // Indice -->               0    1    2    3    4    5    6
        // Nota -->                 DO  DO#   RE   RE#   MI   FA  FA# SOL  SOL# LA   LA#   SI  DO   RE
        static char[] keyboard = { 'a', 'w', 's', 'e', 'd', 'f', 't', 'g', 'y' ,'h', 'u' ,'j', 'k', 'l'};
        static int[] sound_freq = { 262, 277, 294, 311, 330, 349, 370, 392, 415, 440, 466, 494, 523, 587};

        static char LeggiTasto()//lettura char
        {
            if (!Console.KeyAvailable) return '\0';

            ConsoleKeyInfo key = Console.ReadKey(true);

            return key.KeyChar;
        }

        static int TrovaFrequenza(char nota)//verifica la frequenza da segnare
        {
            for (int i = 0; i < keyboard.Length; i++)
            {
                if (keyboard[i] == nota) return sound_freq[i];
            }
            return 0;
        }

        
        static void Main(string[] args)
        {
            Console.Title = "PietroMalzone3H";

            Console.Write(" ____________________________________\r\n|\\                                    \\\r\n| \\                                    \\\r\n|  \\____________________________________\\\r\n|  |       __---_ _---__                |\r\n|  |      |======|=====|                |\r\n|  |      |======|=====|                |\r\n|  |  ____|__---_|_---_|______________  |\r\n|  | |                                | |\r\n|   \\ \\                                \\ \\\r\n|  \\ ||\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\| | \r\n|  ||| |                               || |\r\n \\ ||| |           -  -                || |\r\n  \\'|| |-----------\\\\-\\\\---------------|| |\r\n    \\|_|            \"  \"               \\|_|\r\n\r\n--------------------featured with Antonio De Rosa----------------------------\r\n");

            Console.WriteLine("Benvenuto al SuonaTu!\nPremi '1' se vuoi lasciarci il comando! :0\nPremi '2' se ti piace suonare ;)");
            
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    leggiFile(@"..\..\file.txt");
                    break;
                case '2':
                    while (true)
                    {
                        char tasto = LeggiTasto();
                        if (tasto != '\0')
                        {
                            RiproduciFrequenza(tasto);
                        }
                    }
            }
        }

        static void RiproduciFrequenza(char tasto)//suona
        {
                int frequenza = TrovaFrequenza(tasto);
                if (frequenza != 0)
                    Console.Beep(TrovaFrequenza(tasto), 400);
        }
        static void leggiFile(string nome)//legge da file
        {
            using (StreamReader sr = new StreamReader(nome))
            {
                while (!sr.EndOfStream)
                {
                    foreach (char c in sr.ReadLine()) RiproduciFrequenza(c);
                }
            }
        }
    }
}
