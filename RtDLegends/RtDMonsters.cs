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
        public string[] AshLandsMonsterList = new string[]
        {
         "Assassin_RtD",
         "Berserker_RtD",
         "Demon_RtD",
         "DragonBoar_RtD",
         "FallenCrusader_RtD",
         "CursedKnight_RtD",
         "Wizard_RtD"
        };

        public string[] DeepNorthMonsterList = new string[]
        {
         "Befouler_RtD",
         "Davil_RtD",
         "Executioner_RtD",
         "NorthernTroll_RtD",
         "FaeWolfIce_RtD",
         "FaeWolfLightening_RtD",
         "ElfHunterF_RtD",
         "ElfHunterM_RtD",
         "ElfPriestM_RtD",
         "ElfWarriorF_RtD",
         "ElfWarriorM_RtD"
        };

        public static SpawnConfig[] AshLandsSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 450,
                SpawnChance = 5,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxGroupSize = 1,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxAltitude = 500,
                Biome = Heightmap.Biome.AshLands,
                MinAltitude = 2
            }
        };

        public static SpawnConfig[] DeepNorthSpawnConfig = new SpawnConfig[]
        {
            new SpawnConfig
            {
                SpawnDistance = 100,
                SpawnInterval = 450,
                SpawnChance = 5,
                SpawnAtNight = true,
                SpawnAtDay = true,
                MaxGroupSize = 1,
                MaxSpawned = 1,
                MaxLevel = 2,
                MaxAltitude = 500,
                Biome = Heightmap.Biome.DeepNorth,
                MinAltitude = 2
            }
        };

        public static CreatureConfig AshLandsCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.Demon,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = AshLandsSpawnConfig
        };

        public static CreatureConfig DeepNorthCreatureConfig = new CreatureConfig
        {
            Faction = Character.Faction.MountainMonsters,
            UseCumulativeLevelEffects = true,
            SpawnConfigs = DeepNorthSpawnConfig
        };
        
        public string[] CustomSEShieldList = new string[]
        {
            // Status Effects
            "SE_FairyShield_RtD",
        };

        public string[] CustomSEList = new string[]
        {
            // Status Effects
            "SE_FairyHeal_RtD",
            "SE_ArcherAshLands_RtD",
            "SE_AssassinAshLands_RtD",
            "SE_MonkArmorAshLands_RtD",
            "SE_WarriorArmorAshLands_RtD",
            "SE_ArcherBlackForest_RtD",
            "SE_AssassinBlackForest_RtD",
            "SE_MonkArmorBlackForest_RtD",
            "SE_WarriorArmorBlacKForest_RtD",
            "SE_ArcherDeepNorth_RtD",
            "SE_AssassinDeepNorth_RtD",
            "SE_MonkArmorDeepNorth_RtD",
            "SE_WarriorArmorDeepNorth_RtD",
            "SE_ArcherMistlands_RtD",
            "SE_AssassinMistlands_RtD",
            "SE_MonkArmorMistlands_RtD",
            "SE_WarriorArmorMistlands_RtD",
            "SE_ArcherMountain_RtD",
            "SE_AssassinMountain_RtD",
            "SE_MonkArmorMountain_RtD",
            "SE_WarriorArmorMountain_RtD",
            "SE_ArcherPlains_RtD",
            "SE_AssassinPlains_RtD",
            "SE_MonkArmorPlains_RtD",
            "SE_WarriorArmorPlains_RtD",
            "SE_ArcherSwamp_RtD",
            "SE_AssassinSwamp_RtD",
            "SE_MonkArmorSwamp_RtD",
            "SE_WarriorArmorSwamp_RtD",
            "SE_OdinsFists_RtD",
            "SE_DeerHideMeadows_RtD",
            "SlowFall_RtD"
        };

        public string[] ItemsListMonsters = new string[]
        {
            // Items
            "CookedDragonBoarMeat_RtD",
            "DragonBoarMeat_RtD",
            "CookedFaeWolfMeat_RtD",
            "FaeWolfMeat_RtD",
            "SpiritHeart_RtD",
            "FroMetalOre_RtD",
            "FroMetalBar_RtD",
            "ThorHammer_RtD"
        };

        public string[] PrefabsListMonsters = new string[]
        {
            // Prefabs
            "Ragdoll_SO_Thor_RtD",
            "projectile_thorhammer_RtD",
            "elextricvfx_RtD",
            "fx_eikthyr_stomp_RtD",
            "fx_fae_death_RtD",
            "fx_fae_hit_RtD",
            "fx_fairyprotect_RtD",
            "vfx_dragon_firebreath_RtD",
            "vfx_elementalgolem_death_RtD",
            "vfx_elementalgolem_hurt_RtD",
            "vfx_FairyShield_RtD",
            "vfx_fireball_dragonlaunch_RtD",
            "fx_flameexplosion_death_rtd",
            "fx_FaeSpiritShieldBreak_RtD",
            "fx_FaeSpiritShieldHit_RtD",
            "Ragdoll_Necromander_RtD",
            //Projectiles
            "bow_projectile_frost_RtD",
            "bow_projectile_poison_RtD",
            "ElfSpearProjectile_RtD",
            "FairyHealAOE_RtD",
            //Melee VFX
            "vfx_ArcaneSlashHitM_RtD",
            "vfx_EarthSlashHitM_RtD",
            "vfx_FireSlashHitM_RtD",
            "vfx_FrostSlashHitM_RtD",
            "vfx_LightningSlashHitM_RtD",
            "vfx_LightSlashHitM_RtD",
            "vfx_ShadowSlashHitM_RtD",
            "vfx_StormSlashHitM_RtD",
            "vfx_WaterSlashHitM_RtD",
            //AshLands Attacks
            "AssassinAttack1_RtD",
            "AssassinAttack2_RtD",
            "AssassinAttack3_RtD",
            "BerserkerAttack1_RtD",
            "BerserkerAttack2_RtD",
            "BerserkerAttack3_RtD",
            "BerserkerAttack4_RtD",
            "BerserkerAttack5_RtD",
            "BoarAttck1_RtD",
            "BoarAttck2_RtD",
            "CrusaderAttack1_RtD",
            "CrusaderAttack2_RtD",
            "CrusaderAttack3_RtD",
            "DemonClawAttack_RtD",
            "DemonHornAttack_RtD",
            "DemonProjectileAttack_RtD",
            "dragon_bite1_RtD",
            "dragon_claw_left1_RtD",
            "dragon_claw_right1_RtD",
            "dragon_firebreath1_RtD",
            "dragon_spit_shotgun1_RtD",
            "dragon_taunt1_RtD",
            "NecromancerMelee1_RtD",
            "NecromancerMelee2_RtD",
            "NecromancerSpell1_RtD",
            "NecromancerSpell2_RtD",
            "NecromancerSpell3_RtD",
            "NecromancerSpell4_RtD",
            "NecromancerSpell5_RtD",
            "NecromancerSpell6_RtD",
            "PigletAttck1_RtD",
            "PigletAttck2_RtD",
            "WizardAttack1_RtD",
            "WizardAttack2_RtD",
            //DeepNorth Attacks
            "ElfWarriorAttackF1_RtD",
            "ElfWarriorAttackF2_RtD",
            "ElfWarriorAttackF3_RtD",
            "ElfWarriorAttackF4_RtD",
            "ElfWarriorAttackM1_RtD",
            "ElfWarriorAttackM2_RtD",
            "ElfWarriorAttackM3_RtD",
            "ElfWarriorAttackM4_RtD",
            "HunterBowAttack1_RtD",
            "HunterBowAttack2_RtD",
            "HunterMBomb_RtD",
            "HunterMelee1_RtD",
            "HunterMelee2_RtD",
            "HunterMelee3_RtD",
            "HunterMKick_RtD",
            "HunterSpear4_RtD",
            "PriestMelee1_RtD",
            "PriestSpell3_RtD",
            "PriestSpell4_RtD",
            "SpiritAOEAttack2_RtD",
            "SpiritAttackDoubleHand1_RtD",
            "SpiritAttackDoubleHand2_RtD",
            "SpiritAttackMelee1_RtD",
            "SpiritHealAttack1_RtD",
            "SpiritHealIceAttack2_RtD",
            "SpiritHealLighteningAttack3_RtD",
            "Wolf_Attack1_RtD",
            "Wolf_Attack2_RtD",
            "Wolf_Attack3frost_RtD",
            "Wolf_Attack3lightening_RtD",
            //CursedKnight
            "CursedKnightMelee1_RtD",
            "CursedKnightMelee2_RtD",
            "CursedKnightMelee3_RtD",
            "CursedKnightSpell_RtD",
            //RagDolls
            "Ragdoll_Assassin_RtD",
            "Ragdoll_CursedKnight_RtD",
            "Ragdoll_Berserker_RtD",
            "Ragdoll_Demon_RtD",
            "Ragdoll_DragonBoar_RtD",
            "Ragdoll_FallenCrusader_RtD",
            "Ragdoll_ElfHunterF_RtD",
            "Ragdoll_ElfHunterM_RtD",
            "Ragdoll_ElfPriestM_RtD",
            "Ragdoll_ElfWarriorF_RtD",
            "Ragdoll_ElfWarriorM_RtD",
            //Thor Attacks
            "ThorAOEattack1_RtD",
            "ThorAOEattack2_RtD",
            "ThorMelee1_RtD",
            "ThorMelee2_RtD",
            "ThorSpell1_RtD",
            "ThorSpell2_RtD",
            "ThorSpell3_RtD",
            "ThorSummon1_RtD",
            //Thor Projectiles
            "ThorProjectile1_RtD",
            "ThorProjectile2_RtD",
            "ThorProjectile3_RtD",
            //Thor Explosions
            "ThorExplosionSmall_RtD",
            "ThorExplosionMedium_RtD",
            "ThorExplosionLarge_RtD",
            //Thor AOE
            "ThorHammerAOE_RtD",
            "ThorSpellAOE_RtD",
            //Spawners
            "Spawner_Assassin_RtD",
            "Spawner_Berserker_RtD",
            "Spawner_Demon_RtD",
            "Spawner_DragonBoar_RtD",
            "Spawner_FallenCrusader_RtD",
            "Spawner_Wizard_RtD",
            "Spawner_ElfHunterM_RtD",
            "Spawner_ElfHunterF_RtD",
            "Spawner_ElfPriest_RtD",
            "Spawner_ElfWarriorM_RtD",
            "Spawner_ElfWarriorF_RtD",
            "Spawner_FaeWolfIce_RtD",
            "Spawner_FaeWolfLightning_RtD",
            // Line break
            "LichKingAOE_RtD",
            "LichKingMelee1_RtD",
            "LichKingMelee2_RtD",
            "LichKingMelee3_RtD",
            "LichKingSpell1_RtD",
            "LichKingSpell2_RtD",
            "LichKingSummon_RtD",
            "Ragdoll_LichKing_RtD",
            "BefoulerMelee1_RtD",
            "BefoulerMelee2_RtD",
            "BefoulerMelee3_RtD",
            "BefoulerSpell_RtD",
            "Ragdoll_Befouler_RtD",
            "DavilMeele_RtD",
            "DavilSpell1_RtD",
            "DavilSpell2_RtD",
            "DavilSpell3_RtD",
            "Ragdoll_Davil_RtD",
            "ExecutionerMelee1_RtD",
            "ExecutionerMelee2_RtD",
            "ExecutionerMelee3_RtD",
            "ExecutionerSpell_RtD",
            "Ragdoll_Exectutioner_RtD",
            "NorthernMelee1_RtD",
            "NorthernMelee2_RtD",
            "NorthernMelee3_RtD",
            "NorthernSpell_RtD",
            "Ragdoll_Northern_RtD",
            // Vegvisir 
            "Vegvisir_Necromancer_Altar_RtD",
            "Vegvisir_SpiritAltar_RtD",
            "Vegvisir_ThorAltar_RtD",
            // New stuff
            "DemonWhipAttack_RtD",
            "Ragdoll_Wizard_RtD"
        };
        
        public string[] MonsterList = new string[]
        {
            // Monsters without spawners
            "LichKing_RtD",
            "DragonBoarTamed_RtD",
            "FaeWolfLighteningCub_RtD",
            "FaeWolfIceCub_RtD",
            "FaeWolfIceTamed_RtD",
            "FaeWolfLighteningTamed_RtD",
            "Necromancer_RtD",
            "DragonPiglet_RtD",
            "SO_Thor_RtD"
        };
        
        public ConfigEntry<bool> LoggingEnable;

        public void AddShieldEffect()
        {
            try
            {
                foreach (string prefabNameSE1 in CustomSEShieldList)
                {
                    // You would change SE_Stats here, to what ever SE base you used, like SE_Infection_HS or SE_Smoke etc.
                    SE_Shield statusEffect1 = _myAssets.LoadAsset<SE_Shield>(prefabNameSE1);
                    if (statusEffect1 != null)
                    {
                        CustomStatusEffect customEffect1 = new(statusEffect1, true);
                        ItemManager.Instance.AddStatusEffect(customEffect1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + statusEffect1 + " to the Object database"); }
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding SE_Stats Effects: {arg}");
            }
        }

        public void AddSEStatusEffect()
        {
            try
            {
                foreach (string prefabNameSE in CustomSEList)
                {
                    // You would change SE_Stats here, to what ever SE base you used, like SE_Infection_HS or SE_Smoke etc.
                    SE_Stats statusEffect = _myAssets.LoadAsset<SE_Stats>(prefabNameSE);
                    if (statusEffect != null)
                    {
                        CustomStatusEffect customEffect = new(statusEffect, true);
                        ItemManager.Instance.AddStatusEffect(customEffect);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + statusEffect + " to the Object database"); }
                    }
                }
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding SE_Stats Effects: {arg}");
            }
        }

        public void AddItemsMonsters()
        {
            try
            {
                foreach (string prefab1 in ItemsListMonsters)
                {
                    GameObject prefabbed1 = _myAssets.LoadAsset<GameObject>(prefab1);
                    if (prefabbed1 != null)
                    {
                        CustomItem customPrefabS1 = new CustomItem(prefabbed1, true);
                        ItemManager.Instance.AddItem(customPrefabS1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefab1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefab1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        public void AddPrefabs()
        {
            try
            {
                foreach (string prefabName1 in PrefabsListMonsters)
                {
                    GameObject prefab1 = _myAssets.LoadAsset<GameObject>(prefabName1);
                    if (prefab1 != null)
                    {
                        CustomPrefab customPrefab1 = new CustomPrefab(prefab1, true);
                        PrefabManager.Instance.AddPrefab(customPrefab1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabName1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }

        public void RegisterMonsters()
        {
            try
            {
                foreach (string prefabName1 in MonsterList)
                {
                    GameObject prefab1 = _myAssets.LoadAsset<GameObject>(prefabName1);
                    if (prefab1 != null)
                    {
                        CustomCreature customPrefab1 = new CustomCreature(prefab1, true);
                        CreatureManager.Instance.AddCreature(customPrefab1);

                        if (LoggingEnable.Value) { Logger.LogMessage("Added: " + prefabName1 + " to the Object database"); }
                    }
                    else
                    {
                        Logger.LogMessage("Failed to add: " + prefabName1 + " to the object database");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
        
        public void Locations()
        {
            try
            {
                // Location2
                GameObject Location2F = _myAssets.LoadAsset<GameObject>("NecromancerAltar_RtD");
                if (Location2F != null)
                {
                    CustomLocation Object2F = new(Location2F, true, new LocationConfig
                    {
    
                        Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.AshLands),
                        BiomeArea = Heightmap.BiomeArea.Median,
                        MinAltitude = 25f,
                        MaxAltitude = 500f,
                        Quantity = 6,
                        MaxTerrainDelta = 3,
                        ForestTresholdMin = 1f,
                        ForestTrasholdMax = 99f,
                        MinDistanceFromSimilar = 256f,
                        ExteriorRadius = 35f,
                        ClearArea = true,
                        Priotized = true,
                    });
                    ZoneManager.Instance.AddCustomLocation(Object2F);
                }
                else { Logger.LogWarning("Failed to load location prefab: NecromancerAltar_RtD"); }

                // Location3
                GameObject Location4F = _myAssets.LoadAsset<GameObject>("Vegvisir_Necromancer_RtD");
                if (Location4F != null)
                {
                    CustomLocation Object4F = new(Location4F, true, new LocationConfig
                    {
    
                        Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.AshLands),
                        BiomeArea = Heightmap.BiomeArea.Median,
                        MinAltitude = 1f,
                        MaxAltitude = 500f,
                        ExteriorRadius = 20,
                        Quantity = 12,
                        MaxTerrainDelta = 3,
                        ForestTresholdMin = 1f,
                        ForestTrasholdMax = 99f,
                        MinDistanceFromSimilar = 256f,
                        ClearArea = true,
                        SlopeRotation = true,
                    });
                    ZoneManager.Instance.AddCustomLocation(Object4F);
                }
                else { Logger.LogWarning("Failed to load location prefab: Vegvisir_Necromancer_RtD"); }

                // Location5
                GameObject Shrine56 = _myAssets.LoadAsset<GameObject>("SpiritShrine_RtD");
                if (Shrine56 != null)
                {
                    CustomLocation ShrineObject56 = new(Shrine56, true, new LocationConfig
                    {
    
                        Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                        BiomeArea = Heightmap.BiomeArea.Everything,
                        MinAltitude = 25f,
                        MaxAltitude = 500f,
                        Quantity = 6,
                        MaxTerrainDelta = 2,
                        ExteriorRadius = 15f,
                        ClearArea = true,
                        Priotized = true,
                    });
                    ZoneManager.Instance.AddCustomLocation(ShrineObject56);
                }
                else { Logger.LogWarning("Failed to load location prefab: SpiritShrine_RtD"); }

                // Location5
                GameObject NorthLocation566 = _myAssets.LoadAsset<GameObject>("Vegvisir_Spirit_RtD");
                if (NorthLocation566 != null)
                {
                    CustomLocation NorthObject566 = new(NorthLocation566, true, new LocationConfig
                    {
    
                        Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                        BiomeArea = Heightmap.BiomeArea.Everything,
                        MinAltitude = 5f,
                        MaxAltitude = 500f,
                        Quantity = 12,
                        ExteriorRadius = 5f,
                        ClearArea = true,
                    });
                    ZoneManager.Instance.AddCustomLocation(NorthObject566);
                }
                else { Logger.LogWarning("Failed to load location prefab: Vegvisir_Spirit_RtD"); }

                // Thor Location
                GameObject ThorValue1 = _myAssets.LoadAsset<GameObject>("ThorShrine_RtD");
                if (ThorValue1 != null)
                {
                    CustomLocation ThorObject1 = new(ThorValue1, true, new LocationConfig
                    {
    
                        Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                        BiomeArea = Heightmap.BiomeArea.Everything,
                        MinAltitude = 25f,
                        MaxAltitude = 500f,
                        Quantity = 6,
                        MaxTerrainDelta = 2,
                        ExteriorRadius = 15f,
                        ClearArea = true,
                        Priotized = true,
                    });
                    ZoneManager.Instance.AddCustomLocation(ThorObject1);
                }
                else { Logger.LogWarning("Failed to load location prefab: ThorShrine_RtD"); }

                GameObject ThorValue2 = _myAssets.LoadAsset<GameObject>("Vegvisir_Thor_RtD");
                if (ThorValue2 != null)
                {
                    CustomLocation ThorObject2 = new(ThorValue2, true, new LocationConfig
                    {
    
                        Biome = ZoneManager.AnyBiomeOf(Heightmap.Biome.DeepNorth),
                        BiomeArea = Heightmap.BiomeArea.Everything,
                        MinAltitude = 25f,
                        MaxAltitude = 500f,
                        Quantity = 6,
                        MaxTerrainDelta = 2,
                        ExteriorRadius = 15f,
                        ClearArea = true,
                        Priotized = true,
                    });
                    ZoneManager.Instance.AddCustomLocation(ThorObject2);
                }
                else { Logger.LogWarning("Failed to load location prefab: Vegvisir_Thor_RtD"); }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding custom location: {ex}");
            }
        }

        public void AshLandsSpawners()
        {
            try
            {
                foreach (string prefabName in AshLandsMonsterList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, AshLandsCreatureConfig));
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

        public void DeepNorthSpawners()
        {
            try
            {
                foreach (string prefabName in DeepNorthMonsterList)
                {
                    GameObject prefab = _myAssets.LoadAsset<GameObject>(prefabName);
                    if (prefab != null)
                    {
                        CreatureManager.Instance.AddCreature(new CustomCreature(prefab, true, DeepNorthCreatureConfig));
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
    }
}