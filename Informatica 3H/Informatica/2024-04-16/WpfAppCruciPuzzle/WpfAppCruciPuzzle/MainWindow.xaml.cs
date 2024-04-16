//Pietro Malzone 3H 16/04/2024
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
            
            RisolviPuzzle.IsEnabled = false;//inizializzo quello che inizialmente non mi serve
            RisolviPuzzle_Copy.IsEnabled = false;
            ListSearched.IsReadOnly = true;
            SolutionText.IsReadOnly = true;
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

                while (!sr.EndOfStream)//leggo tutte le righe
                {
                    string linea = sr.ReadLine();                    
                    words.Add(linea);
                }
                sr.Close();

                for (int i = 0; i < righe; i++)//riempio la matrice
                {
                    for (int j = 0; j < colonne; j++)
                    {
                        matrix[i, j] = strings[i][j];
                    }
                }
            }
        }
        int counter = 0;
        public void Risolvi()//funzione che cerca dove si trova la parola
        {
            

            if (WordList.SelectedItem == null)
            {
                return;
            }
            else
            {

                found = new bool[righe, colonne];

                string s = WordList.SelectionBoxItem.ToString();
                counter++;
                ListSearched.Text = ListSearched.Text + $"\n{counter}) {s}";
                
                for (int i = 0; i < colonne; i++)
                {
                    for (int j = 0; j < righe; j++)
                    {
                        if (Search(i, j, 1, 0, s)) break;//dx
                        if (Search(i, j, -1, 0, s)) break;//sx
                        if (Search(i, j, 0, 1, s)) break;//up
                        if (Search(i, j, 0, -1, s)) break;//down
                        if (Search(i, j, 1, 1, s)) break;//up-dx
                        if (Search(i, j, -1, 1, s)) break;//up-sx
                        if (Search(i, j, 1, -1, s)) break;//down-dx
                        if (Search(i, j, -1, -1, s)) break;//down-sx
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
                if (WordList.Items.Count == 0)//se ho trovato tutte le parole rivelo la soluzione
                {
                    
                    SolutionText.Text = sol;
                    RisolviPuzzle_Copy.IsEnabled = false;
                    RisolviPuzzle.IsEnabled = false;
                }
            }
            
        }
        public void RisolviTutto()//stessa funzione di quella precedente ma risolve senza chiedere all'utente che parola vuole trovare
        {
            
            found = new bool[righe, colonne];

            foreach(string s in words)
            {
                counter ++;
                ListSearched.Text = ListSearched.Text + $"\n{counter}) {s}";
                for (int i = 0; i < colonne; i++)
                {
                    for (int j = 0; j < righe; j++)
                    {
                        if (Search(i, j, 1, 0, s)) break;//dx
                        if (Search(i, j, -1, 0, s)) break;//sx
                        if (Search(i, j, 0, 1, s)) break;//up
                        if (Search(i, j, 0, -1, s)) break;//down
                        if (Search(i, j, 1, 1, s)) break;//up-dx
                        if (Search(i, j, -1, 1, s)) break;//up-sx
                        if (Search(i, j, 1, -1, s)) break;//down-dx
                        if (Search(i, j, -1, -1, s)) break;//down-sx
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
            if (WordList.Items.Count == 0)// se ho trovato tutte le parole rivelo la soluzione
            {
                
                SolutionText.Text = sol;
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
            
            
            for (int i = 0; i < word.Length; i++)
            {
                
                x1 -= xDir; y1 -= yDir;
                found[x1, y1] = true;
                buttons[x1, y1].BorderBrush = Brushes.SpringGreen;
                buttons[x1, y1].Background = Brushes.PaleGreen;
            }
            WordList.Items.Remove(word);
            return true;
        }

    

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            righe = 0;
            colonne = 0;
            WordList.Items.Clear();
            ListSearched.Clear();
            SolutionText.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = percorso;
            openFileDialog.Filter = "Text documents (.txt)|*.txt";//modo per permettere all'utente di scegliere il file
            
            if (openFileDialog.ShowDialog() == true)
            {
                percorso = openFileDialog.FileName;
                
                
            }else throw new Exception("Errore nell'apertura del file");
            gridwin.Children.Clear();
            words.Clear();

            

            LetturaGenericaDiFile(percorso);
           
            buttons = new Button[righe, colonne];//creazione matrici di bottoni
            for (int i = 0; i < colonne; i++)
            {
                for (int j = 0; j < righe; j++)
                {
                    Button b = new Button();
                    b.Width = 29;
                    b.Height = 29;
                    b.Content = "";
                    b.BorderBrush = Brushes.IndianRed;
                    b.Background = Brushes.PeachPuff;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(i * 30, j * 30, 0, 0);
                    gridwin.Children.Add(b);

                    buttons[j, i] = b;
                    

                }
            }
            
            for (int i = 0; i < words.Count; i++)//aumento la lista di parole con le parole presenti nel file
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

