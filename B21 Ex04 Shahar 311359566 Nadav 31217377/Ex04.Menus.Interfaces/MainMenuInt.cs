using System;

namespace Ex04.Menus.Interfaces
{
    public class InterfaceMenu
    {
        private MenuItem m_MainItem;


        public InterfaceMenu (string i_Title)
        {
            m_MainItem = new MenuItem(i_Title);
        }

        public void AddItem(MenuItem i_MenuToADD)
        {
            m_MainItem.AddItem(i_MenuToADD);
        }

        public void RemoveItem(MenuItem i_MenuToDel)
        {
            m_MainItem.RemoveItem(i_MenuToDel);
        }

    


    }
}
