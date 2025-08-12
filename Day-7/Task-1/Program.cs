using System;

namespace Task1
{
    public delegate bool CompareDelegate(int a, int b);
    class BubbleSorter
    {
        public static void Sort(int[] array, CompareDelegate comparison)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparison(array[j], array[j + 1]))
                    {
                        // Swap
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        static bool Ascending(int a, int b) => a > b;
        static bool Descending(int a, int b) => a < b;

        static void Main()
        {
            int[] numbers = { 5, 2, 9, 1, 5, 6 };

            Console.WriteLine("Original: " + string.Join(", ", numbers));

            // Sort ascending
            BubbleSorter.Sort(numbers, Ascending);
            Console.WriteLine("Ascending: " + string.Join(", ", numbers));

            // Sort descending
            BubbleSorter.Sort(numbers, Descending);
            Console.WriteLine("Descending: " + string.Join(", ", numbers));

            Console.ReadKey();
        }
    }
}
