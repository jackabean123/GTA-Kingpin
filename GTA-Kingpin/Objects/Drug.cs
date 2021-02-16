namespace GTA_Kingpin.Objects
{
    class Drug
    {

        public string Name { get; set; }
        public int BaseBuyPrice { get; set; }
        public int BaseSellPrice { get; set; }
        public int RequiredLevel { get; set; }

        public Drug(string name, int baseBuyPrice, int baseSellPrice, int requiredLevel)
        {
            Name = name;
            BaseBuyPrice = baseBuyPrice;
            BaseSellPrice = baseSellPrice;
            RequiredLevel = requiredLevel;
        }

        public Drug()
        {
            Name = "";
            BaseBuyPrice = 0;
            BaseSellPrice = 0;
            RequiredLevel = 0;
        }

    }

}
