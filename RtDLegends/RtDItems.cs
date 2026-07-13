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

namespace RtDLegends                        
{
    internal partial class RtDLegends : BaseUnityPlugin   
    {
        
        public void ItemConversions()
        {
            try
            {

                // Create a custom recipe with a RecipeConfig
                var recipeconfig1 = new RecipeConfig();
                recipeconfig1.Item = "Item_QuicksilverBar_RtD"; // Name of the item prefab to be crafted
                recipeconfig1.CraftingStation = CraftingStations.Forge;
                recipeconfig1.AddRequirement(new RequirementConfig("Obsidian", 1));
                recipeconfig1.AddRequirement(new RequirementConfig("Silver", 1));
                recipeconfig1.AddRequirement(new RequirementConfig("Item_OrichalcumBar_RtD", 1));
                ItemManager.Instance.AddRecipe(new CustomRecipe(recipeconfig1));

                var recipeconfig2 = new RecipeConfig();
                recipeconfig2.Item = "Item_BrassBar_RtD"; // Name of the item prefab to be crafted
                recipeconfig2.CraftingStation = CraftingStations.Forge;
                recipeconfig2.AddRequirement(new RequirementConfig("Copper", 1));
                recipeconfig2.AddRequirement(new RequirementConfig("Item_ZincBar_RtD", 1));
                recipeconfig2.AddRequirement(new RequirementConfig("Flint", 1));
                ItemManager.Instance.AddRecipe(new CustomRecipe(recipeconfig2));

                var recipeconfig3 = new RecipeConfig();
                recipeconfig3.Item = "Item_BrightsteelBar_RtD"; // Name of the item prefab to be crafted
                recipeconfig3.CraftingStation = CraftingStations.Forge;
                recipeconfig3.AddRequirement(new RequirementConfig("Guck", 1));
                recipeconfig3.AddRequirement(new RequirementConfig("Iron", 1));
                recipeconfig3.AddRequirement(new RequirementConfig("Item_MoonironBar_RtD", 1));
                ItemManager.Instance.AddRecipe(new CustomRecipe(recipeconfig3));

                var recipeconfig4 = new RecipeConfig();
                recipeconfig4.Item = "Item_CelestialBronzeBar_RtD"; // Name of the item prefab to be crafted
                recipeconfig4.CraftingStation = CraftingStations.Forge;
                recipeconfig4.AddRequirement(new RequirementConfig("Item_GoldBar_RtD", 1));
                recipeconfig4.AddRequirement(new RequirementConfig("Copper", 1));
                recipeconfig4.AddRequirement(new RequirementConfig("Tin", 1));
                ItemManager.Instance.AddRecipe(new CustomRecipe(recipeconfig4));

                var recipeconfig5 = new RecipeConfig();
                recipeconfig5.Item = "Item_NetheriteBar_RtD"; // Name of the item prefab to be crafted
                recipeconfig5.CraftingStation = CraftingStations.Forge;
                recipeconfig5.AddRequirement(new RequirementConfig("Tar", 1));
                recipeconfig5.AddRequirement(new RequirementConfig("BlackMetal", 1));
                recipeconfig5.AddRequirement(new RequirementConfig("Item_BloodironBar_RtD", 1));
                ItemManager.Instance.AddRecipe(new CustomRecipe(recipeconfig5));
                
                var blastConfig1 = new SmelterConversionConfig();
                blastConfig1.Station = Smelters.BlastFurnace;
                blastConfig1.FromItem = "FroMetalOre_RtD";
                blastConfig1.ToItem = "FroMetalBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig1));

                var blastConfig = new SmelterConversionConfig();
                blastConfig.Station = Smelters.BlastFurnace;
                blastConfig.FromItem = "FlametalOre";
                blastConfig.ToItem = "Flametal";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig));
                
                var blastConfig2 = new SmelterConversionConfig();
                blastConfig2.Station = Smelters.BlastFurnace;
                blastConfig2.FromItem = "Item_BloodironOre_RtD";
                blastConfig2.ToItem = "Item_BloodironBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig2));

                var blastConfig3 = new SmelterConversionConfig();
                blastConfig3.Station = Smelters.Smelter;
                blastConfig3.FromItem = "Item_GoldOre_RtD";
                blastConfig3.ToItem = "Item_GoldBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig3));

