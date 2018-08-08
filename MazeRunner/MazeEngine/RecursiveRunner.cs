using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeRunner
{
    class RecursiveRunner : Runner
    {
        private int[,] wasHere;
        bool gameStatus = false;
        int correctPathSize = 0;
        private List<int[]> correctPath = new List<int[]>();

        //get right path or if not false by recursion
        public bool recursiveSolve(int y, int x, Maze maze)
        {
            if (maze.Map[y, x] == 2)
            {
                int[] arrStep = new int[2];
                arrStep[0] = y;
                arrStep[1] = x;
                correctPath.Add(arrStep);
                return true;
            }
            if (maze.Map[y, x] == 0 || wasHere[y, x] == 1) return false;

            wasHere[y, x] = 1;
            if (y != 0)
                if (recursiveSolve(y - 1, x, maze))
                {
                    int[] arrStep = new int[2];
                    arrStep[0] = y;
                    arrStep[1] = x;
                    correctPath.Add(arrStep);
                    return true;
                }
            if (y != maze.MazeSize - 1)
                if (recursiveSolve(y + 1, x, maze))
                {
                    int[] arrStep = new int[2];
                    arrStep[0] = y;
                    arrStep[1] = x;
                    correctPath.Add(arrStep);
                    return true;
                }
            if (x != 0)
                if (recursiveSolve(y, x - 1, maze))
                {
                    int[] arrStep = new int[2];
                    arrStep[0] = y;
                    arrStep[1] = x;
                    correctPath.Add(arrStep);
                    return true;
                }
            if (x != maze.MazeSize - 1)
                if (recursiveSolve(y, x + 1, maze))
                {
                    int[] arrStep = new int[2];
                    arrStep[0] = y;
                    arrStep[1] = x;
                    correctPath.Add(arrStep);
                    return true;
                }
            return false;
        }


        public override int Run(Maze maze)
        {
            Thread.Sleep(200);
            wasHere = new int[maze.MazeSize, maze.MazeSize];
            if (playerEntranceStartCount == 0)
            {
                playerEntranceStartCount++;
                gameStatus = recursiveSolve(selectedEntranceY, selectedEntranceX, maze);
                correctPathSize = correctPath.Count();
                if (gameStatus)
                {
                    maze.Map[correctPath[correctPathSize - 1][0], correctPath[correctPathSize - 1][1]] = 3;
                    maze.Map[correctPath[0][0], correctPath[0][1]] = 10;
                }
            }

            if (gameStatus)
            {
                if (correctPathSize > 0)
                {
                    correctPathSize--;
                    playerCurPosY = correctPath[correctPathSize][0];
                    playerCurPosX = correctPath[correctPathSize][1];
                    if (correctPathSize < correctPath.Count() - 1)
                    {
                        playerPrevPosY = correctPath[correctPathSize + 1][0];
                        playerPrevPosX = correctPath[correctPathSize + 1][1];
                    }
                    return 0;
                }
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
