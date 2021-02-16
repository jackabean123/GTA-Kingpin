using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using LiteDB;
using System.Collections.Generic;
using System.IO;

namespace GTA_Kingpin.Database
{
    static class DatabaseManager
    {

        public enum Tables
        {
            Character, Drugs
        }

        public static void Create()
        {
            if (!Exists())
            {
                using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
                {
                    var characters = db.GetCollection<Character>(Tables.Character.ToString());
                    Character character = new Character();
                    characters.Insert(character);

                    var drugs = db.GetCollection<Drug>(Tables.Drugs.ToString());
                    List<Drug> drugList = DrugHelper.CreateDrugList();
                    drugs.InsertBulk(drugList);

                    UIHelper.ShowNotification("Boom! " + drugs.Query().Count());
                }
            }
        }

        private static bool Exists()
        {
            return File.Exists(GlobalVariables.DatabaseLocation);
        }

    }
}
