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

namespace KitchenSoupsPlus.Soups
{
    public class MisoSoupPotCookedItemView : PositionSplittableView
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
                prefab.GetChild("Miso.002")
            });
        }
    }

    public class MisoSoupPotCooked : CustomItem
    {
        public override string UniqueNameID => "Miso Soup Pot Cooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MisoSoupPotCooked");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 3;
        public override Item SplitSubItem => Refs.MisoSoup;
        public override List<Item> SplitDepletedItems => new() { Refs.ChoppedTofuPot };
        public override Item DisposesTo => Refs.Pot;
        public override bool PreventExplicitSplit => false;
        public override string ColourBlindTag => "Mi";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pot = Prefab.GetChild("Pot/Pot.001");
            var miso = Prefab.GetChild("Miso.002");

            //Visuals

            miso.ApplyMaterialToChild("Miso Water", "Bean");
            miso.ApplyMaterialToChild("Scallions", "Cooked Broccoli", "Lettuce");
            miso.ApplyMaterialToChild("Tofu", "Raw Pastry");
            Prefab.ApplyMaterialToChild("Chopped Tofu", "Mayonnaise");

            pot.ApplyMaterialToChild("Cylinder", "Metal");

            pot.ApplyMaterialToChild("Cylinder.001", "Metal Dark");


            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");


            if (!Prefab.HasComponent<MisoSoupPotCookedItemView>())
            {
                var view = Prefab.AddComponent<MisoSoupPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
