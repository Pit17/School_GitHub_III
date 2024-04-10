namespace ConsoleAppClassiAlunni
{

    public class GestoreAlunno
    {
        private string name;
        private string surname;
        private int birth_year;
        List<List<int>> marks;
        private int n_materie = 4;
        public enum Materie
        {
            Italiano,
            Matematica,
            Informatica,
            Inglese
        }
        public GestoreAlunno()
        {
            marks = new List<List<int>>();
            for (int i = 0; i < n_materie; i++)
            {
                marks.Add(new List<int>());
            }

        }

        public void AddMarks(Materie materia, int mark)
        {
            marks[(int)materia].Add(mark);
        }
        public void SetName(string nome)
        {
            name = nome;
        }
        public void SetSurname(string cognome)
        {
            surname = cognome;
        }
        public void SetBirthYear(int anno)
        {
            birth_year = anno;
        }
        public void GetName()
        {
            Console.WriteLine(name);
        }
        public void GetSurname()
        {
            Console.WriteLine(surname);
        }
        public void GetBirthYear()
        {
            Console.WriteLine(birth_year);
        }

        public List<int> GetMarks(Materie materia)
        {
            return marks[(int)materia];
        }
        public double GetMedia(Materie materia)
        {
            double media = 0;
            foreach (int i in marks[(int)materia])
            {
                media += i;


            }
            return media / marks[(int)materia].Count;
        }

        public List<List<int>> GetAllMarks(Materie materia)
        {
            return marks;
        }
    }
}