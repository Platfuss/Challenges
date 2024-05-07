using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Challenges.Codewars.Kyu3;
/// <summary>
/// https://www.codewars.com/kata/540d0fdd3b6532e5c3000b5b
/// </summary>
internal class BinomialExpansion : IStartable
{
    public void Start()
    {
        Console.WriteLine(Expand("(x+1)^2"));      // returns "x^2+2x+1"
        Console.WriteLine(Expand("(5y+20)^1"));    // returns "5y+20"
        Console.WriteLine(Expand("(p-1)^3"));      // returns "p^3-3p^2+3p-1"
        Console.WriteLine(Expand("(2f+4)^6"));     // returns "64f^6+768f^5+3840f^4+10240f^3+15360f^2+12288f+4096"
        Console.WriteLine(Expand("(-2a-4)^0"));    // returns "1"
        Console.WriteLine(Expand("(-12t+43)^2"));  // returns "144t^2-1032t+1849"
        Console.WriteLine(Expand("(r+0)^203"));    // returns "r^203"
        Console.WriteLine(Expand("(-x-1)^2"));     // returns "x^2+2x+1"
    }

    private static readonly Regex _exFormula = new(@"\((?<a>(-?(\d+)|-(\d+)?))?(?<identifier>\p{L})(?<b>[+\-]\d+)\)\^(?<pow>\d+)", RegexOptions.Compiled);

    public static string Expand(string formula)
    {
        GetIdentifiers(_exFormula.Match(formula), out int a, out char identifier, out int b, out int pow);
        Dictionary<int, long> mainDictionary = new() { { 1, a }, { 0, b } };
        (int value, int rank)[] multipliers = new (int value, int rank)[] { (a, 1), (b, 0) };

        if (pow == 0)
            return "1";

        for (int i = 1; i < pow; i++)
        {
            Dictionary<int, long> helperDictionary = new();
            foreach ((int value, int rank) in multipliers)
            {
                foreach (KeyValuePair<int, long> wage in mainDictionary.OrderByDescending(w => w.Key))
                {
                    int newKey = wage.Key + rank;
                    if (!helperDictionary.ContainsKey(newKey))
                        helperDictionary[newKey] = 0;

                    helperDictionary[newKey] += value * wage.Value;
                }
            }

            mainDictionary = helperDictionary;
        }

        return FormatOutput(identifier, mainDictionary);
    }

    public static string FormatOutput(char identifier, Dictionary<int, long> wages)
    {
        StringBuilder builder = new();
        foreach (KeyValuePair<int, long> wage in wages.OrderByDescending(w => w.Key))
        {
            string identifierWage = wage.Key > 1
                ? $"{identifier}^{wage.Key}"
                : wage.Key == 1
                    ? identifier.ToString()
                    : null;

            string plusSign = wage.Value > 0 && builder.Length > 0 ? "+" : null;

            if (wage.Value == 0)
                continue;
            else if (wage.Value == 1 && wage.Key != 0)
                builder.Append($"{plusSign}{identifierWage}");
            else if (wage.Value == -1 && wage.Key != 0)
                builder.Append($"-{identifierWage}");
            else
                builder.Append($"{plusSign}{wage.Value}{identifierWage}");
        }
        return builder.ToString();
    }

    public static void GetIdentifiers(Match mFormula, out int a, out char identifier, out int b, out int pow)
    {
        if (mFormula.Groups["a"].Success)
            a = mFormula.Groups["a"].Value == "-" ? -1 : int.Parse(mFormula.Groups["a"].Value);
        else
            a = 1;

        identifier = mFormula.Groups["identifier"].Value.First();
        b = int.Parse(mFormula.Groups["b"].Value);
        pow = int.Parse(mFormula.Groups["pow"].Value);
    }
}
