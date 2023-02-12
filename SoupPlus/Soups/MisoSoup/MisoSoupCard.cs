using KitchenData;
using KitchenLib.Utils;
using KitchenSoupsPlus.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSoupsPlus.Soups
{
    class MisoSoupCard : ModDish
    {
        public override string UniqueNameID => "Miso Soup Dish";
        public override DishType Type => DishType.Starter;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.MisoSoup,
                Phase = MenuPhase.Starter,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Pot,
            Refs.Water,
            Refs.Soybeans,
            Refs.Miso
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook,
            Refs.Chop
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add water and soybeans to a pot and cook. Press and chop boiled soybeans to get a pot of tofu. Fill the pot of tofu with water and miso, then cook to make soup. Portion and serve." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Miso Soup", "Adds Miso Soup as a Starter", "An abnormal dish, unique when compared other soups") }
        };
    }
}
