using GTA;
using GTA.Math;
using GTA_Kingpin.Database;
using GTA_Kingpin.Helpers;

namespace GTA_Kingpin.Objects
{
    class Dealer
    {

        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }
        public Ped Ped { get; set; }

        public Dealer()
        {
            Name = RandomNames.GetRandomName();
            X = 86;
            Y = -1958;
            Z = 21;
            R = 344;
            Ped = null;
        }

        public Dealer(float x, float y, float z, float r)
        {
            Name = RandomNames.GetRandomName();
            X = x;
            Y = y;
            Z = z;
            R = r;
            Ped = null;
        }

        public Vector3 GetVector3()
        {
            return new Vector3(X, Y, Z);
        }

    }

}
