using System.Net.Security;

namespace PrimitivePerVettori
{
    class VettoreDiStringhe
    {
        private string[] vett;
        private int vett_count;

        public VettoreDiStringhe(int dimensioni)
        {
            vett = new string[dimensioni];
            vett_count = 0;
        }
        public bool IsEmpty() { return vett_count == 0; }
        public bool IsFull() { return vett_count == vett.Length; }
        public int Available() { return vett.Length - vett_count; }
        public void Add(string value)
        {
            if (IsFull())
                Realloc(ref vett, 2 * vett.Length);

            vett[vett_count++] = value;
        }
        public int Find(string search_for)
        {
            // Cerca il valore 'search_for' nel vettore e torna l'indice di dove si trova
            // Torna -1 se il valore non presente

            for (int i = 0; i < vett_count; ++i)
            {
                if (vett[i] == search_for)
                    return i;
            }

            return -1;
        }
        public void InsertAt(int idx, string value)
        {
            ShiftRight(idx);
            vett[idx] = value;
        }
        public void EraseFrom(int idx)
        {
            ShiftLeft(idx);
        }
        public void Sort()
        {
            // Ordinamento "per selezione"

            // Ciclo esterno: effettua le N-1 passate
            for (int i = 0; i < vett_count-1; i++)
            {
                // Determinare l'indice j_min del valore più piccolo fra [i] e [Length-1]
                int j_min = i;
                for (int j = i + 1; j < vett_count; j++)
                {
                    if (vett[j_min].CompareTo(vett[j]) > 0)
                        j_min = j;
                }
                // Effettua un solo scambio [i] <-> [j_min] per ogni passata
                if (i != j_min)
                {
                    // Scambio [i] <-> [j_min]
                    string aux = vett[i];
                    vett[i] = vett[j_min];
                    vett[j_min] = aux;
                }
            }
        }
        private void Realloc(ref string[] vett, int alloc_size)
        {
            string[] new_vett = new string[alloc_size];

            int idx_max = Math.Min(vett.Length, new_vett.Length);
            for (int i = 0; i < idx_max; ++i)
                new_vett[i] = vett[i];
        
            vett = new_vett;
        }
        private void ShiftRight(int idx)
        {
            if (idx < 0 || vett_count < idx)
                throw new IndexOutOfRangeException();

            if (IsFull())
                Realloc(ref vett, 2 * vett.Length);

            int move_count = vett_count - idx;  // numero di elementi da spostare
            for (int k = move_count; k > 0; --k)
                vett[idx + k] = vett[idx + k - 1];
            ++vett_count;
        }
        private void ShiftLeft(int idx)
        {
            if (idx < 0 || vett_count <= idx)
                throw new IndexOutOfRangeException();

            int move_count = vett_count-idx-1;  // numero di elementi da spostare
            for (int k = 0; k < move_count; ++k)
                vett[idx+k] = vett[idx+k+1];
            --vett_count;
        }
    }
}
