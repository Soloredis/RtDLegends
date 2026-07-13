using System;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace RtDLegends
{
    internal partial class RtDLegends : BaseUnityPlugin
    {
        private static readonly string[] ArmorPrefabList =
        {
            // BlackForest
            "BlackForestArcherChest_RtD",
            "BlackForestArcherHelmet_RtD",
            "BlackForestArcherLegs_RtD",
            "BlackForestMonkChest_RtD",
            "BlackForestMonkHelmet_RtD",
            "BlackForestMonkLegs_RtD",
            "BlackForestMonkCape_RtD",
            "BlackForestHardLeatherCape_RtD",
            // Swamp
            "SwampAssassinChest_RtD",
            "SwampAssassinHelmet_RtD",
            "SwampAssassinLegs_RtD",
            "SwampMonkChest_RtD",
            "SwampMonkHelmet_RtD",
            "SwampMonkLegs_RtD",
            "SwampMonkCape_RtD",
            "SwampAssassinCape_RtD",
            // Mountain
            "MountainArcherChest_RtD",
            "MountainArcherHelmet_RtD",
            "MountainArcherLegs_RtD",
            "MountainAssassinChest_RtD",
            "MountainAssassinHelmet_RtD",
            "MountainAssassinLegs_RtD",
            "MountainMonkChest_RtD",
            "MountainMonkHelmet_RtD",
            "MountainMonkLegs_RtD",
            "MountainMonkCape_RtD",
            "MountainHybridCape_RtD",
            // Plains
            "PlainsArcherChest_RtD",
            "PlainsArcherHelmet_RtD",
            "PlainsArcherLegs_RtD",
            "PlainsAssassinChest_RtD",
            "PlainsAssassinHelmet_RtD",
            "PlainsAssassinLegs_RtD",
            "PlainsMonkChest_RtD",
            "PlainsMonkHelmet_RtD",
            "PlainsMonkLegs_RtD",
            "PlainsMonkCape_RtD",
            "PlainsArcherCape_RtD",
            "PlainsAssassinCape_RtD",
            // Mistlands
            "MistlandsArcherChest_RtD",
            "MistlandsArcherHelmet_RtD",
            "MistlandsArcherLegs_RtD",
            "MistlandsAssassinChest_RtD",
            "MistlandsAssassinHelmet_RtD",
            "MistlandsAssassinLegs_RtD",
            "MistlandsMonkChest_RtD",
            "MistlandsMonkHelmet_RtD",
            "MistlandsMonkLegs_RtD",
            "MistlandsMonkCape_RtD",
            "MistlandsArcherCape_RtD",
            "MistlandsAssassinCape_RtD",
            // AshLands
            "AshLandsArcherChest_RtD",
            "AshLandsArcherHelmet_RtD",
            "AshLandsArcherLegs_RtD",
            "AshLandsAssassinChest_RtD",
            "AshLandsAssassinHelmet_RtD",
            "AshLandsAssassinLegs_RtD",
            "AshLandsMonkChest_RtD",
            "AshLandsMonkHelmet_RtD",
            "AshLandsMonkLegs_RtD",
            "AshLandsMonkCape_RtD",
            "AshLandsArcherCape_RtD",
            "AshLandsAssassinCape_RtD",
            "AshLandsHybridCape_RtD",
            "AshLandsWarriorChest_RtD",
            "AshLandsWarriorHelmet_RtD",
            "AshLandsWarriorLegs_RtD",
            // DeepNorth
            "DeepNorthArcherHelmet_RtD",
            "DeepNorthArcherLegs_RtD",
            "DeepNorthAssassinChest_RtD",
            "DeepNorthAssassinHelmet_RtD",
            "DeepNorthAssassinLegs_RtD",
            "DeepNorthMonkChest_RtD",
            "DeepNorthMonkHelmet_RtD",
            "DeepNorthMonkLegs_RtD",
            "DeepNorthMonkCape_RtD",
            "DeepNorthHybridCape_RtD",
            "DeepNorthWarriorChest_RtD",
            "DeepNorthWarriorHelmet_RtD",
            "DeepNorthWarriorLegs_RtD",
            "DeepNorthArcherChest_RtD",
        };

        private static readonly string[] ArmorBiomeList =
        {
            // BlackForest
            "BlackForest",
            "BlackForest",
            "BlackForest",
            "BlackForest",
            "BlackForest",
            "BlackForest",
            "BlackForest",
            "BlackForest",
            // Swamp
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            "Swamp",
            // Mountain
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            "Mountain",
            // Plains
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            "Plains",
            // Mistlands
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            "Mistlands",
            // AshLands
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            "AshLands",
            // DeepNorth
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
            "DeepNorth",
        };

        private static readonly string[] ArmorStationList =
        {
            // BlackForest
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            // Swamp
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            // Mountain
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            // Plains
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            CraftingStations.Forge,
            // Mistlands
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // AshLands
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // DeepNorth
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
        };

        // Requirement item names, one row per armor piece, same order as ArmorPrefabList.
        private static readonly string[][] ArmorReqItems =
        {
            // BlackForest
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            // Swamp
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "ArmorTrollLeatherChest" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "HelmetTrollLeather" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "ArmorTrollLeatherLegs" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestMonkChest_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestMonkHelmet_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestMonkLegs_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestMonkCape_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "CapeTrollHide" },
            // Mountain
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "ArmorRootChest" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "HelmetRoot" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "ArmorRootLegs" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampAssassinChest_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampAssassinHelmet_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampAssassinLegs_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampMonkChest_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampMonkHelmet_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampMonkLegs_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampMonkCape_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "TrophyBonemass" },
            // Plains
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainArcherChest_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainArcherHelmet_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainArcherLegs_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainAssassinChest_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainAssassinHelmet_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainAssassinLegs_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainMonkChest_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainMonkHelmet_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainMonkLegs_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainMonkCape_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "TrophyDragonQueen" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "TrophyDragonQueen" },
            // Mistlands
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsArcherChest_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsArcherHelmet_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsArcherLegs_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAssassinChest_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAssassinHelmet_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAssassinLegs_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsMonkChest_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsMonkHelmet_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsMonkLegs_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsMonkCape_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsArcherCape_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAssassinCape_RtD" },
            // AshLands
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsArcherChest_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsArcherHelmet_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsArcherLegs_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAssassinChest_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAssassinHelmet_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAssassinLegs_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsMonkChest_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsMonkHelmet_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsMonkLegs_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsMonkCape_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsArcherCape_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAssassinCape_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "QueenDrop" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "ArmorCarapaceChest" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "HelmetCarapace" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "ArmorCarapaceLegs" },
            // DeepNorth
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsArcherHelmet_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsArcherLegs_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAssassinChest_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAssassinHelmet_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAssassinLegs_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsMonkChest_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsMonkHelmet_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsMonkLegs_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsMonkCape_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsHybridCape_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsWarriorChest_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsWarriorHelmet_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsWarriorLegs_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsArcherChest_RtD" },
        };

        // Requirement amounts, same shape as ArmorReqItems above.
        private static readonly int[][] ArmorReqAmounts =
        {
            // BlackForest
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // Swamp
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // Mountain
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // Plains
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // Mistlands
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // AshLands
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // DeepNorth
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
        };

        // Requirement "amount per level" (the recipe upgrade cost per station level).
        // Recover is always true for every armor requirement, so it isn't broken out into its own array - it's just hardcoded true where it's used below.
        private static readonly int[][] ArmorReqLevels =
        {
            // BlackForest
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // Swamp
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // Mountain
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // Plains
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // Mistlands
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // AshLands
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // DeepNorth
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
        };

        // Config entries, one array per field, index-matched to ArmorPrefabList.
        private ConfigEntry<bool>[] ArmorEnabledConfigs;
        private ConfigEntry<string>[][] ArmorReqItemConfigs;
        private ConfigEntry<int>[][] ArmorReqAmountConfigs;

        public void CreateArmorConfigs()
        {
            try
            {
                // Order counts down so each biome section reads top-to-bottom in the
                // Configuration Manager in the same order the lists above are defined.
                int order = 10000;

                ArmorEnabledConfigs = new ConfigEntry<bool>[ArmorPrefabList.Length];
                ArmorReqItemConfigs = new ConfigEntry<string>[ArmorPrefabList.Length][];
                ArmorReqAmountConfigs = new ConfigEntry<int>[ArmorPrefabList.Length][];

                for (int i = 0; i < ArmorPrefabList.Length; i++)
                {
                    string prefab = ArmorPrefabList[i];
                    string section = "Armor - " + ArmorBiomeList[i];

                    ArmorEnabledConfigs[i] = Config.Bind(section, prefab + " - Enabled", true,
                        new ConfigDescription("Enable or disable crafting/adding of " + prefab + ".", null,
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    ArmorReqItemConfigs[i] = new ConfigEntry<string>[ArmorReqItems[i].Length];
                    ArmorReqAmountConfigs[i] = new ConfigEntry<int>[ArmorReqItems[i].Length];

                    for (int j = 0; j < ArmorReqItems[i].Length; j++)
                    {
                        int slot = j + 1;
                        string defaultItem = ArmorReqItems[i][j];
                        int defaultAmount = ArmorReqAmounts[i][j];

                        ArmorReqItemConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Item", defaultItem,
                            new ConfigDescription("Requirement " + slot + " for " + prefab + ". Prefab/item id consumed on craft (default: " + defaultItem + ").", null,
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        ArmorReqAmountConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Amount", defaultAmount,
                            new ConfigDescription("Amount of Requirement " + slot + " required to craft " + prefab + " (default item: " + defaultItem + ").",
                            new AcceptableValueRange<int>(0, 9999),
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        ArmorReqItemConfigs[i][j].SettingChanged += ArmorConfigChanged;
                        ArmorReqAmountConfigs[i][j].SettingChanged += ArmorConfigChanged;
                    }

                    ArmorEnabledConfigs[i].SettingChanged += ArmorConfigChanged;
                }

                // This fires once when configs sync from the server, so it catches everything in one go instead of relying on each config's own change event
                SynchronizationManager.OnConfigurationSynchronized += ArmorConfigChanged;
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding armor configuration values: {arg}");
            }
        }

        public void AddArmor()
        {
            try
            {
                for (int i = 0; i < ArmorPrefabList.Length; i++)
                {
                    string prefab = ArmorPrefabList[i];

                    if (!ArmorEnabledConfigs[i].Value)
                    {
                        if (LoggingEnable.Value) { Logger.LogMessage("Skipped (disabled in config): " + prefab); }
                        continue;
                    }

                    ItemConfig itemConfig = new ItemConfig();
                    itemConfig.CraftingStation = ArmorStationList[i];

                    for (int j = 0; j < ArmorReqItems[i].Length; j++)
                    {
                        string reqItem = ArmorReqItemConfigs[i][j].Value;
                        int amount = ArmorReqAmountConfigs[i][j].Value;
                        int amountPerLevel = ArmorReqLevels[i][j];
                        itemConfig.AddRequirement(new RequirementConfig(reqItem, amount, amountPerLevel, true));
                    }

                    ItemManager.Instance.AddItem(new CustomItem(this._myAssets, prefab, true, itemConfig));

                    if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefab + " to the Object database"); }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding armor: {arg}");
            }
        }

        // Fires on ANY armor config change both local edits and Jotunn syncing the server's value into a client's config after connecting. 
        private void ArmorConfigChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ArmorPrefabList.Length; i++)
                {
                    string prefab = ArmorPrefabList[i];
                    Recipe recipe = ItemManager.Instance.GetItem(prefab)?.Recipe?.Recipe;

                    if (recipe == null)
                    {
                        // Item/recipe was never registered (most likely it was disabled at Awake time, so AddArmor() skipped it).
                        continue;
                    }

                    recipe.m_enabled = ArmorEnabledConfigs[i].Value;

                    if (recipe.m_resources == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < ArmorReqItems[i].Length && j < recipe.m_resources.Length; j++)
                    {
                        string reqItemName = ArmorReqItemConfigs[i][j].Value;

                        if (string.IsNullOrWhiteSpace(reqItemName))
                        {
                            continue;
                        }

                        GameObject reqPrefab = PrefabManager.Instance.GetPrefab(reqItemName.Trim());
                        ItemDrop reqItemDrop = reqPrefab != null ? reqPrefab.GetComponent<ItemDrop>() : null;

                        if (reqItemDrop == null)
                        {
                            Logger.LogWarning("Could not resolve requirement item '" + reqItemName + "' for " + prefab + " - leaving that requirement slot unchanged.");
                            continue;
                        }

                        recipe.m_resources[j].m_resItem = reqItemDrop;
                        recipe.m_resources[j].m_amount = ArmorReqAmountConfigs[i][j].Value;
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while re-applying armor configs: {arg}");
            }
        }
    }
}