namespace ConsoleAppGraficomplessi
{
    internal class Program
    {
        static int[,] matrice;
        static int n;
        static int[] precedenti;
        static HashSet<int> v;
        static int[] distanze;
        static void LetturaFileNvalori()
        {

            
            using (StreamReader sr = new StreamReader(@"..\..\..\..\Templates\grafo-100.txt"))
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
            int min = int.MaxValue;
            for (int i = 0;i < distanze.Length;i++)
            {
                if (distanze[i] < min && !v.Contains(distanze[i]))
                    min = distanze[i];
                
            }
            return min;
           
        }
        static int dijkstra(int source, int target)
        {
            for (int i = 0; i < precedenti.Length; i++) precedenti[i] = -1;
            for (int i = 0; i < distanze.Length; i++) distanze[i] = int.MaxValue;

            distanze[source] = 0;
            int min = findMin();
        }
        static void Main(string[] args)
        {
            LetturaFileNvalori();
            


        }
    }
}