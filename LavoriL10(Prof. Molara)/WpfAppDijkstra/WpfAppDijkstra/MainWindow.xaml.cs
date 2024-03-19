using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Serialization;

using System.Threading;

namespace WpfAppDijkstra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string percorso = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\Templates");
        static int[,] matrice;
        static int n;
        static int[] precedenti;
        static HashSet<int> v;
        static int[] distanze;
        int da;
        int a;
        



        public MainWindow()
        {
            InitializeComponent();
            Grid.Height = 2;
            Grid.Width = 2;
            for (int i = 1; i < 30; i++)
            {
                Thread.Sleep(100);
                Grid.Height += 30;
                Grid.Width += 60;
            }
            Start.IsEnabled = false;
            import.IsEnabled = true;
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = percorso;
            openFileDialog.Filter = "Text documents (.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                percorso = openFileDialog.FileName;
                Start.IsEnabled = true;
                percorsoScelto.Text = percorso;
                import.IsEnabled = false;

            }

        }
        static void LetturaFileNvalori(string percorso)
        {


            using (StreamReader sr = new StreamReader(percorso))
            {
                n = (int.Parse(sr.ReadLine()));
                matrice = new int[n, n];
                v = new HashSet<int>();
                distanze = new int[n];
                precedenti = new int[n];

                while (!sr.EndOfStream)
                {
                    string[] linea = sr.ReadLine().Split(',');
                    matrice[int.Parse(linea[0]), int.Parse(linea[1])] = int.Parse(linea[2]);
                    matrice[int.Parse(linea[1]), int.Parse(linea[0])] = int.Parse(linea[2]);
                }
                sr.Close();
            }
        }
        static int findMin()
        {
            int posizione_min = int.MaxValue;
            int min = int.MaxValue;
            for (int i = 0; i < distanze.Length; i++)
            {
                if (distanze[i] < min && !v.Contains(i))
                    posizione_min = i;
                min = distanze[i];

            }
            return posizione_min;

        }
        static int dijkstra(int source, int target)
        {
            for (int i = 0; i < precedenti.Length; i++) precedenti[i] = -1;
            for (int i = 0; i < distanze.Length; i++) distanze[i] = int.MaxValue;

            distanze[source] = 0;
            while (true)
            {
                int min = findMin();

                v.Add(min);
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[min, i] > 0 && !v.Contains(i))
                    {
                        if (distanze[min] + matrice[min, i] < distanze[i])
                        {
                            distanze[i] = distanze[min] + matrice[min, i];
                            precedenti[i] = min;
                        }
                    }
                }
                if (min == target)
                    return distanze[target];
            }


        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int progressValue = 0;
            LetturaFileNvalori(percorso);
            for (int i = 0;i < 4; i++)
            {
                progressValue += 25;
                Progress.Value = progressValue;
                Thread.Sleep(100);


            }
            Thread.Sleep(100);
            Result.Text = (dijkstra(0,2)).ToString();

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            import.IsEnabled = true;
            Start.IsEnabled = false;
            Result.Text = string.Empty;
            percorsoScelto.Text = string.Empty;
            Progress.Value = 0;

        }
    }
}
