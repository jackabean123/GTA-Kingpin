using System;

namespace GTA_Kingpin.Functionality
{
    static class LevelCalculator
    {

        private static double XpPerLevel = 500;

        public static int GetPlayerLevel(double xp)
        {
            double level = 1;
            if (xp == 0)
                return (int)Math.Round(level);

            double lvl = xp / XpPerLevel;
            level = (int)Math.Ceiling(lvl);

            return (int)Math.Round(level);
        }

        public static int GetXpToNextLevel(double xp)
        {
            if ((xp % XpPerLevel) == 0)
                return (int)Math.Round(XpPerLevel);

            double currentLevel = GetPlayerLevel(xp);
            double nextLevelXp = (currentLevel) * XpPerLevel;
            return (int)Math.Round((xp - nextLevelXp) * -1);
        }

    }
}
