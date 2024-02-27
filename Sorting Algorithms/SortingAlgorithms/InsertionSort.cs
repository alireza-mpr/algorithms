using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class InsertionSort
    {
        // Time Complexity: O(N^2), Space: O(1)
        // Iteration: Sum 1, 2, 3,... N-1 = (N)(N-1) / 2
        public static void Sort(int[] array)
        {
            for (int key = 1; key < array.Length; key++)
            {
                int i = key - 1, j = key;
                while (i >= 0 && array[i] > array[j])
                {
                    (array[j], array[i]) = (array[i], array[j]);
                    i--;
                    j--;
                }
            }
        }
    }
}
