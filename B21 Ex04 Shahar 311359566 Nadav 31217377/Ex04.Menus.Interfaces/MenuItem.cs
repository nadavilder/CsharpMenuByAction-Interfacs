using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IFunction
    {
        void FuncToRun(MenuItem i_MenuItem);
    }

    public class MenuItem
    {
        private readonly string r_Title;
        private readonly int r_OptionNum;
        private readonly List<MenuItem> r_SubOptions = new List<MenuItem>();
        private MenuItem m_parent;
        private List<IFunction> m_MenuFunctions = new List<IFunction>();

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public MenuItem(string i_Title, int i_OptionNum, MenuItem i_Parent)
        {
            r_Title = i_Title;
            r_OptionNum = i_OptionNum;
            m_parent = i_Parent;
        }

        public void NotifyAllFunctions()
        {
            foreach (IFunction selected in m_MenuFunctions)
            {
                selected.FuncToRun(this);
            }
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

        public void AddFunctions(IFunction i_FunctionToADD)
        {
            m_MenuFunctions.Add(i_FunctionToADD);
        }

        public MenuItem SelectOption(int i_OptionNum)
        {
            MenuItem nextItem = this;
            if (i_OptionNum == -1)
            {
                nextItem = m_parent;
            }
            else if (r_SubOptions[i_OptionNum].NumOfOptions == 0)
            {
                r_SubOptions[i_OptionNum].NotifyAllFunctions();
            }
            else
            {
                nextItem = r_SubOptions[i_OptionNum];
            }

            return nextItem;
        }

        public int NumOfOptions
        {
            get { return r_SubOptions.Count; }
        }

        public List<MenuItem> SubOptions
        {
            get { return r_SubOptions; }
        }
    }
}
