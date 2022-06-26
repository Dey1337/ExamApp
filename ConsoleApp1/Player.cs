using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string starter { get; set; }

        public int exp { get; set; }

        public int level { get; set; }


        public Player CreateObjectFromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Player player = new Player();
            player.Id = Convert.ToInt32(values[0]);
            player.Name = values[1];
            player.starter = values[2];
            player.exp = Convert.ToInt32(values[3]);
            player.level = Convert.ToInt32(values[4]);

            return player;
        }

    }
}
