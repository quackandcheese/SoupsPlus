using KitchenData;
using KitchenLib.Utils;
using KitchenSoupsPlus.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSoupsPlus.FrenchOnionSoup
{
    class FrenchOnionSoupCard : ModDish
    {
        public override string UniqueNameID => "French Onion Soup Dish";
        public override DishType Type => DishType.Starter;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.FrenchOnionSoup,
                Phase = MenuPhase.Starter,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Pot,
            Refs.Water,
            Refs.Onion,
            Refs.Cheese
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add water and an onion to a pot, cook. Add onion or chopped onion and grated cheese to broth. Cook, portion, and serve." }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("French Onion Soup", "Adds French Onion Soup as a Starter", "Cheese and onions, what more do you need") }
        };
    }
}
