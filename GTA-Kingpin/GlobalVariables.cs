using GTA_Kingpin.Helpers;
using NativeUI;
using System.IO;

namespace GTA_Kingpin
{
    static class GlobalVariables
    {

        public static double Version = 0.01;
        public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public static string ScriptsFolder = CurrentDirectory+"\\scripts";
        public static string KingpinFolder = ScriptsFolder+"\\Kingpin";
        public static string ImagesFolder = KingpinFolder + "\\Images";

        public static bool DevelopmentEnabled = false;

        public static void ToggleDevelopment()
        {
            DevelopmentEnabled = !DevelopmentEnabled;
            devMenu.Visible = false;
            UIHelper.ShowNotification("~w~Development Mode " + (DevelopmentEnabled ? "~g~Enabled" : "~r~Disabled"));
        }

        public static string DataDatabaseLocation = "filename=" + KingpinFolder + "\\data.db;upgrade=true";
        public static string LocationsDatabaseLocation = "filename=" + KingpinFolder + "\\locations.db;upgrade=true";

        public static string RawDatabaseLocation = KingpinFolder + "\\data.db";

        public static string DevMenuBanner = ImagesFolder + "\\dev_banner.png";
        public static string DealerMenuBanner = ImagesFolder + "\\dealer_banner.png";
        public static string CharacterMenuBanner = ImagesFolder + "\\character_banner.png";        

        public static MenuPool pool = new MenuPool();

        public static UIMenu devMenu;
        public static UIMenu dealerMenu;
        public static UIMenu characterMenu;

    }
}
