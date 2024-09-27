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
    class MisoSoupPot : CustomItemGroup<MisoSoupPotItemGroupView>
    {
        public override string UniqueNameID => "Miso Soup Pot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MisoSoupPot");
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
                    Refs.ChoppedTofuPot
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Water
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Miso
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 10f,
                Process = Refs.Cook,
                Result = Refs.MisoSoupPotCooked
            }
        };

        private bool GameDataBuilt = false;
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChild("Pot/Pot.001");

            //Visuals

            Prefab.ApplyMaterialToChild("Chopped Tofu.002", "Mayonnaise");
            Prefab.ApplyMaterialToChild("Miso.003", "Onion");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");

            Prefab.ApplyMaterialToChild("Water.003", "Water");
            Prefab.ApplyMaterialToChild("Scallions.001", "Cooked Broccoli", "Lettuce");


            Prefab.GetComponent<MisoSoupPotItemGroupView>()?.Setup(Prefab);

            if (GameDataBuilt)
            {
                return;
            }

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }

            GameDataBuilt = true;
        }
    }
    #endregion


    public class MisoSoupPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Chopped Tofu.002"),
                    Item = Refs.ChoppedTofuPot,
                },
                new()
                {
                    Objects = new()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Miso.003"),
                        GameObjectUtils.GetChildObject(prefab, "Scallions.001"),
                    },
                    DrawAll = true,
                    Item = Refs.Miso
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Water.003"),
                    Item = Refs.Water
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "Mi",
                    Item = Refs.Miso
                },
                new ()
                {
                    Text = "W",
                    Item = Refs.Water
                }
            };
        }
    }
}
