using LiteDB;

namespace GTA_Kingpin.Objects
{
    class Drug
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseBuyPrice { get; set; }
        public int BaseSellPrice { get; set; }
        public int RequiredLevel { get; set; }
        public int BaseAmount { get; set; }

        public Drug(int id, string name, int baseBuyPrice, int baseSellPrice, int requiredLevel, int baseAmount)
        {
            Id = id;
            Name = name;
            BaseBuyPrice = baseBuyPrice;
            BaseSellPrice = baseSellPrice;
            RequiredLevel = requiredLevel;
            BaseAmount = baseAmount;
        }

        public Drug()
        {
            Name = "";
            BaseBuyPrice = 0;
            BaseSellPrice = 0;
            RequiredLevel = 0;
            BaseAmount = 1;
        }

    }

    public enum Drugs
    {
        Weed = 1,
        Heroin = 2,
        Ketamine = 3,
        Meth = 4,
        LSD = 5,
        MDMA = 6,
        Spice = 7,
        Steroids = 8,
        Cocaine = 9
    }

}
