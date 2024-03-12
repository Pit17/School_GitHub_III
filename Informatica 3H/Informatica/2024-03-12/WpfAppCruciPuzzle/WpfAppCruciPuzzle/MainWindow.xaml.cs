using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppCruciPuzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //Pietro Malzone 3H 12/03/2024
    public partial class MainWindow : Window
    {
        string percorso = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\Templates");
        public int colonne = 0;
        public int righe = 0;
        Button[,] buttons;
        List<string> words = new List<string>();
        List<char> matrix = new List<char>();
        public MainWindow()
        {
            InitializeComponent();
            Start_Button.IsEnabled = false;
        }
  

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            gridwin.Children.Clear();
            words.Clear();
            matrix.Clear();
            LetturaGenericaDiFile(percorso);
            Start_Button.IsEnabled = false;
            buttons = new Button[righe, colonne];
            for (int i = 0;i < colonne; i++)
            {
                for (int j = 0;j < righe; j++)
                {
                    Button b = new Button();
                    b.Width = 29;
                    b.Height = 29;
                    b.Content = "";
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(j * 30, i * 30, 0,0);
                    gridwin.Children.Add(b);

                    buttons[j,i] = b;
                    

                }
            }
            for (int i =0;i < words.Count; i++)
            {
                WordList.Items.Add(words[i]);
                
            }
            
          
            for (int i = 0; i < matrix.Count; i++)
            {
                int ir = i / colonne;
                int ic = i % colonne;
                buttons[ir, ic].Content = matrix[i];

            }

        }

        static void ScritturaGenericaDiFile(string nome_file)
        {
            using (StreamWriter sw = new StreamWriter(nome_file))
            {
                // inserire qui il codice che, mediante .Write() e/o .WriteLine(),
                // scriva una o più righe nel file
                sw.Close();
            }
        }
        private void LetturaGenericaDiFile(string nome_file)
        {
            bool matrice = true;
            int nparole = 0;
            
            
            using (StreamReader sr = new StreamReader(nome_file))
            {
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string linea = sr.ReadLine(); // legge la prossima riga del file
                    if (linea == string.Empty)
                    {
                        matrice = false;
                    }
                    if (matrice == true)
                    {
                        colonne = linea.Length;
                        for (int i = 0;i < linea.Length; i++)
                        {
                            matrix.Add(linea[i]);
                        }
                        righe++;
                    }
                    else
                    {
                        words.Add(linea);
                    }
                }
                sr.Close();
            }
        }

        //static bool CercaSinistraDestra(string parola)
        //{
        //    bool find;
        //    for (int i = 0;i < righe; i++) 
        //    {
        //        find = true;
        //        for(int x = 0; (x<parola.Length) && find; x++) { 
                    
                
                
        //        }
            
            
        //    }
        //}
        static bool CercaDestraSinistra(string parola)
        {
            return true;
        }
        static bool CercaAltoBasso(string parola)
        {
            return true;
        }
        static bool CercaBassoAlto(string parola)
        {
            return true;
        }
        static bool CercaAltoDestra(string parola)
        {
            return true;
        }
        static bool CercaAltoSinistra(string parola)
        {
            return true;
        }
        static bool CercaBassoDestra(string parola)
        {
            return true;
        }
        static bool CercaBassoSinistra(string parola)
        {
            return true;
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = percorso;
            openFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                percorso = openFileDialog.FileName;
                Start_Button.IsEnabled = true;
                
            }
            
        }
    }
}
