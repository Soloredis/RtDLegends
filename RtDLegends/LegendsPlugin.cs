using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
/*using HarmonyLib;*/

namespace RtDLegends
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Patch)]
    [BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInIncompatibility("blacks7ar.SeedBed")]
    [BepInIncompatibility("randyknapp.mods.epicloot")]
    [BepInIncompatibility("org.bepinex.plugins.valheim_plus")]
    /*[HarmonyPatch]*/
    
    internal partial class RtDLegends : BaseUnityPlugin
    {
        private const string ModGuid = "Soloredis.RtDLegends";
        private const string ModName = "RtDLegends";
        private const string ModVersion = "1.3.47";

        private AssetBundle _myAssets;

        /*private static Harmony _harmony; */

        private static readonly string[] DungeonPropList =
        [
            // Food_Crates
            "Prop_FoodBarrel1_BlackForest_RtD",
            "Prop_FoodBarrel1_RtD",
            "Prop_FoodBarrel2_BlackForest_RtD",
            "Prop_FoodBarrel2_RtD",
            "Prop_FoodCrate1_BlackForest_RtD",
            "Prop_FoodCrate1_RtD",

            // Props_Bones
            "Props_Skeleton__Full_Headless_RtD",
            "Props_Skeleton__Full_RtD",
            "Props_Skeleton__Full_Sitting_RtD",
            "Props_Skeleton_Clavicle_RtD",
            "Props_Skeleton_Femur_RtD",
            "Props_Skeleton_Fibula_RtD",
            "Props_Skeleton_Foot_RtD",
            "Props_Skeleton_Hand_RtD",
            "Props_Skeleton_Humerus_RtD",
            "Props_Skeleton_Pelvis_RtD",
            "Props_Skeleton_Radius_RtD",
            "Props_Skeleton_RibCage_RtD",
            "Props_Skeleton_Skull_RtD",
            "Props_Skeleton_Spine_RtD",
            "Props_Skeleton_Tibia_RtD",
            "Props_Skeleton_Ulna_RtD",

            // Props_Coffin
            "crypt_PlainsHorror01_chest",
            "crypt_PlainsHorror_chest",
            "Spawner_PlainsHorror01_rise",
            "Spawner_PlainsHorror_rise",
            "crypt_SwampHorror01_chest",
            "crypt_SwampHorror_chest",
            "Spawner_SwampChaser_rise",
            "Spawner_SwampHorror01_rise",
            "crypt_BlackForestHorror01_chest",
            "crypt_BlackForestHorror_chest",
            "Spawner_BlackForestHorror01_rise",
            "Spawner_BlackForestHorror_rise",

            // Props_Extras
            "AmphoraGroup00_RtD",
            "BookOld_00_RtD",
            "BookOld_01_RtD",
            "BookOld_02_RtD",
            "BookOld_03_RtD",
            "BookOld_04_RtD",
            "BookOld_05_RtD",
            "BookOld_06_RtD",
            "BookOld_07_RtD",
            "CobWebs_RtD",
            "HangingVines_RtD",

            // Props_Iron
            "ChainForged00_RtD",
            "ChainForged01_RtD",
            "ForgedDragon_00_RtD",
            "ForgedDragon_01_RtD",
            "ForgedDragon_02_RtD",
            "ForgedDragon_03_RtD",
            "GrilleDeco_00_RtD",
            "GrilleDeco_01_RtD",
            "GrilleDeco_02_RtD",
            "GrilleDeco_03_RtD",
            "Pole00_RtD",
            "Pole01_RtD",
            "Pole02_RtD",
            "Props_CageHanging_RtD",
            "Props_ChainHanging1_RtD",
            "Props_ChainHanging2_RtD",
            "Props_ChainHangingGround_RtD",
            "Props_ChainStraight_RtD",
            "VaneDeco_00_RtD",
            "VaneDeco_01_RtD",
            "VaneDeco_02_RtD",
            "VaneDeco_03_RtD",
            "VaneDeco_04_RtD",
            "VaneDeco_05_RtD",
            "VaneDeco_06_RtD",
            "VaneDeco_07_RtD",
            "WindRose00_RtD",
            "Exterior_DungeonLighting_RtD",

            // Props_Lighting
            "CandleHolder03_LGT_RtD",
            "Prefab_Brazier_01_on_RtD",
            "Prefab_Forged_torch_complete_01_on_RtD",
            "Prefab_Forged_torch_complete_02_off_RtD",
            "Prop_TempleBrazier_RtD",
            "TorchWall00_LGT_RtD",

            // Props_MineRocks
            "Prop_BlackForestGold_RtD",
            "Prop_MeadowsFlint_RtD",
            "Prop_MistlandsFelOre_RtD",
            "Prop_MountainOrichalcum_RtD",
            "Prop_PlainsBloodiron_RtD",
            "Prop_SwampMooniron_RtD",
            "Prop_ArcaneMine_RtD",
            "Prop_FlametalMine_RtD",

            // Props_Mushroom
            "Pickable_Mushroom_Blue1_RtD",
            "Pickable_Mushroom_Blue2_RtD",
            "Pickable_Mushroom_Blue3_RtD",
            "Pickable_Mushroom_Brown1_RtD",
            "Pickable_Mushroom_Brown2_RtD",
            "Pickable_Mushroom_Brown3_RtD",
            "Pickable_Mushroom_Green1_RtD",
            "Pickable_Mushroom_Green2_RtD",
            "Pickable_Mushroom_Green3_RtD",
            "Pickable_Mushroom_Green_C1_RtD",
            "Pickable_Mushroom_Green_C2_RtD",
            "Pickable_Mushroom_Green_C3_RtD",
            "Pickable_Mushroom_Ice1_RtD",
            "Pickable_Mushroom_Ice2_RtD",
            "Pickable_Mushroom_Ice3_RtD",
            "Pickable_Mushroom_Jade1_RTD",
            "Pickable_Mushroom_Jade2_RtD",
            "Pickable_Mushroom_Jade3_RtD",
            "Pickable_Mushroom_Jottun1_RtD",
            "Pickable_Mushroom_Jottun2_RtD",
            "Pickable_Mushroom_Jottun3_RtD",
            "Pickable_Mushroom_Red1_RtD",
            "Pickable_Mushroom_Red2_RtD",
            "Pickable_Mushroom_Red3_RtD",
            "Pickable_Mushroom_Smoke1_RtD",
            "Pickable_Mushroom_Smoke2_RtD",
            "Pickable_Mushroom_Smoke3_RtD",
            "Pickable_Mushroom_Yellow1_RtD",
            "Pickable_Mushroom_Yellow2_RtD",
            "Pickable_Mushroom_Yellow3_RtD",
            "Pickable_Crystal_RtD",
            "Pickable_BlackMetal_RtD",

            // Props_Roots
            "root1_RtD",
            "root2_RtD",
            "root3_RtD",
            "root4_RtD",
            "root5_RtD",

            // Props_Stone
            "BigBricksBlock00_RtD",
            "BigBricksBlock01_RtD",
            "RoofTileCeramic_Pannel00_RtD",
            "RoofTileCeramicOld00_RtD",
            "RoofTileCeramicOld01_RtD",
            "RoofTileCeramicOld02_RtD",
            "RoofTileCeramicOld03_RtD",
            "RoofTileCeramicOld04_RtD",
            "RoofTileCeramicOld05_RtD",
            "RoofTileCeramicOldLine00_RtD",
            "RoofTileCeramicOldLine01_RtD",
            "RoofTiledOld00_RtD",
            "RoofTiledOld01_RtD",
            "RoofTiledOld02_RtD",
            "RoofTiledOld03_RtD",
            "RoofTiledOld04_RtD",
            "RoofTiledOld05_RtD",
            "RoofTiledOld06_RtD",
            "RoofTiledOld07_RtD",
            "RoofTiledOld08_RtD",
            "RoofTiledOld09_RtD",
            "StoneArc00_RtD",
            "StoneArc01_RtD",
            "StoneArc02_RtD",
            "StoneArc04_RtD",
            "StoneArc04b_RtD",
            "StoneBlock00_RtD",
            "StoneBlock01_RtD",
            "StoneBlock02_RtD",
            "StoneBlock03_RtD",
            "StoneBlock04_RtD",
            "StoneBlock05_RtD",
            "StoneBlock06_RtD",
            "StoneBlock07_RtD",
            "StoneBlock08_RtD",
            "StoneBlock09_RtD",
            "StoneBlock10_RtD",
            "StoneBlock11_RtD",
            "StoneBlock12_RtD",
            "StoneBlock13_RtD",
            "StoneBlock14_RtD",
            "StoneBlock15_RtD",
            "StoneBlock16_RtD",
            "StoneBlockSupport00_RtD",

            // Props_Wood
            "BenchTrunk00_RtD",
            "ChairWooden00_RtD",
            "Prop_RubblePile1_RtD",
            "Prop_RubblePile2_RtD",
            "Prop_RubblePile3_RtD",
            "StairsWooden00_RtD",
            "StairsWooden00b_RtD",
            "StairsWooden00c_RtD",
            "Table00_RtD",
            "TableWooden00_RtD",
            "WindowFrameShade00_RtD",
            "WindowFrameShade01_RtD",
            "WindowFrameShade02_RtD",
            "WindowFrameShade03_RtD",
            "WindowFrameShade04_RtD",
            "WindowFrameShade05_RtD",
            "WindowFrameShade06_RtD",
            "WindowFrameShade07_RtD",
            "WindowFrameShade08_RtD",
            "WindowFrameShade09_RtD",
            "WoodPlanksBoard00b_RtD",
            "WoodPlanksBoard01b_RtD",
            "WoodPlatform00_RtD",
            "WoodPlatform00b_RtD",
            "WoodPlatform00c_RtD",
            "WoodPlatform01_RtD",
            "WoodPlatform01b_RtD",
            "WoodPlatform01c_RtD",
            "WoodShelving00_RtD",
            "WoodShelving00b_RtD",
            "WoodShelving01_RtD",
            "WoodShelving01b_RtD",
            "WoodShelving01c_RtD",
            "WoodWallBoard00_RtD",
            "WoodWallBoard00b_RtD",
            "WoodWallBoard01_RtD",
            "WoodWallBoard01b_RtD",
            "WoodWallBoard01c_RtD",
            "WoodWallBoard02_RtD",
            "WoodWallBoard02b_RtD",

            // Spawners
            "DG_Shrine_AshLands_RtD",
            "DG_Spawner_Assassin_RtD",
            "DG_Spawner_CursedKnight_RtD",
            "DG_Spawner_FallenCrusader_RtD",
            "DG_Shrine_BlackForest_RtD",
            "DG_Spawner_BlackForestHorror01_RtD",
            "DG_Spawner_BlackForestHorror_RtD",
            "DG_Shrine_DeepNorth_RtD",
            "DG_Spawner_Befouler_RtD",
            "DG_Spawner_Davil_RtD",
            "DG_Spawner_Executioner_RtD",
            "DG_Spawner_NorthernTroll_RtD",
            "DG_Shrine_Meadows_RtD",
            "DG_Spawner_MeadowsGolem_RtD",
            "DG_Spawner_MeadowsSnade_RtD",
            "DG_Shrine_Mistlands_RtD",
            "DG_Shrine_Mountain_RtD",
            "DG_Spawner_MistlandsSpider1_RtD",
            "DG_Spawner_MistlandsSpider2_RtD",
            "DG_Spawner_MistlandsSpider3_RtD",
            "DG_Spawner_MistlandsSpider4_RtD",
            "DG_Spawner_MountainHorror01_RtD",
            "DG_Spawner_MountainHorror_RtD",
            "DG_Spawner_MountainUndead_RtD",
            "DG_Spawner_MountainWatcher_RtD",
            "DG_Spawner_PlainsHorror01_RtD",
            "DG_Spawner_PlainsHorror_RtD",
            "DG_Spawner_PlainsSizzler_RtD",
            "DG_Shrine_Plains_RtD",
            "DG_Shrine_Swamp_RtD",
            "DG_Spawner_SwampHorror01_RtD",
            "DG_Spawner_SwampHorror_RtD",
            "DG_Spawner_SwampSludger01_RtD",
            "DG_Spawner_SwampSludger_RtD",
            
            // Props_Treasure_Chests
            "Chest_Wood_RtD",
            "Chest_Stone_RtD",
            "Chest_Steel_RtD",
            "Chest_Iron_RtD",
            "Chest_Gold_RtD",
            "Chest_Frometal_RtD",
            "Chest_Flametal_RtD",
            "Chest_Fel_RtD"
        ];
        
        public string[] SoundEffectListMonsters = new string[]
        {
            // Line break
            "sfx_undead_attack1_RtD",
            "sfx_undead_attack2_RtD",
            "sfx_undead_attack3_RtD",
            "sfx_undead_attack4_RtD",
            "sfx_undead_death_RtD",
            "sfx_undead_hit_RtD",
            "sfx_undead_idle1_RtD",
            "sfx_undead_idle2_RtD",
            "sfx_undead_idle3_RtD",
            "sfx_wraith_attack1_RtD",
            "sfx_wraith_attack2_RtD",
            "sfx_wraith_attack3_RtD",
            "sfx_wraith_attack4_RtD",
            "sfx_wraith_death_RtD",
            "sfx_wraith_hit_RtD",
            "sfx_wraith_idle1_RtD",
            "sfx_wraith_idle2_RtD",
            "sfx_wraith_idle3_RtD",
            "sfx_alerted_large_RtD",
            "sfx_lich_attack1_RtD",
            "sfx_lich_attack2_RtD",
            "sfx_lich_attack3_RtD",
            "sfx_lich_attack4_RtD",
            "sfx_lich_death_RtD",
            "sfx_lich_hit_RtD",
            "sfx_lich_idle1_RtD",
            "sfx_lich_idle2_RtD",
            "sfx_lich_idle3_RtD",
            "sfx_alerted_small_RtD",
            "sfx_demon_attack1_RtD",
            "sfx_demon_attack2_RtD",
            "sfx_demon_attack3_RtD",
            "sfx_demon_attack4_RtD",
            "sfx_demon_death_RtD",
            "sfx_demon_hit_RtD",
            "sfx_demon_idle1_RtD",
            "sfx_demon_idle2_RtD",
            "sfx_demon_idle3_RtD",
            "sfx_thor_attack1_RtD",
            "sfx_thor_attack2_RtD",
            "sfx_thor_attack3_RtD",
            "sfx_thor_attack4_RtD",
            "sfx_thor_death_RtD",
            "sfx_thor_hit_RtD",
            "sfx_thor_idle1_RtD",
            "sfx_thor_idle2_RtD",
            "sfx_thor_idle3_RtD",
            // Sound Effects
            "sfx_arcanemonster_RtD",
            "sfx_earthcastmonster_RtD",
            "sfx_firecastmonster_RtD",
            "sfx_icecastmonster_RtD",
            "sfx_lifecastmonster_RtD",
            "sfx_lightcastmonster_RtD",
            "sfx_lighteningcastmonster_RtD",
            "sfx_naturecasttmonster_RtD",
            "sfx_stormcastmonster_RtD",
            "sfx_voidcastmonster_RtD",
            "sfx_watercastmonster_RtD",
            "sfx_elfalerted_RtD",
            "sfx_ElfAttackF_RtD",
            "sfx_ElfAttackM_RtD",
            "sfx_ElfDeathF_RtD",
            "sfx_ElfDeathM_RtD",
            "sfx_ElfHitF_RtD",
            "sfx_ElfHitM_RtD",
            "sfx_elfidle_RtD",
            "sfx_fairy_alerted_RtD",
            "sfx_fairy_attack_RtD",
            "sfx_fairy_cast_RtD",
            "sfx_fairy_death_RtD",
            "sfx_fairy_idle_RtD",
            "sfx_spiderqueen_attack_RtD",
            "sfx_spiderqueen_death_RtD",
            "sfx_spiderqueen_hit_RtD",
            "sfx_spiderqueenranged_RtD",
            "sfx_meadowsboss_alerted_RtD",
            "sfx_meadowsboss_attack_RtD",
            "sfx_meadowsboss_death_RtD",
            "sfx_meadowsboss_hit_RtD",
            "sfx_meadowsboss_idle_RtD",
            "sfx_meadowsboss_ranged_RtD",
            "sfx_mountainboss_alerted_RtD",
            "sfx_mountainboss_attack_RtD",
            "sfx_mountainboss_death_RtD",
            "sfx_mountainboss_hit_RtD",
            "sfx_mountainboss_idle_RtD",
            "sfx_mountainboss_ranged_RtD",
            "sfx_plainsboss_alerted_RtD",
            "sfx_plainsboss_attack_RtD",
            "sfx_plainsboss_death_RtD",
            "sfx_plainsboss_hit_RtD",
            "sfx_plainsboss_idle_RtD",
            "sfx_plainsboss_ranged_RtD",
            "sfx_swampboss_death_RtD",
            "sfx_swampboss_alerted_RtD",
            "sfx_swampboss_idle_RtD",
            "sfx_troll_alerted_RtD",
            "sfx_troll_attack_hit_RtD",
            "sfx_troll_attacking_RtD",
            "sfx_troll_death_RtD",
            "sfx_troll_footstep_RtD",
            "sfx_troll_footstep_water_RtD",
            "sfx_troll_hit_RtD",
            "sfx_troll_idle_RtD",
            "sfx_chomper_alerted_RtD",
            "sfx_chomper_attack_RtD",
            "sfx_chomper_death_RtD",
            "sfx_chomper_hit_RtD",
            "sfx_chomper_idle_RtD",
            "sfx_chomper_ranged_RtD",
            "sfx_locmur_alerted_RtD",
            "sfx_locmur_attack_RtD",
            "sfx_locmur_death_RtD",
            "sfx_locmur_hit_RtD",
            "sfx_locmur_idle_RtD",
            "sfx_locmur_ranged_RtD",
            "sfx_summon_attack_RtD",
            "sfx_frozenundead_alerted_RtD",
            "sfx_frozenundead_attack_RtD",
            "sfx_frozenundead_death",
            "sfx_frozenundead_hit_RtD",
            "sfx_frozenundead_idle_RtD",
            "sfx_frozenundead_ranged_RtD",
            "sfx_sizzler_alerted_RtD",
            "sfx_sizzler_attack_RtD",
            "sfx_sizzler_death_RtD",
            "sfx_sizzler_hit_RtD",
            "sfx_sizzler_idle_RtD",
            "sfx_sizzler_ranged_RtD",
            "sfx_sludger_alerted_RtD",
            "sfx_sludger_attack_RtD",
            "sfx_sludger_death_RtD",
            "sfx_sludger_hit_RtD",
            "sfx_sludger_idle_RtD",
            "sfx_sludger_ranged_RtD",
            "sfx_snade_alerted_RtD",
            "sfx_snade_attack_RtD",
            "sfx_snade_death_RtD",
            "sfx_snade_hit_RtD",
            "sfx_snade_idle_RtD",
            "sfx_snade_ranged_RtD",
            "sfx_snade_RtD",
            "sfx_arachnid_alerted_RtD",
            "sfx_arachnid_attack_RtD",
            "sfx_arachnid_death",
            "sfx_arachnid_hit_RtD",
            "sfx_arachnid_idle_RtD",
            "sfx_arachnid_ranged_RtD",
            "sfx_watcher_alerted_RtD",
            "sfx_watcher_attack_RtD",
            "sfx_watcher_death_RtD",
            "sfx_watcher_hit_RtD",
            "sfx_watcher_idle_RtD",
            "sfx_watcher_ranged_RtD",
            "fx_footstep_jog_RtD",
            "fx_footstep_run_RtD",
            "fx_footstep_water_RtD",
            "sfx_offeringS_RtD",
            "sfx_golem_alerted_RtD",
            "sfx_golem_attack_RtD",
            "sfx_golem_death_RtD",
            "sfx_golem_hit_RtD",
            "sfx_golem_idle_RtD",
            "sfx_golem_ranged_RtD",
            "fx_Queen_Run_RtD",
            "fx_Queen_Walk_RtD",
            "sfx_queenalerted_RtD",
            "sfx_mutant3_attack_RtD1",
            "sfx_mutantranged3_RtD1",
            "sfx_swampboss_hit_RtD",
            "sfx_queenranged_RtD",
            "sfx_Goblin_Orc_death_Dragonide_RtD",
            "sfx_Goblin_Orc_Dragonide_alerted_RtD",
            "sfx_Goblin_Orc_Dragonide_attack_RtD",
            "sfx_Goblin_Orc_Dragonide_hit_RtD",
            "sfx_Goblin_Orc_Dragonide_idle_RtD",
            "sfx_spider_alerted_RtD",
            "sfx_spider_attack_RtD",
            "sfx_spider_death_RtD",
            "sfx_spider_hit_RtD",
            "sfx_spider_idle_RtD",
            "sfx_spider_ranged_RtD",
            "sfx_Harpy_Griffin_alerted_RtD",
            "sfx_Harpy_Griffin_attack_RtD",
            "sfx_Harpy_Griffin_death_RtD",
            "sfx_Harpy_Griffin_hit_RtD",
            "sfx_Harpy_Griffin_idle_RtD",
            "sfx_manticora_chimera_alerted_RtD",
            "sfx_manticora_chimera_attack_RtD",
            "sfx_manticora_chimera_death_RtD",
            "sfx_manticora_chimera_hit_RtD",
            "sfx_manticora_chimera_idle_RtD",
            "sfx_hydra_wyvern_alerted_RtD",
            "sfx_hydra_wyvern_attack_RtD",
            "sfx_hydra_wyvern_death_RtD",
            "sfx_hydra_wyvern_hit_RtD",
            "sfx_hydra_wyvern_idle_RtD",
            "sfx_rat_alerted_idle_RtD",
            "sfx_rat_attack_RtD",
            "sfx_rat_hit_death_RtD"
        };
        
        public static string[] DungeonDoorList =
        [
            /*"xxx",*/

        ];

        // Dungeon Meadows
        public static string[] DungeonEndcapMeadowsList =
        [
            "MeadowsEndCap_RtD"
        ];

        public static string[] DungeonSpacerMeadowsList =
        [
            /*"xxx",*/
        ];

        public static string[] DungeonCorridorMeadowsList =
        [
            "MeadowsCorridor1_RtD",
            "MeadowsCorridor2_RtD"
        ];

        public static string[] DungeonCornerMeadowsList =
        [
            "MeadowsCornerL_RtD",
            "MeadowsCornerR_RtD"
        ];

        public static string[] DungeonRoomMeadowsList =
        [
            "MeadowsRoom1_RtD",
            "MeadowsRoom2_RtD"
        ];

        public static string[] DungeonStairsMeadowsList =
        [
            /*"MeadowsStairs_RtD"*/
        ];

        // Dungeon BlackForest
        public static string[] DungeonEndcapBlackForestList =
        [
            "BlackForestEndCap_RtD"
        ];

        public static string[] DungeonSpacerBlackForestList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorBlackForestList =
        [
            "BlackForestCorridor1_RtD",
            "BlackForestCorridor2_RtD",
            "BlackForestStairsHall_RtD"
        ];

        public static string[] DungeonCornerBlackForestList =
        [
            "BlackForestCornerL_RtD",
            "BlackForestCornerR_RtD"
        ];

        public static string[] DungeonRoomBlackForestList =
        [
            "BlackForestRoom1_RtD",
            "BlackForestRoom2_RtD",
        ];

        public static string[] DungeonStairsBlackForestList =
        [
            "BlackForestStairsL_RtD",
            "BlackForestStairsR_RtD"
        ];

        // Dungeon Swamp
        public static string[] DungeonEndcapSwampList =
        [
            "SwampEndCap_RtD"
        ];

        public static string[] DungeonSpacerSwampList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorSwampList =
        [
            "SwampCorridor1_RtD",
            "SwampCorridor2_RtD"
        ];

        public static string[] DungeonCornerSwampList =
        [
            "SwampCornerL_RtD",
            "SwampCornerR_RtD"
        ];

        public static string[] DungeonRoomSwampList =
        [
            "SwampRoom1_RtD",
            "SwampRoom2_RtD"
        ];

        public static string[] DungeonStairsSwampList =
        [
            "SwampStairsL_RtD",
            "SwampStairsR_RtD",
            
        ];

        // Dungeon Mountain
        public static string[] DungeonEndcapMountainList =
        [
            "MountainEndCap_RtD"
        ];

        public static string[] DungeonSpacerMountainList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorMountainList =
        [
            "MountainCorridor1_RtD",
            "MountainCorridor2_RtD"
        ];

        public static string[] DungeonCornerMountainList =
        [
            "MountainCornerL_RtD",
            "MountainCornerR_RtD"
        ];

        public static string[] DungeonRoomMountainList =
        [
            "MountainRoom1_RtD",
            "MountainRoom2_RtD"
        ];

        public static string[] DungeonStairsMountainList =
        [
            "MountainStairsL_RtD",
            "MountainStairsR_RtD",
            "MountainHallStairs_RtD"
        ];

        // Dungeon Plains
        public static string[] DungeonEndcapPlainsList =
        [
            "PlainsEndCap_RtD"
        ];

        public static string[] DungeonSpacerPlainsList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorPlainsList =
        [
            "PlainsCorridor1_RtD",
            "PlainsCorridor2_RtD"
        ];

        public static string[] DungeonCornerPlainsList =
        [
            "PlainsCornerL_RtD",
            "PlainsCornerR_RtD"
        ];

        public static string[] DungeonRoomPlainsList =
        [
            "PlainsRoom1_RtD",
            "PlainsRoom2_RtD"
        ];

        public static string[] DungeonStairsPlainsList =
        [
            "PlainsStairsL_RtD",
            "PlainsStairsR_RtD"
        ];

        // Dungeon Mistlands
        public static string[] DungeonEndcapMistlandsList =
        [
            "MistlandsEndCap_RtD"
        ];

        public static string[] DungeonSpacerMistlandsList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorMistlandsList =
        [
            "MistlandsCorridor1_RtD",
            "MistlandsCorridor2_RtD"
        ];

        public static string[] DungeonCornerMistlandsList =
        [
            "MistlandsCornerL_RtD",
            "MistlandsCornerR_RtD"
        ];

        public static string[] DungeonRoomMistlandsList =
        [
            "MistlandsRoom1_RtD",
            "MistlandsRoom2_RtD"
        ];

        public static string[] DungeonStairsMistlandsList =
        [
            "MistlandsStairsL_RtD",
            "MistlandsStairsR_RtD"
        ];

        // Dungeon AshLands
        public static string[] DungeonEndcapAshLandsList =
        [
            "AshLandsEndCap_RtD"
        ];

        public static string[] DungeonSpacerAshLandsList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorAshLandsList =
        [
            "AshLandsCorridor1_RtD",
            "AshLandsCorridor2_RtD",
            "AshLandsStairsHall_RtD"
        ];

        public static string[] DungeonCornerAshLandsList =
        [
            "AshLandsCornerL_RtD",
            "AshLandsCornerR_RtD"
        ];

        public static string[] DungeonRoomAshLandsList =
        [
            "AshLandsRoom1_RtD",
            "AshLandsRoom2_RtD"
        ];

        public static string[] DungeonStairsAshLandsList =
        [
            "AshLandsStairsL_RtD",
            "AshLandsStairsR_RtD",
            "AshLandsStairs1_RtD"
        ];

        // Dungeon DeepNorth
        public static string[] DungeonEndcapDeepNorthList =
        [
            "DeepNorthEndCap_RtD"
        ];

        public static string[] DungeonSpacerDeepNorthList =
        [
            /* "xxx",*/
        ];

        public static string[] DungeonCorridorDeepNorthList =
        [
            "DeepNorthCorridor1_RtD",
            "DeepNorthCorridor2_RtD"
        ];

        public static string[] DungeonCornerDeepNorthList =
        [
            "DeepNorthCornerL_RtD",
            "DeepNorthCornerR_RtD"
        ];

        public static string[] DungeonRoomDeepNorthList =
        [
            "DeepNorthRoom1_RtD",
            "DeepNorthRoom2_RtD"
        ];

        public static string[] DungeonStairsDeepNorthList =
        [
            "DeepNorthStairs1_RtD"
        ];

        // Dungeon Themes
        private static readonly string ThemeMeadowsDungeon = "MeadowsDungeonTheme_RtD";
        private static readonly string ThemeBlackForestDungeon = "BlackForestDungeonTheme_RtD";
        private static readonly string ThemeSwampDungeon = "SwampDungeonTheme_RtD";
        private static readonly string ThemeMountainDungeon = "MountainDungeonTheme_RtD";
        private static readonly string ThemePlainsDungeon = "PlainsDungeonTheme_RtD";
        private static readonly string ThemeMistlandsDungeon = "MistlandsDungeonTheme_RtD";
        private static readonly string ThemeAshLandsDungeon = "AshLandsDungeonTheme_RtD";
        private static readonly string ThemeDeepNorthDungeon = "DeepNorthDungeonTheme_RtD";

        // Dungeon Location Configs
        private static readonly LocationConfig MeadowsDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Meadows,
            BiomeArea = Heightmap.BiomeArea.Everything,
            ForestTresholdMin = 0,
            Quantity = 50,
            MinDistance = 128,
            MinDistanceFromSimilar = 100,
            Priotized = true,
            MinAltitude = 10f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig BlackForestDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.BlackForest,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 128,
            Quantity = 140,
            Priotized = true,
            MinAltitude = 10f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig SwampDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Swamp,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 128,
            Quantity = 115,
            Priotized = true,
            MinAltitude = 1f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig MountainDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Mountain,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 56,
            Quantity = 90,
            Priotized = true,
            MinAltitude = 65f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig PlainsDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Plains,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 128,
            Quantity = 110,
            Priotized = true,
            MinAltitude = 10f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig MistlandsDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Mistlands,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 70,
            Quantity = 115,
            Priotized = true,
            MinAltitude = 5f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig AshLandsDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.AshLands,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 128,
            Quantity = 110,
            Priotized = true,
            MinAltitude = 10f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        private static readonly LocationConfig DeepNorthDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.DeepNorth,
            BiomeArea = Heightmap.BiomeArea.Everything,
            MinDistanceFromSimilar = 95,
            Quantity = 110,
            Priotized = true,
            MinAltitude = 1f,
            ClearArea = true,
            ExteriorRadius = 15
        };

        // Dungeon Room Configs
        // Meadows
        private static readonly RoomConfig EntranceMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerMeadowsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMeadowsDungeon,
            Weight = 1f
        };

        // BlackForest
        private static readonly RoomConfig EntranceBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerBlackForestConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeBlackForestDungeon,
            Weight = 1f
        };

        // Swamp
        private static readonly RoomConfig EntranceSwampConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapSwampConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorSwampConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerSwampConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsSwampConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomSwampConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomSwampConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerSwampConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeSwampDungeon,
            Weight = 1f
        };

        // Mountain
        private static readonly RoomConfig EntranceMountainConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapMountainConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorMountainConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerMountainConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsMountainConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomMountainConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomMountainConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerMountainConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMountainDungeon,
            Weight = 1f
        };

        // Plains
        private static readonly RoomConfig EntrancePlainsConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapPlainsConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorPlainsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerPlainsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsPlainsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomPlainsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomPlainsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerPlainsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemePlainsDungeon,
            Weight = 1f
        };

        // Mistlands
        private static readonly RoomConfig EntranceMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerMistlandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeMistlandsDungeon,
            Weight = 1f
        };

        // AshLands
        private static readonly RoomConfig EntranceAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerAshLandsConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeAshLandsDungeon,
            Weight = 1f
        };

        // DeepNorth
        private static readonly RoomConfig EntranceDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig EndcapDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            Endcap = true,
            EndcapPrio = 0,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CorridorDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig CornerDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig StairsDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };

        /*private static RoomConfig _stairRoomDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 2,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };*/

        private static readonly RoomConfig RoomDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 1,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1f
        };

        private static readonly RoomConfig SpacerDeepNorthConfig = new RoomConfig
        {
            Enabled = true,
            MinPlaceOrder = 0,
            ThemeName = ThemeDeepNorthDungeon,
            Weight = 1
        };

        /*        // Template
                static RoomConfig templateConfig = new RoomConfig
                {
                    Divider = false,
                    Enabled = true,
                    Endcap = false,
                    EndcapPrio = 0,
                    Entrance = false,
                    FaceCenter = false,
                    MinPlaceOrder = 0,
                    ThemeName = themeMeadowsDungeon,
                    Weight = 1f
                };*/
        
        private void Awake()
        {
            LoadBundle();
            CreateConfigs();
            Addlocalizations();
            JSONSupport();
            AddSoundEffects();
            AddPrefabsMonstrum();
            AddPrefabs();
            Locations();
            AddItemsMonsters();
            AddItemsMonstrum();
            ItemConversions();
            AddShieldEffect(); 
            StatusEffects();
            CreateRecipes();
            Bosses();
            RegisterMonsters();
            MeadowsSpawner();
            BlackForestSpawner();
            SwampSpawner();
            MountainSpawner();
            PlainsSpawner();
            MistlandsSpawner();
            AshLandsSpawners();
            DeepNorthSpawners();
            Altars();
            AddSEStatusEffect();
            
            // Adjust Vanilla Dungeons
            
            ZoneManager.OnVanillaLocationsAvailable += AdjustVanillaDungeons;
            
            // On prefabs awake
            
            PrefabManager.OnVanillaPrefabsAvailable += AddTempleDungeonProps;
            PrefabManager.OnVanillaPrefabsAvailable += ModifyItems;

            // Locations, vegetation, dungeon altars
            ZoneManager.OnVanillaLocationsAvailable += OnVanillaLocationsAvailable;
            ZoneManager.OnVanillaLocationsAvailable += OnVanillaLocationsAvailableMonstrum;

            // Dungeon rooms
            DungeonManager.OnVanillaRoomsAvailable += OnVanillaRoomsAvailable;
            DungeonManager.OnVanillaRoomsAvailable += OnVanillaRoomsAvailableMonstrum;
            
            // Volume Mixer
            
            PrefabManager.OnPrefabsRegistered += FixSFX;

            if (LoggingEnable.Value) { Logger.LogWarning("Logging is enabled in the config."); }
        }
        
        private void LoadBundle()
        {
            try
            {
                _myAssets = AssetUtils.LoadAssetBundleFromResources("rtdlegends", Assembly.GetExecutingAssembly());
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while loading bundles: {arg}");
            }
        }
        
        private void CreateConfigs()
        {
            try
            {
                Config.SaveOnConfigSet = true;

                LoggingEnable = Config.Bind("Logging", "Enable", false, new ConfigDescription("Enable or Disable Logging.", null, new ConfigurationManagerAttributes
                {
                    IsAdminOnly = true,
                    Order = 15
                }));

                // Weapons and Shields - one Enabled toggle + per-requirement cost overrides
                // for every weapon/shield itemscript object, see RtDWeaponShieldConfigs.cs
                CreateWeaponAndShieldConfigs();

                // Armor - same treatment for every armor/cape itemscript object,
                // see RtDArmorConfigs.cs
                CreateArmorConfigs();
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
        }
        
        public void AddSoundEffects()
        {
            try
            {
                foreach (string prefabNameI1 in SoundEffectListMonsters)
                {
                    GameObject prefabI1 = _myAssets.LoadAsset<GameObject>(prefabNameI1);
                    if (prefabI1 != null)
                    {
                        CustomPrefab customPrefab4 = new CustomPrefab(prefabI1, true);
                        PrefabManager.Instance.AddPrefab(customPrefab4);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabNameI1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabNameI1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
        
        private void AddTempleDungeonProps()
        {
            try
            {
                // Props
                foreach (string prefabName in DungeonPropList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab)
                    {
                        CustomPrefab customPrefab = new(prefab, true);
                        PrefabManager.Instance.AddPrefab(customPrefab);
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the Prefab database");
                    }
                }

                // Doors
                foreach (string prefabName in DungeonDoorList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab)
                    {
                        CustomPrefab customPrefab = new CustomPrefab(prefab, true);
                        PrefabManager.Instance.AddPrefab(customPrefab);
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the Prefab database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding Pieces: {arg}");
            }
            finally
            {
                PrefabManager.OnVanillaPrefabsAvailable -= AddTempleDungeonProps;
            }
        }

/*        private void OnVanillaPrefabsAvailable()
        {
            try
            {
                DungeonManager.Instance.RegisterEnvironment(MyAssets, "_EnvSetup_RtDLegends");
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding environments: {arg}");
            }
        }*/

        private void OnVanillaLocationsAvailable()
        {
            try
            {
                // Loading a new custom location as a dungeon entrance
                var meadowsLocationPrefab = _myAssets.LoadAsset<GameObject>("Meadows_DG_RtD");
                if (meadowsLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(meadowsLocationPrefab, ThemeMeadowsDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(meadowsLocationPrefab, true, MeadowsDungeonLocConfig));
                }

                var blackForestLocationPrefab = _myAssets.LoadAsset<GameObject>("BlackForest_DG_RtD");
                if (blackForestLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(blackForestLocationPrefab, ThemeBlackForestDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(blackForestLocationPrefab, true, BlackForestDungeonLocConfig));
                }

                var swampLocationPrefab = _myAssets.LoadAsset<GameObject>("Swamp_DG_RtD");
                if (swampLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(swampLocationPrefab, ThemeSwampDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(swampLocationPrefab, true, SwampDungeonLocConfig));
                }

                var mountainLocationPrefab = _myAssets.LoadAsset<GameObject>("Mountain_DG_RtD");
                if (mountainLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(mountainLocationPrefab, ThemeMountainDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(mountainLocationPrefab, true, MountainDungeonLocConfig));
                }

                var plainsLocationPrefab = _myAssets.LoadAsset<GameObject>("Plains_DG_RtD");
                if (plainsLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(plainsLocationPrefab, ThemePlainsDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(plainsLocationPrefab, true, PlainsDungeonLocConfig));
                }

                var mistlandsLocationPrefab = _myAssets.LoadAsset<GameObject>("Mistlands_DG_RtD");
                if (mistlandsLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(mistlandsLocationPrefab, ThemeMistlandsDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(mistlandsLocationPrefab, true, MistlandsDungeonLocConfig));
                }

                var ashLandsLocationPrefab = _myAssets.LoadAsset<GameObject>("AshLands_DG_RtD");
                if (ashLandsLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(ashLandsLocationPrefab, ThemeAshLandsDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(ashLandsLocationPrefab, true, AshLandsDungeonLocConfig));
                }

                var deepNorthLocationPrefab = _myAssets.LoadAsset<GameObject>("DeepNorth_DG_RtD");
                if (deepNorthLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(deepNorthLocationPrefab, ThemeDeepNorthDungeon);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(deepNorthLocationPrefab, true, DeepNorthDungeonLocConfig));
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon locations: {arg}");
            }
            finally
            {
                ZoneManager.OnVanillaLocationsAvailable -= OnVanillaLocationsAvailable;
            }
        }
        
        private void FixSFX()
        {
            try
            {
                AudioSource mixerGroupSFX = PrefabManager.Cache.GetPrefab<AudioSource>("sfx_arrow_hit");

                foreach (string prefabName in SoundEffectListMonsters)
                {
                    GameObject prefab = PrefabManager.Cache.GetPrefab<GameObject>(prefabName);
                    prefab.GetComponentInChildren<AudioSource>().outputAudioMixerGroup = mixerGroupSFX.outputAudioMixerGroup;

                    if (LoggingEnable.Value) { Logger.LogMessage("Audio Mixer set on: " + prefabName); }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while fixing custom audio: {arg}");
            }
            finally
            {
                PrefabManager.OnPrefabsRegistered -= FixSFX;
            }
        }

        private void OnVanillaRoomsAvailable()
        {
            try
            {
                // Entrance
                GameObject prefabMeadowsEntrance = _myAssets.LoadAsset<GameObject>("MeadowsEntrance_RtD");
                if (prefabMeadowsEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabMeadowsEntrance, true, EntranceMeadowsConfig));
                }
                GameObject prefabBlackForestEntrance = _myAssets.LoadAsset<GameObject>("BlackForestEntrance_RtD");
                if (prefabBlackForestEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabBlackForestEntrance, true, EntranceBlackForestConfig));
                }
                GameObject prefabSwampEntrance = _myAssets.LoadAsset<GameObject>("SwampEntrance_RtD");
                if (prefabSwampEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabSwampEntrance, true, EntranceSwampConfig));
                }
                GameObject prefabMountainEntrance = _myAssets.LoadAsset<GameObject>("MountainEntrance_RtD");
                if (prefabMountainEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabMountainEntrance, true, EntranceMountainConfig));
                }
                GameObject prefabPlainsEntrance = _myAssets.LoadAsset<GameObject>("PlainsEntrance_RtD");
                if (prefabPlainsEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabPlainsEntrance, true, EntrancePlainsConfig));
                }
                GameObject prefabMistlandsEntrance = _myAssets.LoadAsset<GameObject>("MistlandsEntrance_RtD");
                if (prefabMistlandsEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabMistlandsEntrance, true, EntranceMistlandsConfig));
                }
                GameObject prefabAshLandsEntrance = _myAssets.LoadAsset<GameObject>("AshLandsEntrance_RtD");
                if (prefabAshLandsEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabAshLandsEntrance, true, EntranceAshLandsConfig));
                }
                GameObject prefabDeepNorthEntrance = _myAssets.LoadAsset<GameObject>("DeepNorthEntrance_RtD");
                if (prefabDeepNorthEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabDeepNorthEntrance, true, EntranceDeepNorthConfig));
                }
                AddMeadowsDungeonCorridors();
                AddMeadowsDungeonStairs();
                AddMeadowsDungeonCorners();
                AddMeadowsDungeonRooms();
                AddMeadowsDungeonEncaps();
                AddMeadowsDungeonSpacer();

                AddBlackForestDungeonCorridors();
                AddBlackForestDungeonStairs();
                AddBlackForestDungeonCorners();
                AddBlackForestDungeonRooms();
                AddBlackForestDungeonEncaps();
                AddBlackForestDungeonSpacer();

                AddSwampDungeonCorridors();
                AddSwampDungeonStairs();
                AddSwampDungeonCorners();
                AddSwampDungeonRooms();
                AddSwampDungeonEncaps();
                AddSwampDungeonSpacer();

                AddMountainDungeonCorridors();
                AddMountainDungeonStairs();
                AddMountainDungeonCorners();
                AddMountainDungeonRooms();
                AddMountainDungeonEncaps();
                AddMountainDungeonSpacer();

                AddPlainsDungeonCorridors();
                AddPlainsDungeonStairs();
                AddPlainsDungeonCorners();
                AddPlainsDungeonRooms();
                AddPlainsDungeonEncaps();
                AddPlainsDungeonSpacer();

                AddMistlandsDungeonCorridors();
                AddMistlandsDungeonStairs();
                AddMistlandsDungeonCorners();
                AddMistlandsDungeonRooms();
                AddMistlandsDungeonEncaps();
                AddMistlandsDungeonSpacer();

                AddAshLandsDungeonCorridors();
                AddAshLandsDungeonStairs();
                AddAshLandsDungeonCorners();
                AddAshLandsDungeonRooms();
                AddAshLandsDungeonEncaps();
                AddAshLandsDungeonSpacer();

                AddDeepNorthDungeonCorridors();
                AddDeepNorthDungeonStairs();
                AddDeepNorthDungeonCorners();
                AddDeepNorthDungeonRooms();
                AddDeepNorthDungeonEncaps();
                AddDeepNorthDungeonSpacer();
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while fixing custom audio: {arg}");
            }
            {
                DungeonManager.OnVanillaRoomsAvailable -= OnVanillaRoomsAvailable;
            }
        }
        
        // Dungeon balances 
        
        private void AdjustVanillaDungeons()
        {
            try
            {
                var Crypt1 = ZoneManager.Instance.GetZoneLocation("Crypt2");
                Crypt1.m_quantity = 140;
                
                var Crypt2 = ZoneManager.Instance.GetZoneLocation("Crypt3");
                Crypt2.m_quantity = 140;
                
                var Crypt3 = ZoneManager.Instance.GetZoneLocation("Crypt4");
                Crypt3.m_quantity = 125;
                
                var Crypt4 = ZoneManager.Instance.GetZoneLocation("SunkenCrypt4");
                Crypt4.m_quantity = 155;
                
                var Crypt5 = ZoneManager.Instance.GetZoneLocation("Mistlands_DvergrTownEntrance1");
                Crypt5.m_quantity = 100;
                
                var Crypt6 = ZoneManager.Instance.GetZoneLocation("Mistlands_DvergrTownEntrance2");
                Crypt6.m_quantity = 100;
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding configuration values: {arg}");
            }
            finally
            {
                ZoneManager.OnVanillaLocationsAvailable -= AdjustVanillaDungeons;
            }
        }

        // Meadows

        private void AddMeadowsDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorMeadowsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorMeadowsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMeadowsDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsMeadowsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsMeadowsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMeadowsDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerMeadowsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerMeadowsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMeadowsDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomMeadowsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomMeadowsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMeadowsDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapMeadowsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapMeadowsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMeadowsDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerMeadowsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerMeadowsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // BlackForest

        private void AddBlackForestDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorBlackForestList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorBlackForestConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddBlackForestDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsBlackForestList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsBlackForestConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddBlackForestDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerBlackForestList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerBlackForestConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddBlackForestDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomBlackForestList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomBlackForestConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddBlackForestDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapBlackForestList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapBlackForestConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddBlackForestDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerBlackForestList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerBlackForestConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // Swamp

        private void AddSwampDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorSwampList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorSwampConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddSwampDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsSwampList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsSwampConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddSwampDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerSwampList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerSwampConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddSwampDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomSwampList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomSwampConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddSwampDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapSwampList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapSwampConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddSwampDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerSwampList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerSwampConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // Mountain

        private void AddMountainDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorMountainList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorMountainConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMountainDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsMountainList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsMountainConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMountainDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerMountainList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerMountainConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMountainDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomMountainList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomMountainConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMountainDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapMountainList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapMountainConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMountainDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerMountainList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerMountainConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // Plains

        private void AddPlainsDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorPlainsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorPlainsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddPlainsDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsPlainsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsPlainsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddPlainsDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerPlainsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerPlainsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddPlainsDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomPlainsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomPlainsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddPlainsDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapPlainsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapPlainsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddPlainsDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerPlainsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerPlainsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // Mistlands

        private void AddMistlandsDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorMistlandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorMistlandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMistlandsDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsMistlandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsMistlandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMistlandsDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerMistlandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerMistlandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMistlandsDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomMistlandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomMistlandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMistlandsDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapMistlandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapMistlandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddMistlandsDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerMistlandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerMistlandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // AshLands

        private void AddAshLandsDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorAshLandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorAshLandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddAshLandsDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsAshLandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsAshLandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddAshLandsDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerAshLandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerAshLandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddAshLandsDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomAshLandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomAshLandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddAshLandsDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapAshLandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapAshLandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddAshLandsDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerAshLandsList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerAshLandsConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        // DeepNorth

        private void AddDeepNorthDungeonCorridors()
        {
            try
            {
                // Corridors
                foreach (string prefabName in DungeonCorridorDeepNorthList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CorridorDeepNorthConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddDeepNorthDungeonStairs()
        {
            try
            {
                // Stairs
                foreach (string prefabName in DungeonStairsDeepNorthList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, StairsDeepNorthConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddDeepNorthDungeonCorners()
        {
            try
            {
                // Corners
                foreach (string prefabName in DungeonCornerDeepNorthList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, CornerDeepNorthConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddDeepNorthDungeonRooms()
        {
            try
            {
                // Rooms
                foreach (string prefabName in DungeonRoomDeepNorthList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, RoomDeepNorthConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddDeepNorthDungeonEncaps()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonEndcapDeepNorthList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, EndcapDeepNorthConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }

        private void AddDeepNorthDungeonSpacer()
        {
            try
            {
                // Endcaps
                foreach (string prefabName in DungeonSpacerDeepNorthList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefab, true, SpacerDeepNorthConfig));
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon corridor rooms: {arg}");
            }
        }
    }
}