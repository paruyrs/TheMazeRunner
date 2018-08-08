using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    public enum CardinalDirection
    {
        NORTH = 0,
        SOUTH = 2,
        EAST = 1,
        WEST = 3
    }

    enum MazeCordinate
    {

        WALL = 0,
        ROUTE = 1,
        FINISH = 2,
        START = 3,
        OUT_OF_BOUNDS
    }

    enum MovementDirection
    {
        BACKWARD = 2,
        FORWARD = 0,
        RIGHT = 1,
        LEFT = 3
    }

    enum MovementResult
    {
        MOVE_IMPOSSIBLE,
        MOVED,
        FOUND_FINISH,
        BACK_TO_START
    }
}
