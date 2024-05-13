using Challenges.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenges.Codewars.Kyu3;
/// <summary>
/// https://www.codewars.com/kata/5519a584a73e70fa570005f5/train/csharp
/// </summary>
internal class PrimeStreaming : IStartable
{
    public void Start()
    {
        IEnumerable<int> result = Stream2().Take(1_000_000);
    }

    private static readonly HashSet<int> _knownPrimes = new() { 2 };

    public static IEnumerable<int> Stream()
    {
        yield return 2;
        while (true)
        {
            int knownMax = _knownPrimes.Max();
            List<int> newPrimes = new();
            Parallel.ForEach(Enumerable.Range(knownMax + 1, (int)Math.Pow(knownMax, 2) - knownMax - 1), number =>
            {
                if (!_knownPrimes.Where(p => p <= (int)Math.Sqrt(number)).Any(p => number % p == 0))
                {
                    lock (newPrimes)
                        newPrimes.Add(number);
                }
            });

            foreach (int number in newPrimes.OrderBy(x => x))
            {
                yield return number;
                _knownPrimes.Add(number);
            }
        }
    }

    public static IEnumerable<int> Stream2()
    {
        var sieve = new BitArray(1 << 24);
        for (var p = 2; p < sieve.Length; p++)
        {
            if (sieve[p]) continue;
            yield return p;
            for (int i = p * 2; i < sieve.Length; i += p)
                sieve.Set(i, true);
        }
    }
}
