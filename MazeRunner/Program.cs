using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to Start The Game.");
            var keyPressed = Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Game newGame = new Game();

                Console.CursorVisible = true;

                newGame.ChooseRunner();
                newGame.StartGame();

                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPress Enter to Restart Game or Esc to Exit Game");
                Console.ResetColor();

                while (true)
                {
                    keyPressed = Console.ReadKey();
                    if (keyPressed.Key.ToString() == "Escape")
                    {
                        return;
                    }
                    if (keyPressed.Key.ToString() == "Enter")
                    {
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }







}
