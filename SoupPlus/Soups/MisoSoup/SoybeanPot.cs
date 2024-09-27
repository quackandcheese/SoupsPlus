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
    class SoybeanPot : CustomItemGroup<SoybeanPotItemGroupView>
    {
        public override string UniqueNameID => "SoybeanPot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("SoybeanPot");
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
                    Refs.Pot
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
                    Refs.Soybeans
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 8f,
                Process = Refs.Cook,
                Result = Refs.SoybeanPotCooked
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChild("Pot/Pot.001");

            //Visuals

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");

            Prefab.ApplyMaterialToChild("Water.001", "Water");
            Prefab.ApplyMaterialToChild("Soybeans.001", "Lettuce");


            Prefab.GetComponent<SoybeanPotItemGroupView>()?.Setup(Prefab);
        }
    }
    #endregion


    public class SoybeanPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Pot"),
                    Item = Refs.Pot,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Soybeans.001"),
                    Item = Refs.Soybeans,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Water.001"),
                    Item = Refs.Water
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "S",
                    Item = Refs.Soybeans
                }
            };
        }
    }
}
