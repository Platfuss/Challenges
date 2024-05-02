using Challenges.Helpers;
using System;
using System.Collections.Generic;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/train-composition/96017
/// </summary>
internal class TrainComposition : IStartable
{
    public void Start()
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        train.AttachWagonFromRight(19);
        train.AttachWagonFromLeft(5);
        Console.WriteLine(train.DetachWagonFromRight());
        Console.WriteLine(train.DetachWagonFromLeft());
    }

    private LinkedList<int> wagons = new();
    public void AttachWagonFromLeft(int wagonId)
    {
        wagons.AddFirst(wagonId);
    }

    public void AttachWagonFromRight(int wagonId)
    {
        wagons.AddLast(wagonId);
    }

    public int DetachWagonFromLeft()
    {
        int first = wagons.First.Value;
        wagons.RemoveFirst();
        return first;
    }

    public int DetachWagonFromRight()
    {
        int last = wagons.Last.Value;
        wagons.RemoveLast();
        return last;
    }
}
