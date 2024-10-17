using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class CountingSort
    {
        public static int[] Sort(int[] array)
        {
            if (array.Length == 0)
                return array;

            var max = array.Max();
            var counts = new int[max + 1];

            foreach (var n in array)
                counts[n]++;

            var result = new int[array.Length];
            var k = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                for (int counter = 0; counter < counts[i]; counter++)
                    result[k++] = i;
            }
            return result;
        }
    }
}
