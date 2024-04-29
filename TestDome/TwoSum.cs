using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/two-sum/96020
/// </summary>
internal class TwoSum : IStartable
{
    public void Start()
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices != null)
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }

    public static Tuple<int, int> FindTwoSum(List<int> list, int sum)
    {
        Dictionary<int, int[]> groups = list.Select((value, index) => (value, index)).GroupBy(x => x.value).ToDictionary(x => x.Key, x => x.Select(xs => xs.index).ToArray());
        foreach (var group in groups)
        {
            int secondValue = sum - group.Key;
            if (groups.TryGetValue(secondValue, out int[] indexes))
            {
                int firstIndex = group.Value.First();
                if (secondValue != group.Key)
                    return new Tuple<int, int>(firstIndex, indexes.First());
                else if (group.Value.Length >= 2)
                    return new Tuple<int, int>(firstIndex, group.Value.First(i => i != firstIndex));
            }
        }
        return null;
    }
}
