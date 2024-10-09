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
            var hash = new Dictionary<int, List<int>>();
            for (int i = startIndex; i < array.Length; i++)
            {
                var n = array[i];
                if (!hash.ContainsKey(n))
                    hash[n] = new List<int>();
                hash[n].Add(i);
            }
            
            var result = new List<int[]>();
            for (int i = startIndex; i < array.Length; i++)
            {
                var n = array[i];
                var complement = target - n;

                if (hash.ContainsKey(complement))
                {
                    foreach (var compIndex in hash[complement])
                    {
                        if (compIndex > i)
                            result.Add(new int[] { array[i], array[compIndex] });
                    }
                }
            }
            return result;
        }

        public static List<int[]> OnePassHash(int[] array, int target, int startIndex = 0)
        {
            var hash = new Dictionary<int, List<int>>();
            var result = new List<int[]>();

            for (int i = startIndex; i < array.Length; i++)
            {
                var n = array[i];
                var complement = target - n;

                if (hash.ContainsKey(complement))
                {
                    foreach (var compIndex in hash[complement])
                    {
                        result.Add(new int[] { array[i], array[compIndex] });
                    }
                }

                if (!hash.ContainsKey(n))
                    hash[n] = new List<int>();

                hash[n].Add(i);
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
                {
                    var jCopy = j;
                    while (i < jCopy && array[jCopy] == array[j])
                    {
                        result.Add(new int[] { array[i], array[jCopy] });
                        jCopy--;
                    }
                    i++;
                    continue;
                }

                if (sum < target)
                    i++;
                else
                    j--;
            }
            return result;
        }
    }
}
