using Challenges.Helpers;
using System;
using System.Linq;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/boat-movements/113617
/// </summary>
internal class BoatMovements : IStartable
{
    public void Start()
    {
        bool[,] gameMatrix =
        {
            {false, true,  true,  false, false, false},//0
            {true,  true,  true,  false, false, false},//1
            {true,  true,  true,  true,  true,  true},//2
            {false, true,  true,  false, true,  true},//3
            {false, true,  true,  true,  false, true},//4
            {false, false, false, false, false, false},//5
        };

        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
        Console.WriteLine(CanTravelTo(gameMatrix, 3, 2, 3, 3));
    }

    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        int width = gameMatrix.GetLength(0);
        int height = gameMatrix.GetLength(1);

        if (!IsValid(fromColumn, width) || !IsValid(toColumn, width) || !IsValid(fromRow, height) || !IsValid(toRow, height))
            return false;

        if (fromRow != toRow && fromColumn != toColumn)
            return false;

        bool isMovingHorizontaly = fromRow == toRow && fromColumn != toColumn;
        if (isMovingHorizontaly)
        {
            int maxMovementSpeed = fromColumn < toColumn ? 2 : 1;
            if (Math.Abs(toColumn - fromColumn) > maxMovementSpeed)
                return false;

            (fromColumn, toColumn) = fromColumn <= toColumn ? (fromColumn, toColumn) : (toColumn, fromColumn);
            return Enumerable.Range(0, width).Select(x => gameMatrix[fromRow, x]).Skip(fromColumn).Take(toColumn - fromColumn + 1).All(x => x);
        }
        else
        {
            if (Math.Abs(fromRow - toRow) > 1)
                return false;

            (fromRow, toRow) = fromRow <= toRow ? (fromRow, toRow) : (toRow, fromRow);
            return Enumerable.Range(0, height).Select(x => gameMatrix[x, fromColumn]).Skip(fromRow).Take(toRow - fromRow + 1).All(x => x);
        }
    }

    private static bool IsValid(int value, int comparingTo)
    {
        return value >= 0 && value < comparingTo;
    }
}
