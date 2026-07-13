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
        private static readonly string[] WeaponPrefabList =
        {
            // Meadows
            "MeadowsAtgeir_RtD",
            "MeadowsAxe1H_RtD",
            "MeadowsAxe2H_RtD",
            "MeadowsBow_RtD",
            "MeadowsClub_RtD",
            "MeadowsDagger_RtD",
            "MeadowsDefender_RtD",
            "MeadowsSpear_RtD",
            "MeadowsSword1H_RtD",
            "MeadowsSword2H_RtD",
            "MeadowsShield_RtD",
            // BlackForest
            "BlackForestAtgeir_RtD",
            "BlackForestAxe1H_RtD",
            "BlackForestAxe2H_RtD",
            "BlackForestBow_RtD",
            "BlackForestClub_RtD",
            "BlackForestDagger_RtD",
            "BlackForestDefender_RtD",
            "BlackForestSpear_RtD",
            "BlackForestSledge_RtD",
            "BlackForestSword1H_RtD",
            "BlackForestSword2H_RtD",
            "BlackForestShield_RtD",
            // Swamp
            "SwampAtgeir_RtD",
            "SwampAxe1H_RtD",
            "SwampAxe2H_RtD",
            "SwampBow_RtD",
            "SwampClub_RtD",
            "SwampDagger_RtD",
            "SwampDefender_RtD",
            "SwampSledge_RtD",
            "SwampSpear_RtD",
            "SwampSword1H_RtD",
            "SwampSword2H_RtD",
            "SwampShield_RtD",
            // Mountain
            "MountainAtgeir_RtD",
            "MountainAxe1H_RtD",
            "MountainAxe2H_RtD",
            "MountainBow_RtD",
            "MountainClub_RtD",
            "MountainDagger_RtD",
            "MountainDefender_RtD",
            "MountainSledge_RtD",
            "MountainSpear_RtD",
            "MountainSword1H_RtD",
            "MountainSword2H_RtD",
            "MountainShield_RtD",
            // Plains
            "PlainsAtgeir_RtD",
            "PlainsAxe1H_RtD",
            "PlainsAxe2H_RtD",
            "PlainsBow_RtD",
            "PlainsClub_RtD",
            "PlainsDagger_RtD",
            "PlainsDefender_RtD",
            "PlainsSledge_RtD",
            "PlainsSpear_RtD",
            "PlainsSword1H_RtD",
            "PlainsSword2H_RtD",
            "PlainsShield_RtD",
            // Mistlands
            "MistlandsAtgeir_RtD",
            "MistlandsAxe1H_RtD",
            "MistlandsAxe2H_RtD",
            "MistlandsBow_RtD",
            "MistlandsClub_RtD",
            "MistlandsDagger_RtD",
            "MistlandsDefender_RtD",
            "MistlandsSledge_RtD",
            "MistlandsSpear_RtD",
            "MistlandsSword1H_RtD",
            "MistlandsSword2H_RtD",
            "MistlandsShield_RtD",
            // AshLands
            "AshLandsAtgeir_RtD",
            "AshLandsAxe1H_RtD",
            "AshLandsAxe2H_RtD",
            "AshLandsBow_RtD",
            "AshLandsClub_RtD",
            "AshLandsDagger_RtD",
            "AshLandsDefender_RtD",
            "AshLandsSledge_RtD",
            "AshLandsSpear_RtD",
            "AshLandsSword1H_RtD",
            "AshLandsSword2H_RtD",
            "AshLandsShieldBow_RtD",
            "AshLandsShield_RtD",
            // DeepNorth
            "DeepNorthAtgeir_RtD",
            "DeepNorthAxe1H1_RtD",
            "DeepNorthAxe2H1_RtD",
            "DeepNorthBow_RtD",
            "DeepNorthClub_RtD",
            "DeepNorthDagger_RtD",
            "DeepNorthDefender_RtD",
            "DeepNorthSledge1_RtD",
            "DeepNorthSledge2_RtD",
            "DeepNorthSpear_RtD",
            "DeepNorthSword1H1_RtD",
            "DeepNorthShieldBow_RtD",
            "DeepNorthSword2H1_RtD",
            "DeepNorthSword2H2_RtD",
            "DeepNorthShield_RtD",
            "DeepNorthAxe2H2_RtD",
            // Special
            "AxeFlametal_RtD",
            "PickAxeFlametal_RtD",
            "OdinsFist_RtD",
            "OdinsDefender_RtD",
        };

        private static readonly string[] WeaponBiomeList =
        {
            // Meadows
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            "Meadows",
            // BlackForest
            "BlackForest",
            "BlackForest",
            "BlackForest",
            "BlackForest",
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
            "DeepNorth",
            "DeepNorth",
            // Special
            "Special",
            "Special",
            "Special",
            "Special",
        };

        private static readonly string[] WeaponStationList =
        {
            // Meadows
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            CraftingStations.Workbench,
            // BlackForest
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
            // Swamp
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
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            // Special
            CraftingStations.BlackForge,
            CraftingStations.BlackForge,
            CraftingStations.Forge,
            CraftingStations.Forge,
        };

        // Requirement item names, one row per weapon/shield, same order as WeaponPrefabList.
        private static readonly string[][] WeaponReqItems =
        {
            // Meadows
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Wood", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Flint", "MeadowsCore_RtD" },
            new string[] { "MeadowsToken_RtD", "Wood", "MeadowsCore_RtD" },
            // BlackForest
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsAtgeir_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsAxe1H_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsAxe2H_RtD" },
            new string[] { "BlackForestToken_RtD", "FineWood", "BlackForestCore_RtD", "MeadowsBow_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsClub_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsDagger_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsDefender_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsSpear_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "TrophyTheElder" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsSword1H_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsSword2H_RtD" },
            new string[] { "BlackForestToken_RtD", "Item_CelestialBronzeBar_RtD", "BlackForestCore_RtD", "MeadowsShield_RtD" },
            // Swamp
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestAtgeir_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestAxe1H_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestAxe2H_RtD" },
            new string[] { "SwampToken_RtD", "ElderBark", "SwampCore_RtD", "BlackForestBow_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestClub_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestDagger_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestDefender_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestSledge_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestSpear_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestSword1H_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestSword2H_RtD" },
            new string[] { "SwampToken_RtD", "Item_BrightsteelBar_RtD", "SwampCore_RtD", "BlackForestShield_RtD" },
            // Mountain
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampAtgeir_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampAxe1H_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampAxe2H_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampBow_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampClub_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampDagger_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampDefender_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampSledge_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampSpear_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampSword1H_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampSword2H_RtD" },
            new string[] { "MountainToken_RtD", "Item_QuicksilverBar_RtD", "MountainCore_RtD", "SwampShield_RtD" },
            // Plains
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainAtgeir_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainAxe1H_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainAxe2H_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainBow_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainClub_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainDagger_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainDefender_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainSledge_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainSpear_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainSword1H_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainSword2H_RtD" },
            new string[] { "PlainsToken_RtD", "Item_NetheriteBar_RtD", "PlainsCore_RtD", "MountainShield_RtD" },
            // Mistlands
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAtgeir_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAxe1H_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsAxe2H_RtD" },
            new string[] { "MistlandsToken_RtD", "YggdrasilWood", "MistlandsCore_RtD", "PlainsBow_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsClub_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsDagger_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsDefender_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsSledge_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsSpear_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsSword1H_RtD" },
            new string[] { "MistlandsToken_RtD", "FelmetalBar_RtD", "MistlandsCore_RtD", "PlainsSword2H_RtD" },
            new string[] { "MistlandsToken_RtD", "Item_NetheriteBar_RtD", "MistlandsCore_RtD", "PlainsShield_RtD" },
            // AshLands
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAtgeir_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAxe1H_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsAxe2H_RtD" },
            new string[] { "AshLandsToken_RtD", "Blackwood", "AshLandsCore_RtD", "MistlandsBow_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsClub_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsDagger_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsDefender_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsSledge_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsSpear_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsSword1H_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsSword2H_RtD" },
            new string[] { "AshLandsToken_RtD", "Blackwood", "AshLandsCore_RtD", "MistlandsBow_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "AshLandsCore_RtD", "MistlandsShield_RtD" },
            // DeepNorth
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAtgeir_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAxe1H_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAxe2H_RtD" },
            new string[] { "DeepNorthToken_RtD", "Blackwood", "DeepNorthCore_RtD", "AshLandsBow_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsClub_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsDagger_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsDefender_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsSledge_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsSledge_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsSpear_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsSword1H_RtD" },
            new string[] { "DeepNorthToken_RtD", "Blackwood", "DeepNorthCore_RtD", "AshLandsShieldBow_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsSword2H_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsSword2H_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsShield_RtD" },
            new string[] { "DeepNorthToken_RtD", "FroMetalBar_RtD", "DeepNorthCore_RtD", "AshLandsAxe2H_RtD" },
            // Special
            new string[] { "AshLandsToken_RtD", "Flametal", "BurningGland_RtD", "AshLandsCore_RtD" },
            new string[] { "AshLandsToken_RtD", "Flametal", "BurningGland_RtD", "AshLandsCore_RtD" },
            new string[] { "BlackForestToken_RtD", "Iron", "MeadowsCore_RtD", "TrophyEikthyr" },
            new string[] { "BlackForestToken_RtD", "Iron", "MeadowsCore_RtD", "TrophyEikthyr" },
        };

        // Requirement amounts, same shape as WeaponReqItems above.
        private static readonly int[][] WeaponReqAmounts =
        {
            // Meadows
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 45, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 15, 1 },
            new int[] { 3, 45, 1 },
            // BlackForest
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 35, 1, 1 },
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
            new int[] { 3, 35, 1, 1 },
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
            new int[] { 3, 35, 1, 1 },
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
            new int[] { 3, 35, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 35, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // DeepNorth
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 50, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 50, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
            // Special
            new int[] { 3, 15, 2, 1 },
            new int[] { 3, 15, 2, 1 },
            new int[] { 3, 15, 1, 1 },
            new int[] { 3, 15, 1, 1 },
        };

        // Requirement "amount per level" (the recipe upgrade cost per station level).
        // Recover is always true for every weapon/shield requirement, so it isn't broken out into its own array - it's just hardcoded true where it's used below.
        
        private static readonly int[][] WeaponReqLevels =
        {
            // Meadows
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            new int[] { 3, 2, 1 },
            // BlackForest
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
            // Swamp
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
            new int[] { 3, 2, 1, 0 },
            new int[] { 3, 2, 1, 0 },
            // Special
            new int[] { 3, 2, 0, 1 },
            new int[] { 3, 2, 0, 1 },
            new int[] { 3, 10, 1, 0 },
            new int[] { 3, 10, 1, 0 },
        };

        // Config entries, one array per field, index-matched to WeaponPrefabList.
        private ConfigEntry<bool>[] WeaponEnabledConfigs;
        private ConfigEntry<string>[][] WeaponReqItemConfigs;
        private ConfigEntry<int>[][] WeaponReqAmountConfigs;

        public void CreateWeaponAndShieldConfigs()
        {
            try
            {
                // Order counts down so each biome section reads top-to-bottom in the Configuration Manager in the same order the lists above are defined.
                
                int order = 20000;

                WeaponEnabledConfigs = new ConfigEntry<bool>[WeaponPrefabList.Length];
                WeaponReqItemConfigs = new ConfigEntry<string>[WeaponPrefabList.Length][];
                WeaponReqAmountConfigs = new ConfigEntry<int>[WeaponPrefabList.Length][];

                for (int i = 0; i < WeaponPrefabList.Length; i++)
                {
                    string prefab = WeaponPrefabList[i];
                    string section = "Weapons And Shields - " + WeaponBiomeList[i];

                    WeaponEnabledConfigs[i] = Config.Bind(section, prefab + " - Enabled", true,
                        new ConfigDescription("Enable or disable crafting/adding of " + prefab + ".", null,
                        new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                    WeaponReqItemConfigs[i] = new ConfigEntry<string>[WeaponReqItems[i].Length];
                    WeaponReqAmountConfigs[i] = new ConfigEntry<int>[WeaponReqItems[i].Length];

                    for (int j = 0; j < WeaponReqItems[i].Length; j++)
                    {
                        int slot = j + 1;
                        string defaultItem = WeaponReqItems[i][j];
                        int defaultAmount = WeaponReqAmounts[i][j];

                        WeaponReqItemConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Item", defaultItem,
                            new ConfigDescription("Requirement " + slot + " for " + prefab + ". Prefab/item id consumed on craft (default: " + defaultItem + ").", null,
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        WeaponReqAmountConfigs[i][j] = Config.Bind(section, prefab + " - Requirement " + slot + " Amount", defaultAmount,
                            new ConfigDescription("Amount of Requirement " + slot + " required to craft " + prefab + " (default item: " + defaultItem + ").",
                            new AcceptableValueRange<int>(0, 9999),
                            new ConfigurationManagerAttributes { IsAdminOnly = true, Order = order-- }));

                        WeaponReqItemConfigs[i][j].SettingChanged += WeaponConfigChanged;
                        WeaponReqAmountConfigs[i][j].SettingChanged += WeaponConfigChanged;
                    }

                    WeaponEnabledConfigs[i].SettingChanged += WeaponConfigChanged;
                }
                
                // This fires once when configs sync from the server, so it catches everything in one go instead of relying on each config's own change event
                
                SynchronizationManager.OnConfigurationSynchronized += WeaponConfigChanged;
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding weapon/shield configuration values: {arg}");
            }
        }

        public void AddWeaponsAndShields()
        {
            try
            {
                for (int i = 0; i < WeaponPrefabList.Length; i++)
                {
                    string prefab = WeaponPrefabList[i];

                    if (!WeaponEnabledConfigs[i].Value)
                    {
                        if (LoggingEnable.Value) { Logger.LogMessage("Skipped (disabled in config): " + prefab); }
                        continue;
                    }

                    ItemConfig itemConfig = new ItemConfig();
                    itemConfig.CraftingStation = WeaponStationList[i];

                    for (int j = 0; j < WeaponReqItems[i].Length; j++)
                    {
                        string reqItem = WeaponReqItemConfigs[i][j].Value;
                        int amount = WeaponReqAmountConfigs[i][j].Value;
                        int amountPerLevel = WeaponReqLevels[i][j];
                        itemConfig.AddRequirement(new RequirementConfig(reqItem, amount, amountPerLevel, true));
                    }

                    ItemManager.Instance.AddItem(new CustomItem(this._myAssets, prefab, true, itemConfig));

                    if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefab + " to the Object database"); }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding weapons and shields: {arg}");
            }
        }

        // Fires on ANY weapon/shield config change - both local edits and Jotunn syncing the server's value into a client's config after connecting.
        private void WeaponConfigChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < WeaponPrefabList.Length; i++)
                {
                    string prefab = WeaponPrefabList[i];
                    Recipe recipe = ItemManager.Instance.GetItem(prefab)?.Recipe?.Recipe;

                    if (recipe == null)
                    {
                        // Item/recipe was never registered (most likely it was disabled at  Awake time, so AddWeaponsAndShields() skipped it). 
                        continue;
                    }

                    recipe.m_enabled = WeaponEnabledConfigs[i].Value;

                    if (recipe.m_resources == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < WeaponReqItems[i].Length && j < recipe.m_resources.Length; j++)
                    {
                        string reqItemName = WeaponReqItemConfigs[i][j].Value;

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
                        recipe.m_resources[j].m_amount = WeaponReqAmountConfigs[i][j].Value;
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while re-applying weapon/shield configs: {arg}");
            }
        }
    }
}