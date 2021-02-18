using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Menus;
using System;
using System.Windows.Forms;

namespace GTA_Kingpin.Scripts
{
    class Development : Script
    {

        public Development()
        {
            Instantiate();

            Tick += OnTick;
            KeyDown += OnKeyDown;
        }

        private void OnTick(object sender, EventArgs e)
        {

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                GlobalVariables.ToggleDevelopment();

            if (e.KeyCode == Keys.Subtract)
                DeveloperMenu.ToggleMenu();
        }

        private void Instantiate()
        {
            
        }


    }
}
