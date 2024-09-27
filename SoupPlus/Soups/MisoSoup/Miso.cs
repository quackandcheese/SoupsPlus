using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenSoupsPlus;
using SoupsPlus.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenSoupsPlus.Soups
{
    class Miso : CustomItem
    {
        public override string UniqueNameID => "Miso";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Miso");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override Appliance DedicatedProvider => Refs.MisoProvider;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var miso = Prefab.GetChild("Miso.001");

            miso.ApplyMaterialToChild("Cylinder.015", "Metal Dark");
            miso.ApplyMaterialToChild("Cylinder.016", "Onion");
        }
    }
}
