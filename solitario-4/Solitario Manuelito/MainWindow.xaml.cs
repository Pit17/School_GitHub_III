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
            trash_stack_0.Children.Add(Deck_Org.takeCard());
            trash_stack_1.Children.Add(Deck_Org.takeCard());
            trash_stack_2.Children.Add(Deck_Org.takeCard());
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Deck_Org.setUp();
            slot_0.Children.Add(Deck_Org.takeCard());
            slot_1.Children.Add(Deck_Org.takeCard());
            slot_2.Children.Add(Deck_Org.takeCard());
            slot_3.Children.Add(Deck_Org.takeCard());
        }
        private void Card_move(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(new Canvas(),new Canvas(), DragDropEffects.Move);
            }
        }
        private void Card_drop(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(new Canvas(), new Canvas(), DragDropEffects.Move);
            }
        }
    }
}