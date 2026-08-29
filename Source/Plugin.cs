using BepInEx;
using BepInEx.Logging;
using GRewind;

namespace grewind.Source
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        ManualLogSource logger => base.Logger;

        void Start()
        {
            logger.Log(LogLevel.Message, PluginInfo.Version);
        }
    }
}
