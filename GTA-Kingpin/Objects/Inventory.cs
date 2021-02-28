using GTA_Kingpin.Helpers;
using GTA_Kingpin.Scripts;
using LiteDB;

namespace GTA_Kingpin.Objects
{
    class Inventory
    {

        [BsonId]
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int DealerId { get; set; }
        public int WeedId { get; set; }
        public int WeedAmount { get; set; }
        public int HeroinId { get; set; }
        public int HeroinAmount { get; set; }
        public int KetamineId { get; set; }
        public int KetamineAmount { get; set; }
        public int MethId { get; set; }
        public int MethAmount { get; set; }
        public int LSDId { get; set; }
        public int LSDAmount { get; set; }
        public int MDMAId { get; set; }
        public int MDMAAmount { get; set; }
        public int SpiceId { get; set; }
        public int SpiceAmount { get; set; }
        public int SteroidsId { get; set; }
        public int SteroidsAmount { get; set; }
        public int CocaineId { get; set; }
        public int CocaineAmount { get; set; }

        public Inventory(int id, int characterId, int dealerId, int weedId, int weedAmount, int heroinId,
            int heroinAmount, int ketamineId, int ketamineAmount, int methId, int methAmount, int lSDId,
            int lSDAmount, int mDMAId, int mDMAAmount, int spiceId, int spiceAmount, int steroidsId,
            int steroidsAmount, int cocaineId, int cocaineAmount)
        {
            Id = id;
            CharacterId = characterId;
            DealerId = dealerId;
            WeedId = weedId;
            WeedAmount = weedAmount;
            HeroinId = heroinId;
            HeroinAmount = heroinAmount;
            KetamineId = ketamineId;
            KetamineAmount = ketamineAmount;
            MethId = methId;
            MethAmount = methAmount;
            LSDId = lSDId;
            LSDAmount = lSDAmount;
            MDMAId = mDMAId;
            MDMAAmount = mDMAAmount;
            SpiceId = spiceId;
            SpiceAmount = spiceAmount;
            SteroidsId = steroidsId;
            SteroidsAmount = steroidsAmount;
            CocaineId = cocaineId;
            CocaineAmount = cocaineAmount;
        }

        public Inventory()
        {
            
        }

        public Inventory(int dealerId)
        {
            CharacterId = 0;
            DealerId = dealerId;
            WeedId = DatabaseHandler.Weed.Id;
            WeedAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Weed);
            HeroinId = DatabaseHandler.Heroin.Id;
            HeroinAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Heroin);
            KetamineId = DatabaseHandler.Ketamine.Id;
            KetamineAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Ketamine);
            MethId = DatabaseHandler.Meth.Id;
            MethAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Meth);
            LSDId = DatabaseHandler.LSD.Id;
            LSDAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.LSD);
            MDMAId = DatabaseHandler.MDMA.Id;
            MDMAAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.MDMA);
            SpiceId = DatabaseHandler.Spice.Id;
            SpiceAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Spice);
            SteroidsId = DatabaseHandler.Steroids.Id;
            SteroidsAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Steroids);
            CocaineId = DatabaseHandler.Cocaine.Id;
            CocaineAmount = MiscHelper.GenerateDrugAmount(DatabaseHandler.Cocaine);
        }
    }

}
