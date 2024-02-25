namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 10, 3, 5, 7, 3, 1, -1, 2, 0 };

            BubbleSort.SortSlightlyOptimized(array);

            array.ToList().ForEach(p => Console.Write(p + " "));
        }
    }
}