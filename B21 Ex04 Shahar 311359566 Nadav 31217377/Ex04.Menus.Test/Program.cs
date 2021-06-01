using System;
using Ex04.Menus;


namespace Ex04.Menus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Delegates.MainMenuDel mainMenuDel = BuildDelegateMenu();
            mainMenuDel.Show();


        }


        private static Delegates.MainMenuDel BuildDelegateMenu()
        {
            Delegates.MainMenuDel mainMenu = new Delegates.MainMenuDel("Main Menu");

            mainMenu.AddOption("Version and Spaces");
            mainMenu.MainOptions.SubOptions[0].AddOption("Show Version");
            mainMenu.MainOptions.SubOptions[0].SubOptions[0].Selected += ShowVersion;
            mainMenu.MainOptions.SubOptions[0].AddOption("Count Spaces");
            mainMenu.MainOptions.SubOptions[0].SubOptions[1].Selected += CountSpaces;
            mainMenu.AddOption("Show Date/Time");
            mainMenu.MainOptions.SubOptions[1].AddOption("Show Time");
            mainMenu.MainOptions.SubOptions[1].SubOptions[0].Selected += ShowTime;
            mainMenu.MainOptions.SubOptions[1].AddOption("Show Date");
            mainMenu.MainOptions.SubOptions[1].SubOptions[1].Selected += ShowDate;

            return mainMenu;
        }

        private static void ShowVersion()
        {
            Console.WriteLine("App Version: 21.1.4.8930");
            EndOfFunction();
        }

        private static void CountSpaces()
        {
            Console.WriteLine("Count spaces logic");
            EndOfFunction();
        }

        private static void ShowTime()
        {
            Console.WriteLine("Current Time");
            EndOfFunction();
        }

        private static void ShowDate()
        {
            Console.WriteLine("Current Date");
            EndOfFunction();
        }

        private static void EndOfFunction()
        {
            Console.WriteLine("Press Enter to go back to menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
