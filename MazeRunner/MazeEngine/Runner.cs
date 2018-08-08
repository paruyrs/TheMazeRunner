using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    abstract class Runner
    {
        protected int playerCurPosX;
        protected int playerCurPosY;
        protected int playerPrevPosX;
        protected int playerPrevPosY;
        protected int playerCardinalDirection;
        protected int selectedEntrance;
        protected int selectedEntranceX;
        protected int selectedEntranceY;
        protected int enteredField;
        protected int playerEntranceStartCount;
        protected int[] movmentCordinate;
        private CardinalDirection movmentCardinalDirection;
        public Runner()
        {
            playerEntranceStartCount = 0;
        }

       

        public int SelectedEntrance
        {
            get
            {
                return selectedEntrance;
            }
        }
        public abstract int Run(Maze maze);

        public int PlayerPrevPosX
        {
            get
            {
                return playerPrevPosX;
            }
        }
        public int PlayerPrevPosY
        {
            get
            {
                return playerPrevPosY;
            }
        }
        public int PlayerCurPosX
        {
            get
            {
                return playerCurPosX;
            }
        }
        public int PlayerCurPosY
        {
            get
            {
                return playerCurPosY;
            }
        }
        public void SelectStartPosition(List<int[]> allStartPositions)
        {

            int numberOfEntrances = allStartPositions.Count;
            Console.WriteLine("Please choose Start point (1-" + numberOfEntrances + "): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out selectedEntrance))
                {
                    if (selectedEntrance > 0 && selectedEntrance <= numberOfEntrances)
                    {
                        playerPrevPosY = playerCurPosY = selectedEntranceY = allStartPositions[selectedEntrance - 1][0];
                        playerPrevPosX = playerCurPosX = selectedEntranceX = allStartPositions[selectedEntrance - 1][1];
                        enteredField = 3;

                        Console.WriteLine("You have choosen S" + selectedEntrance + " Entrance." + "\nPress any key to Continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    }
                }
                Console.Write("\nPlease enter correct Entrance Number (1-" + numberOfEntrances + "): ");
            }
        }
        public void CheckInitialPlayerCardinalDirection(int mazeSize)
        {
            /*  
               N(0)
                /\    
          W(3)< ** >E(1)
                \/  
                S(2)             
             */
            if (selectedEntranceY == mazeSize - 1)
            {
                playerCardinalDirection = (int)CardinalDirection.NORTH;
            }
            if (selectedEntranceY == 0)
            {
                playerCardinalDirection = (int)CardinalDirection.SOUTH; ;
            }
            if (selectedEntranceY > 0 && selectedEntranceY < mazeSize - 1 && selectedEntranceX == mazeSize - 1)
            {
                playerCardinalDirection = (int)CardinalDirection.WEST;
            }
            if (selectedEntranceY > 0 && selectedEntranceY < mazeSize - 1 && selectedEntranceX == 0)
            {
                playerCardinalDirection = (int)CardinalDirection.EAST; ;
            }

        }
        private CardinalDirection CheckPlayerCardinalDirection(MovementDirection movementDirection)
        {
            /*  
               N(0)
                /\    
          W(3)< ** >E(1)
                \/  
                S(2)             
        BACKWARD = 2,
        FORWARD = 0,
        RIGHT = 1,
        LEFT = 3
             */
            int calculatedCardinalDirection = (playerCardinalDirection + (int)movementDirection) % 4;
            return (CardinalDirection)Enum.ToObject(typeof(CardinalDirection), calculatedCardinalDirection);

        }

        protected int[] getCordinateForCardinalDirection(CardinalDirection direction)
        {
            switch (direction)
            {
                case CardinalDirection.NORTH:
                    return new int[] { playerCurPosY - 1, playerCurPosX };
                case CardinalDirection.SOUTH:
                    return new int[] { playerCurPosY + 1, playerCurPosX };
                case CardinalDirection.EAST:
                    return new int[] { playerCurPosY, playerCurPosX + 1 };
                case CardinalDirection.WEST:
                    return new int[] { playerCurPosY, playerCurPosX - 1 };
            }
            return null;
        }


        public  MazeCordinate CheckIfMoveAvailable(MovementDirection moveDirection, Maze maze)
        {
            movmentCardinalDirection = CheckPlayerCardinalDirection(moveDirection);

            movmentCordinate = getCordinateForCardinalDirection(movmentCardinalDirection);
            MazeCordinate mazeCordinate = maze.getMazeCordinate(movmentCordinate[0], movmentCordinate[1]);
            return mazeCordinate;


        }
        public MovementResult Move(MazeCordinate mazeCordinate, Maze maze)
        {

            switch (mazeCordinate)
            {
                case MazeCordinate.START:
                    playerEntranceStartCount++;
                    movePlayer(movmentCardinalDirection, movmentCordinate[0], movmentCordinate[1], (int)MazeCordinate.START, maze);
                    return MovementResult.BACK_TO_START;

                case MazeCordinate.ROUTE:
                    movePlayer(movmentCardinalDirection, movmentCordinate[0], movmentCordinate[1], (int)MazeCordinate.ROUTE, maze);
                    return MovementResult.MOVED;

                case MazeCordinate.FINISH:
                    movePlayer(movmentCardinalDirection, movmentCordinate[0], movmentCordinate[1], (int)MazeCordinate.FINISH, maze);
                    return MovementResult.FOUND_FINISH;

            }
            return MovementResult.MOVE_IMPOSSIBLE;

        }
        private void movePlayer(CardinalDirection playerCardinalDirection, int playerCurPosY, int playerCurPosX, int enteredField, Maze maze)
        {
            playerPrevPosY = this.playerCurPosY;
            playerPrevPosX = this.playerCurPosX;

            maze.Map[playerPrevPosY, playerPrevPosX] = this.enteredField;
            this.enteredField = enteredField;
            maze.Map[playerCurPosY, playerCurPosX] = 10;

            this.playerCardinalDirection = (int)playerCardinalDirection;
            this.playerCurPosY = playerCurPosY;
            this.playerCurPosX = playerCurPosX;

        }
    }

}
