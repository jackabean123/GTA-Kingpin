using GTA;
using GTA.Math;
using GTA_Kingpin.Helpers;
using LiteDB;

namespace GTA_Kingpin.Objects
{
    class Dealer
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }
        public Ped Ped { get; set; }

        public Dealer()
        {
            Name = RandomNames.GetRandomName();
            X = 85.50f;
            Y = -1959.43f;
            Z = 21.12f;
            R = 344.75f;
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
