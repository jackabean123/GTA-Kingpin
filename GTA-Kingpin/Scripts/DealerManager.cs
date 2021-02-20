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
                int? dealerInRange = GetDealerInVecinity();
                if (dealerInRange != null)
                {
                    UIHelper.ShowNotification("In vecinity of " + DatabaseHandler.dealers[(int)dealerInRange].Name);
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
                    Ped ped = World.CreatePed(RandomPeds.GetRandomPed(), dealer.GetVector3(), dealer.R);
                    Blip blip = World.CreateBlip(dealer.GetVector3());
                    blip.Sprite = BlipSprite.Drugs;
                    blip.Color = BlipColor.Green;
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

        private int? GetDealerInVecinity()
        {
            for (int i = 0; i < DatabaseHandler.dealers.Count; i++)
                if (DatabaseHandler.dealers[i].GetVector3().DistanceTo(Game.Player.Character.Position) < 5)
                    return i;
            return null;
        }

    }
}
