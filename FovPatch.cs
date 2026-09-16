using SPT.Reflection.Patching;
using EFT.UI.Settings;
using System;
using System.Linq;
using System.Reflection;

namespace SamSWAT.FOV
{
    public class FovPatch : ModulePatch
    {
        private static readonly FieldInfo FovValuesField =
            typeof(GameSettingsTab).GetField(
                "readOnlyCollection_0",
                BindingFlags.Static | BindingFlags.NonPublic);

        protected override MethodBase GetTargetMethod()
        {
            return typeof(GameSettingsTab).GetMethod("Show");
        }

        [PatchPrefix]
        private static void PatchPrefix()
        {
            if (FovValuesField == null)
            {
                FovPlugin.Log.LogError("Could not find GameSettingsTab.readOnlyCollection_0. FOV slider patch was not applied.");
                return;
            }

            if (FovPlugin.MaxFov.Value < FovPlugin.MinFov.Value)
            {
                FovPlugin.MinFov.Value = 50;
                FovPlugin.MaxFov.Value = 75;
            }

            int rangeCount =
                FovPlugin.MaxFov.Value -
                FovPlugin.MinFov.Value +
                1;

            var fovValues = Array.AsReadOnly(
                Enumerable.Range(
                    FovPlugin.MinFov.Value,
                    rangeCount
                ).ToArray()
            );

            FovValuesField.SetValue(null, fovValues);
        }
    }
}