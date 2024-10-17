using SortingAlgorithms;
using System.Collections.Generic;

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
                new int[] { 10,10 , -1, -1, 10, 3, 1, -1, 2, 0 },
             };

            foreach (var array in arrays)
            {
                Print("Unsorted", array);
                //BubbleSort.SortSlightlyOptimized(array);
                QuickSort.Sort(array);
                //InsertionSort.Sort(array);
                Print("Sorted", array);
                Console.WriteLine("===");
            }

            Console.WriteLine("***** Counting Sort *****");

            var theArray = new int[] { 1, 100, 0, 2, 4, 4, 5, 100, 100, 1, 7, 0, 0, 5, 7 };
            Print("Unsorted", theArray);
            Print("Sorted:", CountingSort.Sort(theArray));


            arrays = new[]
            {
                new int[] { 10, 3, 5, 7, 3, 1, -1, 2, 0 },
                new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 10,10 , -1, -1, 10, 3, 1, -1, 2, 0 },
            };

            Console.WriteLine("*****");


            int K = 4;
            foreach (var array in arrays)
            {
                Print("Unsorted", array);
                Print($"Smallest {K} elements:", KSmallestValues.Get(array, K));
                Console.WriteLine("===");
            }
        }

        private static void Print(string message, IEnumerable<int> array)
        {
            Console.WriteLine(message);
            array.ToList().ForEach(p => Console.Write(p + " "));
            Console.WriteLine();
        }
    }
}