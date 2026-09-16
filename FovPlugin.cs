using BepInEx;
using BepInEx.Configuration;
using Comfort.Common;
using EFT;
using System;
using UnityEngine;

namespace SamSWAT.FOV
{
    [BepInPlugin("com.samswat.fov", "SamSWAT.FOV", "1.0.3")]
    [BepInDependency("FOVFix", BepInDependency.DependencyFlags.SoftDependency)]
    public class FovPlugin : BaseUnityPlugin
    {
        internal static BepInEx.Logging.ManualLogSource Log;
        internal static ConfigEntry<int> MinFov;
        internal static ConfigEntry<int> MaxFov;
        internal static ConfigEntry<float> ViewmodelDepthOffset;
        internal static ConfigEntry<float> ViewmodelHorizontalOffset;
        internal static ConfigEntry<float> ViewmodelVerticalOffset;

        private void Awake()
        {
            Log = Logger;

            MinFov = Config.Bind(
                "FOV Adjustments",
                "Min FOV Value",
                50,
                new ConfigDescription(
                    "Minimum field of view setting. Default is 50",
                    new AcceptableValueRange<int>(1, 149)));

            MaxFov = Config.Bind(
                "FOV Adjustments",
                "Max FOV Value",
                75,
                new ConfigDescription(
                    "Maximum field of view setting. Default is 75",
                    new AcceptableValueRange<int>(1, 150)));

            ViewmodelDepthOffset = Config.Bind(
                "Viewmodel Controls",
                "Viewmodel Depth Offset",
                0.05f,
                new ConfigDescription(
                    "Adjusts weapon distance from the screen. Lower values move the weapon further away. Default is 0.05",
                    new AcceptableValueRange<float>(-0.1f, 0.1f)));

            ViewmodelHorizontalOffset = Config.Bind(
                "Viewmodel Controls",
                "Viewmodel Horizontal Offset",
                0.04f,
                new ConfigDescription(
                    "Adjusts weapon left/right position. Lower values shift the weapon to the left. Default is 0.04",
                    new AcceptableValueRange<float>(-0.1f, 0.1f)));

            ViewmodelVerticalOffset = Config.Bind(
                "Viewmodel Controls",
                "Viewmodel Vertical Offset",
                0.04f,
                new ConfigDescription(
                    "Adjusts weapon height position. Lower values shift the weapon downward. Default is 0.04",
                    new AcceptableValueRange<float>(-0.1f, 0.1f)));

            ViewmodelDepthOffset.SettingChanged += ViewmodelOffset_SettingChanged;
            ViewmodelHorizontalOffset.SettingChanged += ViewmodelOffset_SettingChanged;
            ViewmodelVerticalOffset.SettingChanged += ViewmodelOffset_SettingChanged;

            new FovPatch().Enable();
            new CameraOffsetPatch().Enable();
            new SettingsApplierPatch().Enable();
        }

        private void ViewmodelOffset_SettingChanged(object sender, EventArgs e)
        {
            var gameWorld = Singleton<GameWorld>.Instance;

            if (gameWorld == null || gameWorld.RegisteredPlayers == null)
                return;

            var player = gameWorld.MainPlayer;

            if (player == null)
                return;

            var pwa = player.ProceduralWeaponAnimation;
            var hands = pwa.HandsContainer;

            hands.CameraOffset =
                new Vector3(ViewmodelHorizontalOffset.Value, ViewmodelVerticalOffset.Value, ViewmodelDepthOffset.Value);
        }
    }
}
