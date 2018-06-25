using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * A gready approach to RoundRobin tournament problem.
             * The result(output) depends on the order of the processing of the teams: because it's greedy.
             * Also, the result may be near optmial and no guarantee it is optimal.
            */

            // Input:
            int N = args != null && args.Length > 0 && int.TryParse(args[0], out int n) ? n : 5;

            //Optional inputs:
            bool justWeeks = args != null && args.Length > 1 && bool.TryParse(args[1], out bool justweeks) ? justweeks : false;

            //Output:
            List<List<string>> schedule = MakeSchedule(N);

            if (!justWeeks)
                Present(schedule);
            else
                Console.WriteLine($"{N}: {schedule.Count}");
        }

        private static List<List<string>> MakeSchedule(int N)
        {
            Dictionary<int, HashSet<int>> TeamOpponents = new Dictionary<int, HashSet<int>>();
            Enumerable.Range(0, N).ToList()
                .ForEach(team =>
                TeamOpponents.Add(
                    team,
                    new HashSet<int>(Enumerable.Range(0, N).Except(new[] { team }))));

            int toalMatches = N * (N - 1) / 2;
            int doneMatches = 0;

            List<List<string>> schedule = new List<List<string>>();

            while (doneMatches < toalMatches)
            {
                List<string> thisRound = new List<string>();
                HashSet<int> thisRoundTeams = new HashSet<int>();

                foreach (var team in Enumerable.Range(0, N)/*just for better result:*/.OrderBy(p => Guid.NewGuid()))
                {
                    if (thisRoundTeams.Contains(team))
                        continue;

                    var possibleOpponents = TeamOpponents[team];
                    if (!possibleOpponents.Any())
                        continue;

                    bool canPlay = false;
                    int opponent = -1;
                    foreach (var possibleOpponent in possibleOpponents/*just for better result:*/.OrderBy(p => Guid.NewGuid()))
                    {
                        if (thisRoundTeams.Contains(possibleOpponent))
                            continue;

                        canPlay = true;
                        opponent = possibleOpponent;
                        break;
                    }
                    if (canPlay)
                    {
                        thisRound.Add($"{team + 1}:{opponent + 1}");
                        possibleOpponents.Remove(opponent);
                        TeamOpponents[opponent].Remove(team);
                        thisRoundTeams.Add(team);
                        thisRoundTeams.Add(opponent);
                        doneMatches++;
                    }
                }

                schedule.Add(thisRound);
            }

            return schedule;
        }

        static void Present(List<List<string>> schedule)
        {
            for (int r = 0; r < schedule.Count; r++)
            {
                Console.Write($"Week {r + 1}:\t");
                foreach (var m in schedule[r])
                {
                    Console.Write(m + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
