using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SoupsPlus.Utils;

namespace KitchenSoupsPlus.Soups
{
    public class MisoProvider : CustomAppliance
    {
        public override string UniqueNameID => "MisoProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MisoProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Miso Provider", "Provides Miso", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Refs.Miso.ID)
        };


        public override void OnRegister(Appliance appliance)
        {
            MaterialHelper.SetupGenericFlourSack(Prefab, "Onion");
        }
    }
}
