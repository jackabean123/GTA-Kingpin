using GTA_Kingpin.Functionality;
using GTA_Kingpin.Objects;
using GTA_Kingpin.Scripts;
using System;
using System.Collections.Generic;

namespace GTA_Kingpin.Helpers
{
    static class MiscHelper
    {

        public static int GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return (int)Math.Round(random.NextDouble() * (maximum - minimum) + minimum);
        }

        public static List<Drug> CreateDrugList()
        {
            List<Drug> drugs = new List<Drug>
            {
                new Drug((int)Drugs.Weed, "Weed", 30, 45, 1, 30),
                new Drug((int)Drugs.Heroin, "Heroin", 120, 160, 2, 26),
                new Drug((int)Drugs.Ketamine, "Ketamine", 200, 260, 3, 24),
                new Drug((int)Drugs.Meth, "Meth", 210, 250, 4, 20),
                new Drug((int)Drugs.LSD, "LSD", 260, 320, 5, 18),
                new Drug((int)Drugs.MDMA, "MDMA", 350, 430, 6, 16),
                new Drug((int)Drugs.Spice, "Spice", 430, 500, 7, 12),
                new Drug((int)Drugs.Steroids, "Steroids", 700, 850, 8, 11),
                new Drug((int)Drugs.Cocaine, "Cocaine", 2300, 2800, 9, 8)
            };
            return drugs;
        }

        public static int GenerateDrugAmount(Drug drug)
        {
            return GetRandomNumber(0, drug.BaseAmount * LevelCalculator.GetPlayerLevel(DatabaseHandler.character.Xp));
        }

    }
}
