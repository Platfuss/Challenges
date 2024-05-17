using Challenges.Helpers;
using System;
using System.Linq;

namespace Challenges.Codewars.Kyu6;
/// <summary>
/// https://www.codewars.com/kata/545cedaa9943f7fe7b000048/train/csharp
/// </summary>
internal class DetectPangram : IStartable
{
    public void Start()
    {
        Console.WriteLine(IsPangram("The quick brown fox jumps over the lazy dog."));
    }

    public static bool IsPangram(string str)
    {
        return Enumerable.Range(0, 26).Select(n => 'A' + n).All(c => str.ToUpper().Contains((char)c));
    }
}
