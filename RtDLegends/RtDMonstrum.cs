using System;
using BepInEx;
using Jotunn.Managers;
using Jotunn.Entities;
using UnityEngine;
using Jotunn.Configs;

namespace RtDLegends                        
{
    internal partial class RtDLegends : BaseUnityPlugin   
    {
        // Prefab Lists
        public string[] PrefabListMonstrum = new string[]
        {
            "ashlandsmutantprojectile_RtD",
            "plainsmutantprojectile_RtD1",
            "blackforestmutantprojectile_RtD",
            "deepnorthmutantprojectile_RtD",
            "meadowsmutantprojectile_RtD",
            "mistlandsmutantprojectile_RtD",
            "mountainmutantprojectile2_RtD",
            "mountainmutantprojectile3_RtD",
            "mountainmutantprojectile_RtD",
            "plainsmutantprojectile_RtD",
            "sizzleprojectile_RtD",
            "spawn_earthstorm_RtD",
            "spawn_earthstormA_RtD",
            "spawn_firestorm_RtD",
            "spawn_icestorm2_RtD",
            "spawn_icestorm_RtD",
            "spawn_meteorstorm_RtD",
            "spawn_sizzlerstorm_RtD",
            "spawn_spikeballstorm_RtD",
            "spawn_voidstorm_RtD",
            "swampmutantprojectile2_RtD",
            "swampmutantprojectile_RtD",
            "webeggprojectile_RtD",
            "vfx_stonegolem_hurt_RtD",
            "vfx_stonegolem_death_RtD",
            "AirBlast_RtD",
            "ArcaneBlast_RtD",
            "EarthBlast_RtD",
            "EarthBlastA_RtD",
            "EarthCurse_RtD",
            "ElectricBlast_RtD",
            "FireBlast_RtD",
            "FrostBlast_RtD",
            "HealingBlast_RtD",
            "HolyBlast_RtD",
            "LighteningCurse_RtD",
            "StormCurse_RtD",
            "VoidCurse_RtD",
            "WaterBlast_RtD",
            "AirSpray_RtD",
            "ArcaneSpray_RtD",
            "EarthSpray_Rtd",
            "ElectricSpray_RtD",
            "FireSpray_RtD",
            "FireSprayAOE_RtD",
            "FrostSpray2_RtD",
            "HealingSpray_RtD",
            "HolySpray_RtD",
            "VoidSpray_RtD",
            "WaterSpray_RtD",
            "AirRainAOE1_RtD",
            "ArcaneRain1_RtD",
            "EarthPillarM_RtD",
            "EarthRainAOE2_RtD",
            "EarthRainAOE1_RtD",
            "ElectricRainAOE1_RtD",
            "FirePillarMAOE1_RtD",
            "FireRainAOE2_RtD",
            "FireRainAOE1_RtD",
            "FrostRainAOE2_RtD",
            "FrostRainAOE3_RtD",
            "FrostRainAOE1_RtD",
            "HealingRainAOE1_RtD",
            "HolyRainAOE1_RtD",
            "IcePillarM1_RtD",
            "LighteningPillarB_RtD",
            "VoidRainAOE2_RtD",
            "VoidRainAOE1_RtD",
            "WaterRainAOE1_RtD",
            "Ragdoll_MistlandsSpider1_RtD",
            "Ragdoll_PlainsChomper1_RtD",
            "Ragdoll_EikthyrSpirit_RtD",
            "Ragdoll_BlackForestGolem_RtD",
            "Ragdoll_MountainBoss_RtD",
            "Ragdoll_PlainsBoss_RtD",
            "Ragdoll_SpiderQueen_RtD",
            "Ragdoll_TrollKing_RtD",
            "Ragdoll_SwampBoss_RtD",
            "MistlandsMeleeC1_RtD",
            "MistlandsMeleeC2_RtD",
            "PlainsMeleeC1_RtD",
            "PlainsMeleeC2_RtD",
            "PlainsMeleeC3_RtD",
            "BlackForestGolemMelee1_RtD",
            "BlackForestGolemMelee2_RtD",
            "BlackForestGolemSpell_RtD",
            "BlackForestGolemSummon_RtD",
            "EikthyrSpiritAttack1_RtD",
            "EikthyrSpiritAttack2_RtD",
            "EikthyrSpiritAttack3_RtD",
            "EikthyrSpiritAttack4_RtD",
            "EikthyrSpiritSpell_RtD",
            "EikthyrSpiritSummon_RtD",
            "MountainBossAttack1_RtD",
            "MountainBossAttack2_RtD",
            "MountainBossAttack3_RtD",
            "MountainBossAttack4_RtD",
            "MountainBossSpell_RtD",
            "MountainBossSummon_RtD",
            "PlainsBossMelee1_RtD",
            "PlainsBossMelee2_RtD",
            "PlainsBossMelee3_RtD",
            "PlainsBossSpell1_RtD",
            "PlainsBossSpell2_RtD",
            "PlainsBossSummon_RtD",
            "SpiderQueenMelee1_RtD",
            "SpiderQueenMelee2_RtD",
            "SpiderQueenMelee3_RtD",
            "SpiderQueenMelee4_RtD",
            "SpiderQueenMelee5_RtD",
            "SpiderQueenMelee6_RtD",
            "SpiderQueenSpell_RtD",
            "SpiderQueenSummon_RtD",
            "SwampBossMelee1_RtD",
            "SwampBossMelee2_RtD",
            "SwampBossMelee3_RtD",
            "SwampBossMelee4_RtD",
            "SwampBossSpell_RtD",
            "SwampBossSummon_RtD",
            "LighteningExplosionLarge_RtD",
            "troll_groundslam_aoe_RtD",
            "troll_melee1_RtD",
            "troll_melee2_RtD",
            "troll_melee3_RtD",
            "troll_melee4_RtD",
            "troll_spell_RtD",
            "troll_summon_RtD",
            "trollkingprojectile1_RtD",
            "trollkingprojectile2_RtD",
            "trollstorm_RtD",
            "ArcaneExplosionSmall1_RtD",
            "EarthExplosionLarge1_RtD",
            "EarthExplosionSmall1_RtD",
            "EggExplosion_RtD",
            "FireExplosionSmall1_RtD",
            "FrostExplosionLarge1_RtD",
            "FrostExplosionSmall1_RtD",
            "LightningExplosionSmall1_RtD",
            "SpikyExplosionSmall1_RtD",
            "StormExplosionSmall1_RtD",
            "vfx_bloodsplat_death_RtD",
            "vfx_bloodsplat_hit_RtD",
            "VFX_IceSpray_RtD",
            "VoidExplosionSmall1_RtD",
            "FX_Armor_RtD",
            "FX_Frosted_RtD",
            "FX_Shocked_RtD",
            "FX_Weakened_RtD",
            "vfx_troll_attack_hit_RtD",
            "vfx_troll_death_RtD",
            "vfx_troll_footstep_RtD",
            "vfx_troll_footstep_water_RtD",
            "vfx_troll_groundslam_RtD",
            "vfx_troll_log_hitground_RtD",
            "vfx_troll_rock_destroyed_RtD",
            "vfx_offeringS_RtD",
            "Spawner_PlainsChomper1_RtD",
            "Spawner_BlackForestGolem_RtD",
            "Spawner_MistlandsSpider1_RtD",
            // 
            "VegvisirBlackForest_Altar_RtD",
            "VegvisirMeadows_Altar_RtD",
            "VegvisirMistlands_Altar_RtD",
            "VegvisirMountain_Altar_RtD",
            "VegvisirPlains_Altar_RtD",
            "VegvisirSwamp_Altar_RtD",
            "MistlandsAltar_Interior_RtD",
            "MountainAltar_Interior_RtD",
            "BlackForestMeleeTE1_RtD",
            "BlackForestMeleeTE2_RtD",
            "BlackForestMeleeTE3_RtD",
            "Ragdoll_TreeEnt_RtD",
            "Spawner_TreeEnt_RtD",
            "BlackForestMeleeTR1_RtD",
            "BlackForestMeleeTR2_RtD",
            "BlackForestMeleeTR3_RtD",
            "Ragdoll_Troll_RtD",
            "Spawner_Troll_RtD",
            "BlackForestUndeadMelee1_RtD",
            "BlackForestUndeadMelee2_RtD",
            "Ragdoll_BlackForestUndead_RtD",
            "Spawner_BlackForestUndead_RtD",
            "MeadowsMeleeHG1_RtD",
            "MeadowsMeleeHG2_RtD",
            "Ragdoll_MeadowsHobgoblin_RtD",
            "Spawner_MeadowsHobgoblin_RtD",
            "MeadowsMeleeSP1_RtD",
            "MeadowsMeleeSP2_RtD",
            "Ragdoll_MeadowsSpider_RtD",
            "Spawner_MeadowsSpider_RtD",
            "MistlandsMeleeHP1_RtD",
            "MistlandsMeleeHP2_RtD",
            "MistlandsMeleeHP3_RtD",
            "Ragdoll_MistlandsHarpy_RtD",
            "Spawner_MistlandsHarpy_RtD",
            "MistlandsMeleeMT1_RtD",
            "MistlandsMeleeMT2_RtD",
            "MistlandsMeleeMT3_RtD",
            "Ragdoll_MistlandsManticora_RtD",
            "Spawner_MistlandsManticora_RtD",
            "MistlandsMeleeWF1_RtD",
            "MistlandsMeleeWF2_RtD",
            "MistlandsMeleeWF3_RtD",
            "Ragdoll_MistlandsWolf_RtD",
            "Spawner_MistlandsWolf_RtD",
            "MountainMeleeGF1_RtD",
            "MountainMeleeGF2_RtD",
            "MountainMeleeGF3_RtD",
            "Ragdoll_MountainGriffin_RtD",
            "Spawner_MountainGriffin_RtD",
            /*"MountainMeleeHY1_RtD",
            "MountainMeleeHY2_RtD",
            "MountainMeleeHY3_RtD",
            "Ragdoll_MountainHydra_RtD",
            "Spawner_MountainHydra_RtD",*/
            "MountainMeleeWF1_RtD",
            "MountainMeleeWF2_RtD",
            "MountainMeleeWF3_RtD",
            "Ragdoll_MountainWerewolf_RtD",
            "Spawner_MountainWerewolf_RtD",
            "FrostSpray_RtD",
            "MountainIceBreathWV_RtD",
            "MountainMeleeWV1_RtD",
            "MountainMeleeWV2_RtD",
            "MountainSpellWV_RtD",
            "Ragdoll_MountainWyvern_RtD",
            "Spawner_MountainWyvern_RtD",
            "PlainsChimeraAttack1_RtD",
            "PlainsChimeraAttack2_RtD",
            "PlainsChimeraAttack3_RtD",
            "Ragdoll_PlainsChimera_RtD",
            "Spawner_PlainsChimera_RtD",
            "PlainsDragonideAttack1_RtD",
            "PlainsDragonideAttack2_RtD",
            "PlainsDragonideAttack3_RtD",
            "Ragdoll_PlainsDragonide_RtD",
            "Spawner_PlainsDragonide_RtD",
            "PlainsOrcAttack1_RtD",
            "PlainsOrcAttack2_RtD",
            "PlainsOrcAttack3_RtD",
            "Ragdoll_PlainsOrc_RtD",
            "Spawner_PlainsOrc_RtD",
            "Ragdoll_SwampGhoul_RtD",
            "Spawner_SwampGhoul_RtD",
            "SwampGhoulMelee1_RtD",
            "SwampGhoulMelee2_RtD",
            "SwampGhoulMelee3_RtD",
            "Ragdoll_SwampMummy_RtD",
            "Spawner_SwampMummy_RtD",
            "SwampMummyMelee1_RtD",
            "SwampMummyMelee2_RtD",
            "SwampMummyMelee3_RtD",
            "Ragdoll_SwampRat_RtD",
            "Spawner_SwampRat_RtD",
            "SwampRatMelee1_RtD",
            "Ragdoll_SwampVampire_RtD",
            "Spawner_SwampVampire_RtD",
            "SwampVampireMelee1_RtD",
            "SwampVampireMelee2_RtD",
            "SwampVampireMelee3_RtD",
            "MeadowsKobaldMelee1_RtD",
            "MeadowsKobaldMelee2_RtD",
            "Ragdoll_MeadowsKobald_RtD",
            "MountainSpellWV_Flying_RtD",
            "WyvernProjectileFlying_RtD",
            "Spawner_MeadowsKobald_RtD",
            // None surface
            "MountainUndeadMelee_RtD",
            "MountainUndeadSpell_RtD",
            "Ragdoll_MountainUndead_RtD",
            "Spawner_MountainUndead_RtD",
            "Ragdoll_SwampSludger_RtD",
            "Spawner_SwampSludger_RtD",
            "SwampMeleeC1_RtD",
            "SwampMeleeC2_RtD",
            "SwampSpellC1_RtD",
            "SwampSummonC1_RtD",
            "digg_v3_RtD",
            "vfx_Place_digg_RtD",
            "vfx_ArcaneSlashHit_RtD",
            "vfx_EarthSlashHit_RtD",
            "vfx_FireSlashHit_RtD",
            "vfx_LightningSlashHit_RtD",
            "vfx_LightSlashHit_RtD",
            "vfx_ShadowSlashHit_RtD",
            "vfx_StormSlashHit_RtD",
            "vfx_WaterSlashHit_RtD",
            "AshLandsSpearProjectile_RtD",
            "BlackForestSpearProjectile_RtD",
            "DeepNorthSpearProjectile_RtD",
            "MeadowsSpearProjectile_RtD",
            "MistlandsSpearProjectile_RtD",
            "MountainSpearProjectile_RtD",
            "PlainsSpearProjectile_RtD",
            "SwampSpearProjectile_RtD",
            "FireArrowNova_RtD",
            "LightningArrowNova_RtD",
            "ArcaneArrowNova_RtD",
            "StormArrowNova_RtD",
            "MistlandsArrowNova_RtD",
            "FrostArrowNova_RtD",
            "VoidArrowNova_RtD",
            "SwampArrowNova_RtD"
        };

