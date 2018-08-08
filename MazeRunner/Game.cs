using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Game
    {
        private List<Runner> runners = new List<Runner>();
        private Runner choosenRunner;
        private Maze maze = new Maze();

        public Game()
        {
            RightHandRunner rightHandRunner = new RightHandRunner();
            runners.Add(rightHandRunner);
            RandomRunner randomRunner = new RandomRunner();
            runners.Add(randomRunner);
            RecursiveRunner recursiveRunner = new RecursiveRunner();
            runners.Add(recursiveRunner);
            ManualRunner manualRunner = new ManualRunner();
            runners.Add(manualRunner);
        }
        public void ChooseRunner()
        {
            //display all available runners
            int Runnerscount = 0;
            foreach (Runner e in runners)
            {
                Runnerscount++;
                Console.WriteLine("Runner Number #{0}: {1}", Runnerscount, e.GetType().Name);

            }
            int runnerNumber;

            //Select Runner
            Console.Write("\nPlease enter number of Runner (1-" + Runnerscount + "): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out runnerNumber))
                {
                    if (runnerNumber > 0 && runnerNumber <= Runnerscount)
                    {
                            Console.WriteLine("You have Choosen: {0}", runners[runnerNumber - 1].GetType().Name);
                            Console.WriteLine("Press any key to Continue...");
                            Console.ReadKey();
                            Console.Clear();
                            choosenRunner = runners[runnerNumber - 1];
                            break;
                    }
                }
                Console.Write("\nPlease enter correct number of Runner (1-" + Runnerscount + "): ");
            }
        }

        public void StartGame()
        {
            int gameProgress = 0;
            if (!maze.LoadMaze())
            {
                return;
            }
            Render render = new Render(maze);
            render.printMaze();
            choosenRunner.SelectStartPosition(maze.AllStartPositions);
            Console.CursorVisible = false;
            render.printMaze(choosenRunner.PlayerCurPosY, choosenRunner.PlayerCurPosX);
            //if 0 in progress if 1 win if 2 lose
            choosenRunner.CheckInitialPlayerCardinalDirection(maze.MazeSize);
            while (gameProgress == 0)
            {
               //Thread.Sleep(200);
                gameProgress = choosenRunner.Run(maze);
                render.printPlayerMove(choosenRunner.PlayerCurPosX, choosenRunner.PlayerCurPosY,
                    choosenRunner.PlayerPrevPosX, choosenRunner.PlayerPrevPosY, choosenRunner.SelectedEntrance);

            }
            
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            Console.CursorVisible = true;

            if (gameProgress == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Beep(2000, 50);
                Console.WriteLine("\nVictory");
            }
            else if (gameProgress == 2)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLoose");
            }
        }
    }
}
