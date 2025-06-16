using KitchenData;
using KitchenLib.Utils;
using KitchenSoupsPlus.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSoupsPlus.ChickenNoodleSoup
{
    class ChickenNoodleSoupCard : ModDish
    {
        public override string UniqueNameID => "Chicken Noodle Soup Dish";
        public override DishType Type => DishType.Starter;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.ChickenNoodleSoup,
                Phase = MenuPhase.Starter,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Pot,
            Refs.Chicken,
            Refs.Spaghetti,
            Refs.Water,
            Refs.Onion
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add water and an onion to a pot, cook. Add boxed pasta and raw chicken to broth. Cook, portion, and serve." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Chicken Noodle Soup", "Adds Chicken Noodle Soup as a Starter", "A classic comfort in a bowl, it's the cure for the common cold and the soul.") }
        };
    }
}
