using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeRunner
{
    class RightHandRunner : Runner
    {

        public override int Run(Maze maze)
        {
            Thread.Sleep(200);
            MazeCordinate mazeCordinate;
            MovementResult movementResult;
            if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.RIGHT, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                movementResult = Move(mazeCordinate, maze);
            }
            else if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.FORWARD, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                movementResult = Move(mazeCordinate, maze);
            }
            else if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.LEFT, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                movementResult = Move(mazeCordinate, maze);
            }
            else if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.BACKWARD, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                movementResult = Move(mazeCordinate, maze);
            }
            else
            {
               // mazeCordinate = CheckIfMoveAvailable(MovementDirection.BACKWARD, maze);
               // movementResult = Move(mazeCordinate, maze);
                return 2;
            }
            if (playerEntranceStartCount == 3)
            {
                return 2;
            }

            else if (movementResult == MovementResult.FOUND_FINISH)
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
