using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public readonly List<MenuItem> r_Options = new List<MenuItem>();
        private readonly string r_Title;
        private int r_OptionNum;
        public event Action Selected;

        public MenuItem(string i_Title, int i_OptionNum)
        {
            r_Title = i_Title;
            r_OptionNum = i_OptionNum;
        }


        public void AddOption(string i_Title)
        {
            r_Options.Add(new MenuItem(i_Title, r_Options.Count + 1));
        }

        public void ShowOptions()
        {
            if(r_OptionNum!= -1)
            {
                Console.WriteLine($"{r_OptionNum}. {r_Title}");
            }
            else
            {
                Console.WriteLine(r_Title);
            }
            Console.WriteLine("===============");
            foreach(MenuItem option in r_Options)
            {
                Console.WriteLine($"{option.r_OptionNum}. {option.r_Title}");
            }
            Console.WriteLine("0. Exit");
        }

        public MenuItem SelectOption(int i_OptionNum)
        {
            
            MenuItem nextItem = this;
            //If leaf // invoke on sub option
            if(r_Options.Count == 0)
            {
                this.OnSelected();
            }
            else
            {
                nextItem = r_Options[i_OptionNum];
            }
            return nextItem;
        }
        protected virtual void OnSelected()
        {
            Selected.Invoke();
        }

        public int NumOfOptions
        {
            get { return r_Options.Count; }
        }


    }
}
