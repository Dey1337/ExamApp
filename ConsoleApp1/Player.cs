using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string starter { get; set; }
        [DataMember]
        public int exp { get; set; }
        [DataMember]
        public int level { get; set; }
        public Player(int id, string name, string starter, int exp, int level)
        {
            this.Id = id;
            this.Name = name;
            this.starter = starter;
            this.exp = exp;
            this.level = level;
        }
    }
}
