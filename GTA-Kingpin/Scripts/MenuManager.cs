using GTA;
using GTA_Kingpin.Menus;
using System;

namespace GTA_Kingpin.Scripts
{
    class MenuManager : Script
    {

        public MenuManager()
        {
            DeveloperMenu.CreateMenu();

            Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            GlobalVariables.pool.ProcessMenus();
        }

    }
}
