using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenSoupsPlus.ChickenNoodleSoup;
using KitchenSoupsPlus.FrenchOnionSoup;
using KitchenSoupsPlus.Soups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSoupsPlus
{
    internal class Refs
    {
        #region Vanilla References
        // Items
        public static Item Carrots => Find<Item>(ItemReferences.Carrot);
        public static Item ChoppedCarrots => Find<Item>(ItemReferences.CarrotChopped);
        public static Item Pot => Find<Item>(ItemReferences.Pot);
        public static Item Water => Find<Item>(ItemReferences.Water);
        public static Item DepletedSoup => Find<Item>(ItemReferences.SoupDepleted);
        public static Item Broth => Find<Item>(ItemReferences.BrothCookedOnion);
        public static Item Onion => Find<Item>(ItemReferences.Onion);
        public static Item ChoppedOnion => Find<Item>(ItemReferences.OnionChopped);
        public static Item Cheese => Find<Item>(ItemReferences.Cheese);
        public static Item ChoppedCheese => Find<Item>(ItemReferences.CheeseGrated);

        // Processes
        public static Process Cook => Find<Process>(ProcessReferences.Cook);
        public static Process Chop => Find<Process>(ProcessReferences.Chop);
        public static Process Knead => Find<Process>(ProcessReferences.Knead);
        public static Process Oven => Find<Process>(ProcessReferences.RequireOven);
        #endregion

        #region IngredientLib References
        public static ItemGroup PastaPot => Find<ItemGroup>("IngredientLib", "potted pasta");
        public static Item Chicken => Find<Item>("IngredientLib", "chicken");
        public static Item EggNoodle => Find<Item>("IngredientLib", "egg dough pasta");
        public static Item BoxNoodle => Find<Item>("IngredientLib", "box pasta");
        #endregion

        #region Modded References
        // Items
            // Chicken Noodle
        public static ItemGroup ChickenNoodleSoupPot => Find<ItemGroup, ChickenNoodleSoupPot>();
        public static Item ChickenNoodleSoupPotCooked => Find<Item, ChickenNoodleSoupPotCooked>();
        public static Item ChickenNoodleSoup => Find<Item, ChickenNoodleSoup.ChickenNoodleSoup>();
            // French Onion
        public static ItemGroup FrenchOnionSoupPot => Find<ItemGroup, FrenchOnionSoupPot>();
        public static ItemGroup FrenchOnionSoupPotChopped => Find<ItemGroup, FrenchOnionSoupPotChopped>();
        public static Item FrenchOnionSoupPotCooked => Find<Item, FrenchOnionSoupPotCooked>();
        public static Item FrenchOnionSoup => Find<Item, FrenchOnionSoup.FrenchOnionSoup>();
            // Miso
        public static Item Soybeans => Find<Item, Soybeans>();
        public static ItemGroup SoybeanPot => Find<ItemGroup, SoybeanPot>();
        public static Appliance SoybeanProvider => Find<Appliance, SoybeanProvider>();
        public static Item SoybeanPotCooked => Find<Item, SoybeanPotCooked>();
        public static Item ChoppedTofuPot => Find<Item, ChoppedTofuPot>();
        public static ItemGroup MisoSoupPot => Find<ItemGroup, MisoSoupPot>();
        public static Item MisoSoupPotCooked => Find<Item, MisoSoupPotCooked>();
        public static Item MisoSoup => Find<Item, MisoSoup>();
        public static Item Miso => Find<Item, Miso>();
        public static Appliance MisoProvider => Find<Appliance, MisoProvider>();

        // Cards
            // Chicken Noodle
        public static Dish ChickenNoodleSoupCard => Find<Dish, ChickenNoodleSoupCard>();
            // French Onion
        public static Dish FrenchOnionSoupCard => Find<Dish, FrenchOnionSoupCard>();
            // Miso
        public static Dish MisoSoupCard => Find < Dish, MisoSoupCard>();
        #endregion



        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }

        private static Appliance.ApplianceProcesses FindApplianceProcess<C>() where C : CustomSubProcess
        {
            ((CustomApplianceProccess)CustomSubProcess.GetSubProcess<C>()).Convert(out var process);
            return process;
        }
    }
}
