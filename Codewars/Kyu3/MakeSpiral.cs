using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Challenges.Codewars.Kyu3;
/// <summary>
/// https://www.codewars.com/kata/534e01fbbb17187c7e0000c6/train/csharp
/// </summary>
internal class MakeSpiral : IStartable
{
    public void Start()
    {
        int input = 8;

        int[,] actual = Spiralize(input);
        Console.WriteLine();
    }

    public static int[,] Spiralize(int size)
    {
        int[][] map = Enumerable.Repeat(1, size).Select(x => Enumerable.Repeat(1, size).ToArray()).ToArray();
        (int row, int col) position = (1, 0);

        bool gotStuck = false;
        while (!gotStuck)
        {
            foreach (Direction direction in GetDirection())
            {
                gotStuck = true;
                bool isValid = true;
                while (isValid)
                {
                    map[position.row][position.col] = 0;
                    (int row, int col) nextPosition = GetNextPoint(position, direction);
                    isValid = IsValidMove(map, nextPosition, direction);
                    if (isValid)
                    {
                        position = nextPosition;
                        gotStuck = false;
                    }
                    else
                        break;
                }

                if (gotStuck)
                    break;
            }
        }

        int[,] map2D = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                map2D[i, j] = map[i][j];
        }
        return map2D;
    }

    private static bool IsValidMove(int[][] map, (int row, int col) position, Direction direction)
    {
        int mapSize = map.GetLength(0);
        if (position.row == mapSize - 1 || position.col == 0 || position.col == mapSize - 1)
            return false;

        if (map[position.row][position.col] == 0)
            return false;

        (int row, int col) = GetNextPoint(position, direction);
        if (row > mapSize - 1 || col > mapSize - 1)
            return true;

        return map[row][col] != 0;
    }

    private static (int row, int col) GetNextPoint((int row, int col) position, Direction direction)
    {
        return direction switch
        {
            Direction.Right => (position.row, position.col + 1),
            Direction.Down => (position.row + 1, position.col),
            Direction.Left => (position.row, position.col - 1),
            Direction.Up => (position.row - 1, position.col),
            _ => throw new Exception()
        };
    }

    private static IEnumerable<Direction> GetDirection()
    {
        while (true)
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                yield return direction;
        }
    }

    public enum Direction
    {
        Right, Down, Left, Up
    }
}
