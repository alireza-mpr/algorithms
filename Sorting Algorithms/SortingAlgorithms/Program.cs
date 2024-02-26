using SortingAlgorithms;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrays = new[]
            {
                new int[] { 10, 3, 5, 7, 3, 1, -1, 2, 0 },
                new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
             };


            foreach (var array in arrays)
            {
                Print(array);
                //BubbleSort.SortSlightlyOptimized(array);
                InsertionSort.Sort(array);
                Print(array);
                Console.WriteLine("===");

            }
        }

        private static void Print(int[] array)
        {
            array.ToList().ForEach(p => Console.Write(p + " "));
            Console.WriteLine();
        }
    }
}