﻿using System;
using static System.Console;

namespace ConsoleApp1
{
    public class StartMenu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public StartMenu(string prompt , string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            
            WriteLine(Prompt);

            ResetColor();

            WriteLine();
            for ( int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;


                if (i== SelectedIndex)
                {
                    prefix = "[X]";
                    ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    prefix = "[ ]";
                    ForegroundColor = ConsoleColor.Blue;
                    BackgroundColor = ConsoleColor.Black;
                }

                Write($" {prefix} ");
                ForegroundColor = ConsoleColor.DarkYellow;
                Write($"{currentOption}");
                WriteLine();
                WriteLine();
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();
                
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
