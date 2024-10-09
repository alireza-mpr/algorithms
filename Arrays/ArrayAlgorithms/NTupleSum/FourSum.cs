using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgorithms.NTupleSum
{
    public class FourSum
    {
        public static List<int[]> FourNumberSum(int[] array, int targetSum)
        {
            var results = new List<int[]>();

            var hash = new Dictionary<int, List<List<int>>>();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    var summand1 = array[i] + array[j];
                    var summand2 = targetSum - summand1;
                    if (hash.ContainsKey(summand2))
                    {
                        foreach (var complements in hash[summand2])
                        {
                            var result = new List<int>(complements);
                            result.Add(array[i]);
                            result.Add(array[j]);
                            results.Add(result.ToArray());
                        }
                    }
                }
                for (int k = 0; k < i; k++)
                {
                    var sum = array[i] + array[k];
                    if (!hash.ContainsKey(sum))
                        hash[sum] = new List<List<int>>();
                    hash[sum].Add(new List<int>() { array[i], array[k] });
                }
            }
            return results;
        }
    }
}
