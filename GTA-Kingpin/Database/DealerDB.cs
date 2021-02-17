using GTA_Kingpin.Objects;
using LiteDB;
using System.Collections.Generic;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    static class DealerDB
    {

        public static void AddDealer(Dealer Dealer)
        {
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                collection.Upsert(Dealer);
            }
        }

        public static long GetNextId()
        {
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                long id = collection.Query().Count();
                return id + 1;
            }
        }

        public static List<Dealer> GetAllDealers()
        {
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                List<Dealer> dealers = collection.Query().ToList();
                return dealers;
            }
        }

    }
}
