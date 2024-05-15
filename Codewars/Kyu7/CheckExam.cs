using Challenges.Helpers;
using System.Linq;

namespace Challenges.Codewars.Keyu7;
/// <summary>
/// https://www.codewars.com/kata/5a3dd29055519e23ec000074/train/csharp
/// </summary>
internal class CheckExam : IStartable
{
    public void Start()
    {
        System.Console.WriteLine(CheckExams(new string[] { "a", "a", "b", "b" }, new string[] { "a", "c", "b", "d" }));
        System.Console.WriteLine(CheckExams(new string[] { "a", "a", "c", "b" }, new string[] { "a", "a", "b", "" }));
        System.Console.WriteLine(CheckExams(new string[] { "b", "c", "b", "a" }, new string[] { "", "a", "a", "c" }));
    }

    public static int CheckExams(string[] arr1, string[] arr2)
    {
        int score = 0;
        foreach ((string x, int i) item in arr1.Select((x, i) => (x, i)))
        {
            score += item.x == arr2[item.i]
               ? 4
               : arr2[item.i] == string.Empty
                   ? 0 : -1;
        }
        return score > 0 ? score : 0;
    }
}
