using Challenges.Helpers;
using Challenges.TestDome;
using System;

namespace Challenges;

internal class Program
{
    static void Main(string[] args)
    {
        IStartable startable = new Folders();
        Console.WriteLine($"Running: {startable.GetType().Name}");
        startable.Start();

        Console.WriteLine($"\r\nPress any key to continue...");
        Console.ReadKey();
    }
}
