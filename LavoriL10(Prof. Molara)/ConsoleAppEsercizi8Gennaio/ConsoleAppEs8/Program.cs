namespace ConsoleAppEs8
{
    internal class Program
    {
        static int[] UnisciOrdina(int[] vett1, int[] vett2)
        {
            int[] vettore = new int[vett1.Length + vett2.Length];

            int v1 = 0, v2 = 0;

            for (int i = 0; i < vettore.Length; i++)
            {
                if (v2 == vett2.Length) vettore[i] = vett1[v1++];
                else if (v1 == vett1.Length) vettore[i] = vett2[v2++];
                else
                {
                    if (vett1[v1] > vett2[v2]) vettore[i] = vett2[v2++];
                    else vettore[i] = vett1[v1++];
                }

            }

            return vettore;
        }
        static void Main(string[] args)
        {
            int[] v1 = { 1, 5, 10, 15 };
            int[] v2 = { 3, 5, 6, 7, 8, 9, 12, 16, 17, 18, 19 };
            int[] ordinato = UnisciOrdina(v1, v2);

            for (int i = 0; i < ordinato.Length; i++) Console.Write(ordinato[i] + " ");
        }
    }
}