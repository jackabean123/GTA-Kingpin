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
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DatabaseHandler.initialised && !instantiated)
                Instantiate();
        }

        private void OnAbort(object sender, EventArgs e)
        {
            foreach (Dealer dealer in DatabaseHandler.dealers)
                if (dealer.Ped != null)
                    dealer.Ped.Delete();
        }

        private void SpawnDealers()
        {
            if (DatabaseHandler.dealers != null)
            {
                foreach (Dealer dealer in DatabaseHandler.dealers)
                {
                    UIHelper.ShowNotification("Spawning Ped: " + dealer.Name);
                    World.CreatePed(RandomPeds.GetRandomPed(), dealer.GetVector3(), dealer.R);
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
