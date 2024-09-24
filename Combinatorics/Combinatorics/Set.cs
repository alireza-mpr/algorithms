using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    public class Set
    {
        public static List<List<T>> GetSubsets<T>(List<T> set)
        {
            var result = new List<List<T>>();
            result.Add(new List<T>());

            foreach (var num in set)
            {
                var resultCount = result.Count;
                for (int i = 0; i < resultCount; i++)
                {
                    var newSubSet = new List<T>(result[i]);
                    newSubSet.Add(num);
                    result.Add(newSubSet);
                }
            }
            return result;
        }
    }
}
