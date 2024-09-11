namespace Heap
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap((parent, child) => parent < child);
            heap.Add(1);
            heap.Add(2);
            heap.Add(3);
            heap.Add(4);
            heap.Add(-1);
            heap.Remove();
            heap.Remove();
            heap.Remove();


            Console.WriteLine(heap.Peek());

            Console.ReadKey();
        }
    }
}