using GTA_Kingpin.Objects;
using System.Collections.Generic;

namespace GTA_Kingpin.Helpers
{
    static class DrugHelper
    {

        public static List<Drug> CreateDrugList()
        {
            List<Drug> drugs = new List<Drug>
            {
                new Drug("Weed", 30, 45, 1),
                new Drug("Heroin", 120, 160, 2),
                new Drug("Ketamine", 200, 260, 3),
                new Drug("Meth", 210, 250, 4),
                new Drug("LSD", 260, 320, 5),
                new Drug("MDMA", 350, 430, 6),
                new Drug("Spice", 430, 500, 7),
                new Drug("Steroids", 700, 850, 8),
                new Drug("Cocaine", 2300, 2800, 9)
            };
            return drugs;
        }

    }
}
