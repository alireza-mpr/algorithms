using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundRobinTournament
{
    class Program
    {
        static List<int?> Table;
        static List<List<int?>> schedule = new List<List<int?>>();

        static void Main(string[] args)
        {
            int N = args != null && args.Length > 0 && int.TryParse(args[0], out int n) ? n : 5;
            bool justWeeks = args != null && args.Length > 1 && bool.TryParse(args[1], out bool justweeks) ? justweeks : false;

            schedule.AddRange(Rotate(N));
            if (!justWeeks)
                Present(schedule);
            else
                Console.WriteLine($"{N}: {schedule.Count}");          
        }        

        static IEnumerable<List<int?>> Rotate(int N)
        {
            var totalPairMatches = N * (N - 1);
            var donePairMatches = 0;
            Table = Enumerable.Range(0, N).Select(p => new int?(p)).ToList();
            bool hasEmptySlot = N % 2 == 1;
            if (hasEmptySlot)
                Table.Add(null);

            var oddN = (int)Math.Ceiling(N / 2.0);

            while (donePairMatches < totalPairMatches)
            {
                Table.Insert(1, Table.Last());
                Table.RemoveAt(Table.Count - 1);
                donePairMatches += N - (hasEmptySlot ? 1 : 0);

                yield return new List<int?>(Table);
            }
        }

        private static void Present(List<List<int?>> weeks)
        {
            var len = weeks.Count().ToString().Length;

            int weekCntr = 0;
            foreach (var w in weeks)
            {
                weekCntr++;
                Console.Write($"Week {(weekCntr).ToString("D" + len)}: ");
                for (int i = 0; i < w.Count() / 2; i++)
                {
                    Console.Write($"{Pad(w[i], len)}:{Pad(w[w.Count - i - 1], len)} \t");
                }
                Console.WriteLine();
            }
        }

        private static string Pad(int? v, int len)
        {
            return v == null ? new string('-', len) : (v.Value + 1).ToString("D" + len);
        }
    }
}
