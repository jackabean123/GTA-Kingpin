using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using System;
using System.Collections.Generic;

namespace GTA_Kingpin.Scripts
{

    static class DatabaseHandler
    {

        /* Main DB */
        public static bool DBCreated = false;

        /* DealerManager */
        public static bool requestDealers = true;
        public static List<Dealer> dealers = null;
        public static List<Blip> dealerBlips = new List<Blip>();
        public static int? dealerInRangeIndex = null;
        public static int? removeDealer = null;
        public static bool requestDealerInventory = false;

        /* Character */
        public static bool requestCharacter = true;
        public static Character character = null;

        /* Inventory */
        public static bool requestCharacterInventory = true;
        public static Inventory characterInventory = null;
        public static bool dealerInventoryInitialised = false;
        public static Inventory dealerInventory = null;

        /* Drugs */
        public static Drug Weed = null;
        public static Drug Heroin = null;
        public static Drug Ketamine = null;
        public static Drug Meth = null;
        public static Drug LSD = null;
        public static Drug MDMA = null;
        public static Drug Spice = null;
        public static Drug Steroids = null;
        public static Drug Cocaine = null;

        /* All Scripts */
        public static bool initialised = false;

    }

    class Main : Script
    {

        public Main()
        {
            CreateDatabase();

            Tick += OnTick;
            Interval = 100;
        }

        private void OnTick(object sender, EventArgs e)
        {
            UpdateUIScript();
            SetupDrugGlobals();
            SetupDealerInventories();
            LoadDealers();
            DeleteDealer();
            LoadDealerInventory();
        }

        private void CreateDatabase()
        {
            if (!DatabaseHandler.DBCreated)
                DatabaseManager.Create();
            DatabaseHandler.initialised = true;
        }

        private void SetupDealerInventories()
        {
            if (!DatabaseHandler.dealerInventoryInitialised)
            {
                InventoryDB.SetAllDealerInventories();
                DatabaseHandler.dealerInventoryInitialised = true;
            }
        }

        private void SetupDrugGlobals()
        {
            if (DatabaseHandler.initialised)
            {
                DrugDB.SetupGlobals();
            }
        }

        private void UpdateUIScript()
        {
            if (DatabaseHandler.requestCharacter)
            {
                DatabaseHandler.character = CharacterDB.GetCharacter();
                DatabaseHandler.requestCharacter = false;
            }
            if (DatabaseHandler.requestCharacterInventory)
            {
                DatabaseHandler.characterInventory = InventoryDB.GetCharacterInventory();
                DatabaseHandler.requestCharacterInventory = false;
            }
        }

        private void LoadDealers()
        {
            if (DatabaseHandler.requestDealers)
            {
                DatabaseHandler.dealers = DealerDB.GetAllDealers();
                DatabaseHandler.requestDealers = false;
            }
        }

        private void DeleteDealer()
        {
            if (DatabaseHandler.removeDealer != null)
            {
                var dealer = DatabaseHandler.dealers[(int)DatabaseHandler.dealerInRangeIndex];
                DealerDB.RemoveDealer(dealer);
                DatabaseHandler.removeDealer = null;
                UIHelper.ShowNotification("Removed " + dealer.Name + " - Reload the mod");
            }
        }

        private void LoadDealerInventory()
        {
            if (DatabaseHandler.requestDealerInventory && DatabaseHandler.dealerInventory == null && DatabaseHandler.dealerInRangeIndex != null)
            {
                DatabaseHandler.dealerInventory = InventoryDB.GetDealerInventory(DatabaseHandler.dealers[(int)DatabaseHandler.dealerInRangeIndex]);
            }
            else if (!DatabaseHandler.requestDealerInventory && DatabaseHandler.dealerInventory != null)
            {
                DatabaseHandler.dealerInventory = null;
                DatabaseHandler.requestDealerInventory = false;
            }
        }

    }
}
