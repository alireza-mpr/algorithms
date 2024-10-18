using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class QuickSelect
    {
        public static List<int> GetSmallestValues(int[] values, int k)
        {
            QuickSelectHelper(values, 0, values.Length - 1, k);
            return values.Take(k).ToList();
        }

        private static void QuickSelectHelper(int[] array, int start, int end, int k)
        {
            if (start > end)
                return;

            var pivot = array[start];
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (array[left] < pivot)
                {
                    left++;
                    continue;
                }

                if (array[right] > pivot)
                {
                    right--;
                    continue;
                }

                Swap(array, left, right);
                left++;
                right--;
            }
            Swap(array, right, start);

            if (right == k - 1)
                return;

            if (right > k - 1)
                QuickSelectHelper(array, start, right - 1, k);
            else
                QuickSelectHelper(array, right + 1, end, k);
        }

        static void Swap(int[] array, int i, int j)
        {
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
