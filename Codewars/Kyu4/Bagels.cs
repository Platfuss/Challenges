using Challenges.Helpers;
using System;

namespace Challenges.Codewars.Kyu4;
internal class Bagels : IStartable
{
    public void Start()
    {
        Bagel bagel = Bagel;
        Console.WriteLine(bagel.Value == 4);
    }

    public static Bagel Bagel
    {
        get
        {
            Bagel bagel = new();
            bagel.GetType().GetProperty("Value").SetValue(bagel, 4);
            return bagel;
        }
    }
}

sealed class Bagel
{
    public int Value { get; private set; } = 3;
}
