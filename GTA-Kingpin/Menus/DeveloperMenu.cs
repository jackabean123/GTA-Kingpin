using GTA;
using GTA.Math;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;
using NativeUI;
using System;
using System.IO;
using System.Linq;

namespace GTA_Kingpin.Menus
{

    static class DeveloperMenu
    {

        private static Ped Ped;
        private static PedHash CurrentPedHash = PedHash.ClubCust03AFY;
        private static int Rotation = 180;

        public static void CreateMenu()
        {
            GlobalVariables.devMenu = new UIMenu("", "");
            GlobalVariables.devMenu.OnItemSelect += OnItemSelectHandler;
            GlobalVariables.devMenu.OnListChange += OnListChangedHandler;
            GlobalVariables.devMenu.OnSliderChange += OnSliderChangedHandler;

            if (File.Exists(GlobalVariables.DevMenuBanner))
                GlobalVariables.devMenu.SetBannerType(GlobalVariables.DevMenuBanner);

            GlobalVariables.devMenu.AddItem(new UIMenuListItem("Ped Model", PedHelper.GetPedHashList(), 0, "Load the selected character."));
            GlobalVariables.devMenu.AddItem(new UIMenuSliderItem("Ped Rotation", "Set the ped rotation") { Maximum = 360, Value = 180 });
            GlobalVariables.devMenu.AddItem(new UIMenuItem("~r~Clear Ped", "Clears the ped model"));

            GlobalVariables.devMenu.AddItem(new UIMenuItem("~g~Add Dealer Location", "Adds a new dealer location"));
            GlobalVariables.devMenu.AddItem(new UIMenuItem("~r~Remove Dealer Location", "Removes nearest dealer"));

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
                case "~g~Add Dealer Location":
                    if (Ped == null)
                        UIHelper.ShowNotification("Set a ped model and rotation");
                    else
                        DevelopmentFunctions.SetDealerLocation(Ped.Position, Rotation, CurrentPedHash);
                    break;
                case "~r~Clear Ped":
                    if (Ped != null)
                        Ped.Delete();
                    break;
            }
        }

        static internal void OnListChangedHandler(UIMenu sender, UIMenuListItem list, int newindex)
        {
            switch (list.Text)
            {
                case "Ped Model":
                    if (Ped != null)
                        Ped.Delete();
                    PedHash hash = PedHelper.GetPedFromString(list.Items[newindex].ToString());
                    Ped = World.CreatePed(hash, Game.Player.Character.GetOffsetPosition(new Vector3(0, 2, 0)), Rotation);
                    CurrentPedHash = hash;
                    break;
            }
        }

        static internal void OnSliderChangedHandler(UIMenu sender, UIMenuSliderItem slider, int newindex)
        {
            switch (slider.Text)
            {
                case "Ped Rotation":
                    if (Ped != null)
                    {
                        Rotation = slider.Value;
                        Ped.Heading = Rotation;
                    }
                    break;
            }
            
        }

        static internal PedHash GetPedFromString(string PedName)
        {
            foreach (PedHash ped in Enum.GetValues(typeof(PedHash)).Cast<PedHash>())
                if (ped.ToString() == PedName)
                    return ped;
            return PedHash.Abigail;
        }

        static internal void Reset()
        {
            if (GlobalVariables.devMenu != null)
                GlobalVariables.devMenu.MenuItems.Clear();
            CreateMenu();
        }

    }

    class PedHashObject : object
    {
        public string Name { get; set; }
        public uint Value { get; set; }

        public PedHashObject(string name, uint value)
        {
            this.Name = name;
            this.Value = value;
        }

        public PedHashObject(PedHash hash)
        {
            this.Name = hash.ToString();
            this.Value = (uint)hash;
        }

        public override string ToString()
        {
            return Name;
        }

    }

}
