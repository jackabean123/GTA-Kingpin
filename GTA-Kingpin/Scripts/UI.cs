using GTA;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Menus;
using System;
using System.Windows.Forms;

namespace GTA_Kingpin.Scripts
{
    class UI : Script
    {
        public UI()
        {
            Instantiate();

            Tick += OnTick;
            KeyDown += OnKeyDown;

            Interval = 8;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DatabaseHandler.DBCreated)
                UIHelper.ShowStats(DatabaseHandler.character);
            if (DatabaseHandler.dealerInRangeIndex != null && GlobalVariables.dealerMenu != null && !GlobalVariables.dealerMenu.Visible)
                UIHelper.ShowNearDealer(DatabaseHandler.dealers[(int)DatabaseHandler.dealerInRangeIndex]);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
                CharacterInventory.Toggle();
        }

        private void Instantiate()
        {
            UIHelper.ShowNotification("~r~||| ~g~Kingpin Initialised ~b~" + GlobalVariables.Version + " ~r~|||");
        }

    }
}
