using GTA_Kingpin.Helpers;
using GTA_Kingpin.Objects;
using GTA_Kingpin.Scripts;
using NativeUI;
using System.Drawing;
using System.IO;

namespace GTA_Kingpin.Menus
{
    static class DealerMenu
    {

        private static Dealer Dealer;

        public static void CreateMenu(Dealer dealer)
        {
            Dealer = dealer;
            GlobalVariables.dealerMenu = new UIMenu("", Dealer.Name);

            if (File.Exists(GlobalVariables.DealerMenuBanner))
                GlobalVariables.dealerMenu.SetBannerType(GlobalVariables.DealerMenuBanner);

            SetItem("Weed", DatabaseHandler.dealerInventory.WeedAmount);
            SetItem("Heroin", DatabaseHandler.dealerInventory.HeroinAmount);
            SetItem("Ketamine", DatabaseHandler.dealerInventory.KetamineAmount);
            SetItem("Meth", DatabaseHandler.dealerInventory.MethAmount);
            SetItem("LSD", DatabaseHandler.dealerInventory.LSDAmount);
            SetItem("MDMA", DatabaseHandler.dealerInventory.MDMAAmount);
            SetItem("Spice", DatabaseHandler.dealerInventory.SpiceAmount);
            SetItem("Steroids", DatabaseHandler.dealerInventory.SteroidsAmount);
            SetItem("Cocaine", DatabaseHandler.dealerInventory.CocaineAmount);

            GlobalVariables.pool.Add(GlobalVariables.dealerMenu);
        }

        private static void SetItem(string item, int amount)
        {
            Logger.Log(item + " " + amount);
            UIMenuColoredItem menuItem = new UIMenuColoredItem(item, Color.Gray, Color.Green);
            menuItem.SetRightLabel("~h~" + (amount > 0 ? "~g~" : "~r~") + amount);
            GlobalVariables.dealerMenu.AddItem(menuItem);
        }

        public static void ToggleMenu()
        {
            GlobalVariables.dealerMenu.Visible = !GlobalVariables.dealerMenu.Visible;
        }

    }
}
