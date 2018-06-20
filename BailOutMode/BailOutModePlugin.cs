using Harmony;
using IllusionPlugin;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace BailOutMode
{
    public class BailOutModePlugin : IPlugin
    {
        public string Name => "Bail Out Mode";
        public string Version => "0.0.1";

        public void OnApplicationStart()
        {
            Console.WriteLine("[Bailout] Starting Bailout");
            var harmony = HarmonyInstance.Create("com.foolishdave.beatsaber.bailout");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Console.WriteLine("[Bailout] Assembly Patched");

            SceneManager.activeSceneChanged += SceneChange;
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

        private void SceneChange(Scene oldScene, Scene scene)
        {

        }
    }
}
