using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.Codewars.Kyu5;
/// <summary>
/// https://www.codewars.com/kata/5270d0d18625160ada0000e4/train/csharp
/// </summary>
internal class GreedIsGood : IStartable
{
    public void Start()
    {
        Console.WriteLine(Score(new int[] { 4, 4, 4, 3, 3 }) == 400);
        Console.WriteLine(Score(new int[] { 2, 4, 4, 5, 4 }) == 450);
    }

    private static Dictionary<int, (int Quantity, int Points)[]> scoringRules = new()
    {
        { 1, new (int, int)[] { (3, 1000), (1, 100) } },
        { 2, new (int, int)[] { (3, 200) } },
        { 3, new (int, int)[] { (3, 300) } },
        { 4, new (int, int)[] { (3, 400) } },
        { 5, new (int, int)[] { (3, 500), (1, 50) } },
        { 6, new (int, int)[] { (3, 600) } },
    };

    public static int Score(int[] dice)
    {
        int score = 0;
        foreach (IGrouping<int, int> scoreGroup in dice.GroupBy(d => d))
        {
            int groupCount = scoreGroup.Count();
            (int Quantity, int Points)[] rules = scoringRules[scoreGroup.Key];

            foreach (var (Quantity, Points) in rules)
            {
                while (groupCount >= Quantity)
                {
                    groupCount -= Quantity;
                    score += Points;
                }
            }
        }

        return score;
    }
}
