using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;

namespace GTA_Kingpin.Database
{
    static class DevelopmentFunctions
    {

        public static void SetDealerLocation(GTA.Math.Vector3 Position, float Rotation)
        {
            Dealer Dealer = new Dealer(Position.X, Position.Y, Position.Z, Rotation);
            DealerDB.AddDealer(Dealer);
            UIHelper.ShowNotification("Added new dealer location");
        }

    }
}
