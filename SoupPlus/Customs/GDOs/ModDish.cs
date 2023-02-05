using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace KitchenSoupsPlus.Customs
{
    public abstract class ModDish : CustomDish
    {
        public virtual IDictionary<Locale, string> LocalisedRecipe { get; }

        public virtual IDictionary<Locale, UnlockInfo> LocalisedInfo { get; }

        public override LocalisationObject<UnlockInfo> Info
        {
            get
            {
                var info = new LocalisationObject<UnlockInfo>();

                foreach (var entry in LocalisedInfo)
                {
                    info.Add(entry.Key, entry.Value);
                }

                return info;
            }
        }
    }
}