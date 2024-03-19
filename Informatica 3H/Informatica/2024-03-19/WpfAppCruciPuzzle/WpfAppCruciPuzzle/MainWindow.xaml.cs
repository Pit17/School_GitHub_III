//Pietro Malzone 3H 12/03/2024
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
    
    public partial class MainWindow : Window
    {
        string percorso = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\Templates");
        public int colonne = 0;
        public int righe = 0;
        Button[,] buttons;
        List<string> words = new List<string>();
       
        private char[,] matrix;
        private bool[,] found;
        

        
        public MainWindow()
        {
            InitializeComponent();
            
            RisolviPuzzle.IsEnabled = false;
            RisolviPuzzle_Copy.IsEnabled = false;   
        }
  


        
        private void LetturaGenericaDiFile(string nome_file)
        {
            bool matrice = true;
            
            List<string> strings = new List<string>();
            
            using (StreamReader sr = new StreamReader(nome_file))
            {
                
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string tmp = sr.ReadLine();
                    if (tmp == "") break;
                    else { 
                        righe++; 
                        colonne = tmp.Length;
                        strings.Add(tmp);
                    }
                    
                    
                }
                matrix = new char[righe, colonne];

                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();                    
                    words.Add(linea);
                }
                sr.Close();

                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < colonne; j++)
                    {
                        matrix[i, j] = strings[i][j];
                    }
                }
            }
        }

        public void Risolvi()
        {
            int counter = 0;

            if (WordList.SelectedItem == null)
            {
                return;
            }
            else
            {

                found = new bool[righe, colonne];

                string s = WordList.SelectionBoxItem.ToString();
                MessageBox.Show(s);
                for (int i = 0; i < colonne; i++)
                {
                    for (int j = 0; j < righe; j++)
                    {
                        if (Search(i, j, 1, 0, s)) break;
                        if (Search(i, j, -1, 0, s)) break;
                        if (Search(i, j, 0, 1, s)) break;
                        if (Search(i, j, 0, -1, s)) break;
                        if (Search(i, j, 1, 1, s)) break;
                        if (Search(i, j, -1, 1, s)) break;
                        if (Search(i, j, 1, -1, s)) break;
                        if (Search(i, j, -1, -1, s)) break;
                    }
                }
                string sol = "";
                for (int j = 0; j < righe; j++)
                {
                    for (int i = 0; i < colonne; i++)
                    {
                        if (!found[j, i]) sol += matrix[j, i].ToString();
                    }
                }
                if (WordList.Items.Count == 0)
                {
                    MessageBox.Show(sol);
                    RisolviPuzzle_Copy.IsEnabled = false;
                    RisolviPuzzle.IsEnabled = false;
                }
            }
            
        }
        public void RisolviTutto()
        {
            int counter = 0;
            found = new bool[righe, colonne];

            foreach(string s in words)
            {
                for (int i = 0; i < colonne; i++)
                {
                    for (int j = 0; j < righe; j++)
                    {
                        if (Search(i, j, 1, 0, s)) break;
                        if (Search(i, j, -1, 0, s)) break;
                        if (Search(i, j, 0, 1, s)) break;
                        if (Search(i, j, 0, -1, s)) break;
                        if (Search(i, j, 1, 1, s)) break;
                        if (Search(i, j, -1, 1, s)) break;
                        if (Search(i, j, 1, -1, s)) break;
                        if (Search(i, j, -1, -1, s)) break;
                    }
                }
            }
                
            string sol = "";
            for (int j = 0; j < righe; j++)
            {
                for (int i = 0; i < colonne; i++)
                {
                    if (!found[j, i]) sol += matrix[j, i].ToString();
                }
            }
            if (WordList.Items.Count == 0)
            {
                MessageBox.Show(sol);
                RisolviPuzzle_Copy.IsEnabled = false;
                RisolviPuzzle.IsEnabled = false;
            }

        }

        bool Search(int x, int y, int xDir, int yDir, string word)
        {
            int x1 = y, y1 = x;
            for (int i = 0; i < word.Length; i++)
            {
                if (x1 < 0 || x1 >= matrix.GetLength(0) || y1 < 0 || y1 >= matrix.GetLength(1)) return false;
                if (word[i] == matrix[x1, y1])
                {
                    x1 += xDir; y1 += yDir;
                }
                else return false;
            }
            //if found traceback
            
            for (int i = 0; i < word.Length; i++)
            {
                
                x1 -= xDir; y1 -= yDir;
                found[x1, y1] = true;
                buttons[x1, y1].BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#eb2d59");
                buttons[x1, y1].Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ed87ab");
            }
            WordList.Items.Remove(word);
            return true;
        }

    

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            righe = 0;
            colonne = 0;
            WordList.Items.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = percorso;
            openFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                percorso = openFileDialog.FileName;
                
                
            }
            gridwin.Children.Clear();
            words.Clear();

            LetturaGenericaDiFile(percorso);
           
            buttons = new Button[righe, colonne];
            for (int i = 0; i < colonne; i++)
            {
                for (int j = 0; j < righe; j++)
                {
                    Button b = new Button();
                    b.Width = 29;
                    b.Height = 29;
                    b.Content = "";
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(i * 30, j * 30, 0, 0);
                    gridwin.Children.Add(b);

                    buttons[j, i] = b;


                }
            }
            for (int i = 0; i < words.Count; i++)
            {
                WordList.Items.Add(words[i]);

            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    buttons[i, j].Content = matrix[i, j];
                }
            }
            RisolviPuzzle.IsEnabled = true;
            RisolviPuzzle_Copy.IsEnabled = true;
            
        }

        private void RisolviPuzzle_Click(object sender, RoutedEventArgs e)
        {
            RisolviPuzzle.IsEnabled = false;
            Risolvi();
            RisolviPuzzle.IsEnabled = true;
        }

        private void RisolviPuzzle_Click2(object sender, RoutedEventArgs e)
        {
            RisolviPuzzle.IsEnabled = false;
            RisolviTutto();
            
        }
    }
}

