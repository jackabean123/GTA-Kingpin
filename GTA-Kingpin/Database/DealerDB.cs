using GTA_Kingpin.Objects;
using LiteDB;
using System;
using System.Collections.Generic;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    static class DealerDB
    {

        public static void AddDealer(Dealer Dealer)
        {
            using (var db = new LiteDatabase(GlobalVariables.LocationsDatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                collection.Upsert(Dealer);
            }
        }

        public static long GetNextId()
        {
            using (var db = new LiteDatabase(GlobalVariables.LocationsDatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                long id = collection.Query().Count();
                return id + 1;
            }
        }

        public static List<Dealer> GetAllDealers()
        {
            using (var db = new LiteDatabase(GlobalVariables.LocationsDatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                List<Dealer> dealers = collection.Query().ToList();
                return dealers;
            }
        }

        internal static void RemoveDealer(Dealer dealer)
        {
            using (var db = new LiteDatabase(GlobalVariables.LocationsDatabaseLocation))
            {
                var collection = db.GetCollection<Dealer>();
                collection.Delete(dealer.Id);
            }
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Inventory>();
                List<Inventory> inv = collection.Query().Where(x => x.DealerId == dealer.Id).ToList();
                foreach (Inventory i in inv)
                    collection.Delete(i.Id);
            }
        }
    }
}
