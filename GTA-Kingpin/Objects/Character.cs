namespace GTA_Kingpin.Objects
{
    class Character
    {

        public long Id { get; set; }

        public int Xp { get; set; }

        public Character(long id, int xp)
        {
            Id = id;
            Xp = xp;
        }

        public Character()
        {
            Id = 1;
            Xp = 0;
        }

    }
}
