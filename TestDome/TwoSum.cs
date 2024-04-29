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
        IEnumerable<IGrouping<int, (int value, int index)>> groups = list.Select((value, index) => (value, index)).GroupBy(x => x.value);
        foreach (var group in groups)
        {
            var matchingGroup = groups.FirstOrDefault(g => g.Key == sum - group.Key);
            if (matchingGroup != null)
            {
                if (matchingGroup.Key != group.Key)
                    return new Tuple<int, int>(group.First().index, matchingGroup.First().index);
                else if (group.Count() >= 2)
                {
                    var (value, index) = group.First();
                    return new Tuple<int, int>(index, group.First(g => g.index != index).index);
                }
            }
        }
        return null;
    }
}
