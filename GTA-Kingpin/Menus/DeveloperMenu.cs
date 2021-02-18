using GTA;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
using NativeUI;
using System.IO;

namespace GTA_Kingpin.Menus
{
    static class DeveloperMenu
    {

        public static void CreateMenu()
        {
            GlobalVariables.devMenu = new UIMenu("", "");
            GlobalVariables.devMenu.OnItemSelect += OnItemSelectHandler;
            if (File.Exists(GlobalVariables.DevMenuBanner))
                GlobalVariables.devMenu.SetBannerType(GlobalVariables.DevMenuBanner);

            GlobalVariables.devMenu.AddItem(new UIMenuItem("Add Dealer Location", "Adds a new dealer location"));

            GlobalVariables.pool.Add(GlobalVariables.devMenu);
        }

        public static void ToggleMenu()
        {
            if (GlobalVariables.DevelopmentEnabled)
                GlobalVariables.devMenu.Visible = !GlobalVariables.devMenu.Visible;
        }

        static internal void OnItemSelectHandler(UIMenu sender, UIMenuItem item, int index)
        {
            switch (item.Text)
            {
                case "Add Dealer Location":
                    DevelopmentFunctions.SetDealerLocation(Game.Player.Character.Position, Game.Player.Character.Heading);
                    break;
            }
        }

        static internal void Reset()
        {
            if (GlobalVariables.devMenu != null)
                GlobalVariables.devMenu.MenuItems.Clear();
            CreateMenu();
        }

    }
}
