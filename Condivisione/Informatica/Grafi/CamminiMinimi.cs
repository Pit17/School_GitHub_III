namespace Grafi
{
    internal class Program
    {

        private static List<List<(int dest, int costo)>> grafo = new List<List<(int, int)>>();   // grafo[parteza][arrivo] <-- costo
        static void Main(string[] args)
        {
            Lettura(@"..\..\..\grafo-100.txt");
        }
        static void Lettura(string nomefile)
        {
            using (StreamReader sr = new StreamReader(nomefile))
            {
                string stringa = sr.ReadLine();
                int N = int.Parse(stringa);  // FIX : TODO : usare TryParse()

                for (int i = 0; i < N; i++)
                {
                    grafo.Add(new List<(int, int)>());
                }

                while (!sr.EndOfStream)
                {
                    string riga = sr.ReadLine();
                    var parts = riga.Split(',');
                    // FIX : TODO : controllare che parts.Length == 3

                    int from = int.Parse(parts[0]);
                    int to = int.Parse(parts[1]);
                    int costo = int.Parse(parts[2]);
                    grafo[from].Add((to, costo));
                    grafo[to].Add((from, costo));
                }

                int start = 0;
                int target = 2;
                var percorso = Dijkstra(grafo, start, target);

                if (percorso.Esito)
                {
                    Console.WriteLine($"Il percorso per andare {start} a {target} costa {percorso.Dist[target]}");
                    for (int node = target; node >= 0; node = percorso.Pred[node])
                    {
                        Console.Write($"{node}, ");
                    }
                }
                else
                {
                    Console.WriteLine($"Impossibile andare da {start} a {target}");
                }
            }

            static (bool Esito, List<int> Dist, List<int> Pred) Dijkstra(List<List<(int dest, int costo)>> grafo, int start, int target)
            {
                int N = grafo.Count;

                // STEP 1 : inizializzazione
                HashSet<int> visited = new HashSet<int>();  // insieme vuoto
                List<int> dist = new List<int>();
                List<int> pred = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    dist.Add(int.MaxValue);
                    pred.Add(-1);  // -1 == non ancora noto
                }
                dist[start] = 0;

                while (true)
                {
                    // STEP 2 : ricerca del nodo da visitare
                    //          -> è il minimo in dist[] saltando i nodi che sono già in visited
                    int node_min = -1;  // l'inidice del nodo che ha dist[] minimo
                    for (int node = 0; node < N; ++node)
                    {
                        if (visited.Contains(node))  // ignora i nodi già visitati
                            continue;

                        if (node_min < 0 || dist[node_min] > dist[node])  // (è il primo valore) oppure (è minore del valore corrente)
                            node_min = node;
                    }

                    // STEP 3 : condizione di uscita
                    if (node_min < 0 || dist[node_min] == int.MaxValue)
                    {
                        return (false, null, null);  // il grafo non è connesso
                    }

                    // STEP 4 : visita il nodo j
                    visited.Add(node_min);  // il nodo individuato diventa permanente
                    foreach (var arco in grafo[node_min])  // iteriamo tutte le destinazioni con partenza da node_min
                    {
                        if (visited.Contains(arco.dest))  // ignora i nodi già visitati
                            continue;

                        // NOTA: dist[node_min] <<-- è il costo per arrivare a node_min
                        if (dist[arco.dest] > dist[node_min] + arco.costo)  // il costo attuale è più alto del costo che si ha passando per node_min ?
                        {
                            dist[arco.dest] = dist[node_min] + arco.costo;
                            pred[arco.dest] = node_min;
                        }
                    }

                    // STEP 5 : condizione di terminazione
                    if (node_min == target)  // bingo! Siamo arrivati al nodo di destinazione
                    {
                        return (true, dist, pred);
                    }
                }
            }
        }
    }
}