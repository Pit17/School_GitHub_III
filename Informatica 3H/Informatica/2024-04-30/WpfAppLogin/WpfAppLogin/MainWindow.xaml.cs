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

namespace WpfAppLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        gestoreAccount gestoreAccount = new gestoreAccount();
        public MainWindow()
        {
            InitializeComponent();
            Name.Visibility = Visibility.Hidden;
            Surname.Visibility = Visibility.Hidden;
            btnReg.Visibility = Visibility.Hidden;
            txtNome.Visibility = Visibility.Hidden;
            txtSurname.Visibility = Visibility.Hidden;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
            
        }
        private void minimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void RegClick(object sender, RoutedEventArgs e)
        {
            
            if (txtNome.Text == "" || txtSurname.Text == "" || txtUsername.Text == "" || txtPass.Password == "")
            {
                txtNome.Text = "";
                txtSurname.Text = "";
                txtUsername.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else  
                if (gestoreAccount.Register(txtNome.Text, txtSurname.Text, txtUsername.Text, txtPass.Password)) {
                txtNome.Text = "";
                txtSurname.Text = "";
                txtUsername.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                txtNome.Text = "";
                txtSurname.Text = "";
                txtUsername.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Username already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LogClick(object sender, RoutedEventArgs e)
        {
            if (!gestoreAccount.Login(txtUsername.Text, txtPass.Password))
            {
                txtUsername.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                txtUsername.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Login successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void Loginselector_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
            txtSurname.Text = "";
            txtUsername.Text = "";
            txtPass.Password = "";
            Name.Visibility = Visibility.Hidden;
            Surname.Visibility = Visibility.Hidden;
            btnReg.Visibility = Visibility.Hidden;
            txtNome.Visibility = Visibility.Hidden;
            txtSurname.Visibility = Visibility.Hidden;
            btnLog.Visibility = Visibility.Visible;

        }

        private void RegisterSelector_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
            txtSurname.Text = "";
            txtUsername.Text = "";
            txtPass.Password = "";
            Name.Visibility = Visibility.Visible;
            Surname.Visibility = Visibility.Visible;
            btnReg.Visibility = Visibility.Visible;
            btnLog.Visibility = Visibility.Hidden;
            txtNome.Visibility = Visibility.Visible;
            txtSurname.Visibility = Visibility.Visible;
        }
    }
}
