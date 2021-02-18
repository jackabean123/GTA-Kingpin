using GTA;
using System.Collections.Generic;

namespace GTA_Kingpin.Helpers
{
    static class RandomPeds
    {

        public static PedHash GetRandomPed()
        {
            List<PedHash> peds = GetPedList();
            return peds[MiscHelper.GetRandomNumber(0, peds.Count-1)];
        }

        private static List<PedHash> GetPedList()
        {
            List<PedHash> peds = new List<PedHash>();
            peds.Add(PedHash.Terry);
            peds.Add(PedHash.UshiMaleYoung);
            return peds;
        }

    }
}
