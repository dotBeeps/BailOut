using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ryder.Lightweight;

namespace BailOutMode.Patches
{
    class MenuMasterViewControllerPatches
    {
        private static Redirection didActivateRedirection;

        public static void PatchMethods()
        {
            MethodInfo didActivateInfo =
                typeof(MenuMasterViewController).GetMethod("DidActivate", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo didActivatePatch =
                typeof(MenuMasterViewControllerPatches).GetMethod(nameof(DidActivatePatch), BindingFlags.NonPublic | BindingFlags.Static);
            didActivateRedirection = new Redirection(didActivateInfo, didActivatePatch, true);
        }

        private static void DidActivatePatch(object self)
        {
            didActivateRedirection.InvokeOriginal(self);
            if (BailOutModePlugin.BailedOut)
            {
                ((MainSettingsModel) typeof(MenuMasterViewController)
                        .GetField("_mainSettingsModel", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(self))
                    .gameplayOptions.noEnergy = false;
                BailOutModePlugin.BailedOut = false;
                Console.WriteLine("Reset BailOut");
            }
        }
    }
}
