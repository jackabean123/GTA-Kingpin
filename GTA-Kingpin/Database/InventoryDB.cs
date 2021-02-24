using GTA_Kingpin.Objects;
using GTA_Kingpin.Scripts;
using LiteDB;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    class InventoryDB
    {
        internal static Inventory GetCharacterInventory()
        {
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                var collection = db.GetCollection<Inventory>(Tables.Inventory.ToString());
                return collection.Query().Where(i => i.CharacterId == DatabaseHandler.character.Id).Single();
            }
        }
    }
}
