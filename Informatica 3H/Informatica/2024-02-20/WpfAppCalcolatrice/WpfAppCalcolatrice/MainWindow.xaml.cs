using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
//Pietro Malzone 3h 06/02/2024
namespace WpfAppCalcolatrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int n;
        public int n2;
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text.Length == 8)//se raggiungo il byte di lunghezza disattivo i bottoni
            {
                Zero.IsEnabled = false;
                One.IsEnabled = false;
            }
            else Text.Text = Text.Text + "0"; //altrimenti aggiungo il bit


        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text.Length == 8)//se raggiungo il byte di lunghezza disattivo i bottoni
            {
                One.IsEnabled = false;
                Zero.IsEnabled = false;
            }
            else Text.Text = Text.Text + "1"; //altrimenti aggiungo il bit
        }
   

        private void Shit_left_Click(object sender, RoutedEventArgs e)
        {
            
            bool inputOK;
            int numero;
            string varRead = Shifter.Text,risultato="";
            inputOK = int.TryParse(varRead, out numero);
            if (!inputOK)
            {
                MessageBox.Show("Valore non valido");
                Shifter.Text = string.Empty;
                return;
            }
            else if (numero < 0 || numero > 8)//verifico sia compresa nel range
            {
                MessageBox.Show("Il numero deve essere compreso tra 0 e 8");
                Shifter.Text = string.Empty;
                return;
            }
            else
            {
                
                for(int i = Text.Text.Length-1; i >= 0; i--)//converto base 10
                {
                    n += ((int)Math.Pow(2, Text.Text.Length - 1 -i )* ((int)Text.Text[i] -48));
                }

                n = n << numero;//shift

                while (n > 0)//converto in base 2
                {
                    risultato = (n % 2).ToString() + risultato;
                    n /= 2;

                }
                
                while (risultato.Length < 8)
                {
                    risultato = "0" + risultato;
                }
                Text.Text = risultato;

            }

        }

        private void Shit_right_Click(object sender, RoutedEventArgs e)
        {
            bool inputOK;
            int numero;
            string varRead = Shifter.Text, risultato = "";
            inputOK = int.TryParse(varRead, out numero);
            if (!inputOK)
            {
                MessageBox.Show("Valore non valido");
                Shifter.Text = string.Empty;
                return;
            }
            else if (numero < 0 || numero > 8)//verifico sia compresa nel range
            {
                MessageBox.Show("Il numero deve essere compreso tra 0 e 8");
                Shifter.Text = string.Empty;
                return;
            }
            else
            {

                for (int i = Text.Text.Length - 1; i >= 0; i--)//converto base 10
                {
                    n += ((int)Math.Pow(2, Text.Text.Length - 1 - i) * ((int)Text.Text[i] - 48));
                }

                n = n >> numero;//shift

                while (n > 0)//converto base 2
                {
                    risultato = (n % 2).ToString() + risultato;
                    n /= 2;

                }
                while (risultato.Length < 8)
                {
                    risultato = "0" + risultato;
                }
                risultato =risultato.Substring(risultato.Length - 8);
                Text.Text = risultato;

            }
        }

        private void Not_Click(object sender, RoutedEventArgs e)
        {
            n = 0;
            if (Text.Text.Length < 8)
            {
                while (Text.Text.Length < 8)
                {
                    Text.Text = "0" + Text.Text;
                }
                
            }
            
            for (int i = Text.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n += ((int)Math.Pow(2, Text.Text.Length - 1 - i) * ((int)Text.Text[i] - 48));
            }

            int input = ~n;
            int bit = (1 << 9) -1;//11111111
            input = (input & bit);
            string result = "";
            while (input > 0)//converto base 2
            {
                result = (input % 2).ToString() + result;
                input /= 2;

            }
            while (result.Length < 8) result = "0" + result;
            Text.Text = result.Substring(result.Length-8,8);//tengo solo gli ultimi 8 bit

            
        }

        private void REset(object sender, RoutedEventArgs e)
        {
            Text.Text = String.Empty;
            Shifter.Text = String.Empty;
            One.IsEnabled = true;
            Zero.IsEnabled = true;
            Result.Text = String.Empty;
        }

        private void One2_Click(object sender, RoutedEventArgs e)
        {
            if (Text_Copy.Text.Length == 8)// se raggiungo il byte di lunghezza disattivo i bottoni
            {
                Zero_Copy.IsEnabled = false;
                One_Copy.IsEnabled = false;
            }
            else Text_Copy.Text = Text_Copy.Text + "1";// aggiungo il bit

        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            if (Text_Copy.Text.Length == 8)// se raggiungo il byte di lunghezza disattivo i bottoni
            {
                Zero_Copy.IsEnabled = false;
                One_Copy.IsEnabled = false;
            }
            else Text_Copy.Text = Text_Copy.Text + "0";//aggiungo il bit

        }

        private void Shit_left_Click2(object sender, RoutedEventArgs e)
        {
            bool inputOK;
            int numero;
            string varRead = Shifter2.Text, risultato = "";
            inputOK = int.TryParse(varRead, out numero);
            if (!inputOK)
            {
                MessageBox.Show("Valore non valido");
                Shifter2.Text = string.Empty;
                return;
            }
            else if (numero < 0 || numero > 8)//verifico sia compresa nel range
            {
                MessageBox.Show("Il numero deve essere compreso tra 0 e 8");
                Shifter2.Text = string.Empty;
                return;
            }
            else
            {

                for (int i = Text_Copy.Text.Length - 1; i >= 0; i--)//converto base 10
                {
                    n2 += ((int)Math.Pow(2, Text_Copy.Text.Length - 1 - i) * ((int)Text_Copy.Text[i] - 48));
                }

                n2 = n2 << numero;

                while (n2 > 0)//converto base 2
                {
                    risultato = (n2 % 2).ToString() + risultato;
                    n2 /= 2;

                }

                while (risultato.Length < 8)
                {
                    risultato = "0" + risultato;
                }
                Text_Copy.Text = risultato;

            }
        }

        private void Shit_right_Click2(object sender, RoutedEventArgs e)
        {
            bool inputOK;
            int numero;
            string varRead = Shifter2.Text, risultato = "";
            inputOK = int.TryParse(varRead, out numero);
            if (!inputOK)
            {
                MessageBox.Show("Valore non valido");
                Shifter2.Text = string.Empty;
                return;
            }
            else if (numero < 0 || numero > 8)//verifico sia compresa nel range
            {
                MessageBox.Show("Il numero deve essere compreso tra 0 e 8");
                Shifter2.Text = string.Empty;
                return;
            }
            else
            {

                for (int i = Text_Copy.Text.Length - 1; i >= 0; i--)//converto base 10
                {
                    n2 += ((int)Math.Pow(2, Text_Copy.Text.Length - 1 - i) * ((int)Text_Copy.Text[i] - 48));
                }

                n2 = n2 >> numero;

                while (n2 > 0)//converto base 2
                {
                    risultato = (n2 % 2).ToString() + risultato;
                    n2 /= 2;

                }

                while (risultato.Length < 8)
                {
                    risultato = "0" + risultato;
                }
                risultato = risultato.Substring(risultato.Length - 8);
                Text_Copy.Text = risultato;

            }
        }

        private void Not_Click2(object sender, RoutedEventArgs e)
        {
            n = 0;
            if (Text_Copy.Text.Length < 8)
            {
                while (Text_Copy.Text.Length < 8)
                {
                    Text_Copy.Text = "0" + Text_Copy.Text;
                }

            }

            for (int i = Text_Copy.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n += ((int)Math.Pow(2, Text_Copy.Text.Length - 1 - i) * ((int)Text_Copy.Text[i] - 48));
            }

            int input = ~n;
            int bit = (1 << 9) - 1;//11111111
            input = (input & bit);
            string result = "";
            while (input > 0)//converto base 2
            {
                result = (input % 2).ToString() + result;
                input /= 2;

            }
            while (result.Length < 8) result = "0" + result;
            Text_Copy.Text = result.Substring(result.Length - 8, 8);

        }

        private void REset2(object sender, RoutedEventArgs e)
        {
            Text_Copy.Text = String.Empty;
            Shifter2.Text = String.Empty;
            One_Copy.IsEnabled = true;
            Zero_Copy.IsEnabled = true;
            Result.Text = String.Empty;

        }

        private void AND(object sender, RoutedEventArgs e)
        {
            n = 0;
            n2 = 0;
            for (int i = Text.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n += ((int)Math.Pow(2, Text.Text.Length - 1 - i) * ((int)Text.Text[i] - 48));
            }
            for (int i = Text_Copy.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n2 += ((int)Math.Pow(2, Text_Copy.Text.Length - 1 - i) * ((int)Text_Copy.Text[i] - 48));
            }
            int ris;
            string risultato = "";
            ris = n & n2;//and
            while (ris > 0)//converto base 2 il risultato
            {
                risultato = (ris % 2).ToString() + risultato;
                ris /= 2;

            }
            while (risultato.Length < 8)
            {
                risultato = "0" + risultato;
            }
            risultato = risultato.Substring(risultato.Length - 8);
            Result.Text = risultato;
        }

        private void OR(object sender, RoutedEventArgs e)
        {
            n = 0;
            n2 = 0;
            for (int i = Text.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n += ((int)Math.Pow(2, Text.Text.Length - 1 - i) * ((int)Text.Text[i] - 48));
            }
            for (int i = Text_Copy.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n2 += ((int)Math.Pow(2, Text_Copy.Text.Length - 1 - i) * ((int)Text_Copy.Text[i] - 48));
            }
            int ris;
            string risultato = "";
            ris = n | n2;//or
            while (ris > 0)//converto base 2 il risultato
            {
                risultato = (ris % 2).ToString() + risultato;
                ris /= 2;

            }
            while (risultato.Length < 8)
            {
                risultato = "0" + risultato;
            }
            risultato = risultato.Substring(risultato.Length - 8);
            Result.Text = risultato;
        }

        private void XOR(object sender, RoutedEventArgs e)
        {
            n = 0;
            n2 = 0;
            for (int i = Text.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n += ((int)Math.Pow(2, Text.Text.Length - 1 - i) * ((int)Text.Text[i] - 48));
            }
            for (int i = Text_Copy.Text.Length - 1; i >= 0; i--)//converto base 10
            {
                n2 += ((int)Math.Pow(2, Text_Copy.Text.Length - 1 - i) * ((int)Text_Copy.Text[i] - 48));
            }
            int ris;
            string risultato = "";
            
            ris = n ^ n2;//xor
            while (ris > 0)//converto base 2 il risultato
            {
                risultato = (ris % 2).ToString() + risultato;
                ris /= 2;

            }
            while (risultato.Length < 8)
            {
                risultato = "0" + risultato;
            }
            risultato = risultato.Substring(risultato.Length - 8);
            Result.Text = risultato;

        }

        private void ResetAll(object sender, RoutedEventArgs e)//rest di tutto(porta tutto allo stato iniziale)
        {
            Text.Text= string.Empty;
            Text_Copy.Text = string.Empty;
            Result.Text = string.Empty;
            One_Copy.IsEnabled = true;
            Zero_Copy.IsEnabled = true;
            One.IsEnabled = true;
            Zero.IsEnabled = true;
            Shifter.Text = string.Empty;
            Shifter2.Text = string.Empty;
        }


    }
}
