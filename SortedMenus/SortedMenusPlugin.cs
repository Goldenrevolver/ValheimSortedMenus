﻿using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using System.Reflection;

namespace SortedMenus
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class SortedMenusPlugin : BaseUnityPlugin
    {
        public const string GUID = "goldenrevolver.SortedMenus";
        public const string NAME = "Sorted Cooking, Crafting and Skills Menu";
        public const string VERSION = "1.3.4";

        private const string combineSkillsMod = "goldenrevolver.CombineSpearAndPolearmSkills";
        private const string augaMod = "randyknapp.mods.auga";

        protected void Start()
        {
            SortConfig.LoadConfig(this);

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }

        internal static bool HasSkillsMenuIncompatibleModInstalled()
        {
            return HasCombinedSkillsModInstalled() || HasAugaInstalled();
        }

        internal static bool HasCombinedSkillsModInstalled()
        {
            return Chainloader.PluginInfos.ContainsKey(combineSkillsMod);
        }

        internal static bool HasAugaInstalled()
        {
            return Chainloader.PluginInfos.ContainsKey(augaMod);
        }
    }

    internal enum CraftingStationType
    {
        CookingPot,
        Forge,
        Other,
    }
}