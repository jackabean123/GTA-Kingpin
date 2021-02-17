using System;
using System.IO;

namespace GTA_Kingpin.Helpers
{
    internal static class Logger
    {
        private static readonly string fileName = "kingpin.log";
        public static void Log(object message) => File.AppendAllText(Logger.fileName, DateTime.Now.ToString() + " - " + message + Environment.NewLine);
    }
}
