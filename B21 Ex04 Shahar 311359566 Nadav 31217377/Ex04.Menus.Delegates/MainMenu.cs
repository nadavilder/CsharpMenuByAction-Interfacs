using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly MenuItem r_mainOptions;
        private readonly string r_Title;

        public MainMenu(string i_Title)
        {
            r_Title = i_Title;
            r_mainOptions = new MenuItem(r_Title, -1, null);
        }

        public void AddOption(string i_Title)
        {
            r_mainOptions.AddOption(i_Title);
        }

        public void Show()
        {
            bool interactingWithMenu = true;
            MenuItem curMenuItem = r_mainOptions;
            while (interactingWithMenu)
            {
                curMenuItem.ShowOptions();
                Console.WriteLine($"Please enter your choice (1-{curMenuItem.NumOfOptions} or 0 to exit)");
                string selectedOptionString = Console.ReadLine();
                int selectedOption;
                if (int.TryParse(selectedOptionString, out selectedOption))
                {
                    if (selectedOption >= 0 && selectedOption <= curMenuItem.NumOfOptions)
                    {
                        Console.Clear();
                        curMenuItem = curMenuItem.SelectOption(selectedOption - 1);
                        if (curMenuItem == null)
                        {
                            interactingWithMenu = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option number");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        public MenuItem MainOptions
        {
            get { return r_mainOptions; }
        }
    }
}
