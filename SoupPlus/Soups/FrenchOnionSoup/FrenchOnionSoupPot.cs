using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenData.ItemGroup;
using SoupsPlus.Utils;

namespace KitchenSoupsPlus.Soups
{
    #region Whole Onion
    class FrenchOnionSoupPot : CustomItemGroup<FrenchOnionSoupPotItemGroupView>
    {
        public override string UniqueNameID => "French Onion Soup Pot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FrenchOnionSoupPot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Broth
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Onion
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.ChoppedCheese
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 8f,
                Process = Refs.Cook,
                Result = Refs.FrenchOnionSoupPotCooked
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var onionBroth = Prefab.GetChild("Onion Broth");

            var onionGroup = Prefab.GetChild("Onion Group");

            var pot = Prefab.GetChild("Pot/Pot.001");

            //Visuals

            onionBroth.GetChild("Onion (1)").ApplyMaterialToChild("Onion.002", "Onion");

            onionBroth.ApplyMaterialToChild("Water (2)", "Soup");

            onionGroup.GetChild("Cheese - Grated").ApplyMaterialToChildren("Potato - Chopped", "Cheese - Default");

            onionGroup.GetChild("Onion").GetChild("Onion (1).001").ApplyMaterialToChild("Onion.003", "Onion");

            onionGroup.GetChild("Onion - Chopped").GetChild("Onion - Chopped.001").ApplyMaterialToChildren("Circle", "Onion - Flesh", "Onion");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.003", "Metal Dark");

            Prefab.ApplyMaterialToChild("Water", "Onion");


            Prefab.GetComponent<FrenchOnionSoupPotItemGroupView>()?.Setup(Prefab);
        }
    }
    #endregion

    #region Chopped Onion
    class FrenchOnionSoupPotChopped : CustomItemGroup<FrenchOnionSoupPotItemGroupView>
    {
        public override string UniqueNameID => "French Onion Soup Pot Chopped";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FrenchOnionSoupPot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Broth
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.ChoppedOnion
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.ChoppedCheese
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 6f,
                Process = Refs.Cook,
                Result = Refs.FrenchOnionSoupPotCooked
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var onionBroth = Prefab.GetChild("Onion Broth");

            var onionGroup = Prefab.GetChild("Onion Group");

            var pot = Prefab.GetChild("Pot/Pot.001");

            //Visuals

            onionBroth.GetChild("Onion (1)").ApplyMaterialToChild("Onion.002", "Onion");

            onionBroth.ApplyMaterialToChild("Water (2)", "Soup");

            onionGroup.GetChild("Cheese - Grated").ApplyMaterialToChildren("Potato - Chopped", "Cheese - Default");

            onionGroup.GetChild("Onion").ApplyMaterialToChild("Onion (1).001", "Onion");

            onionGroup.GetChild("Onion - Chopped").GetChild("Onion - Chopped.001").ApplyMaterialToChildren("Circle", "Onion - Flesh", "Onion");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.003", "Metal Dark");

            Prefab.ApplyMaterialToChild("Water", "Onion");



            Prefab.GetComponent<FrenchOnionSoupPotItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }
    #endregion

    public class FrenchOnionSoupPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Onion Broth"),
                        GameObjectUtils.GetChildObject(prefab, "Pot"),
                    },
                    DrawAll = true,
                    Item = Refs.Broth
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion Group/Onion/Onion (1).001"),
                    Item = Refs.Onion
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion Group/Onion - Chopped/Onion - Chopped.001"),
                    Item = Refs.ChoppedOnion
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onion Group/Cheese - Grated"),
                    Item = Refs.ChoppedCheese
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "Ch",
                    Item = Refs.ChoppedCheese
                },
                new ()
                {
                    Text = "O",
                    Item = Refs.Onion
                },
                new ()
                {
                    Text = "O",
                    Item = Refs.ChoppedOnion
                }
            };
        }
    }
}
