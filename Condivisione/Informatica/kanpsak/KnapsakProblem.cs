namespace KnapsakProblem
{
    internal class Program
    {
        const int KNAPSAK_MAX = 67;
        struct Item
        {
            public int weight;  // peso dell'oggetto
            public int value;   // valore dell'oggetto
        }

        static Item[] items = new[] {
            new Item { weight = 23, value = 505 },
            new Item { weight = 26, value = 352 },
            new Item { weight = 20, value = 458 },
            new Item { weight = 18, value = 220 },
            new Item { weight = 32, value = 354 },
            new Item { weight = 27, value = 414 },
            new Item { weight = 29, value = 498 },
            new Item { weight = 26, value = 545 },
            new Item { weight = 30, value = 473 },
            new Item { weight = 27, value = 543 },
        };

        static void Main(string[] args)
        {

        }
    }
}
