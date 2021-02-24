using GTA_Kingpin.Objects;
using NativeUI;
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

            GlobalVariables.dealerMenu.AddItem(new UIMenuItem("Test", ""));
            
            GlobalVariables.pool.Add(GlobalVariables.dealerMenu);
        }

        public static void ToggleMenu()
        {
            GlobalVariables.dealerMenu.Visible = !GlobalVariables.dealerMenu.Visible;
        }

    }
}
