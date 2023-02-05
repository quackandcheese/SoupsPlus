using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenSoupsPlus.ChickenNoodleSoup
{
    class ChickenNoodleSoup : CustomItem
    {
        public override string UniqueNameID => "Chicken Noodle Soup";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenNoodleSoup");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "CN";



        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[1];

            materials[0] = MaterialUtils.GetExistingMaterial("Cooked Pastry");
            MaterialUtils.ApplyMaterial(Prefab, "Broth", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Carrot");
            MaterialUtils.ApplyMaterial(Prefab, "Carrot - Chopped", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cooked Bone");
            MaterialUtils.ApplyMaterial(Prefab, "Chicken", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Cooked Broccoli");
            MaterialUtils.ApplyMaterial(Prefab, "Herbs", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Sack");
            MaterialUtils.ApplyMaterial(Prefab, "Noodles", materials);

            materials[0] = MaterialUtils.GetExistingMaterial("Plate");
            MaterialUtils.ApplyMaterial(Prefab, "Bowl", materials);
        }
    }
}
