using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.Codewars.Kyu4;
/// <summary>
/// https://www.codewars.com/kata/52c4dd683bfd3b434c000292/train/csharp
/// </summary>
internal class CatchingCarMileageNumbers : IStartable
{
    public void Start()
    {
        Console.WriteLine(IsInteresting(3236, new List<int>() { 1337, 256 })); // 0
        Console.WriteLine(IsInteresting(11210, new List<int>() { }));   // 1
        Console.WriteLine(IsInteresting(11211, new List<int>() { }));   // 2
    }

    public static int IsInteresting(int number, List<int> awesomePhrases)
    {
        bool isInterestingNow = false, isInterestingSoon = false;
        foreach ((int value, int i) in Enumerable.Range(number, 3).Select((value, i) => (value, i)))
        {
            bool isInteresting = CheckConditions(value, awesomePhrases);
            if (isInteresting && i == 0)
                isInterestingNow = true;
            else if (isInteresting)
                isInterestingSoon = true;

            if (isInteresting)
                break;
        }

        return isInterestingNow
            ? 2
            : isInterestingSoon
            ? 1 : 0;
    }

    private static bool CheckConditions(int value, List<int> awesomePhrases)
    {
        if (value < 100)
            return false;

        if (awesomePhrases.Contains(value))
            return true;

        string valueString = value.ToString();
        if (Enumerable.Range(1, 9).Select(c => '0' + c).Contains(valueString.First()) && valueString.Skip(1).All(c => c == '0'))
            return true;

        if (valueString.All(c => c == valueString.First()))
            return true;

        if (IsPalindrome(valueString))
            return true;

        if (IsSequential(valueString))
            return true;

        return false;
    }

    private static bool IsSequential(string valueString)
    {
        if (IsSequential(valueString, Enumerable.Range(0, 10).Select(n => (9 - n).ToString().First()).ToList()))
            return true;

        return IsSequential(valueString, Enumerable.Range(1, 9).Append(0).Select(n => n.ToString().First()).ToList());
    }

    private static bool IsSequential(string valueString, List<char> pattern)
    {
        int start = pattern.IndexOf(valueString.First());
        if (start + valueString.Length > pattern.Count)
            return false;

        foreach (char c in valueString)
        {
            if (c != pattern[start++])
                return false;
        }
        return true;
    }

    private static bool IsPalindrome(string valueString)
    {
        int start = 0, end = valueString.Length - 1;
        while (start < end)
        {
            if (valueString[start] != valueString[end])
                return false;
            start++; end--;
        }
        return true;
    }
}
