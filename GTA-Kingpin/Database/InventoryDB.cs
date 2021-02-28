using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using GTA_Kingpin.Scripts;
using LiteDB;
using System.Collections.Generic;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    class InventoryDB
    {
        public static Inventory GetCharacterInventory()
        {
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Inventory>(Tables.Inventory.ToString());
                return collection.Query().Where(i => i.CharacterId == DatabaseHandler.character.Id).Single();
            }
        }

        internal static Inventory GetDealerInventory(Dealer dealer)
        {
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Inventory>(Tables.Inventory.ToString());
                return collection.Query().Where(i => i.Id == dealer.Id).Single();
            }
        }

        internal static void SetAllDealerInventories()
        {
            Logger.Log("Settings dealer inventories");
            ClearDealerInventories();
            Logger.Log("Cleared Inventories");
            List<Dealer> dealers = DealerDB.GetAllDealers();
            Logger.Log("Loaded " + dealers.Count + " dealers");
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Inventory>();
                List<Inventory> invs = new List<Inventory>();
                foreach (Dealer dealer in dealers)
                    invs.Add(new Inventory(dealer.Id));
                Logger.Log("Inserting " + invs.Count + " inventories");
                collection.InsertBulk(invs);
            }
        }

        internal static void ClearDealerInventories()
        {
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Inventory>(Tables.Inventory.ToString());
                collection.DeleteMany(i => i.DealerId != 0);
            }
        }
    }
}
