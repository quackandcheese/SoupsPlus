using IngredientLib.Util;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using SoupsPlus.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace KitchenSoupsPlus.FrenchOnionSoup
{
    public class FrenchOnionSoupPotCookedItemView : PositionSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fFullPosition = ReflectionUtils.GetField<PositionSplittableView>("FullPosition");
            fFullPosition.SetValue(this, new Vector3(0, 0.273f, 0));

            var fEmptyPosition = ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition");
            fEmptyPosition.SetValue(this, new Vector3(0, 0.028f, 0));

            var fObjects = ReflectionUtils.GetField<PositionSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>() 
            { 
                prefab.GetChild("French Onion")
            });
        }
    }

    public class FrenchOnionSoupPotCooked : CustomItem
    {
        public override string UniqueNameID => "French Onion Soup Pot Cooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FrenchOnionSoupPotCooked");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 3;
        public override Item SplitSubItem => Refs.FrenchOnionSoup;
        public override List<Item> SplitDepletedItems => new() { Refs.DepletedSoup };
        public override Item DisposesTo => Refs.Pot;
        public override bool PreventExplicitSplit => false;
        public override string ColourBlindTag => "FrO";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var frenchOnion = Prefab.GetChild("French Onion");

            var pot = Prefab.GetChildFromPath("Pot.002/Pot.003");

            // Visuals

            frenchOnion.GetChild("Cheese - Grated.001").ApplyMaterialToChildren("Potato - Chopped", "Cheese - Default");

            Prefab.GetChild("Onion (1).006").ApplyMaterialToChild("Onion.009", "Onion");

            frenchOnion.GetChild("Onion - Chopped.002").GetChild("Onion - Chopped.003").ApplyMaterialToChildren("Circle", "Onion - Flesh", "Onion");

            frenchOnion.ApplyMaterialToChild("Onion Water", "Onion");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal");

            pot.ApplyMaterialToChild("Cylinder.002", "Metal Dark");

            frenchOnion.ApplyMaterialToChild("Herbs.001", "Lettuce");

            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");


            if (!Prefab.HasComponent<FrenchOnionSoupPotCookedItemView>())
            {
                var view = Prefab.AddComponent<FrenchOnionSoupPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
