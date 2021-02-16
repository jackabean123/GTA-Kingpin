using System.IO;

namespace GTA_Kingpin
{
    static class GlobalVariables
    {

        public static double Version = 0.01;
        public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public static string ScriptsFolder = CurrentDirectory+"\\scripts";
        public static string KingpinFolder = ScriptsFolder+"\\Kingpin";

        public static string DatabaseLocation = KingpinFolder + "\\data.db";

        public static bool DatabaseUpdatedCharacter = false;

        public static void ChangeDatabaseUpdatedCharacter (bool value)
        {
            DatabaseUpdatedCharacter = value;
        }

    }
}
