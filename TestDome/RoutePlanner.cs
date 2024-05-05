using Challenges.Helpers;
using System;
using System.Collections.Generic;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/route-planner/110513
/// </summary>
internal class RoutePlanner : IStartable
{
    public void Start()
    {
        bool[,] mapMatrix = {
            {true, true, true, true},
            {false, true, false, false},
            {false, true, true, false},
            {false, false, true, true},
            {false, false, false, true},
            {false, false, false, true},
            {false, false, false, true},
        };

        Console.WriteLine(RouteExists(0, 0, 6, 3, mapMatrix));
    }

    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                  bool[,] mapMatrix)
    {
        if (!mapMatrix[fromRow, fromColumn] || !mapMatrix[toRow, toColumn])
            return false;

        if (fromRow == toRow && fromColumn == toColumn)
            return true;

        int maxRows = mapMatrix.GetLength(0);
        int maxColumns = mapMatrix.GetLength(1);
        HashSet<(int, int)> visitedPoints = new();

        Queue<(int, int)> pointsOfInterest = new();
        pointsOfInterest.Enqueue((fromRow, fromColumn));
        while (pointsOfInterest.TryDequeue(out (int row, int col) pointToRelax))
        {
            visitedPoints.Add(pointToRelax);

            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                (int row, int col) newPoint = direction switch
                {
                    Direction.Up => (pointToRelax.row - 1, pointToRelax.col),
                    Direction.Right => (pointToRelax.row, pointToRelax.col + 1),
                    Direction.Down => (pointToRelax.row + 1, pointToRelax.col),
                    Direction.Left => (pointToRelax.row, pointToRelax.col - 1),
                    _ => throw new NotImplementedException("Unknown direction")
                };

                if (newPoint.row == toRow && newPoint.col == toColumn)
                    return true;

                if (newPoint.row >= 0 && newPoint.row < maxRows && newPoint.col >= 0 && newPoint.col < maxColumns && mapMatrix[newPoint.row, newPoint.col] == true && !visitedPoints.Contains(newPoint))
                    pointsOfInterest.Enqueue(newPoint);
            }
        }

        return false;
    }

    public enum Direction
    {
        Up, Right, Down, Left
    }
}
