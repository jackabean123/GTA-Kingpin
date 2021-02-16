using GTA_Kingpin.Objects;
using System.Collections;
using System.Collections.Generic;

namespace GTA_Kingpin.Helpers
{
    static class DrugHelper
    {

        public static List<Drug> CreateDrugList()
        {
            List<Drug> drugs = new List<Drug>();
            drugs.Add(new Drug("Weed", 30, 45, 1));
            drugs.Add(new Drug("Heroin", 120, 160, 2));
            drugs.Add(new Drug("Ketamine", 200, 260, 3));
            drugs.Add(new Drug("Meth", 210, 250, 4));
            drugs.Add(new Drug("LSD", 260, 320, 5));
            drugs.Add(new Drug("MDMA", 350, 430, 6));
            drugs.Add(new Drug("Spice", 430, 500, 7));
            drugs.Add(new Drug("Steroids", 700, 850, 8));
            drugs.Add(new Drug("Cocaine", 2300, 2800, 9));
            return drugs;
        }

    }
}
