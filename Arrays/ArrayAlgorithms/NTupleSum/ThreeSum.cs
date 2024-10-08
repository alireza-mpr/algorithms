using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgorithms.NTupleSum
{
    public class ThreeSum
    {
        public static List<int[]> ForLoopPlusPair(int[] array, int target, Func<int[], int, int, List<int[]>> twoPair)
        {
            var result = new List<int[]>();

            for (int i = 0; i < array.Length; i++)
            {
                var twoSums = twoPair(array, target - array[i], i + 1);
                foreach (var twoSum in twoSums)
                {
                    result.Add(new int[] { array[i], twoSum[0], twoSum[1] });
                }
            }

            return result;
        }

    }
}
