using System;
using Ex04.Menus;


namespace Ex04.Menus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Delegates.MainMenuDel mainMenu = new Delegates.MainMenuDel("test");

            mainMenu.AddOption("option 1");
            mainMenu.mainOptions.r_Options[0].AddOption("Sub option 1");
            mainMenu.mainOptions.r_Options[0].AddOption("Sub option 2");
            mainMenu.AddOption("option 2");
            mainMenu.mainOptions.r_Options[1].AddOption("Sub option 1");
            mainMenu.mainOptions.r_Options[1].AddOption("Sub option 2");
            mainMenu.Show();
            
        }
    }
}
