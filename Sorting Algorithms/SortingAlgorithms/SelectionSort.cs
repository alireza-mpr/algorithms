using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SelectionSort 
    {

        /* Time Complexity: Worst: O(N^2), Best: O(N^2)
         * It doesn't stop even if the array becomes sorted in the middle of the way.

         * Space: O(1)
         * Mechanism: It repeatedly selects the smallest element by SCANNING the unsorted portion of the list and
         * places it in its correct position by swapping.

         * Metaphor: Imagine you're picking the smallest fruit from a basket
         * and placing it in the sorted part of your basket. You keep doing this until all the fruit are sorted.
        */
        public static int[] Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var smallest = FindSmallest(array, i);
                Swap(array, i, smallest);
            }
            return array;
        }

        private static int FindSmallest(int[] array, int startIndex)
        {
            var min = array[startIndex];
            var result = startIndex;

            for (int i = startIndex; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    result = i;
                }
            }
            return result;
        }

        private static void Swap(int[] array, int i, int smallest)
        {
            var temp = array[i];
            array[i] = array[smallest];
            array[smallest] = temp;
        }
    }
}
