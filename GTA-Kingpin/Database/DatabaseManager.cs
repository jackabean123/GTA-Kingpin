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
            Character, Drugs, Dealer
        }

        public static void Create()
        {
            if (!Exists() && !DatabaseHandler.DBCreated) {
                Logger.Log("Creating Database");
                NewDatabase();
                DatabaseHandler.DBCreated = true;
            }
        }

        public static void NewDatabase()
        {
            try
            {
                using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
                {
                    Logger.Log("Creating characters table");
                    var collection = db.GetCollection<Character>(Tables.Character.ToString());
                    Character character = new Character();
                    collection.Upsert(character);
                    Logger.Log("Characters rows: " + collection.Query().Count());
                }

                using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
                {
                    Logger.Log("Creating drugs table");
                    var collection = db.GetCollection<Drug>(Tables.Drugs.ToString());
                    List<Drug> drugList = DrugHelper.CreateDrugList();
                    foreach (Drug d in drugList)
                        collection.Upsert(d);
                    Logger.Log("Drugs rows: " + collection.Query().Count());
                }

                using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
                {
                    Logger.Log("Creating dealer table");
                    var collection = db.GetCollection<Dealer>(Tables.Dealer.ToString());
                    var dealer = new Dealer();
                    collection.Upsert(dealer);
                    Logger.Log("Dealer rows: " + collection.Query().Count());
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
