using ArrayAlgorithms.NTupleSum;
using System.ComponentModel.DataAnnotations;

namespace ArrayAlgorithms
{
    public class MyProgram
    {
        private int[] _array;
        public int[] ThreeNumberSort(int[] array, int[] order)
        {
            int i = 0;
            _array = array;
            foreach (var orderEl in order)
            {
                Console.WriteLine($"{orderEl}: {i} = [{string.Join(", ", array)}]");
                int j = array.Length - 1;
                while (i < j)
                {
                    if (array[i] == orderEl)
                    {
                        i++;
                        continue;
                    }
                    if (array[j] != orderEl)
                    {
                        j--;
                        continue;
                    }
                    Swap(i, j);
                    i++;
                    j--;
                    if (array[i] == orderEl)
                    {
                        i++;
                        continue;
                    }
                }
            }
            return _array;
        }
        void Swap(int i, int j)
        {
            var temp = _array[i];
            _array[i] = _array[j];
            _array[j] = temp;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 0, 0, -1, -1, 0, 1, 1 };
            var order = new int[] { 0, 1, -1 };
            var x = new MyProgram().ThreeNumberSort(array, order);
            Console.WriteLine(string.Join(",", x));
            array = new int[] { 7, 6, 4, -1, 1, 2 };
            FourSum.FourNumberSum(array, 16);

            array = new int[] { -1, 3, 5, -4, 8, 11, 1, -1, 6, 11 };
            var k = 2;
            var target = 10;
            PrintProblem(array, k, target);
            PrintSolution("OnePassHash", TwoSum.OnePassHash(array, target));
            PrintSolution("TwoPassHash", TwoSum.TwoPassHash(array, target));
            PrintSolution("TwoPointers", TwoSum.TwoPointers(array, target));

            //for (int i = 0; i < 100000; i++)
            //{
            //    var rand1 = new Random(0);
            //    //array = Enumerable.Range(0, 20).Select(p => (int)rand1.NextInt64(10)).ToArray();
            //    array = new int[] { 8, 7, 0, 1, 4, 5, 7, 6, 7, 7, 3, 5, 8, 4, 2, 3, 2, 9, 6, 8 };

            //    var orgArray = (int[])array.Clone();
            //    k = 3;
            //    target = 10;// rand1.Next(100);

            //    var s1 = ThreeSum.ForLoopPlusPair(array, target, TwoSum.OnePassHash);
            //    var s2 = ThreeSum.ForLoopPlusPair(array, target, TwoSum.TwoPassHash);
            //    Array.Sort(array);
            //    var s3 = ThreeSum.ForLoopPlusPair(array, target, TwoSum.TwoPointers);
            //    if (s1.Count != 0)
            //    {
            //        if (s1.Count != s2.Count || s2.Count != s3.Count)
            //        {
            //            PrintProblem(orgArray, k, target);
            //            PrintSolution("OnePassHash", s1);
            //            PrintSolution("TwoPassHash", s2);
            //            PrintSolution("TwoPointers", s3);
            //        }
            //    }
            //}
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