        public string[] ItemsListMonstrum = new string[]
        {
            "BlackForestCore_RtD",
            "MeadowsCore_RtD",
            "MistlandsCore_RtD",
            "AshLandsCore_RtD",
            "DeepNorthCore_RtD",
            "AshLandsToken_RtD",
            "DeepNorthToken_RtD",
            "MountainCore_RtD",
            "PlainsCore_RtD",
            "SwampCore_RtD",
            "BlackForestToken_RtD",
            "MeadowsToken_RtD",
            "MistlandsToken_RtD",
            "MountainToken_RtD",
            "PlainsToken_RtD",
            "SwampToken_RtD",
            "FelmetalBar_RtD",
            "FelmetalOre_RtD",
            "Item_BloodironBar_RtD",
            "Item_BloodironOre_RtD",
            "Item_BrassBar_RtD",
            "Item_BrightsteelBar_RtD",
            "Item_CelestialBronzeBar_RtD",
            "Item_GoldBar_RtD",
            "Item_GoldOre_RtD",
            "Item_MoonironBar_RtD",
            "Item_MoonironOre_RtD",
            "Item_NetheriteBar_RtD",
            "Item_OrichalcumBar_RtD",
            "Item_OrichalcumOre_RtD",
            "Item_QuicksilverBar_RtD",
            "Item_ZincBar_RtD",
            "Item_ZincOre_RtD"
        };

