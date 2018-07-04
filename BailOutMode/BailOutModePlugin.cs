using IllusionPlugin;
using System;
using System.Reflection;
using BailOutMode.Patches;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BailOutModePlugin : IPlugin
{
    public string Name => "Bail Out Mode";
    public string Version => "0.0.1";

    public static bool BailedOut = false;

    static BailOutModePlugin()
    {

    }

    public void OnApplicationStart()
    {
        Console.WriteLine("[Bailout] Starting Bailout");
        GameEnergyPatches.PatchMethods();
        MenuMasterViewControllerPatches.PatchMethods();
        Console.WriteLine("[Bailout] Assembly Patched");
    }

    public void OnApplicationQuit()
    {

    }

    public void OnLevelWasLoaded(int level)
    {

    }

    public void OnLevelWasInitialized(int level)
    {

    }

    public void OnUpdate()
    {

    }

    public void OnFixedUpdate()
    {

    }

}
