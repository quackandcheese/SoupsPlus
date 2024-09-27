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

namespace KitchenSoupsPlus.ChickenNoodleSoup
{
    public class ChickenNoodleSoupPotCookedItemView : PositionSplittableView
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
                prefab.GetChild("Chicken Noodle")
            });
        }
    }

    public class ChickenNoodleSoupPotCooked : CustomItem
    {
        public override string UniqueNameID => "Chicken Noodle Soup Pot Cooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenNoodleSoupPotCooked");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 3;
        public override Item SplitSubItem => Refs.ChickenNoodleSoup;
        public override List<Item> SplitDepletedItems => new() { Refs.DepletedSoup };
        public override Item DisposesTo => Refs.Pot;
        public override bool PreventExplicitSplit => false;
        public override string ColourBlindTag => "ChiNo";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var chickenNoodle = Prefab.GetChild("Chicken Noodle");

            var pot = Prefab.GetChild("Broth.001");

            pot.ApplyMaterialToChild("Pot.001", "Metal");

            pot.ApplyMaterialToChild("Handles.001", "Metal Dark");

            chickenNoodle.ApplyMaterialToChild("EggNoodles.001", "Sack");

            chickenNoodle.ApplyMaterialToChild("Herbs", "Cooked Broccoli");

            chickenNoodle.ApplyMaterialToChild("Chicken.001", "Cooked Bone");

            chickenNoodle.ApplyMaterialToChild("Carrot - Chopped", "Carrot");

            chickenNoodle.ApplyMaterialToChild("Onion Water", "Cooked Pastry");

            Prefab.GetChild("Onion (1).006").ApplyMaterialToChild("Onion.009", "Onion");

            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");


            if (!Prefab.HasComponent<ChickenNoodleSoupPotCookedItemView>())
            {
                var view = Prefab.AddComponent<ChickenNoodleSoupPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
