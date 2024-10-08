using ArrayAlgorithms.NTupleSum;
using System.ComponentModel.DataAnnotations;

namespace ArrayAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
            var k = 2;
            var target = 10;
            PrintProblem(array, k, target);
            PrintSolution("OnePassHash", TwoSum.OnePassHash(array, target));
            PrintSolution("TwoPassHash", TwoSum.TwoPassHash(array, target));
            PrintSolution("TwoPointers", TwoSum.TwoPointers(array, target));

            array = new int[] { -1, 0, 1, 2, -1, -4 };
            k = 3;
            target = 0;
            PrintProblem(array, k, target);
            PrintSolution("OnePassHash", ThreeSum.ForLoopPlusPair(array, target, TwoSum.OnePassHash));
            PrintSolution("TwoPassHash", ThreeSum.ForLoopPlusPair(array, target, TwoSum.TwoPassHash));
            Array.Sort(array);
            PrintSolution("TwoPointers", ThreeSum.ForLoopPlusPair(array, target, TwoSum.TwoPointers));

            Console.ReadKey();

            return;
            array = new int[200];// { 12, 3, 1, 2, -6, 5, -8, 6 };
            var rand = new Random(0);
            array = array.Select(p => (int)rand.NextInt64(200)).ToArray();
            int targetSum = 30;
            int K = 6;

            //Console.WriteLine($"Finding {K}-elements having sum equal to {targetSum} in array [{string.Join(", ", array)}]:");

            foreach (var nTuple in NElementSum.FindElements(K, array, targetSum))
            {
                //Console.WriteLine(string.Join(", ", nTuple));
            }

            Console.WriteLine("Finished");

            Console.ReadKey();
        }

        private static void PrintSolution(string algorithm, List<int[]> solutions)
        {
            Console.WriteLine();
            Console.WriteLine($"{algorithm} - Found [{solutions.Count}] solution(s):");
            foreach (var solution in solutions)
            {
                Console.WriteLine($"[{string.Join(", ", solution)}]");
            }
            Console.WriteLine();
        }

        private static void PrintProblem(int[] array, int K, int targetSum)
        {
            Console.WriteLine("***");
            Console.WriteLine($"Finding [{K}]-elements having sum equal to [{targetSum}] in array:");
            Console.WriteLine($"[{string.Join(", ", array)}]:");
        }
    }
}