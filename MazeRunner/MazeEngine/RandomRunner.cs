using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeRunner
{
    class RandomRunner : Runner
    {
        public override int Run(Maze maze)
        {
            Thread.Sleep(200);
            List<MovementDirection> randomSteps = new List<MovementDirection>();
            Random rnd = new Random();

            MazeCordinate mazeCordinate;
            MovementResult movementResult;
            if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.FORWARD, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                randomSteps.Add(MovementDirection.FORWARD);
            }
            if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.RIGHT, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                randomSteps.Add(MovementDirection.RIGHT);

            }
            if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.LEFT, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                randomSteps.Add(MovementDirection.LEFT);
            }

            int listCount = randomSteps.Count;
            if (listCount > 0)
            {
                int r = 0;
                if (listCount > 1)
                {
                    r = rnd.Next(randomSteps.Count);
                }

                mazeCordinate = CheckIfMoveAvailable(randomSteps[r], maze);
                movementResult = Move(mazeCordinate, maze);

                if (movementResult == MovementResult.FOUND_FINISH)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            if ((mazeCordinate = CheckIfMoveAvailable(MovementDirection.BACKWARD, maze)) != MazeCordinate.OUT_OF_BOUNDS && mazeCordinate != MazeCordinate.WALL)
            {
                movementResult = Move(mazeCordinate, maze);
                return 0;
            }
            else
            {
                return 2;
            }
        }
    }
}
