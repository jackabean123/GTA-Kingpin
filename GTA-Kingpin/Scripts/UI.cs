using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using System;

namespace GTA_Kingpin.Scripts
{
    class UI : Script
    {

        public UI()
        {
            Instantiate();

            Tick += OnTick;

            Interval = 10;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DatabaseHandler.DBCreated)
                UIHelper.ShowStats(DatabaseHandler.character);
        }

        private void Instantiate()
        {
            
            
            UIHelper.ShowNotification("~r~||| ~g~Kingpin Initialised ~b~" + GlobalVariables.Version + " ~r~|||");
        }

    }
}
