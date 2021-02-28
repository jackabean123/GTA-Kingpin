using GTA_Kingpin.Scripts;
using NativeUI;
using System.Drawing;
using System.IO;

namespace GTA_Kingpin.Menus
{
    static class CharacterInventory
    {

        public static void Create()
        {
            GlobalVariables.characterMenu = new UIMenu("", "");
            
            if (File.Exists(GlobalVariables.CharacterMenuBanner))
                GlobalVariables.characterMenu.SetBannerType(GlobalVariables.CharacterMenuBanner);

            SetItem("Weed", DatabaseHandler.characterInventory.WeedAmount);
            SetItem("Heroin", DatabaseHandler.characterInventory.HeroinAmount);
            SetItem("Ketamine", DatabaseHandler.characterInventory.KetamineAmount);
            SetItem("Meth", DatabaseHandler.characterInventory.MethAmount);
            SetItem("LSD", DatabaseHandler.characterInventory.LSDAmount);
            SetItem("MDMA", DatabaseHandler.characterInventory.MDMAAmount);
            SetItem("Spice", DatabaseHandler.characterInventory.SpiceAmount);
            SetItem("Steroids", DatabaseHandler.characterInventory.SteroidsAmount);
            SetItem("Cocaine", DatabaseHandler.characterInventory.CocaineAmount);

            GlobalVariables.pool.Add(GlobalVariables.characterMenu);
        }

        private static void SetItem(string item, int amount)
        {
            UIMenuColoredItem menuItem = new UIMenuColoredItem(item, Color.Gray, Color.Green);
            menuItem.SetRightLabel("~h~" + (amount > 0 ? "~g~" : "~r~") + amount);
            GlobalVariables.characterMenu.AddItem(menuItem);
        }

        public static void Toggle()
        {
            if (GlobalVariables.characterMenu == null)
                Create();
            GlobalVariables.characterMenu.Visible = !GlobalVariables.characterMenu.Visible;
        }

    }
}
