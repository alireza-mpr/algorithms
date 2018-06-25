using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = args != null && args.Length > 0 && int.TryParse(args[0], out int n) ? n : 5;
            GenerateNumbersRandomly = args != null && args.Length > 1 && bool.TryParse(args[1], out bool randomly) ? randomly : false;
            bool justWeeks = args != null && args.Length > 2 && bool.TryParse(args[2], out bool justweeks) ? justweeks : false;
            var schedule = ComputeSchedule(N);

            if (!justWeeks)
                Present(schedule);
            else
                Console.WriteLine($"{N}: {schedule.Count}");
            // Analyse: d
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"{i}: {ComputeSchedule(i).Count}");
            //}

            Console.WriteLine();
        }

        private static void Present(List<int?[]> weeks)
        {
            var len = weeks.Count.ToString().Length;

            for (int weekCntr = 0; weekCntr < weeks.Count; weekCntr++)
            {
                var w = weeks[weekCntr];
                Console.Write($"Week {(weekCntr + 1).ToString("D" + len)}: ");
                for (int i = 0; i < w.Length; i++)
                {
                    Console.Write($"{Pad(w[i], len)}\t");
                }
                Console.WriteLine();
            }
        }

        private static string Pad(int? v, int len)
        {
            return v == null ? new string('-', len) : (v.Value + 1).ToString("D" + len);
        }

        private static List<int?[]> ComputeSchedule(int N)
        {
            var weeks = new List<int?[]>();
            var matches = new bool[N, N];
            var totalMatches = N * (N - 1) / 2;
            var doneMatches = 0;

            while (doneMatches < totalMatches)
            {
                var currentWeek = new int?[N];

                foreach (int i in GenerateNumbers(0, N))
                {
                    if (currentWeek[i] != null)
                        continue;

                    foreach (int j in GenerateNumbers(i + 1, N))
                    {
                        if (currentWeek[j] != null)
                            continue;

                        if (!matches[i, j] && currentWeek[i] == null && currentWeek[j] == null)
                        {
                            matches[i, j] = true;

                            currentWeek[i] = j;
                            currentWeek[j] = i;
                            doneMatches++;
                            break;
                        }
                    }
                }
                weeks.Add(currentWeek);
            }

            return weeks;
        }

        static Random rand = new Random();

        static bool GenerateNumbersRandomly;

        private static IEnumerable<int> GenerateNumbers(int min, int max)
        {
            if (min >= max)
                yield break;

            var olds = new HashSet<int>();

            while (olds.Count < max)
            {
                var all = Enumerable.Range(min, max - min);
                var availables = all.Except(olds.ToList()).ToList();
                int returnValue;
                if (availables.Count == 0)
                    yield break;

                if (GenerateNumbersRandomly)
                {
                    returnValue = availables[rand.Next(availables.Count)];
                }
                else
                {
                    returnValue = availables.First();
                }

                olds.Add(returnValue);

                yield return returnValue;
            }

        }


    }
}
