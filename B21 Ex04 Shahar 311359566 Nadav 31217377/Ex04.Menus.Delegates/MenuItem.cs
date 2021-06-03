using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private readonly List<MenuItem> r_SubOptions = new List<MenuItem>();
        private readonly string r_Title;
        private int r_OptionNum;
        private MenuItem m_parent;
        public event Action Selected;

        public MenuItem(string i_Title, int i_OptionNum, MenuItem i_Parent)
        {
            r_Title = i_Title;
            r_OptionNum = i_OptionNum;
            m_parent = i_Parent;

        }


        public void AddOption(string i_Title)
        {
            r_SubOptions.Add(new MenuItem(i_Title, r_SubOptions.Count + 1, this));
        }

        public void ShowOptions()
        {
            if (r_OptionNum != -1)
            {
                Console.WriteLine($"{r_OptionNum}. {r_Title}");
            }
            else
            {
                Console.WriteLine(r_Title);
            }
            Console.WriteLine("===============");
            foreach (MenuItem option in r_SubOptions)
            {
                Console.WriteLine($"{option.r_OptionNum}. {option.r_Title}");
            }
            if (r_OptionNum == -1)
            {
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back");
            }
        }

        public MenuItem SelectOption(int i_OptionNum)
        {

            MenuItem nextItem = this;
            //If back
            if (i_OptionNum == -1)
            {
                nextItem = m_parent;
            }
            //If leaf
            else if (r_SubOptions[i_OptionNum].NumOfOptions == 0)
            {
                r_SubOptions[i_OptionNum].OnSelected();
            }
            else
            {
                nextItem = r_SubOptions[i_OptionNum];
            }
            return nextItem;
        }
        protected virtual void OnSelected()
        {
            Selected.Invoke();
        }

        public int NumOfOptions
        {
            get { return r_SubOptions.Count; }
        }

        public List<MenuItem> SubOptions
        {
            get { return r_SubOptions; }
        }

        public int OptionNum
        {
            get { return r_OptionNum; }
        }


    }
}
