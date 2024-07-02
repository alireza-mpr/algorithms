using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgorithms
{
    public class NElementSum
    {
        public static List<int[]> FindElements(int N, int[] array, int targetSum)
        {
            Array.Sort(array);
            return FindElements(N, 0, array, targetSum);
        }

        private static List<int[]> FindElements(int N, int startIndex, int[] array, int targetSum)
        {
            List<int[]> result = new();
            if (N == 2)
            {
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
            for (int i = startIndex; i < array.Length; i++)
            {
                foreach (var nTuple in FindElements(N - 1, i + 1, array, targetSum - array[i]))
                {
                    result.Add((new[] { array[i] }.Concat(nTuple)).ToArray());
                }
            }
            return result;
        }

    }
}
