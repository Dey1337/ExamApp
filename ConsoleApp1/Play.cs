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
    public class PlayGame
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

        public void ShowStats(int health, int exp, int level)
        {
            Console.Write("Health : " + health + " ♥\n");
            if(exp > 100)
            {
                exp = exp - 100;
                level++;
            }
            Console.Write("EXPERIENCE : ");
            for(int i = 0; i<exp/10; i++) Console.Write("█");
            for (int i = exp / 10; i < 10; i++) Console.Write("▒");
            Console.Write(" " + exp + " %");
        }
        

        public void RunGame(int index, string starter, int exp, int level)
        {
            Clear();
            int enemyHealth = 10;
            Console.Write("A WILD SANDSLASH APPEARED !\n");
            Console.ReadKey();
            while (enemyHealth > 0)
            {
                string BulbasaurPrompt = @"
                                           /
                        _,.------....___,.' ',.-.
                     ,-'          _,.--''        |
                   ,'         _.-'              .
                  /   ,     ,'                   `
                 .   /     /                     ``.
                 |  |     .                       \.\
       ____      |___._.  |       __               \ `.
     .'    `---''''       ``''-.--'''`  \            . \
    .  ,            __               `              |   .
    `,'         ,-'''  .               \             |    L
   ,'          '    _.'                -._          /    |
  ,`-.    ,''.   `--'                      >.      ,'     |
 . .'\'   `-'       __    ,  ,-.         /  `.__.-      ,'
 ||:, .           ,'  ;  /  / \ `        `.    .      .'/
 /|:D  \          `--'  ' ,'_  . .         `.__, \   , /
/ L:_  |                 .  ''' :_;                `.'.'
.    '''''                  '''''''''''               '
 `.                                 .    `.   _,..  `
   `,_   .    .                _,-'/    .. `,'   __  `
    ) \`._        ___....----'''  ,'   .'  \ |   '  \  .
   /   `. ''`-.--'''         _,' ,'     `---' |    `./  |
  .   _  `'''''--.._____..--''   ,             '         |
  | .'' `. `-.                /-.           /          ,
  | `._.'    `,_            ;  /         ,'          .
 .'          /| `-.        . ,'         ,           ,
 '-.__ __ _,','    '`-..___;-...__   ,.'\ ____.___.'
 `''^--'..'   '-`-^-'''--    `-^-'`.''''''''''''`.,^.`.--'

";
                string CharmanderPrompt = @"
              _.--''''`-..
            ,'          `.
          ,'          __  `.
         /|          '' __   \
        , |           / |.   .
        |,'          !_.'|   |
      ,'             '   |   |
     /              |`--'|   |
    |                `---'   |
     .   ,                   |                       ,''.
      ._     '           _'  |                    , ' \ `
  `.. `.`-...___,...---''''    |       __,.        ,`''   L,|
  |, `- .`._        _,-,.'   .  __.-'-. /        .   ,    \
-:..     `. `-..--_.,.<       `''      / `.        `-/ |   .
  `,         '''''''''     `.              ,'         |   |  ',,
    `.      '            '            /          '    |'. |/
      `.   |              \       _,-'           |       ''
        `._'               \   '''\                .      |
           |                '     \                `._  ,'
           |                 '     \                 .'|
           |                 .      \                | |
           |                 |       L              ,' |
           `                 |       |             /   '
            \                |       |           ,'   /
          ,' \               |  _.._ ,-..___,..-'    ,'
         /     .             .      `!             ,j'
        /       `.          /        .           .'/
       .          `.       /         |        _.'.'
        `.          7`'---'          |------'''_.'
       _,.`,_     _'                ,''-----'''
   _,-_    '       `.     .'      ,\
   -'' /`.         _,'     | _  _  _.|
  ''''--'---'''''''''        `' '! |! /
                            `'' '' -' 
";
                string SquirtlePrompt = @"
               _,........__
            ,-'            ''`-.
          ,'                   `-.
        ,'                        \
      ,'                           .
      .'\               ,''''.       `
     ._.'|             / |  `       \
     |   |            `-.'  ||       `.
     |   |            '-._,'||       | \
     .`.,'             `..,'.'       , |`-.
     l                       .'`.  _/  |   `.
     `-.._'-   ,          _ _'   -'' \  .     `
`.'''''''''''-.`-...,---------','         `. `..__.
.'        `''-..___      __,'\          \  \     \
\_ .          |   `'''''''''    `.           . \  \
  `.          |              `.          |  .     L
    `.        |`--...________.'.        j   |     |
      `._    .'      |          `.     .|   ,     |
         `--,\       .            `7''''' |  ,      |
            ` `      `            /     |  |      |    _,-'''''''`-.
             \ `.     .          /      |  '      |  ,'          `.
              \  v.__  .        '       .   \    /| /              \
               \/    `''''\'''''''`.       \   \  /.''              |
                `        .        `._ ___,j.  `/ .-       ,---.     |
                ,`-.      \         .''     `.  |/        j     `    |
               /    `.     \       /         \ /         |     /    j
              |       `-.   7-.._ .          |''          '         /
              |          `./_    `|          |            .     _,'
              `.           / `----|          |-............`---'
                \          \      |          |
               ,'           )     `.         |
                7____,,..--'      /          |
                                  `---.__,--.'
";
                string EnemyPrompt = @"
                    ,\
                _,-'.+..----''/_____
             _,'---,        /      `'''',
           .'    ,'  __..../_     _,-'
          /    ,' ,-''       ,'---+--...__
        ,'   ----'        ,'             `''
       '                ,'     ______  ,-''`-._
      /  ,+'''''',   ....-^--..<''''      ``-._    `-.
    ,' .'-'  /      |        `._          `-.   _`-
   /    `'''''''       `           `.           `,''
  |                  `.           `.      ,-'''--.
  '               ,-   `._ ,-''''''`.__:---'''''-._   `._
   `-----..__  _,'     .-''.       `._         `.    `.
   /________.'''/      /  j         | `-._       `.    `.
\`-.`.__    )_/__    ._,-|         |     `.       `.'''''''
 .      `'''''''j   `''''`'   |         |       `.       `.
 \`._       /            L         '         `.....---
  `  `..___'              \      ,''            .   `.
   `.     `              _.\ _.-'' `-._          `.   `.
     `-._  \         _,-''-. '|        .`-.-''''''''``\     `.
         `''-^'   _.-'        |         \  `.      `---...-
              \.''            |          L   `.     `.
              /              `          |     \      `.
             j                `.        |      `,....__`
             |                  \       |       `   \
              .                  .      F        \   `.
      _,...,---`.                 `.   j `.       L--..`
    ,'',.--'''-.   -.                _`. |   `._    .
    ,'        \_.--`._     ,----.-<.  V       `-._ ._
   /.---''''.-'''''' )     `'''''''      `. `-.._         `' `._
        ,' _.-''''''''`.               |     `''-..__        `-.
        '''''         \         _,..-'            `'''----...-'
         '-----------+---''''''''' 
";
                if (starter == "Bulbasaur")
                {
                    Clear();
                    
                    int health = 9;

                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(EnemyPrompt);
                    Console.Write("\nHealth : " + enemyHealth + " ♥\n");
                    Console.Write("\nPress any key to continue ... \n");
                    Console.ReadKey();

                    Console.Write("\nSandslash USED TACKLE !\n");
                    Console.ReadKey();
                    health = health - 2;

                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(BulbasaurPrompt);
                    ShowStats(health, exp, level);
                    Console.ReadKey();
                    string[] options = { "USE Vine Whip", "USE Razor Leaf"};
                    StartMenu mainMenu = new StartMenu("", options);
                    int selectedIndex = mainMenu.Run();

                    switch (selectedIndex)
                    {
                        case 0:
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(BulbasaurPrompt);
                            Console.Write("\nBULBASAUR USED VINE WHIP ... \n");
                            Console.Write("Press any key to continue ... \n");
                            enemyHealth = enemyHealth - 6;
                            Console.ReadKey();
                            break;
                        case 1:
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(BulbasaurPrompt);
                            Console.Write("\nBULBASAUR USED RAZOR LEAF ... \n");
                            Console.Write("Press any key to continue ... \n");
                            enemyHealth = enemyHealth - 12;
                            Console.ReadKey();
                            break;
                    }
                }
                
                if (starter == "Charmander")
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    int health = 8;


                    Console.Write(EnemyPrompt);
                    Console.Write("\nHealth : " + enemyHealth + " ♥\n");
                    Console.Write("\nPress any key to continue ... \n");
                    Console.ReadKey();

                    Console.Write("\nSandslash USED TACKLE !\n");
                    Console.ReadKey();
                    health = health - 2;

                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(CharmanderPrompt);
                    ShowStats(health, exp, level);
                    Console.ReadKey();
                    string[] options = { "USE Ember", "USE Fire Fang" };
                    StartMenu mainMenu = new StartMenu("", options);
                    int selectedIndex = mainMenu.Run();

                    switch (selectedIndex)
                    {
                        case 0:
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(CharmanderPrompt);
                            Console.Write("Charmander Used Ember ... \n");
                            Console.Write("\nPress any key to continue ... ");
                            enemyHealth = enemyHealth - 6;
                            Console.ReadKey();
                            break;
                        case 1:
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(CharmanderPrompt);
                            Console.Write("Charmander Used Fire Fang... \n");
                            Console.Write("\nPress any key to continue ... ");
                            enemyHealth = enemyHealth - 12;
                            Console.ReadKey();
                            break;
                    }

                }
                
                if (starter == "Squirtle")
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    int health = 8;


                    Console.Write(EnemyPrompt);
                    Console.Write("\nHealth : " + enemyHealth + " ♥\n");
                    Console.Write("\nPress any key to continue ... \n");
                    Console.ReadKey();

                    Console.Write("\nSandslash USED TACKLE !\n");
                    Console.ReadKey();
                    health = health - 2;

                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(SquirtlePrompt);
                    ShowStats(health, exp, level);
                    Console.ReadKey();
                    string[] options = { "USE Water Gun", "USE Bubble" };
                    StartMenu mainMenu = new StartMenu("", options);
                    int selectedIndex = mainMenu.Run();

                    switch (selectedIndex)
                    {
                        case 0:
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(SquirtlePrompt);
                            Console.Write("Squirtle Used Water Gun ... \n");
                            Console.Write("\nPress any key to continue ... ");
                            enemyHealth = enemyHealth - 6;
                            Console.ReadKey();
                            break;
                        case 1:
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(SquirtlePrompt);
                            Console.Write("Squirtle Used Bubble ... \n");
                            Console.Write("\nPress any key to continue ... ");
                            enemyHealth = enemyHealth - 12;
                            Console.ReadKey();
                            break;
                    }
                }
                
            }
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nFight ended. Pokemon healed. \n");
            exp = exp + 140;
            while (exp >= 100)
            {
                exp = exp - 100;
                level++;
                
                Console.Write("\nYOUR POKEMON JUST LEVELED UP !");
            }

            // save data at the end of the battle
            List<Player> playerList = new List<Player>();
            playerList = LoadViaDataContractSerialization<List<Player>>("register.xml");
            playerList[index].exp = exp;
            playerList[index].level = level;
            SaveViaDataContractSerialization(playerList, "register.xml");
            Console.Write("\n\nGame Progress Saved. Press any key to start a new battle ... \n");
            Console.ReadKey();
            RunGame(index, starter, exp, level);
            
        }
        
    }
}
