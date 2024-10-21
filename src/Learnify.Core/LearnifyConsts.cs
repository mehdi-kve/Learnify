using Learnify.Debugging;

namespace Learnify
{
    public class LearnifyConsts
    {
        public const string LocalizationSourceName = "Learnify";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "bdbd09464703403bbcd494646c491ba3";
    }
}
