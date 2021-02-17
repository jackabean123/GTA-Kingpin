using GTA;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using System;
using System.Windows.Forms;

namespace GTA_Kingpin.Scripts
{
    class DealerManager : Script
    {

        public DealerManager()
        {
            Tick += OnTick;
            Aborted += OnAbort;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DatabaseHandler.initialised)
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
            foreach (Dealer dealer in DatabaseHandler.dealers)
            {
                Ped ped = World.CreatePed(RandomPeds.GetRandomPed(), dealer.GetVector3(), dealer.R);
                dealer.Ped = ped;
            }
        }

        private void Instantiate()
        {
            SpawnDealers();
        }

    }
}
