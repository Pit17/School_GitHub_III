using System.ComponentModel.DataAnnotations;
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
        Carta[] scala = new Carta[4];
        List<List<Carta>> scarti = new List<List<Carta>>();
        List<Carta>[] mazzetto = new List<Carta>[4];
        Deck_Org mazzo = new Deck_Org();

        Carta? tenuta = null; 
        

        public MainWindow()
        {
            InitializeComponent();

            for(int i = 0; i < 4; i++)
            {
                mazzetto[i] = new List<Carta>
                { mazzo.Pesca() };
                mazzetto[i][0].position = i + 7;
            }

            string path = @$"..\..\..\Music\musica.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.PlayLooping();

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
            scarti.Add(new List<Carta>());
            for(int i = 0; i < 3; i++)
            {
                scarti[scarti.Count-1].Add(mazzo.Pesca());
                scarti[scarti.Count - 1][i].position = i + 4;
            }
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
            var npick = Convert.ToInt32(((Button)sender).Tag);
            MessageBox.Show(npick + "");
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
            
            MessageBox.Show("Scopo del solitario è costruire e completare le basi poste al di sopra del tallone, scorrendolo di tre carte in tre carte, di cui solo la prima è utilizzabile. Se questa viene spostata, la sottostante verrà liberata e diventerà anch’essa utilizzabile.\r\nAl di sotto del tallone, invece, sono presenti quattro sequenze da utilizzare come ausilio per la riuscita del solitario.\r\nPer le basi vale la regola dello stesso seme in senso ascendente, mentre nelle sequenze vale quella del seme diverso in senso discendente.\r\nLe carte in cima alle sequenze, così come le carte del pozzo, possono essere posizionate sulle basi e/o sulle sequenze, mentre il numero di distribuzioni è pari a 3.\r\nPuò essere spostata solo una carta alla volta ", "REGOLE");
        }

        private void Card_pick(object sender, RoutedEventArgs e)
        {
           var npick = Convert.ToInt32(((Button)sender).Tag);
            //MessageBox.Show(npick + "");

            if(npick < 4)
            {
                //basi
            }
            else if(npick < 7)
            {
                //scarti
            }
            else
            {
                //mazzetti
            }
        }
    }
}