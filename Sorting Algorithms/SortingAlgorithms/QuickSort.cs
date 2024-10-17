using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            QuickSortHelper(array, 0, array.Length - 1);
        }

        private static void QuickSortHelper(int[] array, int start, int end)
        {
            if (start > end)
                return;

            var pivot = array[start];
            var i = start + 1;
            var j = end;

            while (i <= j)
            {
                if (array[i] < pivot)
                {
                    i++;
                    continue;
                }

                if (array[j] > pivot)
                {
                    j--;
                    continue;
                }
                Swap(array, i, j);
                i++;
                j--;
            }
            Swap(array, start, j);
            QuickSortHelper(array, start, j - 1);
            QuickSortHelper(array, j + 1, end);
        }

        private static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
