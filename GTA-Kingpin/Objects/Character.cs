using GTA;
using GTA_Kingpin.Database;
using LiteDB;

namespace GTA_Kingpin.Objects
{
    class Character
    {

        [BsonId]
        public int Id { get; set; }
        public int Xp { get; set; }

        public Character(int xp)
        {
            Xp = xp;
        }

        public Character()
        {
            Xp = 0;
        }

    }
}
