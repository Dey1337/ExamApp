using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PlayersReg
    {
        public List<Player> Players { get; set; }

        public orderby orderby { get; set; }

        public void LoadData(string filepath)
        {
            List<Player> Players = File.ReadAllLines(filepath)
                .Skip(1)
                .Select(line => Players.CreateObjectFromCsvLine(line))
                .ToList();
        }
    }

    public enum orderby
    {
        Level,
        LevelDesc,
        Id,
        IdDesc
    }


}
