using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal class Game
    {
        public void Start()
        {
            WriteLine("The game is starting");

            ConsoleKeyInfo keyPressed = ReadKey();
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                WriteLine("You pressed Enter");
            }
            else
            {
                WriteLine("You pressed another key");
            }

            WriteLine("Press any key to exit ...");
            ReadKey(true);

        }
    }
}
