using SPT.Reflection.Patching;
using EFT.Animations;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace SamSWAT.FOV
{
    public class CameraOffsetPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(ProceduralWeaponAnimation).GetMethod("LerpCamera", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        [PatchPostfix]
        [HarmonyPriority(Priority.Last)]
        private static void PatchPostfix(ProceduralWeaponAnimation __instance)
        {
            if (__instance == null || __instance.HandsContainer == null)
            {
                return;
            }

            __instance.HandsContainer.CameraOffset = new Vector3(FovPlugin.ViewmodelHorizontalOffset.Value, FovPlugin.ViewmodelVerticalOffset.Value, FovPlugin.ViewmodelDepthOffset.Value);
        }
    }
}