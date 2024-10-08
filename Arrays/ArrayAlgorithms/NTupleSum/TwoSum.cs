using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ArrayAlgorithms.NTupleSum
{
    public class TwoSum
    {
        public static List<int[]> TwoPassHash(int[] array, int target, int startIndex = 0)
        {
            var hash = new HashSet<int>(array.Skip(startIndex));
            var result = new List<int[]>();

            foreach (var n in array.Skip(startIndex))
            {
                var complement = target - n;

                if (hash.Contains(complement) && complement > n)
                    result.Add(new int[] { complement, n });
            }
            return result;
        }

        public static List<int[]> OnePassHash(int[] array, int target, int startIndex = 0)
        {
            var hash = new HashSet<int>();
            var result = new List<int[]>();

            foreach (var n in array.Skip(startIndex))
            {
                var complement = target - n;

                if (hash.Contains(complement))
                    result.Add(new int[] { complement, n });

                hash.Add(n);
            }
            return result;
        }

        public static List<int[]> TwoPointers(int[] array, int target, int startIndex = 0)
        {
            Array.Sort(array);
            var i = startIndex;
            var j = array.Length - 1;
            var result = new List<int[]>();

            while (i < j)
            {
                var sum = array[i] + array[j];
                if (sum == target)
                    result.Add(new int[] { array[i], array[j] });

                if (sum < target)
                    i++;
                else
                    j--;
            }
            return result;
        }
    }
}
