namespace ArrayAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = new int[200];// { 12, 3, 1, 2, -6, 5, -8, 6 };
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
    }
}