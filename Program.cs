using Challenges.Codewars.Keyu7;
using Challenges.Helpers;
using System;

namespace Challenges;

internal class Program
{
    static void Main(string[] args)
    {
        IStartable startable = new CheckExam();
        Console.WriteLine($"Running: {startable.GetType().Name}");
        startable.Start();

        Console.WriteLine($"\r\nPress any key to continue...");
        Console.ReadKey();
    }
}
