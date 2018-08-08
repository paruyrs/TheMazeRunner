using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class ManualRunner : Runner
    {
        public MazeCordinate CheckIfMoveAvailable(CardinalDirection movementDirection, Maze maze)
        {

            movmentCordinate = getCordinateForCardinalDirection(movementDirection);
            MazeCordinate mazeCordinate = maze.getMazeCordinate(movmentCordinate[0], movmentCordinate[1]);
            return mazeCordinate;

        }
        public override int Run(Maze maze)
        {
            var keyPressed = Console.ReadKey(true).Key;
            MazeCordinate mazeCordinate;
            MovementResult movementResult;

            switch (keyPressed)
            {
                case ConsoleKey.UpArrow:
                    mazeCordinate = CheckIfMoveAvailable(CardinalDirection.NORTH, maze);
                    movementResult = Move(mazeCordinate, maze);
                    break;

                case ConsoleKey.DownArrow:
                    mazeCordinate = CheckIfMoveAvailable(CardinalDirection.SOUTH, maze);
                    movementResult = Move(mazeCordinate, maze);
                    break;

                case ConsoleKey.LeftArrow:
                    mazeCordinate = CheckIfMoveAvailable(CardinalDirection.WEST, maze);
                    movementResult = Move(mazeCordinate, maze);
                    break;

                case ConsoleKey.RightArrow:
                    mazeCordinate = CheckIfMoveAvailable(CardinalDirection.EAST, maze);
                    movementResult = Move(mazeCordinate, maze);
                    break;

                case ConsoleKey.Escape:
                    return 2;

                default:
                    movementResult = MovementResult.MOVE_IMPOSSIBLE;
                    break;
            }

            if (movementResult == MovementResult.FOUND_FINISH)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
