using GTA_Kingpin.Helpers;
using System.IO;

namespace GTA_Kingpin
{
    static class GlobalVariables
    {

        public static double Version = 0.01;
        public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public static string ScriptsFolder = CurrentDirectory+"\\scripts";
        public static string KingpinFolder = ScriptsFolder+"\\Kingpin";

        public static bool DevelopmentEnabled = false;

        public static void ToggleDevelopment()
        {
            DevelopmentEnabled = !DevelopmentEnabled;
            UIHelper.ShowNotification("~o~Development mode " + (DevelopmentEnabled ? "~g~Enabled" : "~r~Disabled"));
        }

        public static string DatabaseLocation = "filename=" + KingpinFolder + "\\data.db;upgrade=true";

    }
}
