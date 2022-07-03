using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using static System.Console;

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
            Title = "𝐏𝐎𝐊𝐄𝐌𝐎𝐍 𝐒𝐈𝐌𝐏𝐋𝐄 𝐆𝐀𝐌𝐄";
            RunMainMenu();
        }

        public void prefix()
        {
            ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n\n[X] ");
            ForegroundColor = ConsoleColor.DarkYellow;
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
HP: 9                       HP: 8                       HP: 10
Attack: 49                  Attack: 52                  Attack: 48
Speed: 45                   Speed: 65                   Speed: 43 
");
            prefix();
            Console.Write("Please Type the name of the pokemon you have chosen ! ( Case sensitive ) : ");

            string starter = Console.ReadLine();
            
            do
            {
                if (starter == "Bulbasaur")
                {
                    prefix();
                    Console.WriteLine(" You have chosen Bulbasaur as your first Pokemon !  \n");
                    break;
                } else if (starter == "Charmander")
                {
                    prefix();
                    Console.WriteLine(" You have chosen Charmander as your first Pokemon !  \n");
                    break;
                } else if (starter == "Squirtle")
                {
                    prefix();
                    Console.WriteLine(" You have chosen Squirtle as your first Pokemon !  \n");
                    break;
                }else
                {
                    Console.Write("\nPlease Type the name of the starter you have chosen ! ( Case sensitive ) : ");
                    starter = Console.ReadLine();
                }
            } while (true);

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

                    prefix();
                    Console.WriteLine(" Welcome Trainer " + findName + "! Press any key to continue ... ");
                    break;
                }
            }
            Console.ReadKey();
            PlayGame actualGame = new PlayGame();
            actualGame.RunGame(playerList.Count-1, starter, 0, 1);
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
            prefix();

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
            prefix();
            Console.WriteLine("Loaded account of " + playerList[index].Name + " with ID " +  index);
            Console.Write("Press any key to start the game ... Use Fullscreen for better experience!  ");

            Console.ReadKey();
            PlayGame actualGame = new PlayGame();
            
            actualGame.RunGame(index, playerList[index].starter, playerList[index].exp, playerList[index].level);
        }

        public void infoStarters()
        {

            Clear();
            prefix();
            Console.Write(@"You have to choose between 3 starter pokemons , you can find all their info when you create a new account");

            prefix();
            Console.Write(@"The most important stat is the HP, there are no mechanics for special moves / types / speed yet");

            prefix();
            Console.Write(@"There is only one pokemon to encounter, easy to fight , more may come with future updates");

            prefix();
            Console.Write(@"This project was created just to practice and test what I learned so far ");

            prefix();
            Console.Write(@"Thank you for playing btw . Press any key to return to main menu ... ");

            Console.ReadKey();
            Clear();
            RunMainMenu();
        }

        public void leaderboard()
        {
            List<Player> playerList = new List<Player>();
            playerList = LoadViaDataContractSerialization<List<Player>>("register.xml");

            string[] options = { "Order by Name", "Order by Name Descending" , "Order by Level", "Order By Level Descending" ,"Order by Creation Date", "Order by Creation Date Descending" };
            StartMenu mainMenu = new StartMenu("", options);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    List<Player> sortbyName = playerList.OrderBy(o => o.Name).ToList();
                    if (sortbyName.Count < 14)
                        for (int i = 0; i < sortbyName.Count; i++) Console.Write(i + 1 + ". " + sortbyName[i].Name + " - level " + sortbyName[i].level + "\n");
                    else for (int i = 0; i < 14; i++) Console.Write(i + 1 + ". " + sortbyName[i].Name + " - level " + sortbyName[i].level + "\n");
                    break;
                case 1:
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    List<Player> sortbynameDescending = playerList.OrderByDescending(o => o.Name).ToList();
                    if(sortbynameDescending.Count < 14)
                        for (int i = 0; i < sortbynameDescending.Count; i++) Console.Write(i+1 + ". " + sortbynameDescending[i].Name + " - level " + sortbynameDescending[i].level + "\n");
                    else for (int i = 0; i < 14; i++) Console.Write(i + 1 + ". " + sortbynameDescending[i].Name + " - level " + sortbynameDescending[i].level + "\n");
                    break;
                case 2:
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    List<Player> sortByLevel = playerList.OrderBy(o => o.level).ToList();
                    if (sortByLevel.Count < 14)
                        for (int i = 0; i < sortByLevel.Count; i++) Console.Write(i + 1 + ". " + sortByLevel[i].Name + " - level " + sortByLevel[i].level + "\n");
                    else for (int i = 0; i < 14; i++) Console.Write(i + 1 + ". " + sortByLevel[i].Name + " - level " + sortByLevel[i].level + "\n");
                    break;
                case 3:
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    List<Player> sortByLevelDescending = playerList.OrderByDescending(o => o.level).ToList();
                    if (sortByLevelDescending.Count < 14)
                        for (int i = 0; i < sortByLevelDescending.Count; i++) Console.Write(i + 1 + ". " + sortByLevelDescending[i].Name + " - level " + sortByLevelDescending[i].level + "\n");
                    else for (int i = 0; i < 14; i++) Console.Write(i + 1 + ". " + sortByLevelDescending[i].Name + " - level " + sortByLevelDescending[i].level + "\n");
                    break;
                case 4:
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    List<Player> sortybyID = playerList.OrderBy(o => o.Id).ToList();
                    if (sortybyID.Count < 14)
                        for (int i = 0; i < sortybyID.Count; i++) Console.Write(i + 1 + ". " + sortybyID[i].Name + " - level " + sortybyID[i].level + "\n");
                    else for (int i = 0; i < 14; i++) Console.Write(i + 1 + ". " + sortybyID[i].Name + " - level " + sortybyID[i].level + "\n");
                    break;
                case 5:
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    List<Player> sortybyIDDescending = playerList.OrderByDescending(o => o.Id).ToList();
                    if (sortybyIDDescending.Count < 14)
                        for (int i = 0; i < sortybyIDDescending.Count; i++) Console.Write(i + 1 + ". " + sortybyIDDescending[i].Name + " - level " + sortybyIDDescending[i].level + "\n");
                    else for (int i = 0; i < 14; i++) Console.Write(i + 1 + ". " + sortybyIDDescending[i].Name + " - level " + sortybyIDDescending[i].level + "\n");
                    break;
            }
            prefix();
            Console.Write("Press any key to return to the main menu ... ");
            Console.ReadKey();
            RunMainMenu();
        }
    }
}
