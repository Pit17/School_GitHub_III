using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Solitario_Manuelito
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public string[] card_deck = new string[40];
        public bool[] card_deck_bool = new bool[40];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

       

        private void Deck_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1;  i <= 10; i++)
            {
                card_deck[i-1] = $"{i}A";
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i+9] = $"{i}B";
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i+19] = $"{i}C";
            }
            for (int i = 1; i <= 10; i++)
            {
                card_deck[i+29] = $"{i}D";
            }
            for(int i = 1;i < card_deck_bool.Length; i++)
            {
                card_deck_bool[i] = true ;
            }
        }
    }
}