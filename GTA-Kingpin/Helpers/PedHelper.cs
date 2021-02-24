using GTA;
using GTA_Kingpin.Menus;
using GTA_Kingpin.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA_Kingpin.Helpers
{
    static class PedHelper
    {

        public static PedHash GetPedFromString(string PedName)
        {
            foreach (PedHash ped in Enum.GetValues(typeof(PedHash)).Cast<PedHash>())
                if (ped.ToString() == PedName)
                    return ped;
            return PedHash.Abigail;
        }

        public static List<object> GetPedHashList()
        {
            List<object> list = new List<object>();
            Array enumVals = Enum.GetValues(typeof(PedHash)).Cast<PedHash>().ToArray();
            foreach (PedHash hash in enumVals)
                list.Add(new PedHashObject(hash));
            return list;
        }

        static public void CheckNearbyDealer()
        {
            for (int i = 0; i < DatabaseHandler.dealers.Count; i++)
            {
                if (DatabaseHandler.dealers[i].GetVector3().DistanceTo(Game.Player.Character.Position) < 5)
                {
                    DatabaseHandler.dealerInRangeIndex = i;
                    return;
                } else {
                    DatabaseHandler.dealerInRangeIndex = null;
                }
            }
        }

    }
}
