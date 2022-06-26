using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game mygame = new Game();
            mygame.Start();

            PlayersReg reg = new PlayersReg();
            reg.LoadData(@"C:\Users\stfu\Documents\GitHub\ExamApp\ConsoleApp1\registry.csv");


        }
    }
}
