using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
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

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
                CharacterDB.AmendXp(1);
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
