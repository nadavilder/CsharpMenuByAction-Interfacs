using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenuDel
    {
        public readonly MenuItem mainOptions;
        private readonly string r_Title;

        public MainMenuDel(string i_Title)
        {
            r_Title = i_Title;
            mainOptions = new MenuItem(r_Title, -1);
        }
        
        public void AddOption(string i_Title)
        {
            mainOptions.AddOption(i_Title);
        }


        public void Show()
        {
            bool interactingWithMenu = true;
            MenuItem curMenuItem = mainOptions;
            while (interactingWithMenu)
            {
                curMenuItem.ShowOptions();
                Console.WriteLine($"Please enter your choice (1-{curMenuItem.NumOfOptions} or 0 to exit)");
                string selectedOptionString = Console.ReadLine();
                int selectedOption;
                if(int.TryParse(selectedOptionString,out selectedOption))
                {
                    if(selectedOption == 0)
                    {
                        interactingWithMenu = false;
                    } else if(selectedOption > 0 && selectedOption <= curMenuItem.NumOfOptions)
                    {
                        curMenuItem = curMenuItem.SelectOption(selectedOption-1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
        }

    }
}
