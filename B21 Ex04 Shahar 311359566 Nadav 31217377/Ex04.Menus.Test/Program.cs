using System;
using System.Linq;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Interfaces.MainMenu mainMenuInterface = BuildinterfacesMenu();
            mainMenuInterface.Show();
            Delegates.MainMenu mainMenuDel = BuildDelegateMenu();
            mainMenuDel.Show();
        }

        private static Interfaces.MainMenu BuildinterfacesMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Main Menu");

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

        private static Delegates.MainMenu BuildDelegateMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Main Menu");

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
            Console.WriteLine("Please enter a sentence...");
            string sentence = Console.ReadLine();
            int countSpaces = sentence.Count(char.IsWhiteSpace);
            Console.WriteLine($"The number of Spaces is {countSpaces}");
            EndOfFunction();
        }

        private static void ShowTimes()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            EndOfFunction();
        }

        private static void ShowDates()
        {
            Console.WriteLine(DateTime.Now.ToString("d/M/yyyy"));
            EndOfFunction();
        }

        private static void EndOfFunction()
        {
            Console.WriteLine("Press Enter to go back to menu");
            Console.ReadLine();
            Console.Clear();
        }

        public class ShowVersion : Interfaces.IFunction
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                ShowVersions();
            }
        }
        
        public class CountSpaces : Interfaces.IFunction
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                CountSpace();
            }
        }

        public class ShowTime : Interfaces.IFunction
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                ShowTimes();
            }
        }

        public class ShowDate : Interfaces.IFunction
        {
            public void FuncToRun(Interfaces.MenuItem i_MenuItem)
            {
                ShowDates();
            }
        }
    }
}