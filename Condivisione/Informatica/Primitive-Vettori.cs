using System.Net.Security;

namespace PrimitivePerVettori
{
    partial class Program
    {
        static bool IsEmpty(string[] vett, int vett_count) { return vett_count == 0; }
        static bool IsFull(string[] vett, int vett_count) { return vett_count == vett.Length; }
        static int Available(string[] vett, int vett_count) { return vett.Length - vett_count; }
        static void Add(string[] vett, ref int vett_count, string value)
        {
            if (IsFull(vett, vett_count))
            {
                vett = Realloc(vett, 2 * vett.Length);
            }

            vett[vett_count++] = value;
        }
        static int Find(string[] vett, int vett_count, string search_for)
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
        static void Insert(string[] vett, ref int vett_count, int idx, string value)
        {
            ShiftRight(vett, ref vett_count, idx);
            vett[idx] = value;
        }
        static void Delete(string[] vett, ref int vett_count, int idx)
        {
            ShiftLeft(vett, ref vett_count, idx);
        }

        static void ShiftRight(string[] vett, ref int vett_count, int idx)
        {
            if (idx < 0 || vett_count < idx)
                throw new IndexOutOfRangeException();

            if (IsFull(vett, vett_count))
                vett = Realloc(vett, 2 * vett.Length);

            int move_count = vett_count - idx;  // numero di elementi da spostare
            for (int k = move_count; k > 0; --k)
                vett[idx+k] = vett[idx+k-1];

            ++vett_count;
        }
        static void ShiftLeft(string[] vett, ref int vett_count, int idx)
        {
            if (idx < 0 || vett_count <= idx)
                throw new IndexOutOfRangeException();

            int move_count = vett_count-idx-1;  // numero di elementi da spostare
            for (int k = 0; k < move_count; ++k)
                vett[idx+k] = vett[idx+k+1];

            --vett_count;
        }
        static string[] Realloc(string[] vett, int alloc_size)
        {
            string[] new_vett = new string[alloc_size];

            int idx_max = Math.Min(vett.Length, new_vett.Length);
            for (int i = 0; i < idx_max; ++i)
                new_vett[i] = vett[i];
        
            return new_vett;
        }
    }
}
