using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Maze
    {
        private int mazeSize;
        private List<int[]> allStartPositions = new List<int[]>();
        public int[,] Map { get; set; }
        
        public List<int[]> AllStartPositions
        {
            get
            {
                return allStartPositions;
            }
        }
        public int MazeSize
        {
            get
            {
                return mazeSize;
            }
        }
        public MazeCordinate getMazeCordinate(int y, int x)
        {
            if (y < 0 || y >= mazeSize || x < 0 || x >= mazeSize)
            {
                return MazeCordinate.OUT_OF_BOUNDS;
            }
            return (MazeCordinate)Enum.ToObject(typeof(MazeCordinate), Map[y, x]);
        }


        public bool LoadMaze()
        {
            //int[] startNew = new int[2];
            //Load map file
            String input = File.ReadAllText(@"Resources/map.txt");
            //get size of maze matrix
            double matrixSize = Math.Sqrt(input.Count(c => !Char.IsWhiteSpace(c)));
            //check if maze is square
            bool isSquare = matrixSize % 1 == 0;
            if (!isSquare)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Map is not square!\nPlease input correct map!");
                Console.ReadKey();
                return false;
            }

            //set size of maze matrix
            mazeSize = (int)matrixSize;

            //put input string to multidiimensional array
            Map = new int[mazeSize, mazeSize];
            int k = 0, m = 0;
            foreach (var row in input.Split('\n'))
            {
                m = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    //check if map format is correct
                    if (!int.TryParse(col.Trim(), out Map[k, m]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Map is not numeric!\nPlease input correct map!");
                        Console.ReadKey();
                        return false;
                    }
                    if (Map[k, m] == 3)
                    {
                        int[] startNew = new int[2];
                        startNew[0] = k;
                        startNew[1] = m;
                        allStartPositions.Add(startNew);
                    }
                    m++;
                }
                k++;
            }
            return true;
        }
    }
}
