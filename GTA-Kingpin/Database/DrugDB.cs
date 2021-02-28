using GTA_Kingpin.Objects;
using GTA_Kingpin.Scripts;
using LiteDB;
using System;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    static class DrugDB
    {

        public static Drug GetDrugById(int Id)
        {
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Drug>(Tables.Drugs.ToString());
                return collection.FindById(Id);
            }
        }

        internal static void SetupGlobals()
        {
            using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
            {
                var collection = db.GetCollection<Drug>(Tables.Drugs.ToString());
                DatabaseHandler.Weed = collection.Query().Where(d => d.Name == "Weed").First();
                DatabaseHandler.Heroin = collection.Query().Where(d => d.Name == "Heroin").First();
                DatabaseHandler.Ketamine = collection.Query().Where(d => d.Name == "Ketamine").First();
                DatabaseHandler.Meth = collection.Query().Where(d => d.Name == "Meth").First();
                DatabaseHandler.LSD = collection.Query().Where(d => d.Name == "LSD").First();
                DatabaseHandler.MDMA = collection.Query().Where(d => d.Name == "MDMA").First();
                DatabaseHandler.Spice = collection.Query().Where(d => d.Name == "Spice").First();
                DatabaseHandler.Steroids = collection.Query().Where(d => d.Name == "Steroids").First();
                DatabaseHandler.Cocaine = collection.Query().Where(d => d.Name == "Cocaine").First();
            }
        }
    }
}