                var blastConfig4 = new SmelterConversionConfig();
                blastConfig4.Station = Smelters.Smelter;
                blastConfig4.FromItem = "Item_MoonironOre_RtD";
                blastConfig4.ToItem = "Item_MoonironBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig4));

                var blastConfig5 = new SmelterConversionConfig();
                blastConfig5.Station = Smelters.Smelter;
                blastConfig5.FromItem = "Item_OrichalcumOre_RtD";
                blastConfig5.ToItem = "Item_OrichalcumBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig5));

                var blastConfig6 = new SmelterConversionConfig();
                blastConfig6.Station = Smelters.BlastFurnace;
                blastConfig6.FromItem = "FelmetalOre_RtD";
                blastConfig6.ToItem = "FelmetalBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig6));

                var blastConfig7 = new SmelterConversionConfig();
                blastConfig7.Station = Smelters.Smelter;
                blastConfig7.FromItem = "Item_ZincOre_RtD";
                blastConfig7.ToItem = "Item_ZincBar_RtD";
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(blastConfig7));
                
                var cookConfig1 = new CookingConversionConfig();
                cookConfig1.FromItem = "DragonBoarMeat_RtD";
                cookConfig1.ToItem = "CookedDragonBoarMeat_RtD";
                cookConfig1.Station = CookingStations.IronCookingStation;
                cookConfig1.CookTime = 20f;
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(cookConfig1));

                var cookConfig2 = new CookingConversionConfig();
                cookConfig2.FromItem = "FaeWolfMeat_RtD";
                cookConfig2.ToItem = "CookedFaeWolfMeat_RtD";
                cookConfig2.Station = CookingStations.IronCookingStation;
                cookConfig2.CookTime = 20f;
                ItemManager.Instance.AddItemConversion(new CustomItemConversion(cookConfig2));
                
            }
            catch (Exception arg)
            {
                Logger.LogWarning($"Exception caught while adding monsters: {arg}");
            }
        }
        
        private void ModifyItems()
        {
            try
            {
                StatusEffect prefab = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_WarriorArmorBlacKForest_RtD");
                ItemDrop prefab2 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetBronze");
                ItemDrop prefab3 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorBronzeChest");
                ItemDrop prefab4 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorBronzeLegs");
                prefab2.m_itemData.m_shared.m_setName = "BronzeSE";
                prefab2.m_itemData.m_shared.m_setSize = 3;
                prefab2.m_itemData.m_shared.m_setStatusEffect = prefab;
                prefab3.m_itemData.m_shared.m_setName = "BronzeSE";
                prefab3.m_itemData.m_shared.m_setSize = 3;
                prefab3.m_itemData.m_shared.m_setStatusEffect = prefab;
                prefab4.m_itemData.m_shared.m_setName = "BronzeSE";
                prefab4.m_itemData.m_shared.m_setSize = 3;
                prefab4.m_itemData.m_shared.m_setStatusEffect = prefab;
                StatusEffect prefab5 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_AssassinBlackForest_RtD");
                ItemDrop prefab6 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetTrollLeather");
                ItemDrop prefab7 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorTrollLeatherChest");
                ItemDrop prefab8 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorTrollLeatherLegs");
                prefab6.m_itemData.m_shared.m_setName = "TrollSE";
                prefab6.m_itemData.m_shared.m_setSize = 3;
                prefab6.m_itemData.m_shared.m_setStatusEffect = prefab5;
                prefab7.m_itemData.m_shared.m_setName = "TrollSE";
                prefab7.m_itemData.m_shared.m_setSize = 3;
                prefab7.m_itemData.m_shared.m_setStatusEffect = prefab5;
                prefab8.m_itemData.m_shared.m_setName = "TrollSE";
                prefab8.m_itemData.m_shared.m_setSize = 3;
                prefab8.m_itemData.m_shared.m_setStatusEffect = prefab5;
                StatusEffect prefab9 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_WarriorArmorSwamp_RtD");
                ItemDrop prefab10 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetIron");
                ItemDrop prefab11 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorIronChest");
                ItemDrop prefab12 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorIronLegs");
                prefab10.m_itemData.m_shared.m_setName = "IronSE";
                prefab10.m_itemData.m_shared.m_setSize = 3;
                prefab10.m_itemData.m_shared.m_setStatusEffect = prefab9;
                prefab11.m_itemData.m_shared.m_setName = "IronSE";
                prefab11.m_itemData.m_shared.m_setSize = 3;
                prefab11.m_itemData.m_shared.m_setStatusEffect = prefab9;
                prefab12.m_itemData.m_shared.m_setName = "IronSE";
                prefab12.m_itemData.m_shared.m_setSize = 3;
                prefab12.m_itemData.m_shared.m_setStatusEffect = prefab9;
                StatusEffect prefab13 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_ArcherSwamp_RtD");
                ItemDrop prefab14 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetRoot");
                ItemDrop prefab15 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorRootChest");
                ItemDrop prefab16 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorRootLegs");
                prefab14.m_itemData.m_shared.m_setName = "RootSE";
                prefab14.m_itemData.m_shared.m_setSize = 3;
                prefab14.m_itemData.m_shared.m_setStatusEffect = prefab13;
                prefab15.m_itemData.m_shared.m_setName = "RootSE";
                prefab15.m_itemData.m_shared.m_setSize = 3;
                prefab15.m_itemData.m_shared.m_setStatusEffect = prefab13;
                prefab16.m_itemData.m_shared.m_setName = "RootSE";
                prefab16.m_itemData.m_shared.m_setSize = 3;
                prefab16.m_itemData.m_shared.m_setStatusEffect = prefab13;
                StatusEffect prefab17 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_WarriorArmorMountain_RtD");
                ItemDrop prefab18 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetDrake");
                ItemDrop prefab19 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorWolfChest");
                ItemDrop prefab20 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorWolfLegs");
                prefab18.m_itemData.m_shared.m_setName = "SilverSE";
                prefab18.m_itemData.m_shared.m_setSize = 3;
                prefab18.m_itemData.m_shared.m_setStatusEffect = prefab17;
                prefab19.m_itemData.m_shared.m_setName = "SilverSE";
                prefab19.m_itemData.m_shared.m_setSize = 3;
                prefab19.m_itemData.m_shared.m_setStatusEffect = prefab17;
                prefab20.m_itemData.m_shared.m_setName = "SilverSE";
                prefab20.m_itemData.m_shared.m_setSize = 3;
                prefab20.m_itemData.m_shared.m_setStatusEffect = prefab17;
                StatusEffect prefab21 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_WarriorArmorPlains_RtD");
                ItemDrop prefab22 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetPadded");
                ItemDrop prefab23 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorPaddedCuirass");
                ItemDrop prefab24 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorPaddedGreaves");
                prefab22.m_itemData.m_shared.m_setName = "BlackMetalSE";
                prefab22.m_itemData.m_shared.m_setSize = 3;
                prefab22.m_itemData.m_shared.m_setStatusEffect = prefab21;
                prefab23.m_itemData.m_shared.m_setName = "BlackMetalSE";
                prefab23.m_itemData.m_shared.m_setSize = 3;
                prefab23.m_itemData.m_shared.m_setStatusEffect = prefab21;
                prefab24.m_itemData.m_shared.m_setName = "BlackMetalSE";
                prefab24.m_itemData.m_shared.m_setSize = 3;
                prefab24.m_itemData.m_shared.m_setStatusEffect = prefab21;
                StatusEffect prefab25 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_WarriorArmorMistlands_RtD");
                ItemDrop prefab26 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetCarapace");
                ItemDrop prefab27 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorCarapaceChest");
                ItemDrop prefab28 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorCarapaceLegs");
                prefab26.m_itemData.m_shared.m_setName = "CarapaceSE";
                prefab26.m_itemData.m_shared.m_setSize = 3;
                prefab26.m_itemData.m_shared.m_setStatusEffect = prefab25;
                prefab27.m_itemData.m_shared.m_setName = "CarapaceSE";
                prefab27.m_itemData.m_shared.m_setSize = 3;
                prefab27.m_itemData.m_shared.m_setStatusEffect = prefab25;
                prefab28.m_itemData.m_shared.m_setName = "CarapaceSE";
                prefab28.m_itemData.m_shared.m_setSize = 3;
                prefab28.m_itemData.m_shared.m_setStatusEffect = prefab25;
                StatusEffect prefab29 = PrefabManager.Cache.GetPrefab<StatusEffect>("SE_DeerHideMeadows_RtD");
                ItemDrop prefab30 = PrefabManager.Cache.GetPrefab<ItemDrop>("HelmetLeather");
                ItemDrop prefab31 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorLeatherChest");
                ItemDrop prefab32 = PrefabManager.Cache.GetPrefab<ItemDrop>("ArmorLeatherLegs");
                prefab30.m_itemData.m_shared.m_setName = "LeatherSE";
                prefab30.m_itemData.m_shared.m_setSize = 3;
                prefab30.m_itemData.m_shared.m_setStatusEffect = prefab29;
                prefab31.m_itemData.m_shared.m_setName = "LeatherSE";
                prefab31.m_itemData.m_shared.m_setSize = 3;
                prefab31.m_itemData.m_shared.m_setStatusEffect = prefab29;
                prefab32.m_itemData.m_shared.m_setName = "LeatherSE";
                prefab32.m_itemData.m_shared.m_setSize = 3;
                prefab32.m_itemData.m_shared.m_setStatusEffect = prefab29;
            }
            catch (Exception arg)
            {
                base.Logger.LogWarning(string.Format("Exception caught while modifing items: {0}", arg));
            }
            finally
            {
                PrefabManager.OnVanillaPrefabsAvailable -= ModifyItems;
            }
        }
        
        public void CreateRecipes()
        {
            try
            {
                // Weapons and Shields (data-driven, config-synced - see RtDWeaponShieldConfigs.cs)
                AddWeaponsAndShields();

                // Armor (data-driven, config-synced - see RtDArmorConfigs.cs)
                AddArmor();

                // Extra Forge Pieces
                
                PieceConfig pieceConfig1 = new PieceConfig();
                pieceConfig1.PieceTable = PieceTables.Hammer;
                pieceConfig1.CraftingStation = CraftingStations.Forge;
                pieceConfig1.Category = "Odins Pieces";
                pieceConfig1.AddRequirement(new RequirementConfig("Iron", 25, 0, true));
                pieceConfig1.AddRequirement(new RequirementConfig("Wood", 15, 0, true));
                pieceConfig1.AddRequirement(new RequirementConfig("BlackForestCore_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this._myAssets, "forge_ext7_RtD", true, pieceConfig1));
                
                PieceConfig pieceConfig2 = new PieceConfig();
                pieceConfig2.PieceTable = PieceTables.Hammer;
                pieceConfig2.CraftingStation = CraftingStations.Forge;
                pieceConfig2.Category = "Odins Pieces";
                pieceConfig2.AddRequirement(new RequirementConfig("Iron", 25, 0, true));
                pieceConfig2.AddRequirement(new RequirementConfig("Wood", 15, 0, true));
                pieceConfig2.AddRequirement(new RequirementConfig("SwampCore_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this._myAssets, "forge_ext8_RtD", true, pieceConfig2));

                PieceConfig pieceConfig3 = new PieceConfig();
                pieceConfig3.PieceTable = PieceTables.Hammer;
                pieceConfig3.CraftingStation = CraftingStations.Forge;
                pieceConfig3.Category = "Odins Pieces";
                pieceConfig3.AddRequirement(new RequirementConfig("Iron", 25, 0, true));
                pieceConfig3.AddRequirement(new RequirementConfig("Wood", 15, 0, true));
                pieceConfig3.AddRequirement(new RequirementConfig("MountainCore_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this._myAssets, "forge_ext9_RtD", true, pieceConfig3));

                PieceConfig pieceConfig4 = new PieceConfig();
                pieceConfig4.PieceTable = PieceTables.Hammer;
                pieceConfig4.CraftingStation = CraftingStations.Forge;
                pieceConfig4.Category = "Odins Pieces";
                pieceConfig4.AddRequirement(new RequirementConfig("Iron", 25, 0, true));
                pieceConfig4.AddRequirement(new RequirementConfig("Wood", 15, 0, true));
                pieceConfig4.AddRequirement(new RequirementConfig("PlainsCore_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this._myAssets, "forge_ext10_RtD", true, pieceConfig4));

                PieceConfig pieceConfig5 = new PieceConfig();
                pieceConfig5.PieceTable = PieceTables.Hammer;
                pieceConfig5.CraftingStation = CraftingStations.Forge;
                pieceConfig5.Category = "Odins Pieces";
                pieceConfig5.AddRequirement(new RequirementConfig("Iron", 25, 0, true));
                pieceConfig5.AddRequirement(new RequirementConfig("Wood", 15, 0, true));
                pieceConfig5.AddRequirement(new RequirementConfig("MistlandsCore_RtD", 1, 0, true));
                PieceManager.Instance.AddPiece(new CustomPiece(this._myAssets, "forge_ext11_RtD", true, pieceConfig5));
                
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Exception caught while adding prefabs: {ex}");
            }
        }
    }
}