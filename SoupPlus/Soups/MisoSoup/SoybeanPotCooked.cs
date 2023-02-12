using IngredientLib.Util;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using SoupsPlus.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenSoupsPlus.Soups
{
    public class SoybeanPotCooked : CustomItem
    {
        public override string UniqueNameID => "SoybeanPotCooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("SoybeanPotCooked");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override Item DisposesTo => Refs.Pot;
        public override List<Item.ItemProcess> Processes => new()
        {
            new Item.ItemProcess()
            {
                Duration = 3f,
                Process = Refs.Chop,
                Result = Refs.ChoppedTofuPot
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChildFromPath("Pot/Pot.001");

            //Visuals

            Prefab.ApplyMaterialToChild("Soybeans", "Bean");
            Prefab.ApplyMaterialToChild("Water.002", "Raw Pastry");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");
        }
    }
}
