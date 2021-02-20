using GTA;

namespace GTA_Kingpin.Helpers
{
    static class VehicleHelper
    {

        public enum TruckBedMod
        {
            None = 0,
            Weapons_Crate = 1,
            Ammo_Box = 2,
            Duffle_Bags = 4
        }

        public static Vehicle CreateDropTruck(TruckBedMod mod)
        {
            Vehicle v = World.CreateVehicle(VehicleHash.Kamacho, new GTA.Math.Vector3(Game.Player.Character.Position.X - 6, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z));
            v.LockStatus = VehicleLockStatus.PlayerCannotEnter;
            v.Mods.PrimaryColor = VehicleColor.MatteBlack;
            v.Mods.InstallModKit();
            v.Mods[VehicleModType.Frame].Index = (int)mod;
            return v;
        }

        public static Vehicle ChangeDropTruck(Vehicle v)
        {
            v.Mods[VehicleModType.Frame].Index = 0;
            return v;
        }

    }
}
