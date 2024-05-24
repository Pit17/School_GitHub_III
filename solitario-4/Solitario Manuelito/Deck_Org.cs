using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Solitario_Manuelito
{
    internal class Deck_Org
    {
        
        public string[] card_deck = new string[40];
        public bool[] card_deck_bool = new bool[40];

        public void setUp()
        {
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i - 1] = $"{i}A";
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i + 9] = $"{i}B";
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i + 19] = $"{i}C";
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i + 29] = $"{i}D";
            }
            for (int i = 1; i < card_deck_bool.Length; i++)
            {
                card_deck_bool[i] = true;
            }
        }
        public int shuffle()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, card_deck.Length);
            if (card_deck_bool[r] == true)
            {
                card_deck_bool[r] = false;
                return r;
            }
            else
            {
                if (!(card_deck_bool.Contains(true)))
                {
                    return -1;
                }

                return shuffle();
            }

        }
        public Carta takeCard()
        {
            int r1 = shuffle();
            Carta c = new Carta(card_deck[r1]);
            if (c.canvas == null) MessageBox.Show("huh?");
            return c;
        }
    }
}
