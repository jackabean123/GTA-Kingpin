using System.Collections.Generic;
using System.Linq;

namespace GTA_Kingpin.Helpers
{
    static class RandomNames
    {

        public static string GetRandomName()
        {
            List<string> names = GetMaleNames();
            return names[MiscHelper.GetRandomNumber(0, names.Count-1)];
        }

        private static List<string> GetMaleNames()
        {
            string names = "Liam,Noah,Oliver,William,Elijah,James,Benjamin,Lucas,Mason,Ethan,Alexander,Henry,Jacob,Michael,Daniel,Logan,Jackson,Sebastian,Jack,Aiden,Owen,Samuel,Matthew,Joseph,Levi,Mateo,David,John,Wyatt,Carter,Julian,Luke,Grayson,Isaac,Jayden,Theodore,Gabriel,Anthony,Dylan,Leo,Lincoln,Jaxon,Asher,Christopher,Josiah,Andrew,Thomas,Joshua,Ezra,Hudson,Charles,Caleb,Isaiah,Ryan,Nathan,Adrian,Christian,Maverick,Colton,Elias,Aaron,Eli,Landon,Jonathan,Nolan,Hunter,Cameron,Connor,Santiago,Jeremiah,Ezekiel,Angel,Roman,Easton,Miles,Robert,Jameson,Nicholas,Greyson,Cooper,Ian,Carson,Axel,Jaxson,Dominic,Leonardo,Luca,Austin,Jordan,Adam,Xavier,Jose,Jace,Everett,Declan,Evan,Kayden,Parker,Wesley,Kai,Brayden,Bryson,Weston,Jason,Emmett,Sawyer,Silas,Bennett,Brooks,Micah";
            return names.Split(',')
                .ToList();
        }

    }
}
