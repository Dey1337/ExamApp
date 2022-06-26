using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    public class Game
    {
        public void Start()
        {
            Title = "𝐏𝐎𝐊𝐄𝐌𝐎𝐍 𝐒𝐈𝐌𝐏𝐋𝐄 𝐆𝐀𝐌𝐄";
            RunMainMenu();

        }

        private void RunMainMenu()
        {
            string prompt = @"                                                                                                                                                                           
██████╗  ██████╗ ██╗  ██╗███████╗███╗   ███╗ ██████╗ ███╗   ██╗
██╔══██╗██╔═══██╗██║ ██╔╝██╔════╝████╗ ████║██╔═══██╗████╗  ██║
██████╔╝██║   ██║█████╔╝ █████╗  ██╔████╔██║██║   ██║██╔██╗ ██║
██╔═══╝ ██║   ██║██╔═██╗ ██╔══╝  ██║╚██╔╝██║██║   ██║██║╚██╗██║
██║     ╚██████╔╝██║  ██╗███████╗██║ ╚═╝ ██║╚██████╔╝██║ ╚████║
╚═╝      ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
 
        ( Use ArrowKeys to select any option )
    Read the info if you play for the first time";


            string[] options = { "Start New Account", "Load Account", "Info about starters", "Leaderboard" };
            StartMenu mainMenu = new StartMenu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    newAcc();
                    break;
                case 1:
                    loadAcc();
                    break;
                case 2:
                    infoStarters();
                    break;
                case 3:
                    leaderboard();
                    break;

            }

        }
        public void newAcc()
        {
            
        }

        public void loadAcc()
        {
            

        }

        public void infoStarters()
        {


        }

        public void leaderboard()
        {

        }
    }

}
