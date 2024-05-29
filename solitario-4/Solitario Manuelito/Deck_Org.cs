using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Documents;

namespace Solitario_Manuelito
{
    internal class Deck_Org
    {
        Random rng = new Random();
        public string[] card_deck = new string[40];
        public bool[] card_deck_bool = new bool[40];
        List<Carta> mazzo = new List<Carta>();

        public Deck_Org()
        {
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i - 1] = $"{i}A";
                mazzo.Add(new Carta($"{i}A"));
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i + 9] = $"{i}B";
                mazzo.Add(new Carta($"{i}B"));
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i + 19] = $"{i}C";
                mazzo.Add(new Carta($"{i}C"));
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i + 29] = $"{i}D";
                mazzo.Add(new Carta($"{i}D"));
            }
            for (int i = 1; i < card_deck_bool.Length; i++)
            {
                card_deck_bool[i] = true;
            }
            Shuffle();
        }

        public void Shuffle()
        {
            int n = mazzo.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carta value = mazzo[k];
                mazzo[k] = mazzo[n];
                mazzo[n] = value;
            }
        }

        public Carta Pesca()
        {
            Carta c = mazzo[mazzo.Count - 1];
            mazzo.RemoveAt(mazzo.Count-1);
            return c;
        }
    }
}
