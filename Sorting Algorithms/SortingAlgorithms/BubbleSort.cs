using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class BubbleSort
    {
        // Time Complexity: O(N^2), Space: O(1)
        // Intuition: In each iteration(bubble) :: the max is pushed to the end of the array
        // Idea:
        // Take two adjucent pointers from the first element.
        //   Move them forward. If necessary, swap the pointers.
        //   Repeat from the second element, and so on.
        // Stop when no swap was done OR,
        // take a wall pointer and incrementally decrement the wall from the end of the array.
        public static void Sort(int[] array)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public static void SortSlightlyOptimized(int[] array)
        {
            // https://youtu.be/9I2oOAr2okY?si=yEYpXAh372rISLct
            for(int wall = array.Length - 1; wall>=0; wall --)
            {
                for (int i = 0; i < wall; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    }
                }
            }
        }
    }
}
