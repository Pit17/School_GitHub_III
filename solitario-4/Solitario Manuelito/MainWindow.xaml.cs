using System;
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
        int mescolate = 2;
        Deck_Org Deck_Org = new Deck_Org();
        Carta[] scala = new Carta[4];
        List<List<Carta>> scarti = new List<List<Carta>>();
        List<Carta>[] mazzetto = new List<Carta>[4];
        Deck_Org mazzo = new Deck_Org();
        bool audio = true;
        Carta? tenuta = null;
        List<Carta> ListaTenuta; 
        SoundPlayer player = new SoundPlayer(@$"..\..\..\Music\Cucaracha.wav");
        public MainWindow()
        {
            InitializeComponent();
            Mescola.Visibility = Visibility.Hidden;
            Mescolate_rimanenti_label.Visibility = Visibility.Hidden;
            mescolate_rimanenti_int.Visibility = Visibility.Hidden;
            for (int i = 0; i < 4; i++)
            {
                mazzetto[i] = new List<Carta>
                { mazzo.Pesca() };
                mazzetto[i][0].position = i + 7;
            }
            player.Load();
            player.PlayLooping();
            refresh();
            Canvas belen = new Canvas();
            belen.Height = 160;
            belen.Width = 108;
            belen.Background = Brushes.Transparent;
            scala_0.Children.Insert(2, belen);
            Canvas barbarita = new Canvas();
            barbarita.Height = 160;
            barbarita.Width = 108;
            barbarita.Background = Brushes.Transparent;
            scala_1.Children.Insert(2, barbarita);
            Canvas esmeralda = new Canvas();
            esmeralda.Height = 160;
            esmeralda.Width = 108;
            esmeralda.Background = Brushes.Transparent;
            scala_2.Children.Insert(2, esmeralda);
            Canvas florencia = new Canvas();
            florencia.Height = 160;
            florencia.Width = 108;
            florencia.Background = Brushes.Transparent;
            scala_3.Children.Insert(2, florencia);
        }
        
        private void refresh()
        {
            if(scarti.Count != 0 && scarti[scarti.Count-1].Count == 0)
            {
                scarti.RemoveAt(scarti.Count-1);
            }
            
            if (slot_0.Children.Count > 2) slot_0.Children.RemoveAt(2);
            if (slot_1.Children.Count > 2) slot_1.Children.RemoveAt(2);
            if (slot_2.Children.Count > 2) slot_2.Children.RemoveAt(2);
            if (slot_3.Children.Count > 2) slot_3.Children.RemoveAt(2);

            if(trash_stack_0.Children.Count > 2) trash_stack_0.Children.RemoveAt(2);
            if (trash_stack_1.Children.Count > 2) trash_stack_1.Children.RemoveAt(2);
            if (trash_stack_2.Children.Count > 2) trash_stack_2.Children.RemoveAt(2);

            if (scala[0] != null && scala_0.Children.Count > 2) scala_0.Children.RemoveAt(2);
            if (scala[1] != null && scala_1.Children.Count > 2) scala_1.Children.RemoveAt(2);
            if (scala[2] != null && scala_2.Children.Count > 2) scala_2.Children.RemoveAt(2);
            if (scala[3] != null && scala_3.Children.Count > 2) scala_3.Children.RemoveAt(2);


            if (mazzetto[0].Count > 0)
            {
                slot_0.Children.Insert(2,mazzetto[0][mazzetto[0].Count - 1].canvas);
            }
            else
            {
                Canvas manuelito = new Canvas();
                manuelito.Height = 160;
                manuelito.Width = 108;
                manuelito.Background = Brushes.Transparent;
                slot_0.Children.Insert(2,manuelito);

            }
            if (mazzetto[1].Count > 0)
            {
                slot_1.Children.Insert(2, mazzetto[1][mazzetto[1].Count - 1].canvas);
            }
            else
            {
                Canvas rodrigo = new Canvas();
                rodrigo.Height = 160;
                rodrigo.Width = 108;
                rodrigo.Background = Brushes.Transparent;
                slot_1.Children.Insert(2, rodrigo);
            }
            if (mazzetto[2].Count > 0)
            {
                
                slot_2.Children.Insert(2, mazzetto[2][mazzetto[2].Count - 1].canvas);
            }
            else
            {
                Canvas alvaro = new Canvas();
                alvaro.Height = 160;
                alvaro.Width = 108;
                alvaro.Background = Brushes.Transparent;
                slot_2.Children.Insert(2, alvaro);
            }
            if (mazzetto[3].Count > 0)
            {
                slot_3.Children.Insert(2, mazzetto[3][mazzetto[3].Count - 1].canvas);
            }
            else
            {
                Canvas camilo = new Canvas();
                camilo.Height = 160;
                camilo.Width = 108;
                camilo.Background = Brushes.Transparent;
                slot_3.Children.Insert(2, camilo);
            }
            if (scarti.Count > 0)
            {
                if (scarti[scarti.Count - 1].Count > 0)                
                {
                    trash_stack_0.Children.Insert(2, scarti[scarti.Count - 1][0].canvas);
                    border2.Visibility = Visibility.Visible;
                    
                }else border2.Visibility = Visibility.Hidden;
                if (scarti[scarti.Count - 1].Count > 1)
                {
                    trash_stack_1.Children.Insert(2, scarti[scarti.Count - 1][1].canvas);
                    border1.Visibility = Visibility.Visible;
                }else border1.Visibility = Visibility.Hidden;
                if (scarti[scarti.Count - 1].Count > 2)
                {
                    trash_stack_2.Children.Insert(2,scarti[scarti.Count - 1][2].canvas);
                    border0.Visibility = Visibility.Visible;
                }else border0.Visibility = Visibility.Hidden;
            }
            if (scala[0] != null) scala_0.Children.Insert(2,scala[0].canvas);
            if (scala[1] != null) scala_1.Children.Insert(2, scala[1].canvas);
            if (scala[2] != null) scala_2.Children.Insert(2,scala[2].canvas);
            if (scala[3] != null) scala_3.Children.Insert(2, scala[3].canvas);

           

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
            if (mazzo.mazzo.Count == 0)
            {
                mescolate_rimanenti_int.Content = mescolate.ToString();
                Mescolate_rimanenti_label.Visibility = Visibility.Visible;
                Mescola.Visibility = Visibility.Visible;
                mescolate_rimanenti_int.Visibility = Visibility.Visible;
            }
            for (int i = 0; i < 3; i++)
            {
                if (mazzo.mazzo.Count == 0)
                {
                    break;
                }
                scarti[scarti.Count-1].Add(mazzo.Pesca());
                scarti[scarti.Count - 1][i].position = i + 4;
            }
            carte_rimanenti.Content = mazzo.mazzo.Count.ToString();
            refresh();
        }
        private void Card_pick(object sender, RoutedEventArgs e)
        {

        }
        
        private void Card_move(object sender, MouseEventArgs e)
        {
            Canvas source = (Canvas)e.Source;
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var g = VisualTreeHelper.GetParent((Canvas)sender) as Grid;
                for (int i = 0;i < 4;i++)
                {
                    if (g.Name == $"slot_{i}")
                    {
                        tenuta = mazzetto[i][mazzetto[i].Count-1];
                        ListaTenuta = mazzetto[i];
                        DragDrop.DoDragDrop(source, source, DragDropEffects.Move);
                    } 
                    
                }
                for (int i = 0;i < 3; i++)
                {
                    if (g.Name == $"trash_stack_{i}")
                    {
                        if (i != scarti[scarti.Count - 1].Count - 1) continue;
                        tenuta = scarti[scarti.Count - 1][i];
                        ListaTenuta = scarti[scarti.Count-1];
                        DragDrop.DoDragDrop(source, source, DragDropEffects.Move);
                    }
                }
                
            }
        }
        

        private void Card_Drop(object sender, DragEventArgs e)
        {
            
            if (!e.Data.GetDataPresent(typeof(Canvas)))
                return;

            if (tenuta.canvas == (Canvas)sender) return;
            var g = VisualTreeHelper.GetParent((Canvas)sender) as Grid;
            for (int i = 0; i < 4; i++)
            {
                if (g.Name == $"slot_{i}")
                {
                    if (CheckMossaMazzetti(i))
                    {
                        mazzetto[i].Add(tenuta);
                        ListaTenuta.Remove(tenuta);
                    }
                }
                if (g.Name == $"scala_{i}")
                {
                    if (CheckMossaScala(i))
                    {
                        g.Children.RemoveAt(2);
                        scala[i] = tenuta;
                        ListaTenuta.Remove(tenuta);
                        if (CheckWin())
                        {
                            MessageBox.Show("COMPLIMENTI! HAI VINTO!");
                        }
                    }
                    
                }
                
            }    
            
            refresh();
           
            

        }
        private void Card_DragOver(object sender, MouseEventArgs e)
        {


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Scopo del solitario è costruire e completare le basi poste al di sopra del tallone, scorrendolo di tre carte in tre carte, di cui solo la prima è utilizzabile. Se questa viene spostata, la sottostante verrà liberata e diventerà anch’essa utilizzabile.\r\nAl di sotto del tallone, invece, sono presenti quattro sequenze da utilizzare come ausilio per la riuscita del solitario.\r\nPer le basi vale la regola dello stesso seme in senso ascendente, mentre nelle sequenze vale quella del seme diverso in senso discendente.\r\nLe carte in cima alle sequenze, così come le carte del pozzo, possono essere posizionate sulle basi e/o sulle sequenze, mentre il numero di distribuzioni è pari a 3.\r\nPuò essere spostata solo una carta alla volta ", "REGOLE");
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (audio)
            {
                audio = false;
                btn.Background = new ImageBrush(new BitmapImage(new Uri(@$"..\..\..\MARTINA-GRAFFIETI-CARTE-ITT-anonimo\muto.png", UriKind.Relative))) ;
                player.Stop();
                
            }
            else
            {
                audio = true;
                btn.Background = new ImageBrush(new BitmapImage(new Uri(@$"..\..\..\MARTINA-GRAFFIETI-CARTE-ITT-anonimo\volume.png", UriKind.Relative)));
                player.PlayLooping();
            }
        }

        private bool CheckMossaMazzetti(int mazzettoScelto)
        {
            
            if (mazzetto[mazzettoScelto].Count == 0) return true;
            else if ((mazzetto[mazzettoScelto][mazzetto[mazzettoScelto].Count - 1].Valore == tenuta.Valore + 1) && (mazzetto[mazzettoScelto][mazzetto[mazzettoScelto].Count - 1].Seme != tenuta.Seme)) return true;
            else return false;  
        }

        private bool CheckMossaScala(int scalaScelta)
        {
            if (scala[scalaScelta] == null)
            {
                if (tenuta.Valore == 1) return true;
                else return false;

            }
            else if ((scala[scalaScelta].Valore == tenuta.Valore - 1) && (scala[scalaScelta].Seme == tenuta.Seme)) return true;
            else return false;

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (mescolate > 0)
            {
                mazzo.mescola(scarti);
                refresh();
                Mescola.Visibility = Visibility.Hidden;
                Mescolate_rimanenti_label.Visibility = Visibility.Hidden;
                mescolate_rimanenti_int.Visibility = Visibility.Hidden;
                mescolate--;
                carte_rimanenti.Content = mazzo.mazzo.Count;
            }
            
        }
        private bool CheckWin()
        {
            int win = 0;
            foreach(var c in scala)
            {
                if (c != null)
                {
                    if(c.Valore == 10) win++;
                }
            }
            if (win == 4) return true;
            else return false;
            
        }

    }
}