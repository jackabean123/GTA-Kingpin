﻿using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Objects;
using System;
using System.Collections.Generic;

namespace GTA_Kingpin.Scripts
{

    static class DatabaseHandler
    {

        /* Main DB */
        public static bool DBCreated = false;

        /* UI */
        public static bool requestCharacter = true;
        public static Character character = null;

        /* DealerManager */
        public static bool requestDealers = true;
        public static List<Dealer> dealers = null;

        /* All Scripts */
        public static bool initialised = false;

    }

    class Main : Script
    {

        public Main()
        {
            Tick += OnTick;
            Interval = 5000;
        }

        private void OnTick(object sender, EventArgs e)
        {
            CreateDatabase();
            UpdateUIScript();
            LoadDealers();
        }

        private void CreateDatabase()
        {
            if (!DatabaseHandler.DBCreated)
            {
                DatabaseManager.Create();
            }
        }

        private void UpdateUIScript()
        {
            if (DatabaseHandler.requestCharacter)
            {
                DatabaseHandler.character = CharacterDB.GetCharacter();
                DatabaseHandler.requestCharacter = false;
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

    }
}