using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Solitario_Manuelito
{
    /// <summary>
    /// Logica di interazione per startMenu.xaml
    /// </summary>
    public partial class startMenu : Window
    {
        public startMenu()
        {
            InitializeComponent();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow game = new MainWindow();
            this.Visibility = Visibility.Hidden;
            game.Show();
        }
    }
}
