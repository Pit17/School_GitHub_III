using System.IO;
using System.Media;
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
       
        Deck_Org Deck_Org = new Deck_Org();
        public MainWindow()
        {
            InitializeComponent();
            Deck_Org.setUp();
            string path;
            //SoundPlayer player = new SoundPlayer(path);
            //player.Load();
            //player.Play();
            slot_0.Children.Add(Deck_Org.takeCard().canvas);
            slot_1.Children.Add(Deck_Org.takeCard().canvas);
            slot_2.Children.Add(Deck_Org.takeCard().canvas);
            slot_3.Children.Add(Deck_Org.takeCard().canvas);
            //bool soundFinished = true;

            //if (soundFinished)
            //{
            //    soundFinished = false;
            //    Task.Factory.StartNew(() => { player.PlaySync(); soundFinished = true; });
            //}
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

       

        private void Deck_Click(object sender, RoutedEventArgs e)
        {
            trash_stack_0.Children.Add(Deck_Org.takeCard().canvas);
            trash_stack_1.Children.Add(Deck_Org.takeCard().canvas);
            trash_stack_2.Children.Add(Deck_Org.takeCard().canvas);
        }

        
        private void Card_move(object sender, MouseEventArgs e)
        {
            
            Canvas source = (Canvas)e.Source;
            source.Opacity = 1;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(source,source, DragDropEffects.Move);
            }
        }
        private void Card_DragOver(object sender, MouseEventArgs e)
        {

            
        }

        private void Card_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Canvas)))
                return;

            Canvas source = (Canvas)e.Data.GetData(typeof(Canvas));
            Canvas target = (Canvas)e.Source;
            target.Background = source.Background;

            //remove opacity from source
            source.Opacity = 1;

        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Regole:\r\n- il tavolo è formato da 8 pile di carte\r\n- le 4 sopra si usano per le scale dello stesso seme in ordine crescente e le carte messe non si possono togliere\r\n- le 4 sotto a seme alternato e decrescenti sono ausiliarie e le carte si possono togliere e mettere a piacimento\r\n- si pescano 3 carte alla volta e si usano da destra verso sinistra; solo se si ha usato la carta    precedente si può usare quella a sinistra\r\n-  una volta finito il mazzo se le 4 pile sopra non sono complete si rimescola la pila degli scarti\r\n","REGOLE");
        }
    }
}