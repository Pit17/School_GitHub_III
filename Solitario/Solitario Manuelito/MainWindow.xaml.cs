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
            slot_0.Children.Add(Deck_Org.takeCard().canvas);
            slot_1.Children.Add(Deck_Org.takeCard().canvas);
            slot_2.Children.Add(Deck_Org.takeCard().canvas);
            slot_3.Children.Add(Deck_Org.takeCard().canvas);
            
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
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(carta,carta, DragDropEffects.Move);
            }
        }
        private void Card_DragOver(object sender, DragEventArgs e)
        {
            Point dropPosition = e.GetPosition(carta);


            Canvas.SetLeft(carta, dropPosition.X);
            Canvas.SetTop(carta, dropPosition.Y);

        }


    }
}