        // Status Effects
        public string[] CustomStatusEffectList = new string[]
        {
            "SE_Shocked_RtD",
            "SE_Weakened_RtD",
            "SE_Frosted_RtD",
            "SE_ArmorWeakness_RtD"
        };

        public string[] StaticList1 = new string[]
        {
            "MeadowsHobgoblin_RtD",
            "MeadowsKobald_RtD",
            "MeadowsSpider_RtD",
        };

        public string[] StaticList2 = new string[]
        {
            "BlackForestGolem_RtD",
            "BlacKForestTreeEnt_RtD",
            "BlacKForestTroll_RtD",
            "BlackForestUndead_RtD",
        };

        public string[] StaticList3 = new string[]
        {
            "SwampGhoul_RtD",
            "SwampMummy_RtD",
            "SwampRat_RtD",
            "SwampVampire_RtD",
        };

        public string[] StaticList4 = new string[]
        {
            "MountainGriffin_RtD",
            "MountainUndead_RtD",
            "MountainWerewolf_RtD",
            "MountainWyvern_RtD"
        };

        public string[] StaticList5 = new string[]
        {
            "PlainsChomper1_RtD",
            "PlainsChimera_RtD",
            "PlainsDragonide_RtD",
            "PlainsOrc_RtD"
        };

