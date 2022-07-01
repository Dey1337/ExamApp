using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using static System.Console;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Game
    {
        static void SaveViaDataContractSerialization<T>(T serializableObject, string filepath)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            var writer = XmlWriter.Create(filepath, settings);
            serializer.WriteObject(writer, serializableObject);
            writer.Close();
        }


        static T LoadViaDataContractSerialization<T>(string filepath)
        {
            var fileStream = new FileStream(filepath, FileMode.Open);
            var reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            var serializer = new DataContractSerializer(typeof(T));
            T serializableObject = (T)serializer.ReadObject(reader, true);
            reader.Close();
            fileStream.Close();
            return serializableObject;
        }
        public void Start()
        {
            Title = "𝐏𝐎𝐊𝐄𝐌𝐎𝐍 𝐒𝐈𝐌𝐏𝐋𝐄 𝐆𝐀𝐌𝐄 - Mazilu Adrian 2022";
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
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"                                                                                                                                                                           
███╗   ██╗███████╗██╗    ██╗    ████████╗██████╗  █████╗ ██╗███╗   ██╗███████╗██████╗ 
████╗  ██║██╔════╝██║    ██║    ╚══██╔══╝██╔══██╗██╔══██╗██║████╗  ██║██╔════╝██╔══██╗
██╔██╗ ██║█████╗  ██║ █╗ ██║       ██║   ██████╔╝███████║██║██╔██╗ ██║█████╗  ██████╔╝
██║╚██╗██║██╔══╝  ██║███╗██║       ██║   ██╔══██╗██╔══██║██║██║╚██╗██║██╔══╝  ██╔══██╗
██║ ╚████║███████╗╚███╔███╔╝       ██║   ██║  ██║██║  ██║██║██║ ╚████║███████╗██║  ██║
╚═╝  ╚═══╝╚══════╝ ╚══╝╚══╝        ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝
                                                                                      
 ");

            List<Player> playerList = new List<Player>();
            playerList = LoadViaDataContractSerialization<List<Player>>("register.xml");
            
            
            

            

            Console.WriteLine(@"
1. Bulbasaur                2. Charmander    		3. Squirtle
Type: Grass + Poison        Type: Fire                  Type: Water
HP: 45                      HP: 39                      HP: 44
Attack: 49                  Attack: 52                  Attack: 48
Speed: 45                   Speed: 65                   Speed: 43 
");
            ForegroundColor = ConsoleColor.Blue;
            Console.Write("[X] ");
            ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Please Type the name of the pokemon you have chosen ! ( Case sensitive ) : ");

            string starter = Console.ReadLine();
            
            do
            {
                if (starter == "Bulbasaur")
                {
                    ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n[X]");
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" You have chosen Bulbasaur as your first Pokemon !  \n");
                    break;
                } else if (starter == "Charmander")
                {
                    ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n[X]");
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" You have chosen Charmander as your first Pokemon !  \n");
                    break;
                } else if (starter == "Squirtle")
                {
                    ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n[X]");
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" You have chosen Squirtle as your first Pokemon !  \n");
                    break;
                }else
                {
                    
                    Console.Write("\nPlease Type the name of the starter you have chosen ! ( Case sensitive ) : ");
                    starter = Console.ReadLine();
                }
            } while (true);

            

            int index = 0;
            while (true)
            {
                Console.Write("\nPlease type a NEW account name ( Case sensitive ) : ");
                string findName = Console.ReadLine();
                bool alreadyExists = playerList.Any(x => x.Name == findName);
                if (!alreadyExists)
                {
                    Player TheNewPlayer = new Player(playerList.Count , findName, starter, 0, 1); // index stars from 0, count = newindex
                    playerList.Add(TheNewPlayer);
                    SaveViaDataContractSerialization(playerList, "register.xml");

                    ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n[X]");
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" Welcome Trainer " + findName + "! Press any key to continue ... ");
                    break;
                }
            }
            Console.ReadKey();
        }

        public void loadAcc()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"                                                                                                                                                                           
██╗      ██████╗  █████╗ ██████╗      █████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███╗   ██╗████████╗
██║     ██╔═══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔════╝██╔════╝██╔═══██╗██║   ██║████╗  ██║╚══██╔══╝
██║     ██║   ██║███████║██║  ██║    ███████║██║     ██║     ██║   ██║██║   ██║██╔██╗ ██║   ██║   
██║     ██║   ██║██╔══██║██║  ██║    ██╔══██║██║     ██║     ██║   ██║██║   ██║██║╚██╗██║   ██║   
███████╗╚██████╔╝██║  ██║██████╔╝    ██║  ██║╚██████╗╚██████╗╚██████╔╝╚██████╔╝██║ ╚████║   ██║   
╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   
                                                                                                                                                                                    
 ");

            List<Player> playerList = new List<Player>();
            playerList = LoadViaDataContractSerialization<List<Player>>("register.xml");
            ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n[X] ");
            ForegroundColor = ConsoleColor.DarkYellow;

            int index = 0;
            while (true)
            {
                Console.Write("Please Type the name of the account you want to load ! ( Case sensitive ) : ");
                string findName = Console.ReadLine();
                bool alreadyExists = playerList.Any(x => x.Name == findName);
                if (alreadyExists)
                {
                    for (int i = 1; i < playerList.Count; i++)
                    {
                        if (playerList[i].Name == findName)
                        {
                            index = i;
                            break;
                        }
                        
                    }
                    break;
                }

            }
            
            Console.WriteLine(index);
            Console.WriteLine("JUST EVOLVED");
            playerList[index].exp = playerList[index].exp + 10;
            playerList[index].level++;
            SaveViaDataContractSerialization(playerList, "register.xml");
            Console.ReadKey();

        }

        public void infoStarters()
        {


        }

        public void leaderboard()
        {

        }
    }

}
