using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenges.Codewars.Kyu4;
/// <summary>
/// https://www.codewars.com/kata/546d15cebed2e10334000ed9/train/csharp
/// </summary>
internal class FindTheUnknownDigit : IStartable
{
    public void Start()
    {
        Console.WriteLine(2 == SolveExpression("1+1=?"));
        Console.WriteLine(6 == SolveExpression("123*45?=5?088"));
        Console.WriteLine(0 == SolveExpression("-5?*-1=5?"));
        Console.WriteLine(5 == SolveExpression("??*??=302?"));
        Console.WriteLine(2 == SolveExpression("?*11=??"));
        Console.WriteLine(2 == SolveExpression("??*1=??"));
        Console.WriteLine(-1 == SolveExpression("19--45=5?"));
        Console.WriteLine(-1 == SolveExpression("??+??=??"));
    }

    private static readonly Regex exFormula = new($@"(?<first>-?[?\d]+)(?<operator>[+\-*])(?<second>-?[?\d]+)=(?<result>-?[?\d]+)", RegexOptions.Compiled);

    public static int SolveExpression(string expression)
    {
        List<int> possibleReplacements = Enumerable.Range(0, 10).Where(n => !expression.Where(char.IsDigit).Select(char.GetNumericValue).Contains(n)).ToList();
        Match mFormula = exFormula.Match(expression);
        string first = mFormula.Groups["first"].Value;
        string operatorSign = mFormula.Groups["operator"].Value;
        string second = mFormula.Groups["second"].Value;
        string result = mFormula.Groups["result"].Value;

        string[] numbers = new string[] { first, second, result };
        if (numbers.Any(n => n.Length > 1 && (n.StartsWith('?') || n.StartsWith("-?"))))
            possibleReplacements.Remove(0);

        foreach (string replacement in possibleReplacements.Select(r => r.ToString()))
        {
            int[] convertedNumbers = numbers.Select(n => int.Parse(n.Replace("?", replacement))).ToArray();
            bool isCorrectEquation = operatorSign switch
            {
                "+" => convertedNumbers[0] + convertedNumbers[1] == convertedNumbers[2],
                "-" => convertedNumbers[0] - convertedNumbers[1] == convertedNumbers[2],
                "*" => convertedNumbers[0] * convertedNumbers[1] == convertedNumbers[2],
                _ => throw new ArgumentException("Unknown operator!")
            };
            if (isCorrectEquation)
                return int.Parse(replacement);
        }

        return -1;
    }
}
