using GTA;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using System;

namespace GTA_Kingpin.Scripts
{
    class DealerManager : Script
    {

        private bool instantiated = false;

        public DealerManager()
        {
            Tick += OnTick;
            Aborted += OnAbort;

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
                    UIHelper.ShowNotification("In vecinity of ");
                }
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