        public string[] StaticList6 = new string[]
        {
            "MistlandsSpider1_RtD",
            "MistlandsHarpy_RtD",
            "MistlandsManticora_RtD",
            "MistlandsWolf_RtD"
        };

        public string[] BossList = new string[]
        {
            "EikthyrSpirit_RtD",
            "MountainBoss_RtD",
            "PlainsBoss_RtD",
            "SpiderQueen_RtD",
            "SwampBoss_RtD",
            "TrollKing_RtD",
            // Dungeon only Mobs
            "SwampSludger_RtD"
        };


        public static SpawnConfig[] MeadowsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 350,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 1,
                Biome = Heightmap.Biome.Meadows,
                MinAltitude = 2    
            }
        };

        public static SpawnConfig[] BlackForestSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 350,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 1,
                Biome = Heightmap.Biome.BlackForest,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] SwampSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 350,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 1,
                Biome = Heightmap.Biome.Swamp,
                MinAltitude = 1
            }
        };

        public static SpawnConfig[] MountainSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 350,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 1,
                Biome = Heightmap.Biome.Mountain
            }
        };

        public static SpawnConfig[] PlainsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 350,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 1,
                Biome = Heightmap.Biome.Plains,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] MistlandsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 350,
                SpawnChance = 10,
                SpawnAtNight = true,
                SpawnAtDay = true,            
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxGroupSize = 1,
                Biome = Heightmap.Biome.Mistlands,
                MinAltitude = 2
            }
        };

        public void StatusEffects()
        {
            try
            {
                foreach (string prefabNameSE in CustomStatusEffectList)
                {
                    // You would change SE_Stats here, to what ever SE base you used, like SE_Infection_HS or SE_Smoke etc.
                    SE_Stats statusEffect = _myAssets.LoadAsset<SE_Stats>(prefabNameSE);
                    if (statusEffect != null)
                    {
                        CustomStatusEffect customEffect = new(statusEffect, true);
                        ItemManager.Instance.AddStatusEffect(customEffect);
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding SE_Stats Effects: {arg}");
            }
        }

        public void AddItemsMonstrum()
        {
            try
            {
                foreach (string prefabNameSO1 in ItemsListMonstrum)
                {
                    GameObject prefabSO1 = _myAssets.LoadAsset<GameObject>(prefabNameSO1);
                    if (prefabSO1 != null)
                    {
                        CustomItem customPrefabSO1 = new CustomItem(prefabSO1, true);
                        ItemManager.Instance.AddItem(customPrefabSO1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabNameSO1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabNameSO1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        public static CreatureConfig MeadowsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.ForestMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MeadowsSpawnConfig
        };


        public void MeadowsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList1)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MeadowsCreatureConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig BlackForestCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.ForestMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = BlackForestSpawnConfig
        };

        public void BlackForestSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList2)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, BlackForestCreatureConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig SwampCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.Undead,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = SwampSpawnConfig
        };

        public void SwampSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList3)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, SwampCreatureConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig MountainCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.MountainMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MountainSpawnConfig
        };

        public void MountainSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList4)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MountainCreatureConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig PlainsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.PlainsMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = PlainsSpawnConfig
        };

        public void PlainsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList5)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, PlainsCreatureConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public static CreatureConfig MistlandsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.MistlandsMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = MistlandsSpawnConfig
        };

        public void MistlandsSpawner()
        {
            try
            {
                foreach (string prefabName in StaticList6)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, MistlandsCreatureConfig));
                        if (LoggingEnable.Value) { Logger.LogMessage("Added monster: " + prefabName); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }

        public void AddPrefabsMonstrum()
        {
            try
            {
                foreach (string prefabName in PrefabListMonstrum)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        GameObject dupeCheck = PrefabManager.Cache.GetPrefab<GameObject>(prefabName);
                        if (dupeCheck == null)
                        {
                            CustomPrefab customPrefab = new CustomPrefab(prefab, true);
                            PrefabManager.Instance.AddPrefab(customPrefab);
                            if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabName + " to the Object database"); }
                        }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
        
        public void Bosses()
        {
            try
            {
                foreach (string prefabNameU1 in BossList)
                {
                    GameObject prefabU1 = _myAssets.LoadAsset<GameObject>(prefabNameU1);
                    if (prefabU1 != null)
                    {
                        CustomCreature customPrefabU1 = new CustomCreature(prefabU1, true);
                        CreatureManager.Instance.AddCreature(customPrefabU1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabNameU1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabNameU1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        public void Altars()
        {
            try
            {
                // Altars

                // Altar1
                GameObject Locations1 = _myAssets.LoadAsset<GameObject>("MeadowsAltar_RtD");
                CustomLocation Objects1 = new(Locations1, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 10,
                    Quantity = 6,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects1);

                // Altar2
                GameObject Locations2 = _myAssets.LoadAsset<GameObject>("BlackForestAltar_RtD");
                CustomLocation Objects2 = new(Locations2, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 10,
                    Quantity = 6,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects2);

                // Altar3
                GameObject Locations3 = _myAssets.LoadAsset<GameObject>("SwampAltar_RtD");
                CustomLocation Objects3 = new(Locations3, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Swamp),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 10,
                    Quantity = 6,
                    MaxTerrainDelta = 10,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects3);

                // Altar5
                GameObject Locations5 = _myAssets.LoadAsset<GameObject>("PlainsAltar_RtD");
                CustomLocation Objects5 = new(Locations5, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Plains),
                    BiomeArea = Heightmap.BiomeArea.Median,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    ExteriorRadius = 10,
                    Quantity = 6,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects5);

                // Vegvisirs

                // Vegvisirs1
                GameObject Locations7 = _myAssets.LoadAsset<GameObject>("VegvisirMeadows_RtD");
                CustomLocation Objects7 = new(Locations7, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Meadows),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    Quantity = 24,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects7);

                // Vegvisirs2
                GameObject Locations8 = _myAssets.LoadAsset<GameObject>("VegvisirBlackForest_RtD");
                CustomLocation Objects8 = new(Locations8, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.BlackForest),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    Quantity = 24,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects8);

                // Vegvisirs3
                GameObject Locations9 = _myAssets.LoadAsset<GameObject>("VegvisirSwamp_RtD");
                CustomLocation Objects9 = new(Locations9, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Swamp),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    Quantity = 24,
                    MaxTerrainDelta = 10,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects9);

                // Vegvisirs4
                GameObject Locations10 = _myAssets.LoadAsset<GameObject>("VegvisirMountain_RtD");
                CustomLocation Objects10 = new(Locations10, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mountain),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    Quantity = 24,
                    MaxTerrainDelta = 10,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects10);

                // Vegvisirs5
                GameObject Locations11 = _myAssets.LoadAsset<GameObject>("VegvisirPlains_RtD");
                CustomLocation Objects11 = new(Locations11, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Plains),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    Quantity = 24,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects11);

                // Vegvisirs6
                GameObject Locations12 = _myAssets.LoadAsset<GameObject>("VegvisirMistlands_RtD");
                CustomLocation Objects12 = new(Locations12, true, new LocationConfig
                {

                    Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.Mistlands),
                    BiomeArea = Heightmap.BiomeArea.Everything,
                    MinAltitude = 2f,
                    MaxAltitude = 500f,
                    Quantity = 24,
                    MaxTerrainDelta = 3,
                    ForestTresholdMin = 1f,
                    ForestTrasholdMax = 99f,
                    MinDistanceFromSimilar = 256f,
                    ClearArea = true,
                    SlopeRotation = true,
                });
                ZoneManager.Instance.AddCustomLocation(Objects12);
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding custom location: {ex}");
            }
        }

        private static readonly string MountainBossTheme = "MountainBossTheme_RtD";

        private static readonly string MistlandsBossTheme = "MistlandsBossTheme_RtD";

        // Mountain
        private static readonly RoomConfig EntranceMountainBossConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = MountainBossTheme,
            Weight = 1f
        };

        // Mistlands
        private static readonly RoomConfig EntranceMistlandsBossConfig = new RoomConfig
        {
            Enabled = true,
            Entrance = true,
            MinPlaceOrder = 0,
            ThemeName = MistlandsBossTheme,
            Weight = 1f
        };
        
        private static readonly LocationConfig MountainBossDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Mountain,
            MinDistanceFromSimilar = 90,
            Quantity = 16,
            Priotized = true,
            MinAltitude = 60f,
            ClearArea = true,
            ExteriorRadius = 15
            
        };
        
        private static readonly LocationConfig MistlandsBossDungeonLocConfig = new LocationConfig
        {
            Biome = Heightmap.Biome.Mistlands,
            MinDistanceFromSimilar = 100,
            Quantity = 16,
            Priotized = true,
            MinAltitude = 10f,
            ClearArea = true,
            ExteriorRadius = 15
        };
        
        public void OnVanillaLocationsAvailableMonstrum()
        {
            try
            {
                // Loading a new custom location as a dungeon entrance
                var meadowsLocationPrefab = _myAssets.LoadAsset<GameObject>("MountainAltar_RtD");
                if (meadowsLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(meadowsLocationPrefab, MountainBossTheme);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(meadowsLocationPrefab, true, MountainBossDungeonLocConfig));
                }

                var blackForestLocationPrefab = _myAssets.LoadAsset<GameObject>("MistlandsAltar_RtD");
                if (blackForestLocationPrefab != null)
                {
                    DungeonManager.Instance.RegisterDungeonTheme(blackForestLocationPrefab, MistlandsBossTheme);

                    ZoneManager.Instance.AddCustomLocation(new CustomLocation(blackForestLocationPrefab, true, MistlandsBossDungeonLocConfig));
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeon locations: {arg}");
            }
            finally
            {
                ZoneManager.OnVanillaLocationsAvailable -= OnVanillaLocationsAvailableMonstrum;
            }
        }

        public void OnVanillaRoomsAvailableMonstrum()
        {
            try
            {
                // Entrance
                GameObject prefabMountainBossEntrance = _myAssets.LoadAsset<GameObject>("MountainEntrance_Boss_RtD");
                if (prefabMountainBossEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabMountainBossEntrance, true, EntranceMountainBossConfig));
                }
                GameObject prefabMistlandsBossEntrance = _myAssets.LoadAsset<GameObject>("MistlandsEntrance_Boss_RtD");
                if (prefabMistlandsBossEntrance != null)
                {
                    DungeonManager.Instance.AddCustomRoom(new CustomRoom(prefabMistlandsBossEntrance, true, EntranceMistlandsBossConfig));
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding dungeons: {arg}");
            }
            finally
            {
                DungeonManager.OnVanillaRoomsAvailable -= OnVanillaRoomsAvailableMonstrum;
            }
        }
    }
}