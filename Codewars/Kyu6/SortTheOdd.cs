using Challenges.Helpers;
using System;
using System.Linq;

namespace Challenges.Codewars.Kyu6;
/// <summary>
/// https://www.codewars.com/kata/578aa45ee9fd15ff4600090d/train/csharp
/// </summary>
internal class SortTheOdd : IStartable
{
    public void Start()
    {
        SortArray(new int[] { 5, 3, 2, 8, 1, 4 });
        Console.WriteLine();
        SortArray(new int[] { 5, 3, 1, 8, 0 });
    }

    public static int[] SortArray(int[] array)
    {
        int[] indexesOfOdds = array.Select((a, index) => a % 2 == 0 ? -1 : index).Where(a => a >= 0).ToArray();
        int[] sortedOdds = array.Where(a => a % 2 != 0).OrderBy(a => a).ToArray();
        for (int i = 0; i < sortedOdds.Length; i++)
            array[indexesOfOdds[i]] = sortedOdds[i];
        return array;
    }
}
