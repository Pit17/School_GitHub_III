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

namespace WpfAppNumeriInParole
{
    //Autore Pietro MAlzone 3H 30/01/2023 WPF per trasformare numeri in lettere
    public partial class MainWindow : Window
    {
        public int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_click(object sender, RoutedEventArgs e)
        {

            string numeroInLettere = "";
            int numero;
            bool inputOK;
            string varRead;

            #region input

                varRead = Input.Text;
                inputOK = int.TryParse(varRead, out numero);
            if (!inputOK) {
                MessageBox.Show("Valore non valido"); 
                return;
            }
            else if (numero < 0 || numero > 9999)//verifico sia compresa nel range
            {
                MessageBox.Show("Il numero deve essere compreso tra 0 e 9999");
                return;
            }

            #endregion


            if (numero == 0)//caso 0
            {

                numeroInLettere = "zero";

            }
            else // numero > di 0
            {

                #region miglialia
                switch (numero / 1000)
                {
                    case 1:
                        numeroInLettere += "mille";
                        break;
                    case 2:
                        numeroInLettere += "duemila";
                        break;
                    case 3:
                        numeroInLettere += "tremila";
                        break;
                    case 4:
                        numeroInLettere += "quattromila";
                        break;
                    case 5:
                        numeroInLettere += "cinquemila";
                        break;
                    case 6:
                        numeroInLettere += "seimila";
                        break;
                    case 7:
                        numeroInLettere += "settemila";
                        break;
                    case 8:
                        numeroInLettere += "ottomila";
                        break;
                    case 9:
                        numeroInLettere += "novemila";
                        break;
                    default:
                        break;

                }
                #endregion

                #region centinaia
                switch (numero / 100 % 10)
                {
                    case 1:
                        numeroInLettere += "cento";
                        break;
                    case 2:
                        numeroInLettere += "duecento";
                        break;
                    case 3:
                        numeroInLettere += "trecento";
                        break;
                    case 4:
                        numeroInLettere += "quattrocento";
                        break;
                    case 5:
                        numeroInLettere += "cinquecento";
                        break;
                    case 6:
                        numeroInLettere += "seicento";
                        break;
                    case 7:
                        numeroInLettere += "settecento";
                        break;
                    case 8:
                        numeroInLettere += "ottocento";
                        break;
                    case 9:
                        numeroInLettere += "novecento";
                        break;
                    default:
                        break;
                }
                #endregion

                #region decine
                switch (numero / 10 % 10)
                {
                    case 1:

                        switch (numero % 100)//casi speciali
                        {
                            case 10:
                                numeroInLettere += "dieci";
                                break;
                            case 11:
                                numeroInLettere += "undici";
                                break;
                            case 12:
                                numeroInLettere += "dodici";
                                break;
                            case 13:
                                numeroInLettere += "tredici";
                                break;
                            case 14:
                                numeroInLettere += "quattordici";
                                break;
                            case 15:
                                numeroInLettere += "quindici";
                                break;
                            case 16:
                                numeroInLettere += "sedici";
                                break;
                            case 17:
                                numeroInLettere += "diciasette";
                                break;
                            case 18:
                                numeroInLettere += "diciotto";
                                break;
                            case 19:
                                numeroInLettere += "diciannove";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        numeroInLettere += "venti";
                        break;
                    case 3:
                        numeroInLettere += "trenta";
                        break;
                    case 4:
                        numeroInLettere += "quaranta";
                        break;
                    case 5:
                        numeroInLettere += "cinquanta";
                        break;
                    case 6:
                        numeroInLettere += "sessanta";
                        break;
                    case 7:
                        numeroInLettere += "settanta";
                        break;
                    case 8:
                        if (numero / 100 % 10 != 0)
                        {
                            numeroInLettere = numeroInLettere.Substring(0, numeroInLettere.Length - 1);
                        }

                        numeroInLettere += "ottanta";
                        break;
                    case 9:
                        numeroInLettere += "novanta";
                        break;
                    default:
                        break;
                }
                #endregion

                #region unità
                if (numero / 10 % 10 != 1)
                {
                    switch (numero % 10)
                    {
                        case 1:
                            if (numero / 10 % 10 != 0)
                            {
                                numeroInLettere = numeroInLettere.Substring(0, numeroInLettere.Length - 1);

                            }
                            numeroInLettere += "uno";
                            break;

                        case 2:
                            numeroInLettere += "due";
                            break;
                        case 3:
                            numeroInLettere += "tre";
                            break;
                        case 4:
                            numeroInLettere += "quattro";
                            break;
                        case 5:
                            numeroInLettere += "cinque";
                            break;
                        case 6:
                            numeroInLettere += "sei";
                            break;
                        case 7:
                            numeroInLettere += "sette";
                            break;
                        case 8:
                            if (numero / 10 % 10 != 0)
                            {
                                numeroInLettere = numeroInLettere.Substring(0, numeroInLettere.Length - 1);

                            }
                            numeroInLettere += "otto";
                            break;

                        case 9:
                            numeroInLettere += "nove";
                            break;
                        default
                            :
                            break;
                    }
                }
                #endregion

            }

            #region output
            Output.Text = numeroInLettere;
            Input.IsEnabled = false;
            #endregion

        }

        private void button_click_reset(object sender, RoutedEventArgs e)
        {         
            Input.IsEnabled = true;
            Input.Text = string.Empty;
            Cronologia.Text = $"\n{i + 1}. {Output.Text}" + Cronologia.Text;
            i++;
            Output.Text = String.Empty;

        }
    }
}
