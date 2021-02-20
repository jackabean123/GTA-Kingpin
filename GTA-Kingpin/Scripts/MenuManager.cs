using GTA;
using GTA.Native;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Menus;
using System;
using System.Windows.Forms;

namespace GTA_Kingpin.Scripts
{
    class MenuManager : Script
    {

        public MenuManager()
        {
            DeveloperMenu.CreateMenu();

            Tick += OnTick;
            KeyDown += OnKeyDown;
            Aborted += OnAborted;
        }

        private void OnTick(object sender, EventArgs e)
        {
            GlobalVariables.pool.ProcessMenus();
        }

        private void OnAborted(object sender, EventArgs e)
        {
            if (v != null)
                v.Delete();
        }
        

        Vehicle v = null;

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            
        }

    }
}
