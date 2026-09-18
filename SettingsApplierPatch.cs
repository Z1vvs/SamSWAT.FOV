using SPT.Reflection.Patching;
using SPT.Reflection.Utils;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace SamSWAT.FOV
{
    public class SettingsApplierPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            Type gameSettingsType = PatchConstants.EftTypes.Single(x => x.GetMethods().Any(m => m.Name == "Clone") && x.GetField("NotificationTransportType") != null);

            Type nestedType = gameSettingsType.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Any(m => m.Name == "method_0"));

            if (nestedType != null) return nestedType.GetMethod("method_0", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return gameSettingsType.GetMethod("method_0", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        }

        [PatchPostfix]
        public static void PatchPostfix(int x, ref int __result)
        {
            __result = Mathf.Clamp(x, FovPlugin.MinFov.Value, FovPlugin.MaxFov.Value);
        }
    }
}
