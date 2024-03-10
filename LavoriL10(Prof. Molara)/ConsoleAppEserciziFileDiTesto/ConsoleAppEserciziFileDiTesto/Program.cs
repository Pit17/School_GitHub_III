namespace ConsoleAppEserciziFileDiTesto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            using (StreamReader sr = new StreamReader("C:\\Users\\Utente\\source\\repos\\ConsoleAppEserciziFileDiTesto\\dati.txt"))
            {
                
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    lista.Add(int.Parse(line));
                }
                sr.Close();
            }

            lista.Sort();

            using (StreamWriter sw = new StreamWriter("C:\\Users\\Utente\\source\\repos\\ConsoleAppEserciziFileDiTesto\\ConsoleAppEserciziFileDiTesto\\Output.txt"))
            {
                foreach (int i in lista)
                {
                    sw.WriteLine(i);
                }
                sw.Close();
            }
        }
    }
}