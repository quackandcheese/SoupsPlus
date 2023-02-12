using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using IngredientLib.Util;
using SoupsPlus.Utils;

namespace KitchenSoupsPlus.Soups
{
    public class SoybeanProvider : CustomAppliance
    {
        public override string UniqueNameID => "SoybeanProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("SoybeanProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Soybean Provider", "Provides Soybeans", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Refs.Soybeans.ID)
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            MaterialHelper.SetupGenericCrates(Prefab);

            Prefab.GetChild("SoyBeans").ApplyMaterialToChildren("Soybeans", "Lettuce");
        }
    }
}
