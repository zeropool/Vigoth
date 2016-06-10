
using System.Reflection;
using VigiothCapital.QuantTrader.Configuration;
namespace VigiothCapital.QuantTrader
{
    /// <summary>
    /// Provides application level constant values
    /// </summary>
    public static class Globals
    {
        static Globals()
        {
            Reset();
        }
        /// <summary>
        /// The root directory of the data folder for this application
        /// </summary>
        public static string DataFolder { get; private set; }
        /// <summary>
        /// Resets global values with the Config data.
        /// </summary>
        public static void Reset ()
        {
            DataFolder = Config.Get("data-folder", Config.Get("data-directory", @"../../../Data/"));
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var versionid = Config.Get("version-id");
            if (!string.IsNullOrWhiteSpace(versionid))
            {
                Version += "." + versionid;
            }
        }
        /// <summary>
        /// The directory used for storing downloaded remote files
        /// </summary>
        public const string Cache = "./cache/data";
        /// <summary>
        /// The version of lean
        /// </summary>
        public static string Version { get; private set; }
    }
}
