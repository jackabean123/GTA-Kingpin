using GTA;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Menus;
using GTA_Kingpin.Objects;
using System;
using System.Windows.Forms;

namespace GTA_Kingpin.Scripts
{
    class DealerManager : Script
    {

        private bool instantiated = false;

        public DealerManager()
        {
            Tick += OnTick;
            Aborted += OnAbort;
            KeyDown += OnKeyDown;

            Interval = 1000;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DatabaseHandler.initialised && !instantiated)
                Instantiate();

            if (DatabaseHandler.initialised && instantiated)
            {
                PedHelper.CheckNearbyDealer();
                if (DatabaseHandler.dealerInRangeIndex != null)
                {
                    if (GlobalVariables.dealerMenu == null)
                        DealerMenu.CreateMenu(DatabaseHandler.dealers[(int)DatabaseHandler.dealerInRangeIndex]);
                }
                else
                {
                    GlobalVariables.dealerMenu = null;
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (DatabaseHandler.initialised && instantiated)
            {
                if (DatabaseHandler.dealerInRangeIndex != null && e.KeyCode == Keys.E)
                    if (GlobalVariables.dealerMenu != null)
                        DealerMenu.ToggleMenu();
            }
        }

        private void OnAbort(object sender, EventArgs e)
        {
            foreach (Dealer dealer in DatabaseHandler.dealers)
                if (dealer.Ped != null)
                    dealer.Ped.Delete();
            foreach (Blip blip in DatabaseHandler.dealerBlips)
                blip.Delete();
        }

        private void SpawnDealers()
        {
            if (DatabaseHandler.dealers != null)
            {
                foreach (Dealer dealer in DatabaseHandler.dealers)
                {
                    Ped ped = World.CreatePed(dealer.GetPedHash(), dealer.GetVector3(), dealer.R);
                    Blip blip = World.CreateBlip(dealer.GetVector3());
                    blip.Sprite = BlipSprite.Drugs;
                    blip.Color = BlipColor.Blue2;
                    blip.IsShortRange = true;
                    blip.Name = dealer.Name + " (Dealer)";
                    dealer.Ped = ped;
                    DatabaseHandler.dealerBlips.Add(blip);
                }
                instantiated = true;
            }
        }

        private void Instantiate()
        {
            SpawnDealers();
        }

    }
}
