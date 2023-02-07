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

namespace KitchenSoupsPlus.FrenchOnionSoup
{
    class FrenchOnionSoup : CustomItem
    {
        public override string UniqueNameID => "French Onion Soup";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FrenchOnionSoup");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideLarge;
        public override string ColourBlindTag => "FO";



        public override void OnRegister(GameDataObject gameDataObject)
        {
            var soupPath = Prefab.GetChild("Broccoli Cheese");

            // Visuals

            soupPath.GetChild("Broc").ApplyMaterialToChild("Circle.014", "Plate");

            soupPath.GetChild("Broc").ApplyMaterialToChild("Circle.015", "Onion");

            soupPath.GetChild("Broc").ApplyMaterialToChild("Plane.004", "Lettuce");

            soupPath.GetChild("Cheese - Grated.002").ApplyMaterialToChildren("Potato - Chopped", "Cheese - Default");

            Prefab.ApplyMaterialToChild("Herbs", "Lettuce");
        }
    }
}
