using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Solitario_Manuelito
{
    internal class Deck_Org
    {
        string[] card_deck = new string[40];
        bool[] card_deck_bool = new bool[40];

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


        public void shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < card_deck.Length; i++)
            {
                int r = rnd.Next(0, card_deck.Length);
                string temp = card_deck[i];
                card_deck[i] = card_deck[r];
                card_deck[r] = temp;
            }
        }

        public Image takeCard()
        {
            Image image = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("\\MARTINA-GRAFFIETI-CARTE-ITT-anonimo\\1A.jpg", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            image.Source = bitmap;
            image.Width = 200;
            image.Height = 200;
            return image;

        }
    }
}
