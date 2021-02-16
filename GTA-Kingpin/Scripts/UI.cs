using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using System;
using System.Windows.Forms;

namespace GTA_Kingpin.Scripts
{
    class UI : Script
    {

        private Character character;

        public UI()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;

            Interval = 10;

            Instantiate();
            LoadStatistics();
        }

        private void OnTick(object sender, EventArgs e)
        {
            UIHelper.ShowStats(character);
            LoadStatistics();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                CharacterDB.AmendXp(1);
            }
        }

        private void Instantiate()
        {
            DatabaseManager.Create();
            character = CharacterDB.GetCharacter();
            UIHelper.ShowNotification("~r~||| ~g~Kingpin Initialised ~b~" + GlobalVariables.Version + " ~r~|||");
        }

        private void LoadStatistics()
        {
            if (GlobalVariables.DatabaseUpdatedCharacter)
            {
                character = CharacterDB.GetCharacter();
                GlobalVariables.ChangeDatabaseUpdatedCharacter(false);
            }
        }

    }
}
