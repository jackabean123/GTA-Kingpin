using GTA_Kingpin.Objects;
using LiteDB;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    static class DrugDB
    {

        public static Drug GetDrugById(int Id)
        {
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                var collection = db.GetCollection<Drug>(Tables.Drugs.ToString());
                return collection.FindById(Id);
            }
        }

    }
}
