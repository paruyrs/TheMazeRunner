using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Render
    {
        private readonly Maze maze;
        public Render(Maze maze)
        {
            this.maze = maze;
        }

        public void printMaze()
        {

            //print maze
            int s = 1;
            int x;
            for (int i = 0; i < maze.MazeSize; i++)
            {
                x = 0;
                for (int j = 0; j < maze.MazeSize; j++)
                {
                    Console.SetCursorPosition(x, i);
                    switch (maze.Map[i, j])
                    {
                        case 0:
                            Console.Write("# ");
                            break;
                        case 1:
                            Console.Write("  ");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("F ");
                            Console.ResetColor();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("S" + s);
                            Console.ResetColor();
                            s++;
                            break;
                        case 10:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("@@");
                            s++;
                            Console.ResetColor();
                            break;
                    }
                    x += 2;
                }
                Console.Write("\n");
            }
        }

        public void printMaze(int playerCurPosY, int playerCurPosX)
        {
            maze.Map[playerCurPosY, playerCurPosX] = 10;
            printMaze();
        }
        public void printPlayerMove(int playerCurPosX, int playerCurPosY, int playerPrevPosX, int playerPrevPosY, int entranceNum)
        {
            Console.SetCursorPosition(playerPrevPosX * 2, playerPrevPosY);
            switch (maze.Map[playerPrevPosY, playerPrevPosX])
            {
                case 1:
                    Console.Write("  ");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("S" + entranceNum);
                    Console.ResetColor();
                    break;
            }

            Console.SetCursorPosition(playerCurPosX * 2, playerCurPosY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@@");
            Console.ResetColor();
            Console.SetCursorPosition(0, maze.MazeSize);
        }
    }
}
