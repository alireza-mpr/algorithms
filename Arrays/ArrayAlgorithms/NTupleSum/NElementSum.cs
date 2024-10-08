using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgorithms.NTupleSum
{
    public class NElementSum
    {
        public static List<int[]> FindElements(int N, int[] array, int targetSum)
        {
            Array.Sort(array);
            return FindElements(N, 0, array, targetSum);
        }

        private static List<int[]> FindElements(int K, int startIndex, int[] array, int targetSum)
        {
            if (K == 4)
                return FindFourNumberSum(startIndex, array, targetSum);

            if (K == 2)
                return FindTwoNumberSum(startIndex, array, targetSum);

            List<int[]> result = new();

            for (int i = startIndex; i < array.Length; i++)
            {
                foreach (var nTuple in FindElements(K - 1, i + 1, array, targetSum - array[i]))
                {
                    result.Add(new[] { array[i] }.Concat(nTuple).ToArray());
                }
            }
            return result;
        }

        private static List<int[]> FindTwoNumberSum(int startIndex, int[] array, int targetSum)
        {
            var result = new List<int[]>();
            int i = startIndex, j = array.Length - 1;
            while (i < j)
            {
                var sum = array[i] + array[j];
                if (sum == targetSum)
                {
                    result.Add(new int[2] { array[i], array[j] });
                    i++;
                    j--;
                }
                else if (sum < targetSum)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return result;
        }

        private static List<int[]> FindFourNumberSum(int startIndex, int[] array, int targetSum)
        {
            var result = new List<int[]>();
            var count = array.Length;
            var pairs = new Dictionary<int, List<int[]>>();
            for (int i = startIndex; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    var thisSum = array[i] + array[j];
                    var summand = targetSum - thisSum;
                    if (pairs.ContainsKey(summand))
                    {
                        Console.WriteLine(thisSum + ":" + summand);
                        foreach (var summandPair in pairs[summand])
                        {
                            result.Add(new int[]{
                           array[i], array[j],
                           summandPair[0], summandPair[1]
                    });
                        }
                    }
                }
                for (int k = startIndex; k < i; k++)
                {
                    var sum = array[i] + array[k];
                    if (!pairs.ContainsKey(sum))
                    {
                        pairs.Add(sum, new List<int[]>());
                    }
                    pairs[sum].Add(new int[] { array[i], array[k] });
                }
            }
            return result;
        }
    }
}
