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
    public class ChoppedTofuPot : CustomItem
    {
        public override string UniqueNameID => "ChoppedTofuPot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChoppedTofuPot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override Item DisposesTo => Refs.Pot;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChildFromPath("Pot/Pot.001");

            //Visuals

            Prefab.ApplyMaterialToChild("Chopped Tofu.001", "Mayonnaise");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");
        }
    }
}
