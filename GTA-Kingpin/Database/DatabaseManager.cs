using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using GTA_Kingpin.Scripts;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;

namespace GTA_Kingpin.Database
{
    static class DatabaseManager
    {

        public enum Tables
        {
            Character, Drugs, Dealer, Inventory
        }

        public static void Create()
        {
            if (!Exists() && !DatabaseHandler.DBCreated) {
                Logger.Log("Creating Database");
                NewDatabase();
                DatabaseHandler.DBCreated = true;
            } else {
                DatabaseHandler.DBCreated = Exists();
            }
        }

        public static void NewDatabase()
        {
            try
            {
                using (var db = new LiteDatabase(GlobalVariables.DataDatabaseLocation))
                {
                    Logger.Log("Creating characters table");
                    var characterCollection = db.GetCollection<Character>(Tables.Character.ToString());
                    Character character = new Character();
                    characterCollection.Upsert(character);
                    Logger.Log("Characters rows: " + characterCollection.Query().Count());

                    Logger.Log("Creating drugs table");
                    var drugCollection = db.GetCollection<Drug>(Tables.Drugs.ToString());
                    List<Drug> drugList = MiscHelper.CreateDrugList();
                    foreach (Drug d in drugList)
                        drugCollection.Upsert(d);
                    Logger.Log("Drugs rows: " + drugCollection.Query().Count());

                    Logger.Log("Creating character inventory " + character.Id);
                    var inventoryCollection = db.GetCollection<Inventory>(Tables.Inventory.ToString());
                    var inventory = new Inventory() { CharacterId = character.Id };
                    inventoryCollection.Insert(inventory);
                    Logger.Log("Inventory rows: " + inventoryCollection.Count());
                }

            } catch (Exception e)
            {
                Logger.Log(e);
                DatabaseHandler.DBCreated = true;
            }

        }

        private static bool Exists()
        {
            return File.Exists(GlobalVariables.RawDatabaseLocation);
        }

    }
}
