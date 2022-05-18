using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class Game
    {
        public static class PermutationsAndCombinations
        {
            public static long nCr(int n, int r)
            {
                // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
                return nPr(n, r) / Factorial(r);
            }

            public static long nPr(int n, int r)
            {
                // naive: return Factorial(n) / Factorial(n - r);
                return FactorialDivision(n, n - r);
            }

            private static long FactorialDivision(int topFactorial, int divisorFactorial)
            {
                long result = 1;
                for (int i = topFactorial; i > divisorFactorial; i--)
                    result *= i;
                return result;
            }

            public static long Factorial(int i)
            {
                if (i <= 1)
                    return 1;
                return i * Factorial(i - 1);
            }
        }

        public void Start()
        {
            Title = "EASY EDS V1 - Mazilu Adrian 2203A";
            RunMainMenu();

        }

        private void RunMainMenu()
        {
            string prompt = @"
                    ███████╗ █████╗ ███████╗██╗   ██╗    ███████╗██████╗ ███████╗    ██╗   ██╗ ██╗
                    ██╔════╝██╔══██╗██╔════╝╚██╗ ██╔╝    ██╔════╝██╔══██╗██╔════╝    ██║   ██║███║
                    █████╗  ███████║███████╗ ╚████╔╝     █████╗  ██║  ██║███████╗    ██║   ██║╚██║
                    ██╔══╝  ██╔══██║╚════██║  ╚██╔╝      ██╔══╝  ██║  ██║╚════██║    ╚██╗ ██╔╝ ██║
                    ███████╗██║  ██║███████║   ██║       ███████╗██████╔╝███████║     ╚████╔╝  ██║
                    ╚══════╝╚═╝  ╚═╝╚══════╝   ╚═╝       ╚══════╝╚═════╝ ╚══════╝      ╚═══╝   ╚═╝
                    

( Use ArrowKeys to select any option )";


            string[] options = { "Combinari", "Aranjamente", "Permutari" };
            StartMenu mainMenu = new StartMenu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Combinari();
                    break;
                case 1:
                     Aranjamente();
                    break;
                case 2:
                    Permutari();
                    break;

            }

        }

        public void Combinari()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            Write(@"Formula COMBINARI : n! / k!(n-k)!");
            ResetColor();
            WriteLine("\n");

            Write(@"Se calculeaza COMBINARI de n luate cate k..


Dati valori pentru n si k : 

n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Write(@"k = ");
            int k = Convert.ToInt32(Console.ReadLine());

            WriteLine();

            ForegroundColor = ConsoleColor.DarkYellow;

            Write("Pentru cazul dat : ");
            ResetColor();
            Write("Combinari de " + n + " luate cate " + k + " : " + n + "! / " + k + "!(" + n + " - " + k + ")! = ");
            Write(PermutationsAndCombinations.nCr(n, k));



            WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            WriteLine(@"Press Tab to return to main menu or press anything else to exit...");
            WriteLine();
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.Tab)
            {
                Clear();
                RunMainMenu();
            }

        }
        public void Aranjamente()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            Write(@"Formula ARANJAMENTE : n! / (n-k)!");
            ResetColor();
            WriteLine("\n");

            Write(@"Se calculeaza ARANJAMENTE de n luate cate k..


Dati valori pentru n si k : 

n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Write(@"k = ");
            int k = Convert.ToInt32(Console.ReadLine());

            WriteLine();

            ForegroundColor = ConsoleColor.DarkYellow;

            Write("Pentru cazul dat : ");
            ResetColor();
            Write("Aranjamente de " + n + " luate cate " + k + " : " + n + "! / ( "+ n + " - " + k + ")! = ");
            Write(PermutationsAndCombinations.nPr(n, k));



            WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            WriteLine(@"Press Tab to return to main menu or press anything else to exit...");
            WriteLine();
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.Tab)
            {
                Clear();
                RunMainMenu();
            }
        }

        public void Permutari()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            Write(@"Formula PERMUTARI de grad n : n!");
            ResetColor();
            WriteLine("\n");

            Write(@"Se calculeaza PERMUTARI de grad n ..


Dati o valoare pentru n : 

n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            WriteLine();

            ForegroundColor = ConsoleColor.DarkYellow;

            Write("Pentru cazul dat : ");
            ResetColor();
            Write("Permutari de ordin " + n + " : " + n + "! = ");
            Write(PermutationsAndCombinations.Factorial(n));



            WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            WriteLine(@"Press Tab to return to main menu or press anything else to exit...");
            WriteLine();
            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.Tab)
            {
                Clear();
                RunMainMenu();
            }
        }

    }
}
