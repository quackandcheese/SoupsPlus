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
    class Soybeans : CustomItem
    {
        public override string UniqueNameID => "Soybeans";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Soybeans");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Refs.SoybeanProvider;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Soybeans.002", "Lettuce");
        }
    }
}
