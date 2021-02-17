using GTA_Kingpin.Objects;
using LiteDB;
using static GTA_Kingpin.Database.DatabaseManager;

namespace GTA_Kingpin.Database
{
    static class CharacterDB
    {

        public static Character GetCharacter()
        {
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                return db.GetCollection<Character>(Tables.Character.ToString()).Query().FirstOrDefault();
            }
        }

        public static void AmendXp(int amount)
        {
            Character character = GetCharacter();
            character.Xp += amount;
            using (var db = new LiteDatabase(GlobalVariables.DatabaseLocation))
            {
                var collection = db.GetCollection<Character>(Tables.Character.ToString());
                collection.Update(character);
            }
        }

    }
}
