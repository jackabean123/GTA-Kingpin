using GTA;
using GTA_Kingpin.Helpers;
using System;

namespace GTA_Kingpin.Scripts
{
    class UI : Script
    {
        public UI()
        {
            Instantiate();

            Tick += OnTick;

            Interval = 8;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DatabaseHandler.DBCreated)
                UIHelper.ShowStats(DatabaseHandler.character);
            if (DatabaseHandler.dealerInRangeIndex != null && !GlobalVariables.dealerMenu.Visible)
                UIHelper.ShowNearDealer();
        }

        private void Instantiate()
        {
            UIHelper.ShowNotification("~r~||| ~g~Kingpin Initialised ~b~" + GlobalVariables.Version + " ~r~|||");
        }

    }
}
