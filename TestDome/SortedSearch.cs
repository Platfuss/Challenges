using Challenges.Helpers;
using System;

namespace Challenges.TestDome;
internal class SortedSearch : IStartable
{
    public void Start()
    {
        Console.WriteLine(CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
    }

    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int idx = Array.BinarySearch(sortedArray, lessThan);
        return idx < 0 ? ~idx : idx;
    }
}
