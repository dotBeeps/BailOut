using Harmony;
using System;
using System.Reflection;

[HarmonyPatch(typeof(GameEnergyCounter))]
[HarmonyPatch("AddEnergy")]
class GameEnergyCounter_AddEnergy_Patch
{
    public static void Prefix(GameEnergyCounter __instance, ref float value)
    {
        if (!(__instance.energy + value <= 1E-05f)) return;

        Console.WriteLine("[Bailout] Lethal energy reached, bailing out!");

        AccessTools.Field(typeof(GameEnergyCounter), "_cannotFail").SetValue(__instance, true);

        var sceneSetup = UnityEngine.Object.FindObjectOfType<MainGameSceneSetup>();
        MainGameSceneSetupData setupData = AccessTools.Field(typeof(MainGameSceneSetupData), "_mainGameSceneSetupData").GetValue(sceneSetup) as MainGameSceneSetupData;
        setupData.gameplayOptions.noEnergy = true;

        UnityEngine.Object.FindObjectOfType<GameEnergyUIPanel>().EnableEnergyPanel(false);

        value = 0;
    }
}
