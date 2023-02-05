using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenSoupsPlus.ChickenNoodleSoup;
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
        public static ItemGroup ChickenNoodleSoupPot => Find<ItemGroup, ChickenNoodleSoupPot>();
        public static Item ChickenNoodleSoupPotCooked => Find<Item, ChickenNoodleSoupPotCooked>();
        public static Item ChickenNoodleSoup => Find<Item, ChickenNoodleSoup.ChickenNoodleSoup>();

        // Cards
        public static Dish ChickenNoodleSoupCard => Find<Dish, ChickenNoodleSoupCard>();
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
