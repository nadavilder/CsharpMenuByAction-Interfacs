﻿using System;
using Ex04.Menus;


namespace Ex04.Menus.Test
{
    class Program
    {

        static void Main(string[] args)
        {
           Interfaces.InterfaceMenu mainMenuInterface = BuildinterfacesMenu();
            mainMenuInterface.Show();
            Delegates.MainMenuDel mainMenuDel = BuildDelegateMenu();
            mainMenuDel.Show();
        }


        private static Interfaces.InterfaceMenu BuildinterfacesMenu()
        {
            Interfaces.InterfaceMenu mainMenu = new Interfaces.InterfaceMenu("Main Menu");

            mainMenu.AddOption("Version and Spaces");
            mainMenu.MainOptions.SubOptions[0].AddOption("Show Version");
            mainMenu.MainOptions.SubOptions[0].SubOptions[0].AddFunctions(new ShowVersion());
            mainMenu.MainOptions.SubOptions[0].AddOption("Count Spaces");
            mainMenu.MainOptions.SubOptions[0].SubOptions[1].AddFunctions(new CountSpaces()); 
            mainMenu.AddOption("Show Date/Time");
            mainMenu.MainOptions.SubOptions[1].AddOption("Show Time");
            mainMenu.MainOptions.SubOptions[1].SubOptions[0].AddFunctions(new ShowTime()); 
            mainMenu.MainOptions.SubOptions[1].AddOption("Show Date");
            mainMenu.MainOptions.SubOptions[1].SubOptions[1].AddFunctions(new ShowDate()); 

            return mainMenu;
        }
        private static Delegates.MainMenuDel BuildDelegateMenu()
        {
            Delegates.MainMenuDel mainMenu = new Delegates.MainMenuDel("Main Menu");

            mainMenu.AddOption("Version and Spaces");
            mainMenu.MainOptions.SubOptions[0].AddOption("Show Version");
            mainMenu.MainOptions.SubOptions[0].SubOptions[0].Selected += ShowVersions;
            mainMenu.MainOptions.SubOptions[0].AddOption("Count Spaces");
            mainMenu.MainOptions.SubOptions[0].SubOptions[1].Selected += CountSpace;
            mainMenu.AddOption("Show Date/Time");
            mainMenu.MainOptions.SubOptions[1].AddOption("Show Time");
            mainMenu.MainOptions.SubOptions[1].SubOptions[0].Selected += ShowTimes;
            mainMenu.MainOptions.SubOptions[1].AddOption("Show Date");
            mainMenu.MainOptions.SubOptions[1].SubOptions[1].Selected += ShowDates;

            return mainMenu;
        }

        private static void ShowVersions()
        {
            Console.WriteLine("App Version: 21.1.4.8930");
            EndOfFunction();
        }

        private static void CountSpace()
        {
            Console.WriteLine("Count spaces logic");
            EndOfFunction();
        }

        private static void ShowTimes()
        {
            Console.WriteLine("Current Time");
            EndOfFunction();
        }

        private static void ShowDates()
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

        public struct ShowVersion : Interfaces.Function
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                ShowVersions();
            }
        }
        public struct CountSpaces : Interfaces.Function
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                CountSpace();
            }
        }

        public struct ShowTime : Interfaces.Function
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                ShowTimes();
            }
        }

        public struct ShowDate : Interfaces.Function
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                ShowDates();
            }
        }

        
    }
}



