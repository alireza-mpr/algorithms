namespace Combinatorics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = new List<string>() { "A", "B", "C", "D" };

            Console.WriteLine($"Subsets of [{string.Join(",", elements)}]:");
            foreach (var subset in Set.GetSubsets(elements).OrderBy(p=>p.Count))
            {
                Console.WriteLine(string.Join(",", subset));
            }

            return;
            var result = new List<List<string>>();
            int c = 2;

            GeneratePermutation(elements, result, c);
            result.Clear();
            GenerateCombination(elements, result, c);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        private static void GenerateCombination(List<string> elements, List<List<string>> allCombinations, int c)
        {
            Combination(elements, 0, c, new(), allCombinations);

            Console.WriteLine($"Combination of {c} selections from {elements.Count} items = {allCombinations.Count}");
            for (int i = 0; i < allCombinations.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {string.Join(",", allCombinations[i])}");
            }
            Console.WriteLine("=== END ===");
        }

        private static void Combination(
            List<string> elements,
            int index,
            int c,
            List<string> thisCombination,
            List<List<string>> allCombinations
            )
        {
            if (thisCombination.Count == c)
            {
                allCombinations.Add(thisCombination);
                return;
            }

            for (int i = index; i < elements.Count; i++)
            {
                var el = elements[i];
                var newCombination = new List<string>(thisCombination)
                {
                    el,
                };
                Combination(elements, i + 1, c, newCombination, allCombinations);
            }
        }
        private static void GeneratePermutation(List<string> elements, List<List<string>> allPermutations, int c)
        {
            Permutation(elements, c, new(), allPermutations);

            Console.WriteLine($"Permutation of {c} selections from {elements.Count} items = {allPermutations.Count}");
            for (int i = 0; i < allPermutations.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {string.Join(",", allPermutations[i])}");
            }
            Console.WriteLine("=== END ===");
        }

        private static void Permutation(
            List<string> elements,
            int c,
            List<string> thisPermutation,
            List<List<string>> allCombinations
            )
        {
            if (thisPermutation.Count == c)
            {
                allCombinations.Add(thisPermutation);
                return;
            }

            for (int i = 0; i < elements.Count; i++)
            {
                var el = elements[i];
                elements.RemoveAt(i);
                var newCombination = new List<string>(thisPermutation)
                {
                    el
                };
                Permutation(elements, c, newCombination, allCombinations);
                elements.Insert(i, el);
            }
        }
    }
}