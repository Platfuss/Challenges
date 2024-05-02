using Challenges.Helpers;
using System;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/sorted-search/96012
/// </summary>
internal class SortedSearch : IStartable
{
    public void Start()
    {
        Console.WriteLine(CountNumbers(new int[] { 1, 2, 3, 4 }, 4));
    }

    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int idx = Array.BinarySearch(sortedArray, lessThan);
        return idx < 0 ? ~idx : idx;
    }
}
