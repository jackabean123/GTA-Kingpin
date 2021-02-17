using System;

namespace GTA_Kingpin.Helpers
{
    static class MiscHelper
    {

        public static int GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return (int)Math.Round(random.NextDouble() * (maximum - minimum) + minimum);
        }

    }
}
