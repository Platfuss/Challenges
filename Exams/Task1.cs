using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.Exams
{
    public class ConstructionGame : IStartable
    {
        private List<bool[,]> floors = new();
        private int length;
        private int width;

        public ConstructionGame(int length, int width)
        {
            this.length = length;
            this.width = width;
        }

        public ConstructionGame()
        {
        }

        public void AddCubes(bool[,] cubes)
        {
            if (floors.Count == 0)
                floors.Add(new bool[length, width]);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (cubes[i, j] == false)
                        continue;

                    int? freeLevel = GetFirstEmptyLevel(i, j);
                    if (freeLevel == null)
                    {
                        floors.Add(new bool[length, width]);
                        floors.Last()[i, j] = true;
                    }
                    else
                        floors[(int)freeLevel][i, j] = true;
                }
            }

            floors.RemoveAll(floor => floor.Cast<bool>().All(i => i == true));
        }

        private int? GetFirstEmptyLevel(int h, int w)
        {
            for (int i = 0; i < floors.Count; i++)
            {
                if (floors[i][h, w] == false)
                    return i;
            }
            return null;
        }

        public int GetHeight()
        {
            return floors.Count != 1
                ? floors.Count
                : floors[0].Cast<bool>().All(i => i == false) ? 0 : 1;
        }

        public void Start()
        {
            ConstructionGame game = new ConstructionGame(2, 2);

            game.AddCubes(new bool[,]
            {
            { true, true },
            { false, false }
            });
            game.AddCubes(new bool[,]
            {
            { true, true },
            { false, true }
            });
            Console.WriteLine(game.GetHeight()); // should print 2

            game.AddCubes(new bool[,]
            {
            { false, false },
            { true, true }
            });
            Console.WriteLine(game.GetHeight()); // should print 1
        }
    }
}
