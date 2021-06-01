using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface Function
    {
        void FuncToRun(MenuItem i_MenuItem);
    }
    public class MenuItem
    {
        private string m_title;
        private List<MenuItem> m_SubMenuItems = new List<MenuItem>();
        private List<Function> m_MenuFunctions = new List<Function>();

        public MenuItem(string i_Title)
        {
            m_title = i_Title;
        }

        public void AddItem(MenuItem i_MenuToADD)
        {
            m_SubMenuItems.Add(i_MenuToADD);
        }

        public void RemoveItem(MenuItem i_MenuToDel)
        {
            m_SubMenuItems.Remove(i_MenuToDel);
        }

        public void AddFunctions(Function i_FunctionToADD)
        {
            m_MenuFunctions.Add(i_FunctionToADD);
        }

        public void RemoveItem(Function i_FunctionToDel)
        {
            m_MenuFunctions.Remove(i_FunctionToDel);
        }

    }
 }
