using Challenges.Helpers;
using System;
using System.Linq;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/sorted-search/96012
/// </summary>
internal class SortedSearch : IStartable
{
    public void Start()
    {
        Console.WriteLine(CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
    }

    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        //int idx = Array.BinarySearch(sortedArray, lessThan);
        //return idx < 0 ? ~idx : idx;
        return BinarySearch(sortedArray, lessThan);
    }

    private static int BinarySearch(int[] sortedArray, int lessThan)
    {
        if (sortedArray.First() >= lessThan)
            return 0;
        else if (sortedArray.Last() < lessThan)
            return sortedArray.Length;

        int leftBound = 0;
        int rightBound = sortedArray.Length - 1;
        int currentIdx = sortedArray.Length / 2;

        while (leftBound < rightBound)
        {
            if (sortedArray[currentIdx] == lessThan)
                return currentIdx;
            else if (sortedArray[currentIdx] < lessThan)
                leftBound = currentIdx + 1;
            else if (sortedArray[currentIdx] > lessThan)
                rightBound = currentIdx;

            currentIdx = leftBound + (rightBound - leftBound) / 2;
        }
        return currentIdx;
    }
}
