namespace ConsoleAppQuarto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dizionario = new Dictionary<int, int>();
            using (StreamReader sr = new StreamReader("C:\\Users\\Utente\\source\\repos\\ConsoleAppEserciziFileDiTesto\\dati.txt"))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    int numero = int.Parse(line);

                    if (dizionario.ContainsKey(numero))
                    
                        dizionario[numero]++;
              
                    else
                    
                        dizionario.Add(numero, 1);
                    
                }
                sr.Close();
            }

            SortedDictionary<int, int> dizionarioOrdinato = new SortedDictionary<int, int>(dizionario);
            

            using (StreamWriter sw = new StreamWriter("C:\\Users\\Utente\\source\\repos\\ConsoleAppEserciziFileDiTesto\\ConsoleAppQuarto\\output.txt"))
            {
                foreach (var i in dizionarioOrdinato)
                {
                    sw.WriteLine($"{i.Key},{i.Value} ");
                }
                sw.Close();
            }
        }
    }
}
    