using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
using LiteDB;

namespace GTA_Kingpin.Objects
{
    class Inventory
    {

        [BsonId]
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int DealerId { get; set; }
        public InvDrug Weed { get; set; }
        public InvDrug Heroin { get; set; }
        public InvDrug Ketamine { get; set; }
        public InvDrug Meth { get; set; }
        public InvDrug LSD { get; set; }
        public InvDrug MDMA { get; set; }
        public InvDrug Spice { get; set; }
        public InvDrug Steroids { get; set; }
        public InvDrug Cocaine { get; set; }

        public Inventory(int id, int characterId, int dealerId, InvDrug weed, InvDrug heroin,
            InvDrug ketamine, InvDrug meth, InvDrug lSD, InvDrug mDMA, InvDrug spice,
            InvDrug steroids, InvDrug cocaine)
        {
            Id = id;
            CharacterId = characterId;
            DealerId = dealerId;
            Weed = weed;
            Heroin = heroin;
            Ketamine = ketamine;
            Meth = meth;
            LSD = lSD;
            MDMA = mDMA;
            Spice = spice;
            Steroids = steroids;
            Cocaine = cocaine;
        }

        public Inventory(int characterId, int dealerId, Drugs weed, Drugs heroin, Drugs ketamine,
            Drugs meth, Drugs lsd, Drugs mdma, Drugs spice, Drugs steroids, Drugs cocaine)
        {
            CharacterId = characterId;
            DealerId = dealerId;
            Weed = new InvDrug(weed);
            Heroin = new InvDrug(heroin);
            Ketamine = new InvDrug(ketamine);
            Meth = new InvDrug(meth);
            LSD = new InvDrug(lsd);
            MDMA = new InvDrug(mdma);
            Spice = new InvDrug(spice);
            Steroids = new InvDrug(steroids);
            Cocaine = new InvDrug(cocaine);
        }

    }

    class InvDrug
    {
        public Drug Drug { get; set; }
        public int Amount { get; set; }

        public InvDrug(int drugId, int amount)
        {
            Drug = DrugDB.GetDrugById(drugId);
            Amount = amount;
        }

        public InvDrug(Drugs drug, int amount)
        {
            Drug = DrugDB.GetDrugById((int)drug);
            Amount = amount;
        }

        public InvDrug (int drugId)
        {
            Drug = DrugDB.GetDrugById(drugId);
            Amount = MiscHelper.GenerateDrugAmount(Drug);
        }

        public InvDrug(Drugs drug)
        {
            Drug = DrugDB.GetDrugById((int)drug);
            Amount = MiscHelper.GenerateDrugAmount(Drug);
        }

    }

}
