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

namespace KitchenSoupsPlus.ChickenNoodleSoup
{
    class ChickenNoodleSoupPot : CustomItemGroup<ChickenNoodleSoupPotItemGroupView>
    {
        public override string UniqueNameID => "Chicken Noodle Soup Pot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenNoodleSoupPot");
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
                    Refs.EggNoodle,
                    Refs.BoxNoodle
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Chicken
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 4.5f,
                Process = Refs.Cook,
                Result = Refs.ChickenNoodleSoupPotCooked
            }
        };

        private bool GameDataBuilt = false;
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];

            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Broth/Pot", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Broth/Handles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Soup");
            MaterialUtils.ApplyMaterial(Prefab, "Broth/Water", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Onion");
            MaterialUtils.ApplyMaterial(Prefab, "Broth/Onion", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sack");
            MaterialUtils.ApplyMaterial(Prefab, "BoxNoodles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sack");
            MaterialUtils.ApplyMaterial(Prefab, "EggNoodles", materials);

            materials[0] = CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Raw Chicken\""];
            MaterialUtils.ApplyMaterial(Prefab, "Chicken", materials);


            Prefab.GetComponent<ChickenNoodleSoupPotItemGroupView>()?.Setup(Prefab);

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
    public class ChickenNoodleSoupPotItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Broth"),
                    Item = Refs.Broth
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Chicken"),
                    Item = Refs.Chicken
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "BoxNoodles"),
                    Item = Refs.BoxNoodle
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "EggNoodles"),
                    Item = Refs.EggNoodle
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "C",
                    Item = Refs.Chicken
                },
                new ()
                {
                    Text = "N",
                    Item = Refs.EggNoodle
                },
                new ()
                {
                    Text = "N",
                    Item = Refs.BoxNoodle
                }
            };
        }
    }
}
