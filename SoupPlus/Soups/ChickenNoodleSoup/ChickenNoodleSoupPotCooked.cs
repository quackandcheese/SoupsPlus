using IngredientLib.Util;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
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
            fFullPosition.SetValue(this, new Vector3(0, 0.028f, 0));

            var fEmptyPosition = ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition");
            fEmptyPosition.SetValue(this, new Vector3(0, 0.273f, 0));

            var fObjects = ReflectionUtils.GetField<PositionSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>() 
            { 
                prefab.GetChildFromPath("Broth.001/Water"),
                prefab.GetChild("EggNoodles.001"),
                prefab.GetChild("Chicken.001"),
                prefab.GetChild("Carrot - Chopped"),
                prefab.GetChild("Herbs")
            });
        }
    }

    public class ChickenNoodleSoupPotCooked : CustomItem
    {
        public override string UniqueNameID => "Chicken Noodle Soup Pot Cooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenNoodleSoupPotCooked");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 0.75f;
        public override int SplitCount => 3;
        public override Item SplitSubItem => Refs.ChickenNoodleSoup;
        public override List<Item> SplitDepletedItems => new() { Refs.DepletedSoup };
        public override Item DisposesTo => Refs.Pot;
        public override bool PreventExplicitSplit => false;
        public override string ColourBlindTag => "CN";


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];

            materials[0] = MaterialUtils.GetExistingMaterial("Metal");
            MaterialUtils.ApplyMaterial(Prefab, "Broth.001/Pot.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Metal Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Broth.001/Handles.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cooked Pastry");
            MaterialUtils.ApplyMaterial(Prefab, "Broth.001/Water.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Carrot");
            MaterialUtils.ApplyMaterial(Prefab, "Carrot - Chopped", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sack");
            MaterialUtils.ApplyMaterial(Prefab, "EggNoodles.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cooked Bone");
            MaterialUtils.ApplyMaterial(Prefab, "Chicken.001", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cooked Broccoli");
            MaterialUtils.ApplyMaterial(Prefab, "Herbs", materials);


            if (!Prefab.HasComponent<ChickenNoodleSoupPotCookedItemView>())
            {
                var view = Prefab.AddComponent<ChickenNoodleSoupPotCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}
