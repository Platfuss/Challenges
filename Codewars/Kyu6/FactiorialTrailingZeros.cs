using Challenges.Helpers;
using System;
using System.Linq;

namespace Challenges.Codewars.Kyu6;
/// <summary>
/// https://www.codewars.com/kata/52f787eb172a8b4ae1000a34
/// </summary>
internal class FactiorialTrailingZeros : IStartable
{
    public void Start()
    {
        Console.WriteLine(TrailingZeros(5));
        Console.WriteLine(TrailingZeros(25));
        Console.WriteLine(TrailingZeros(531));
    }

    public static int TrailingZeros(int n)
    {
        int stop = (int)Math.Log(n, 5);
        return Enumerable.Range(1, stop).Sum(x => (int)(n / Math.Pow(5, x)));
    }
}
