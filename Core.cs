using MelonLoader;

[assembly: MelonInfo(typeof(HelloWorldTVApp.Core), "HelloWorldTVApp", "1.0.0", "HazDS")]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace HelloWorldTVApp
{
    /// <summary>
    /// Entry point for the HelloWorldTVApp demonstrating S1API TV app functionality.
    /// </summary>
    public class Core : MelonMod
    {
        /// <summary>
        /// Called when the mod is initialized by MelonLoader.
        /// </summary>
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("HelloWorldTVApp loaded and added to TV.");
        }
    }
}
