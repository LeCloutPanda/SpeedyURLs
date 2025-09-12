using BepInEx;
using BepInEx.NET.Common;
using BepInExResoniteShim;
using FrooxEngine;
using FrooxEngine.UIX;
using HarmonyLib;

namespace SpeedyURLs;

[ResonitePlugin(PluginMetadata.GUID, PluginMetadata.NAME, PluginMetadata.VERSION, PluginMetadata.AUTHORS, PluginMetadata.REPOSITORY_URL)]
[BepInDependency(BepInExResoniteShim.PluginMetadata.GUID, BepInDependency.DependencyFlags.HardDependency)]
public class SpeedyURLs : BasePlugin
{
    public override void Load()
    {
        HarmonyInstance.PatchAll();
    }

    [HarmonyPatch(typeof(UIExtensions), "EnableTimeout", new Type[] {typeof(Component), typeof(IField<bool>), typeof(IField<string>), typeof(int)})]
    public class HyperlinkOpenDialogPatch
    {
        public static void Prefix(ref int timeout)
        {
            timeout = 0;
        }
    }
}