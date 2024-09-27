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
    class MisoSoup : CustomItem
    {
        public override string UniqueNameID => "MisoSoup";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MisoSoup");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideLarge;
        public override string ColourBlindTag => "Mi";



        public override void OnRegister(GameDataObject gameDataObject)
        {
            var soupPath = Prefab.GetChild("Miso.004/Miso.005");

            // Visuals

            soupPath.ApplyMaterialToChild("Circle.007", "Plate");

            soupPath.ApplyMaterialToChild("Circle.008", "Bean");

            Prefab.ApplyMaterialToChild("Tofu.001", "Raw Pastry");
            Prefab.ApplyMaterialToChild("Scallions.002", "Cooked Broccoli", "Lettuce");
        }
    }
}
