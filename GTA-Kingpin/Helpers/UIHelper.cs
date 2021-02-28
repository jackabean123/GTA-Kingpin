using GTA_Kingpin.Functionality;
using GTA_Kingpin.Objects;
using System.Drawing;

namespace GTA_Kingpin.Helpers
{
    static class UIHelper
    {

        public static void ShowNotification(string s)
        {
            GTA.UI.Notification.Show(s);
        }

        public static void ShowStats(Character character)
        {
            GTA.UI.TextElement elmnt = new GTA.UI.TextElement("~w~Level: ~g~" + LevelCalculator.GetPlayerLevel(character.Xp) + " ~b~\\|/ ~w~XP to next level: ~g~" + LevelCalculator.GetXpToNextLevel(character.Xp),
                new PointF(GTA.UI.Screen.Width - 250, GTA.UI.Screen.Height - 20), 0.4f, Color.White, GTA.UI.Font.ChaletLondon);
            elmnt.Draw();
        }

        public static void Show(string value)
        {
            GTA.UI.TextElement elmnt = new GTA.UI.TextElement(value, new PointF(GTA.UI.Screen.Width - 250, GTA.UI.Screen.Height + 700),
                0.4f, Color.White, GTA.UI.Font.ChaletLondon);
            elmnt.Draw();
        }

        public static void ShowNearDealer(Dealer dealer)
        {
            GTA.UI.TextElement elmnt = new GTA.UI.TextElement("~w~Press ~g~E ~w~to talk to " + dealer.Name,
                new PointF(GTA.UI.Screen.Width - (GTA.UI.Screen.Width - 20), GTA.UI.Screen.Height - (GTA.UI.Screen.Height - 20)), 0.4f, Color.White, GTA.UI.Font.ChaletLondon)
            {
                Outline = true
            };
            elmnt.Draw();
        }

    }
}
