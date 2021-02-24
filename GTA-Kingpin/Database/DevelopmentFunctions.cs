using GTA;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;

namespace GTA_Kingpin.Database
{
    static class DevelopmentFunctions
    {

        public static void SetDealerLocation(GTA.Math.Vector3 Position, float Rotation, PedHash pedHash)
        {
            Dealer Dealer = new Dealer(Position.X, Position.Y, Position.Z, Rotation, pedHash.ToString());
            DealerDB.AddDealer(Dealer);
            UIHelper.ShowNotification("Added new dealer location");
        }

    }
}
